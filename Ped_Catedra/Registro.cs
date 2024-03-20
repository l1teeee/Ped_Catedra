using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void txtDescri_Enter(object sender, EventArgs e)
        {
            if (txtDescri.Text == "DESCRIPCIÓN")
            {
                txtDescri.Clear();
                txtDescri.ForeColor = Color.LightGray;
            }
        }

        private void txtDescri_Leave(object sender, EventArgs e)
        {
            if (txtDescri.Text == "")
            {
                txtDescri.Text = "DESCRIPCIÓN";
                txtDescri.ForeColor = Color.DimGray;
            }
        }

        //*********FIN de estilo del registro*********


        //Boton de regresar
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            // Cerrar el formulario modal
            this.Hide();

        }

        //Boton para recibir datos
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Usuario nuevoUsu = new Usuario();

            nuevoUsu.id = cantidad++;
            nuevoUsu.nombre = txtNombre.Text;
            nuevoUsu.apellido = txtApellido.Text;
            nuevoUsu.usuario = txtUsu.Text;
            nuevoUsu.contraseña = txtContra.Text;
            nuevoUsu.descripcion = txtDescri.Text;
            MessageBox.Show("¡Registro completado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
            this.Close();
        }

        public void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtUsu.Clear();
            txtContra.Clear();
            txtContra2.Clear();
            txtDescri.Clear();
        }
    }
}
