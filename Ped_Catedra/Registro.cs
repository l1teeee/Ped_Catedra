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

namespace Ped_Catedra
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        Login login = new Login();


        public int cantidad = 1;

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



        private void txtDescri_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtDescri_Leave(object sender, EventArgs e)
        {
           
        }

        //*********FIN de estilo del registro*********


        //Boton de regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            login.Show();
            // Cerrar el formulario modal
            this.Hide();

        }

        //Boton para recibir datos
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !Regex.IsMatch(txtNombre.Text, "^[A-Z][a-z]*$"))
            {
                MessageBox.Show("Por favor, ingrese un nombre válido (comenzando con mayúscula).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text) || !Regex.IsMatch(txtApellido.Text, "^[A-Z][a-z]*$"))
            {
                MessageBox.Show("Por favor, ingrese un apellido válido (comenzando con mayúscula).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string correo = txtCorreo.Text.Trim();

            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@gmail.com$";
            Regex regexCorreo = new Regex(patronCorreo);

            if (!regexCorreo.IsMatch(correo))
            {
                MessageBox.Show("Por favor, ingrese un correo válido de Gmail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            



            if (txtContra.Text != txtContra2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario nuevoUsu = new Usuario();

            nuevoUsu.nombre = txtNombre.Text;
            nuevoUsu.apellido = txtApellido.Text;
            nuevoUsu.usuario = txtUsu.Text;
            nuevoUsu.contraseña = txtContra.Text;
            nuevoUsu.correo = txtCorreo.Text;

            // Obtener la confirmación de la contraseña
            string confirmacionContraseña = txtContra2.Text;

            // Llamar al método para insertar el nuevo usuario
            Conexion.InsertarUsuario(nuevoUsu, confirmacionContraseña);

            
            MessageBox.Show("¡Registro completado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
            this.Close();
            login.Show();

        }



        public void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtUsu.Clear();
            txtContra.Clear();
            txtContra2.Clear();
            txtCorreo.Clear();
        }

        
    }
}
