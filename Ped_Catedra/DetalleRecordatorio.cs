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
using Ped_Catedra.Controlador;

namespace Ped_Catedra
{
    public partial class DetalleRecordatorio : Form
    {
        RecordatorioModel recordatorioModel;
        PrioridadControlador ctrlPrioridad;
        string titulo = "";
        public DetalleRecordatorio()
        {
            InitializeComponent();
            recordatorioModel = new RecordatorioModel();
            ctrlPrioridad = new PrioridadControlador();
            
        }

        public void LlenarCampos(int idRecordatorio)
        {
            Recordatorio recordatorio = recordatorioModel.RecordatorioId(idRecordatorio);
            titulo = recordatorio.titulo;
            lblTitulo.Text = recordatorio.titulo.ToUpper();
            lblPrioridad.Text = recordatorio.prioridadName;
            txtDescri.Text = recordatorio.descripcion;
            lblFecha.Text = recordatorio.fecha;
            lblHora.Text = recordatorio.hora;
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (ValidarIngreso())
            {

            }
            pnlFormulario.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = titulo;
            textDescriModi.Text = txtDescri.Text;
            convertFecha();
            ctrlPrioridad.LlenarCmbPrioridades(cmbPrioridad);
            cmbPrioridad.SelectedIndex = ctrlPrioridad.IndexCmbPrioridades(lblPrioridad.Text);
            pnlFormulario.Show();
        }

        private bool ValidarIngreso()
        {
            // Validar el campo titulo
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, ingrese un título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar el campo descripción
            if (string.IsNullOrWhiteSpace(txtDescri.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Obtener la hora actual
            TimeSpan horaActual = DateTime.Now.TimeOfDay;

            // Obtener la hora ingresada en el control 'time'
            TimeSpan horaIngresada = time.Value.TimeOfDay;

            // Validar que la hora ingresada no sea anterior a la hora actual
            if (horaIngresada < horaActual)
            {
                MessageBox.Show("La hora ingresada no puede ser anterior a la hora actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void convertFecha()
        {
            string fechaTexto = lblFecha.Text;
            string horaTexto = lblHora.Text;

            DateTime fecha;
            if (DateTime.TryParse(fechaTexto, out fecha))
            {
                date.Value = fecha;
            }
            DateTime hora;
            if (DateTime.TryParse(horaTexto, out hora))
            {
                DateTime fechaHora = fecha.Date + hora.TimeOfDay;
                time.Value = fechaHora;
            }
        }

    }
}
