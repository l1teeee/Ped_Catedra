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
using Ped_Catedra.Clases;

namespace Ped_Catedra
{
    public partial class DetalleRecordatorio : Form
    {
        RecordatorioModel recordatorioModel;
        ObjetivoControlador objControlador;
        PrioridadControlador ctrlPrioridad;
        string titulo = "";
        int idRecor = 0;
        string idUsu;
        Panel pnlMostrar;
        
        public DetalleRecordatorio(Panel pnlRecordatorios)
        {
            InitializeComponent();
            recordatorioModel = new RecordatorioModel();
            ctrlPrioridad = new PrioridadControlador();
            objControlador = new ObjetivoControlador();
            pnlMostrar = pnlRecordatorios;
            time.Format = DateTimePickerFormat.Time;
            time.ShowUpDown = true;
            date.MinDate = DateTime.Today;

        }

        //Llena los campos del recordatorio seleccionado
        public void LlenarCampos(int idRecordatorio)
        {
            Recordatorio recordatorio = recordatorioModel.RecordatorioId(idRecordatorio);
            idRecor = idRecordatorio;
            titulo = recordatorio.titulo;
            lblTitulo.Text = recordatorio.titulo.ToUpper();
            lblPrioridad.Text = recordatorio.prioridadName;
            txtDescri.Text = recordatorio.descripcion;
            lblFecha.Text = recordatorio.fecha;
            lblHora.Text = recordatorio.hora;
            idUsu = recordatorio.usuarioId;

            objControlador.LlenatDataGrid(dgvObjetivos, idRecordatorio);
        }

        //Botón para modificar los datos en la bdd
        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (ValidarIngreso())
            {
                Recordatorio recordatorio = new Recordatorio();
                recordatorio.id = idRecor;
                recordatorio.titulo = txtTitulo.Text;
                recordatorio.prioridadId = int.Parse(cmbPrioridad.SelectedItem.ToString().Split('-')[0].Trim());
                recordatorio.fecha = date.Value.Date.ToString("yyyy-MM-dd");
                recordatorio.hora = time.Value.TimeOfDay.ToString("hh\\:mm\\:ss");
                recordatorio.descripcion = textDescriModi.Text;

                if (recordatorioModel.ModificarRecor(recordatorio))
                {
                    MessageBox.Show("¡Recordatorio modificado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el recordatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LlenarCampos(idRecor);
                pnlMostrar.Invalidate();
                RecordatorioForm formulario2 = Application.OpenForms.OfType<RecordatorioForm>().FirstOrDefault();
                formulario2.LlenarCmbRecordatorio();
                pnlFormulario.Hide();
            } 
        }

        //Botón para ocultar la vista y mostrar el formulario para modificar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = titulo;
            textDescriModi.Text = txtDescri.Text;
            convertFecha();
            ctrlPrioridad.LlenarCmbPrioridades(cmbPrioridad, idUsu);
            cmbPrioridad.SelectedIndex = ctrlPrioridad.IndexCmbPrioridades(lblPrioridad.Text, idUsu);
            pnlFormulario.Show();
        }

        //Valida el ingreso de los datos a modificar
        private bool ValidarIngreso()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, ingrese un título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textDescriModi.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            TimeSpan horaActual = DateTime.Now.TimeOfDay;
            TimeSpan horaIngresada = time.Value.TimeOfDay;

            DateTime fechaIngresada = date.Value;
            DateTime fechaActual = DateTime.Today;



            if (fechaIngresada < fechaActual || (fechaIngresada == fechaActual && horaIngresada < horaActual))
            {
                MessageBox.Show("La hora ingresada no puede ser anterior a la hora actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Convierte la fecha y hora de texto a dateTime
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

        private void dgvObjetivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                DataGridViewRow selected = dgvObjetivos.Rows[e.RowIndex];
                int id = Convert.ToInt32(selected.Cells["ID"].Value);

                DetalleObjetivo detaObj = new DetalleObjetivo(idUsu);
                detaObj.LlenarCampos(id, idUsu);
                detaObj.Show();
            }
        }
    }
}
