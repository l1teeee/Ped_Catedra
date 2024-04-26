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
    public partial class AgregarRecordatorio : Form
    {
        RecordatorioModel recordatorioModel;
        Panel pnlRecordatorio;
        public Usuario datosUsu;
        public Lista list;

        public AgregarRecordatorio()
        {
            InitializeComponent();
            recordatorioModel = new RecordatorioModel();
            list = new Lista();
            cmbPrioridad.SelectedIndex = 0;
        }

        public void inicializarUsuario(Usuario usu, Panel panel)
        {
            datosUsu = usu;
            pnlRecordatorio = panel;
        }

        //Guardando un nuevo recordatorio
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarIngreso())
            {
                Recordatorio recordatorio = new Recordatorio();
                recordatorio.titulo = txtTitulo.Text;
                recordatorio.prioridadId = int.Parse(cmbPrioridad.SelectedItem.ToString().Split('-')[0].Trim());
                recordatorio.fecha = date.Value.Date.ToString("yyyy-MM-dd");
                recordatorio.hora = time.Value.TimeOfDay.ToString("hh\\:mm\\:ss");
                recordatorio.descripcion = txtDescri.Text;
                recordatorio.usuarioId = datosUsu.id;

                if (recordatorioModel.InsertarRecor(recordatorio))
                {
                    MessageBox.Show("¡Recordatorio agregado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    MessageBox.Show("No se pudo agregar el recordatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                list.MostrarRecordatorios(pnlRecordatorio, datosUsu.id);
                this.Close();
            }
        }
        

        //Validación de datos
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
    }
}
