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
using System.Reflection.Emit;
using System.Windows.Forms.DataVisualization.Charting;

namespace fase1
{
    public partial class Form4 : Form
    {
        private string rolUsuario; // Almacena el rol del usuario (Admin o Medico)
        private int idUsuario; // Almacena el ID del usuario logueado

        public Form4(string rol, int idUsuario)
        {
            InitializeComponent();
            this.MinimumSize = new Size(900, 600);
            this.rolUsuario = rol;
            this.idUsuario = idUsuario;
        }

        // Evento del timer (no implementado)
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        // Evento al hacer clic en una celda del DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];

                string nombre = fila.Cells["nombre"].Value.ToString();
                DateTime fecha = Convert.ToDateTime(fila.Cells["fecha"].Value);
                string rutaFoto = fila.Cells["FotoPath"].Value.ToString();

                lblNombrePaciente.Text = nombre;
                lblFechaCita.Text = fecha.ToString("dd/MM/yyyy");

                if (File.Exists(rutaFoto))
                {
                    pbDetallePaciente.Image = Image.FromFile(rutaFoto);
                }
                else
                {
                    pbDetallePaciente.Image = null;
                }
            }
        }

        // Evento que se ejecuta al cargar el formulario
        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                if (rolUsuario == "Medico")
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

                        label15.Text = "Médico: " + nombre + " " + apellido;

                        if (File.Exists(rutaFoto))
                        {
                            imagen.Image = Image.FromFile(rutaFoto);
                        }
                    }
                    reader.Close();
                }
                else if (rolUsuario == "Admin")
                {
                    label15.Text = "Administrador";
                    imagen.Image = Properties.Resources.admin;
                }
            }

            CargarCitas();

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

                    btnEditarFecha.Text = nombre + " " + apellido;
                    if (File.Exists(rutaFoto))
                        imagen.Image = Image.FromFile(rutaFoto);
                }
            }

            CargarCitas();

            if (rolUsuario == "Medico")
            {
                btnEditarFecha.Enabled = false;
                btnEditarHora.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Evento para editar la hora de una cita
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int colIndex = dataGridView1.Columns["hora"].Index;

                dataGridView1.ReadOnly = false;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.ReadOnly = true;
                }

                dataGridView1.Columns["hora"].ReadOnly = false;
                dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[colIndex];
                dataGridView1.BeginEdit(true);
            }
        }

        // Método que carga todas las citas desde la base de datos
        private void CargarCitas()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"
        SELECT 
            C.id,
            U.nombres + ' ' + U.apellidos AS nombre,     
            U.FotoPath,
            C.area_consulta,
            C.descripcion,
            C.fecha,
            C.hora,
            C.estado
        FROM Citas C
        JOIN Usuarios U ON C.id_usuario = U.id";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        // Evento para editar la fecha de una cita
        private void btnEditarFecha_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int colIndex = dataGridView1.Columns["fecha"].Index;

                dataGridView1.ReadOnly = false;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.ReadOnly = true;
                }

                dataGridView1.Columns["fecha"].ReadOnly = false;
                dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[colIndex];
                dataGridView1.BeginEdit(true);
            }
        }

        // Evento para guardar cambios realizados a una cita
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cita.");
                return;
            }

            int idCita = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            DateTime nuevaFecha = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["fecha"].Value);
            TimeSpan nuevaHora = (TimeSpan)dataGridView1.SelectedRows[0].Cells["hora"].Value;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Citas SET fecha = @fecha, hora = @hora WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fecha", nuevaFecha);
                cmd.Parameters.AddWithValue("@hora", nuevaHora);
                cmd.Parameters.AddWithValue("@id", idCita);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cita actualizada.");
                CargarCitas();
            }

            dataGridView1.ReadOnly = true;
        }

        // Evento para cancelar (eliminar) una cita
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cita para cancelar.");
                return;
            }

            int idCita = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

            var confirm = MessageBox.Show("¿Está seguro de cancelar esta cita?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    string query = "DELETE FROM Citas WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", idCita);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cita cancelada.");
                    CargarCitas();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imagen_Click(object sender, EventArgs e)
        {

        }

        private void pbDetallePaciente_Click(object sender, EventArgs e)
        {

        }
    }
}