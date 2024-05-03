using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ped_Catedra.Controlador;
using Ped_Catedra.Modelo;

namespace Ped_Catedra
{
    public partial class PrioridadForm : Form
    {
        PrioridadControlador ctrlPrioridad;
        PrioridadModel prioridadModel;
        Usuario datosUsu;

        int idPrioridad = 0;

        public PrioridadForm(Usuario usu)
        {
            InitializeComponent();
            btnEliminar.Hide();
            btnModificar.Hide();
            datosUsu = usu;
            prioridadModel = new PrioridadModel();
            ctrlPrioridad = new PrioridadControlador();
            ctrlPrioridad.LlenarTabla(dgvPrioridades, datosUsu.id);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtPrioridad.Text != "")
            {
                if (prioridadModel.InsertarPrioridad(txtPrioridad.Text, datosUsu.id))
                {
                    MessageBox.Show("¡Prioridad agregada!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la prioridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ctrlPrioridad.LlenarTabla(dgvPrioridades, datosUsu.id);
                txtPrioridad.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese un nombre para la prioridad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPrioridades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                idPrioridad = Convert.ToInt32(dgvPrioridades.Rows[e.RowIndex].Cells["id"].Value);
                txtPrioridad.Text = dgvPrioridades.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                btnAgregar.Hide();
                btnEliminar.Show();
                btnModificar.Show();
            }
        }

        private void txtPrioridad_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrioridad.Text))
            {
                btnEliminar.Hide();
                btnModificar.Hide();
                btnAgregar.Show();
            }
        }
    }
}
