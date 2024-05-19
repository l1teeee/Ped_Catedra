using Ped_Catedra.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ped_Catedra.Clases;
using Ped_Catedra.Controlador;


namespace Ped_Catedra
{
    public partial class DetalleObjetivo : Form
    {
        ObjetivoModel objetivoModel;
        ObjetivoControlador objetivoControlador;
        Usuario User;
        public DetalleObjetivo(string id)
        {
            InitializeComponent();
            objetivoModel = new ObjetivoModel();
            objetivoControlador = new ObjetivoControlador();
            
        }

        public void LlenarCampos(int id, string idUsuario)
        {
            Objetivos obj = objetivoModel.obtenerObjetivo(id);
            txtTitulo.Text = obj.titulo;
            txtDescri.Text = obj.descrip;
            lblIdObj.Text = obj.id.ToString();
            objetivoControlador.LlenarCmbRecordatorios(cmbRecordatorios, idUsuario);
            SelectComboBoxItemById(cmbRecordatorios, obj.idRecordatorio.ToString());

        }

        private void SelectComboBoxItemById(ComboBox comboBox, string id)
        {
            // Recorrer todos los elementos del ComboBox
            foreach (var item in comboBox.Items)
            {
                if (item.ToString().StartsWith(id + " -"))
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Objetivos obj = new Objetivos();
                obj.id = int.Parse(lblIdObj.Text);
                obj.titulo = txtTitulo.Text;
                obj.descrip = txtDescri.Text;
                obj.idRecordatorio = int.Parse(cmbRecordatorios.SelectedItem.ToString().ToString().Split('-')[0].Trim());

                if (objetivoModel.ModificarObj(obj))
                {
                    MessageBox.Show("Objetivo Modificado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("No se pudo modificar el objetivo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idRecord = int.Parse(cmbRecordatorios.SelectedItem.ToString().ToString().Split('-')[0].Trim());

            if (objetivoModel.EliminarObj(int.Parse(lblIdObj.Text)))
            {
                MessageBox.Show("Objetivo Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("No se pudo eliminar el objetivo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            MessageBox.Show("IDRECORD" + idRecord);

            RecordatorioForm recForm = new RecordatorioForm();

            DetalleRecordatorio detaRec = new DetalleRecordatorio(recForm.pnlRecordatorios);

            objetivoControlador.LlenatDataGrid(detaRec.dgvObjetivos,idRecord);

            this.Close();
        }

        private bool ValidarDatos()
        {
            if (cmbRecordatorios.SelectedIndex == -1)
            {
                MessageBox.Show("Favor, seleccione un recordatorio para asginarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Favor, ingrese un titulo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescri.Text))
            {
                MessageBox.Show("Favor, ingrese una descripcion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void DetalleObjetivo_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
