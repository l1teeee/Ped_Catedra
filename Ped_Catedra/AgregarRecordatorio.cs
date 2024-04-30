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
    public partial class AgregarRecordatorio : Form
    {
        RecordatorioModel recordatorioModel;
        Panel pnlRecordatorio;
        ComboBox cmbRecordatorio;
        public Usuario datosUsu;
        PrioridadControlador ctrlPrioridades;
        RecordatorioControlador ctrlrecordatorio;

        public AgregarRecordatorio()
        {
            InitializeComponent();
            recordatorioModel = new RecordatorioModel();
            ctrlPrioridades = new PrioridadControlador();
            ctrlrecordatorio = new RecordatorioControlador();
            ctrlPrioridades.LlenarCmbPrioridades(cmbPrioridad);
            cmbPrioridad.SelectedIndex = 0;
        }

        public void inicializarUsuario(Usuario usu, Panel panel, ComboBox cmb)
        {
            datosUsu = usu;
            pnlRecordatorio = panel;
            cmbRecordatorio = cmb;
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
                pnlRecordatorio.Invalidate();//volver a dibujar en el panel
                cmbRecordatorio.Items.Clear();//Limpiar el cmb de recordatorio
                ctrlrecordatorio.LlenarCmbRecordatorios(cmbRecordatorio, datosUsu.id);//Actualizar el cmb de recordatorios


                RecordatorioForm formulario2 = Application.OpenForms.OfType<RecordatorioForm>().FirstOrDefault(); //buscar y obtener una instancia del formulario RecordatorioForm
                formulario2.OcultarElementos(datosUsu.id);//llamando al metodo que muestra o oculta las opciones de buscar y eliminar

                this.Close();//Cerrando el formulario para agregar recordatorio
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
