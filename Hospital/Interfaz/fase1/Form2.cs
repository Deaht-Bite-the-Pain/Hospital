using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Librerías de AForge para manejar la cámara web
using AForge.Video;
using AForge.Video.DirectShow;

namespace fase1
{
    /// <summary>
    /// Formulario de registro para nuevos usuarios o médicos.
    /// Permite ingresar sus datos personales, tomar una foto con la cámara y guardar todo en la base de datos.
    /// </summary>
    public partial class Form2 : Form
    {
        // Variables para manejo de cámara y foto capturada
        private FilterInfoCollection dispositivosVideo;
        private VideoCaptureDevice fuenteVideo;
        private Bitmap imagenCapturada;

        public Form2()
        {
            InitializeComponent();
            this.FormClosing += Form2_FormClosing; // Detiene la cámara al cerrar el formulario
        }

        /// <summary>
        /// Al cargar el formulario, se llenan las listas desplegables con opciones predefinidas.
        /// </summary>
        private void Form2_Load(object sender, EventArgs e)
        {
            cmbGenero.Items.Clear();
            cmbGenero.Items.Add("Hombre");
            cmbGenero.Items.Add("Mujer");

            cmbRol.Items.Clear();
            cmbRol.Items.Add("Medico");
            cmbRol.Items.Add("Usuario");

            cmbArea.Items.Clear();
            cmbArea.Items.Add("Pediatria");
            cmbArea.Items.Add("Oftalmologia");
            cmbArea.Items.Add("Emergencia");

            cmbGenero.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
            cmbArea.SelectedIndex = 0;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Botón para registrar al usuario (paciente o médico)
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de número de teléfono (8 dígitos)
                if (txtTelefono.Text.Length != 8 || !txtTelefono.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El número de teléfono debe tener exactamente 8 dígitos.");
                    return;
                }

                // Contraseña según el tipo de rol
                string contrasenaFinal = "";

                if (cmbRol.Text == "Medico")
                {
                    txtContrasena.Enabled = false;
                    contrasenaFinal = (txtNombre.Text + dtpFechaNacimiento.Value.ToString("yyyyMMdd")).ToLower();

                    MessageBox.Show($"Contraseña única para el médico: {txtNombre.Text} {txtApellido.Text}\n\nContraseña: {contrasenaFinal}",
                                    "Contraseña Asignada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cmbRol.Text == "Usuario")
                {
                    txtContrasena.Enabled = true;
                    if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                    {
                        MessageBox.Show("Debe ingresar una contraseña.");
                        return;
                    }
                    contrasenaFinal = txtContrasena.Text;
                }
                else
                {
                    MessageBox.Show("Seleccione un rol válido.");
                    return;
                }

                // Guardar la imagen capturada en disco
                string carpeta = @"C:\\HospitalDonBosco\\FotosUsuarios";
                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string nombreArchivo = $"usuario_{DateTime.Now.Ticks}.jpg";
                string rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                if (imagenCapturada != null)
                {
                    imagenCapturada.Save(rutaCompleta, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                // Convertir imagen a arreglo de bytes para guardar en base de datos
                byte[] imagenBytes = null;
                if (imagenCapturada != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imagenCapturada.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imagenBytes = ms.ToArray();
                    }
                }

                // Insertar datos en la base de datos
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    string query = @"INSERT INTO Usuarios 
                        (nombres, apellidos, fecha_nacimiento, dui, correo, telefono, genero, rol, area, contrasena, fecha_creacion, FotoPath, foto)
                        VALUES 
                        (@nombres, @apellidos, @fecha_nac, @dui, @correo, @telefono, @genero, @rol, @area, @contrasena, @fecha_creacion, @fotopath, @foto)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@nombres", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@apellidos", txtApellido.Text);
                    cmd.Parameters.AddWithValue("@fecha_nac", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@dui", txtDUI.Text);
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@genero", cmbGenero.Text);
                    cmd.Parameters.AddWithValue("@rol", cmbRol.Text);
                    cmd.Parameters.AddWithValue("@area", cmbArea.Text);
                    cmd.Parameters.AddWithValue("@contrasena", Seguridad.EncriptarSHA256(contrasenaFinal));
                    cmd.Parameters.AddWithValue("@fecha_creacion", dtpFechaCreacion.Value);
                    cmd.Parameters.AddWithValue("@fotopath", rutaCompleta);
                    cmd.Parameters.AddWithValue("@foto", imagenBytes);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario registrado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }

        /// <summary>
        /// Habilita o deshabilita campos dependiendo del rol seleccionado (Usuario o Médico).
        /// </summary>
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedItem.ToString() == "Usuario")
            {
                cmbArea.Enabled = false;
                cmbArea.SelectedIndex = -1;
                txtContrasena.Enabled = true;
            }
            else
            {
                cmbArea.Enabled = true;
                txtContrasena.Enabled = false;
                txtContrasena.Text = "";
            }
        }

        /// <summary>
        /// Inicia la cámara y empieza a capturar video en tiempo real.
        /// </summary>
        private void btnIniciarCamara_Click(object sender, EventArgs e)
        {
            dispositivosVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (dispositivosVideo.Count > 0)
            {
                fuenteVideo = new VideoCaptureDevice(dispositivosVideo[0].MonikerString);
                if (fuenteVideo.VideoCapabilities.Length > 0)
                {
                    fuenteVideo.VideoResolution = fuenteVideo.VideoCapabilities[0];
                }
                fuenteVideo.NewFrame += new NewFrameEventHandler(CapturarFrame);
                fuenteVideo.Start();
            }
            else
            {
                MessageBox.Show("No se encontró ninguna cámara.");
            }
        }

        /// <summary>
        /// Evento que se ejecuta cada vez que se recibe un nuevo frame de la cámara.
        /// </summary>
        private void CapturarFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
                pbCamara.Image = imagen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al capturar imagen: " + ex.Message);
            }
        }

        /// <summary>
        /// Captura una imagen fija del video actual y la guarda en disco.
        /// </summary>
        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (pbCamara.Image != null)
            {
                imagenCapturada = new Bitmap(pbCamara.Image);
                MessageBox.Show("Imagen capturada correctamente.");
            }

            string rutaCarpeta = Path.Combine(Application.StartupPath, "FotosUsuarios");
            if (!Directory.Exists(rutaCarpeta))
                Directory.CreateDirectory(rutaCarpeta);

            string nombreArchivo = $"usuario_{DateTime.Now.Ticks}.jpg";
            string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);
            imagenCapturada.Save(rutaCompleta, System.Drawing.Imaging.ImageFormat.Jpeg);

            MessageBox.Show("Imagen guardada localmente.");
        }

        /// <summary>
        /// Detiene la cámara al cerrar el formulario.
        /// </summary>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fuenteVideo != null && fuenteVideo.IsRunning)
            {
                fuenteVideo.SignalToStop();
                fuenteVideo.WaitForStop();
            }
        }

        /// <summary>
        /// Redirige de regreso al formulario de inicio de sesión.
        /// </summary>
        private void btniniciarsecion2_Click(object sender, EventArgs e)
        {
            Form1 registro = new Form1();
            registro.Show();
            this.Hide();
        }

        // Los métodos vacíos que siguen (groupBoxX_Enter, labelX_Click, etc.) están definidos por el diseñador
        // pero no tienen lógica asociada, y pueden ser eliminados si no se usan.
    }
}