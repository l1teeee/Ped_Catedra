using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ped_Catedra.Modelo;
namespace Ped_Catedra
{
    public partial class Registro : Form
    {

        private string codigoVerificacion; // Variable para almacenar el código de verificación generado
        Usuario nuevoUsu = new Usuario();
        UsuarioModel usuarioModel;
        EnviarCorreoModel correoModel;
        Login login;

        public int cantidad = 1;
        public Registro()
        {
            InitializeComponent();
            txtVeri.Hide();
            txtCodi.Hide();
            labelcodi.Hide();
            btnVeri.Hide();
            label3.Hide();
            usuarioModel = new UsuarioModel();
            correoModel = new EnviarCorreoModel();
            login = new Login();
        }

        //Boton de regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            login.Show();
            // Cerrar el formulario modal
            this.Hide();

        }

        //Botón dónde se reciben los datos
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            
            if(ValidarIngresoUsuario())
            {
                // Mostrar los elementos para la verificación y ocultar los de registro
                txtVeri.Show();
                txtCodi.Show();
                labelcodi.Show();
                btnVeri.Show();
                label3.Show();

                txtRegi.Hide();
                label1.Hide();
                txtNombre.Hide();
                txtApellido.Hide();
                label2.Hide();
                txtUsu.Hide();
                label4.Hide();
                btnRegistro.Hide();
                txtContra.Hide();
                txtContra2.Hide();
                txtRegi.Hide();
                label5.Hide();
                txtContra2.Hide(); 
                label6.Hide();
                txtCorreo.Hide();
                label7.Hide();
                label8.Hide();
                codigoVerificacion = usuarioModel.GenerarCodigo();
                string asunto = "Correo de verificación para inicio de sesión";
                string mensaje = "¡Hola " + txtNombre.Text + " " + txtApellido.Text + "!" +
                    "\n\nAgradecemos que te hayas registrado en MemberMe. A continuación, te enviamos el código de verificación: " + codigoVerificacion;
                correoModel.EnviarCorreo(txtCorreo.Text.Trim(), asunto, mensaje); // Se pasa el correo ingresado 

            }


        }

        //Botón para verificar código enviado al correo y crear el usuario
        private void btnVeri_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txtCodi.Text;

            if (codigoIngresado == codigoVerificacion)
            {
                MessageBox.Show("Código de verificación correcto. ¡Registro completado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Usuario nuevoUsu = new Usuario();
                nuevoUsu.nombres = txtNombre.Text;
                nuevoUsu.apellidos = txtApellido.Text;
                nuevoUsu.id = txtUsu.Text;
                nuevoUsu.contraseña = txtContra.Text;
                nuevoUsu.correo = txtCorreo.Text;

                string campoDuplicado = usuarioModel.InsertarUsuario(nuevoUsu);
                if (campoDuplicado == "")
                {
                    // Mostrar mensaje de éxito y limpiar formulario
                    MessageBox.Show("¡Usuario registrado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar formulario actual
                    login.Show(); // Mostrar formulario de inicio de sesión
                }
                else
                {
                    // Mostrar mensaje de error si hubo un problema al insertar el usuario
                    MessageBox.Show($"Error al registrar usuario: {campoDuplicado}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El código de verificación ingresado es incorrecto. Inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Validación de datos para el registro
        private bool ValidarIngresoUsuario()
        {
            string correo = txtCorreo.Text.Trim();
            Regex regexCorreo = new Regex(@"^[a-zA-Z0-9._%+-]+@gmail.com$");


            if (txtNombre.Text == "NOMBRE" || string.IsNullOrWhiteSpace(txtNombre.Text) || !Regex.IsMatch(txtNombre.Text, "^[A-Za-záéíóúÁÉÍÓÚñÑ]+$"))
            {
                MessageBox.Show("Por favor, ingrese un nombre válido (comenzando con mayúscula).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtUsu.Text == "USUARIO" )
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtApellido.Text == "APELLIDO" || string.IsNullOrWhiteSpace(txtApellido.Text) || !Regex.IsMatch(txtApellido.Text, "^[A-Za-záéíóúÁÉÍÓÚñÑ]+$"))
            {
                MessageBox.Show("Por favor, ingrese un apellido válido (comenzando con mayúscula).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!regexCorreo.IsMatch(correo))
            {
                MessageBox.Show("Por favor, ingrese un correo válido de Gmail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtContra.Text != txtContra2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar la existencia del usuario y del correo
            string campoDuplicadoUsuario = usuarioModel.ValidarExistenciaUsuario(txtUsu.Text);
            string campoDuplicadoCorreo = usuarioModel.ValidarExistenciaCorreo(correo);

            if (campoDuplicadoUsuario != "" || campoDuplicadoCorreo != "")
            {
                string mensajeError = "";
                if (campoDuplicadoUsuario != "")
                {
                    mensajeError += $"El {campoDuplicadoUsuario} ya está registrado.\n";
                }
                if (campoDuplicadoCorreo != "")
                {
                    mensajeError += $"El {campoDuplicadoCorreo} ya está registrado.";
                }

                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //*********INICIO de estilo del registro*********

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE")
            {
                txtNombre.Clear();
                txtNombre.ForeColor = Color.LightGray;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "APELLIDO")
            {
                txtApellido.Clear();
                txtApellido.ForeColor = Color.LightGray;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "")
            {
                txtApellido.Text = "APELLIDO";
                txtApellido.ForeColor = Color.DimGray;
            }
        }

        private void txtUsu_Enter(object sender, EventArgs e)
        {
            if (txtUsu.Text == "NOMBRE DE USUARIO")
            {
                txtUsu.Clear();
                txtUsu.ForeColor = Color.LightGray;
            }
        }

        private void txtUsu_Leave(object sender, EventArgs e)
        {
            if (txtUsu.Text == "")
            {
                txtUsu.Text = "NOMBRE DE USUARIO";
                txtUsu.ForeColor = Color.DimGray;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "CONTRASEÑA")
            {
                txtContra.Clear();
                txtContra.ForeColor = Color.LightGray;
                txtContra.UseSystemPasswordChar = true;
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;
            }
        }

        private void txtContra2_Enter(object sender, EventArgs e)
        {
            if (txtContra2.Text == "CONFIRMA TÚ CONTRASEÑA")
            {
                txtContra2.Clear();
                txtContra2.ForeColor = Color.LightGray;
                txtContra2.UseSystemPasswordChar = true;
            }
        }

        private void txtContra2_Leave(object sender, EventArgs e)
        {
            if (txtContra2.Text == "")
            {
                txtContra2.Text = "CONFIRMA TÚ CONTRASEÑA";
                txtContra2.ForeColor = Color.DimGray;
                txtContra2.UseSystemPasswordChar = false;
            }
        }

        private void txtCorreo_Enter_1(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "CORREO DE USUARIO")
            {
                txtCorreo.Clear();
                txtCorreo.ForeColor = Color.LightGray;
            }
        }

        private void txtCorreo_Leave_1(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "CORREO DE USUARIO";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }
        private void txtCodi_Enter(object sender, EventArgs e)
        {
            if (txtCodi.Text == "CODIGO DE VERIFICACION")
            {
                txtCodi.Clear();
                txtCodi.ForeColor = Color.LightGray;
            }
        }

        private void txtCodi_Leave(object sender, EventArgs e)
        {

            if (txtCodi.Text == "")
            {
                txtCodi.Text = "CODIGO DE VERIFICACION";
                txtCodi.ForeColor = Color.LightGray;
            }
        }
        //*********FIN de estilo del registro*********
    }
}
