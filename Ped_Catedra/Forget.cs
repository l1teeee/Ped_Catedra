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
    public partial class Forget : Form
    {

        private Login login;

        public Forget(Login loginForm)
        {
            InitializeComponent();
            login = loginForm;
        }



        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "CORREO DE LA CUENTA")
            {
                txtCorreo.Clear();
                txtCorreo.ForeColor = Color.LightGray;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "CORREO DE LA CUENTA";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
           login.Show();
            this.Hide();
        }

        private void btnVeri_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string id = Conexion.ObtenerIdUsuario(correo);

            txtID.Text = id.ToString();
        }



    }
}
