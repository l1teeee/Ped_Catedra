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
using Ped_Catedra.Modelo;

namespace Ped_Catedra
{
    public partial class Login : Form
    {
        private UsuarioModel usuarioModel;

        public Login()
        {
            InitializeComponent();
            usuarioModel = new UsuarioModel();
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


        //Boton para iniciar sesión 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsu.Text;
            string contra = txtContra.Text;

            bool credencialesValidas = usuarioModel.VerificarCredenciales(usuario, contra);

            if (credencialesValidas)
            {
                RecordatorioForm recordatorio = new RecordatorioForm();
                recordatorio.inicializarUsuario(usuarioModel.ObtenerDatosUsuario(usuario));
                recordatorio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Habilitar formulario para recuperar contraseña
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forget forget = new Forget(this); 
            forget.Show();
            this.Hide();
        }

        //Habilitar formulario para registrarse
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Hide();
        }


    }
}
