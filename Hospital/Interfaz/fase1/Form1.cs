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

namespace fase1
{
    /// <summary>
    /// Formulario principal de inicio de sesión.
    /// Permite autenticar al usuario y redirigirlo según su rol (Admin, Usuario o Médico).
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Inicializa los controles del formulario (auto generado por Visual Studio)
        }

        // Evento por si se hace clic en el label1 (no tiene lógica asignada por ahora)
        private void label1_Click(object sender, EventArgs e) { }

        // Evento por si se hace clic en el label4 (no tiene lógica asignada por ahora)
        private void label4_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Evento del botón de iniciar sesión.
        /// Verifica si el usuario es Admin, Usuario o Médico y abre el formulario correspondiente.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            string contrasenaHash = Seguridad.EncriptarSHA256(contrasena); // Encripta la contraseña con SHA256

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña.");
                return;
            }

            try
            {
                using (SqlConnection con = Conexion.ObtenerConexion())
                {
                    // 🔐 Verificación para Admin
                    string queryAdmin = "SELECT * FROM Admin WHERE usuario = @usuario AND contrasena = @contrasena";
                    SqlCommand cmdAdmin = new SqlCommand(queryAdmin, con);
                    cmdAdmin.Parameters.AddWithValue("@usuario", usuario);
                    cmdAdmin.Parameters.AddWithValue("@contrasena", contrasena);

                    SqlDataReader reader = cmdAdmin.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        Form4 formAdmin = new Form4("Admin", 1); // Formulario para administrador
                        formAdmin.Tag = "Admin";
                        formAdmin.Show();
                        this.Hide();
                        return;
                    }
                    reader.Close();

                    // 🔐 Verificación para Usuarios o Médicos
                    string queryUser = "SELECT id, rol FROM Usuarios WHERE (nombres + ' ' + apellidos) = @usuario AND contrasena = @contrasena";
                    SqlCommand cmdUser = new SqlCommand(queryUser, con);
                    cmdUser.Parameters.AddWithValue("@usuario", usuario);
                    cmdUser.Parameters.AddWithValue("@contrasena", contrasenaHash);

                    SqlDataReader userReader = cmdUser.ExecuteReader();
                    if (userReader.Read())
                    {
                        int idUsuario = userReader.GetInt32(0);
                        string rol = userReader.GetString(1);
                        userReader.Close();

                        // Redirigir según rol
                        if (rol == "Usuario")
                        {
                            Form3 formUsuario = new Form3(idUsuario); // Pantalla del usuario
                            formUsuario.Show();
                            this.Hide();
                        }
                        else if (rol == "Medico")
                        {
                            Form4 formMedico = new Form4("Medico", idUsuario); // Pantalla del médico
                            formMedico.Tag = "Medico";
                            formMedico.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
            }
        }

        /// <summary>
        /// Método auxiliar para obtener el ID de un usuario dado su correo y contraseña.
        /// </summary>
        private int ObtenerIdDelUsuario(string correo, string contrasena)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string sql = "SELECT id FROM Usuarios WHERE correo = @correo AND contrasena = @contrasena";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contrasena", Seguridad.EncriptarSHA256(contrasena));
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        /// <summary>
        /// Evento del botón de "Registrarse".
        /// Abre el formulario de registro (Form2).
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 registro = new Form2();
            registro.Show();
            this.Hide();
        }

        // Evento de carga del formulario (no se está usando actualmente)
        private void Form1_Load(object sender, EventArgs e) { }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}