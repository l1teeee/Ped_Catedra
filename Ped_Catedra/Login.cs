using MySql.Data.MySqlClient;
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

namespace Ped_Catedra
{
    public partial class Login : Form
    {
        private Conexion mConexion;
        Form1 modalForm = new Form1();


        public Login()
        {
            InitializeComponent();
            mConexion = new Conexion(); 
        }

        //*********INICIO de estilo del login*********
        private void txtUsu_Enter(object sender, EventArgs e)
        {
            if(txtUsu.Text == "USUARIO")
            {
                txtUsu.Clear();
                txtUsu.ForeColor = Color.LightGray;
            }
        }

        private void txtUsu_Leave(object sender, EventArgs e)
        {
            if(txtUsu.Text == "")
            {
                txtUsu.Text = "USUARIO";
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

        //*********FIN de estilo del login*********

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            // Habilitar el formulario principal nuevamente
            registro.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsu.Text;
            string contra = txtContra.Text;

            int count = Conexion.VerificarCredenciales(usuario, contra);

            if (count > 0)
            {
                MessageBox.Show("¡Inicio de sesión exitoso!");
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }




        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
