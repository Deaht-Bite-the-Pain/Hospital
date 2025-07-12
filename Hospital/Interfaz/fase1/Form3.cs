using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace fase1
{
    /// <summary>
    /// Formulario que representa el panel del usuario/paciente.
    /// Permite seleccionar un área médica, ver los médicos disponibles, y agendar una cita.
    /// </summary>
    public partial class Form3 : Form
    {
        private int idUsuario; // ID del paciente logueado

        public Form3(int id)
        {
            InitializeComponent();
            idUsuario = id;
        }

        /// <summary>
        /// Evento que se ejecuta cuando se cambia el área seleccionada.
        /// Carga los médicos disponibles para esa área y ajusta fecha y hora según si es emergencia o no.
        /// </summary>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "SELECT id, nombres + ' ' + apellidos AS Nombre FROM Usuarios WHERE rol = 'Medico' AND area = @area";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@area", cmbArea.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMedicos.DataSource = dt;
            }

            // Configuración especial para área de emergencia
            if (cmbArea.Text == "Emergencia")
            {
                dtpFecha.Value = DateTime.Now;
                dtpFecha.Enabled = false;
                dtpHora.Value = DateTime.Now;
                dtpHora.Enabled = false;
            }
            else
            {
                dtpFecha.Value = DateTime.Now.AddDays(7);
                dtpFecha.Enabled = true;

                // Asignación aleatoria de hora
                Random rnd = new Random();
                int hora = rnd.Next(8, 17); // entre 8 AM y 5 PM
                int minuto = rnd.Next(0, 60);
                dtpHora.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora, minuto, 0);
                dtpHora.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Al cargar el formulario, se configuran los controles y se cargan los datos del paciente.
        /// </summary>
        private void Form3_Load(object sender, EventArgs e)
        {
            dgvMedicos.ReadOnly = true;
            dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicos.MultiSelect = false;
            dgvMedicos.AllowUserToAddRows = false;

            cmbArea.Items.AddRange(new string[] { "Pediatria", "Oftalmologia", "Emergencia" });
            cmbArea.SelectedIndex = 0;

            // Carga del nombre y foto del paciente
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "SELECT nombres, apellidos, FotoPath FROM Usuarios WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    string apellido = reader.GetString(1);
                    string rutaFoto = reader.GetString(2);

                    lblNombre.Text = nombre + " " + apellido;
                    if (File.Exists(rutaFoto))
                    {
                        pbPaciente.Image = Image.FromFile(rutaFoto);
                    }
                }

                reader.Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento del botón para agendar cita. Registra la cita en base de datos y genera ticket en el escritorio.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvMedicos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un médico.");
                return;
            }

            int idMedico = Convert.ToInt32(dgvMedicos.SelectedRows[0].Cells["id"].Value);
            string descripcion = richTextBox1.Text;
            string area = cmbArea.Text;
            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"INSERT INTO Citas (id_usuario, area_consulta, descripcion, fecha, hora, estado)
                                 VALUES (@id_usuario, @area, @descripcion, @fecha, @hora, 'Pendiente')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd.Parameters.AddWithValue("@area", area);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.ExecuteNonQuery();

                // Generación del ticket
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string rutaArchivo;
                string mensaje;

                if (cmbArea.Text == "Emergencia")
                {
                    mensaje = $"⚠️ ATENCIÓN INMEDIATA - CITA DE EMERGENCIA ⚠️\n\n" +
                        $"Estimado(a) {lblNombre.Text},\n\n" +
                        $"Su cita de emergencia ha sido registrada correctamente en el área de {cmbArea.Text}.\n\n" +
                        $"🗓 Fecha: {dtpFecha.Value:dddd, dd 'de' MMMM 'de' yyyy}\n" +
                        $"⏰ Hora asignada automáticamente: {dtpHora.Value:hh:mm tt}\n\n" +
                        $"Por favor preséntese lo antes posible. Un médico lo atenderá a la brevedad.\n\n" +
                        $"- Hospital Don Bosco";

                    rutaArchivo = Path.Combine(escritorio, "Ticket_Emergencia_Hospital.txt");
                }
                else
                {
                    mensaje = $"Hospital Don Bosco - Confirmación de Cita\n\n" +
                        $"Estimado(a) {lblNombre.Text},\n\n" +
                        $"Gracias por agendar su cita en el área de {cmbArea.Text}.\n" +
                        $"Su cita ha sido programada para:\n\n" +
                        $"🗓 Fecha: {dtpFecha.Value:dddd, dd 'de' MMMM 'de' yyyy}\n" +
                        $"⏰ Hora: {dtpHora.Value:hh:mm tt}\n\n" +
                        $"Le esperamos con gusto. ¡Tenga un buen día!\n\n" +
                        $"- Hospital Don Bosco";

                    rutaArchivo = Path.Combine(escritorio, "Ticket_Cita_Hospital.txt");
                }

                // Escribe el ticket como archivo .txt en el escritorio
                File.WriteAllText(rutaArchivo, mensaje, Encoding.UTF8);

                MessageBox.Show("Cita agendada correctamente.\n\n" +
                    "Se ha generado un ticket en el escritorio con los detalles de la cita.",
                    "Cita registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
