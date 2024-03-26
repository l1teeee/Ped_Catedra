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
        Memberme form1 = new Memberme();


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
            this.Hide();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsu.Text;
            string contra = txtContra.Text;

            bool credencialesValidas = Conexion.VerificarCredenciales(usuario, contra);

            if (credencialesValidas)
            {
                // Crear una instancia del formulario Modal
                Modal form1 = new Modal();

                form1.Usuario = usuario;
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }










        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forget forget = new Forget(this); 
            forget.Show();
            this.Hide();
        }
    }
}
