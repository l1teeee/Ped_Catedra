using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ped_Catedra.Modelo;

namespace Ped_Catedra
{
    public partial class Forget : Form
    {

        private string codigoVerificacion; // Variable para almacenar el código de verificación generado
        private UsuarioModel usuarioModel;
        private EnviarCorreoModel correoModel;

        private Login login;

        public Forget(Login loginForm)
        {
            InitializeComponent();
            login = loginForm;
            txtVeri.Hide();
            txtVali.Hide();
            btnCon.Hide();
            txtID.Hide();
            txtCambio.Hide();


            btnCambio.Hide();
            txtContra2.Hide();
            txtContra.Hide();
            label3.Hide();
            label4.Hide();

            usuarioModel = new UsuarioModel();
            correoModel = new EnviarCorreoModel();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
           login.Show();
            this.Hide();
        }

        //Botón donde se recibe el correo y se envia el código al usuario
        private void btnVeri_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            // Obtener el ID del usuario
            string id = usuarioModel.ObtenerIdUsuario(correo);

            if (!string.IsNullOrEmpty(id))
            {
                codigoVerificacion = usuarioModel.GenerarCodigo();
                string asunto = "Correo de verificación para recuperar cuenta";
                string mensaje = "A continuación, te enviamos el código de verificación para que puedas recuperar tu cuenta: " + codigoVerificacion;
                correoModel.EnviarCorreo(correo, asunto, mensaje);

                txtID.Text = id;
                MessageBox.Show("Se ha enviado un código de verificación al correo electrónico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitu.Hide();
                txtCorreo.Hide();
                btnVeri.Hide();
                txtVeri.Show();
                txtVali.Show();
                btnCon.Show();
                txtID.Show();

            }
            else
            {
                MessageBox.Show("Usuario no encontrado. Por favor, verifique el correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Se valida que el código enviado al correo sea el correcto 
        private void btnCon_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txtVali.Text;

            if (codigoIngresado == codigoVerificacion)
            {
                MessageBox.Show("Código de verificación correcto.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCon.Hide();
                txtVeri.Hide();
                txtVali.Hide();
                label1.Hide();

                txtCambio.Show();
                btnCambio.Show();
                txtContra2.Show();
                txtContra.Show();
                label3.Show();
                label4.Show();



            } else
            {
                MessageBox.Show("El codigo es incorrecto, verificar informacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Se actualiza la contraseña 
        private void btnCambio_Click(object sender, EventArgs e)
        {
            if (txtContra.Text != txtContra2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string idUsuario = txtID.Text;
            string nuevaContraseña = txtContra.Text;

            usuarioModel.ActualizarContraseña(idUsuario, nuevaContraseña);

            MessageBox.Show("La contraseña ha sido actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //**********Inicio de Diseño del formulario**********
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

        private void txtVali_Enter(object sender, EventArgs e)
        {
            if (txtVali.Text == "CODIGO")
            {
                txtVali.Clear();
                txtVali.ForeColor = Color.LightGray;
            }
        }

        private void txtVali_Leave(object sender, EventArgs e)
        {
            if (txtVali.Text == "")
            {
                txtCorreo.Text = "CODIGO";
                txtVali.ForeColor = Color.DimGray;
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

        //**********Fin de Diseño del formulario**********
    }
}
