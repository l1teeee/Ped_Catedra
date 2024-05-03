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

        public AgregarRecordatorio()
        {
            InitializeComponent();
            recordatorioModel = new RecordatorioModel();
            ctrlPrioridades = new PrioridadControlador();  
        }

        public void inicializarUsuario(Usuario usu, Panel panel, ComboBox cmb)
        {
            datosUsu = usu;
            pnlRecordatorio = panel;
            cmbRecordatorio = cmb;
            ctrlPrioridades.LlenarCmbPrioridades(cmbPrioridad, datosUsu.id);
            cmbPrioridad.SelectedIndex = 0;
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
                recordatorio.estado = "Disponible";

                if (recordatorioModel.InsertarRecor(recordatorio))
                {
                    MessageBox.Show("¡Recordatorio agregado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el recordatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RecordatorioForm formulario2 = Application.OpenForms.OfType<RecordatorioForm>().FirstOrDefault();
                pnlRecordatorio.Invalidate();//volver a dibujar en el panel
                cmbRecordatorio.Items.Clear();//Limpiar el cmb de recordatorio
                formulario2.LlenarCmbRecordatorio();//Actualizar el cmb de recordatorios


                 //buscar y obtener una instancia del formulario RecordatorioForm
                formulario2.OcultarElementos(datosUsu.id);//llamando al metodo que muestra o oculta las opciones de buscar y eliminar

                this.Close();//Cerrando el formulario para agregar recordatorio
            }
        }
        

        //Validación de datos
        private bool ValidarIngreso()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, ingrese un título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescri.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            TimeSpan horaActual = DateTime.Now.TimeOfDay;
            TimeSpan horaIngresada = time.Value.TimeOfDay;
            if (horaIngresada < horaActual)
            {
                MessageBox.Show("La hora ingresada no puede ser anterior a la hora actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

    }
}
