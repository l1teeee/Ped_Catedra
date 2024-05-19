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
using Ped_Catedra.Clases;

namespace Ped_Catedra
{
    public partial class Login : Form
    {
        private UsuarioModel usuarioModel;
        private ObjetivoModel objetivoModel;
        private EnviarCorreoModel CorreoModel;

        public Login()
        {
            InitializeComponent();
            usuarioModel = new UsuarioModel();
            objetivoModel = new ObjetivoModel();
            CorreoModel = new EnviarCorreoModel();
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
            string correo = usuarioModel.obtenerCorreo(usuario);

            bool credencialesValidas = usuarioModel.VerificarCredenciales(usuario, contra);

            if (credencialesValidas)
            {
                RecordatorioForm recordatorio = new RecordatorioForm();
                recordatorio.inicializarUsuario(usuarioModel.ObtenerDatosUsuario(usuario));
                recordatorio.Show();

                //En este momento se actualizar y se valida que existan recordatorios ya vencidos
                VerificarRecordatorio(usuarioModel.updateEstadoRecordatorios(usuario), usuario, correo);
               

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

        public void VerificarRecordatorio(int actualizados, string usuario, string correo)
        {
            if (actualizados > 0)
            {
                MessageBox.Show("Existen recordatorios caducados, revisa tu correo", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Lista listaCaducados = usuarioModel.obtenerCaducados(usuario);

                string asunto = "Tienes recordatorios caducados";

                Nodo puntero = listaCaducados.inicio;

                StringBuilder mensaje = new StringBuilder();
                mensaje.AppendLine("Lista de Recordatorios, son los siguientes");

                int conta = 1;

                while (puntero != null)
                {
                    Recordatorio rec = puntero.recordatorio;
                    mensaje.AppendLine($"\n\n Recordatorio N°{conta}");
                    mensaje.AppendLine($" Titulo: {rec.titulo}");
                    mensaje.AppendLine($" Descripcion: {rec.descripcion}");
                    mensaje.AppendLine($" Prioridad: {rec.prioridadName}");
                    mensaje.AppendLine($" Fecha: {rec.fecha}\t Hora: {rec.hora}");
                    mensaje.AppendLine(" Objetivos:");

                    Lista listaObjetivos = objetivoModel.obtenerObjetviosRecord(rec.id);

                    Nodo punteroObjetivos = listaObjetivos.inicio;

                    if (punteroObjetivos == null)
                    {
                        mensaje.AppendLine("No posee objetivos este recordatorio");
                    }
                    else
                    {
                        int contaobj = 1;
                        while (punteroObjetivos != null)
                        {
                            Objetivos obj = punteroObjetivos.obj;
                            mensaje.AppendLine($"\t Objetivo N°" + contaobj);
                            mensaje.AppendLine($"\t Titulo: {obj.titulo}");
                            mensaje.AppendLine($"\t Descripcion: {obj.descrip}");
                            punteroObjetivos = punteroObjetivos.siguiente;
                            contaobj++;
                        }
                    }

                    puntero = puntero.siguiente;
                    conta++;
                }
                CorreoModel.EnviarCorreo(correo, asunto, mensaje);

            }
        }


    }
}
