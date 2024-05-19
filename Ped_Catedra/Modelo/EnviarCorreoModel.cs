using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace Ped_Catedra.Modelo
{
    public class EnviarCorreoModel
    {
        /*public void EnviarCodigoVerificacion(string correoDestinatario, string codigo)
        {
            string contraseñaCorreo = "qukrhapiaxidtdfj";
            string asuntoCorreo = "Código de Verificación";
            string mensajeCorreo = "Su código de verificación es: " + codigo;

            try
            {
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
                clienteSmtp.Port = 587;
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential("cuponerarivas@gmail.com", contraseñaCorreo);

                MailMessage correo = new MailMessage("cuponerarivas@gmail.com", correoDestinatario, asuntoCorreo, mensajeCorreo);

                clienteSmtp.Send(correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        //Enviar correo
        public void EnviarCorreo(string destinatario, string asunto, string mensaje)
        {
            try
            {
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
                clienteSmtp.Port = 587;
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential("cuponerarivas@gmail.com", "qukrhapiaxidtdfj");

                MailMessage correo = new MailMessage("cuponerarivas@gmail.com", destinatario, asunto, mensaje);

                clienteSmtp.Send(correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EnviasCaducados(string destinatario, string asunto, string mensaje)
        {
            try
            {
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
                clienteSmtp.Port = 587;
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential("cuponerarivas@gmail.com", "qukrhapiaxidtdfj");

                MailMessage correo = new MailMessage("cuponerarivas@gmail.com", destinatario, asunto, mensaje);

                clienteSmtp.Send(correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
