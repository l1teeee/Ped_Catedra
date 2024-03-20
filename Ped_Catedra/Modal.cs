using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ped_Catedra
{
    public partial class Modal : Form
    {
        private Lista list;
        Memberme mainMenu;
        public string Usuario { get; set; }
        public Modal()
        {
            InitializeComponent();
            cmbPrioridad.SelectedIndex = 0;
            list = new Lista();
            mainMenu = new Memberme();
        }

        private void btnCloseModal_Click(object sender, EventArgs e)
        {

            

            // Cerrar el formulario modal
            this.Close();

            // Habilitar el formulario principal nuevamente
            mainMenu.Enabled = true;
        }


        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            Recordatorio recordatorio = new Recordatorio();

            recordatorio.titulo = txtTitulo.Text;
            recordatorio.fecha = date.Value.Date.ToString("yyyy-MM-dd");
            recordatorio.hora = time.Value.TimeOfDay.ToString("hh\\:mm\\:ss");
            recordatorio.prioridad = cmbPrioridad.Text;
            recordatorio.descripcion = txtDescri.Text;

            list.Insertar(recordatorio);
            list.Mostrar(dgvRecordatorios);
            MessageBox.Show("¡Recordatorio agregado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }

        public void Limpiar()
        {
            txtTitulo.Text = "TITULO";
            txtDescri.Clear();
            cmbPrioridad.SelectedIndex = 0;
        }

        private void dgvRecordatorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object valorCelda = dgvRecordatorios.Rows[e.RowIndex].Cells[0].Value;

                if (valorCelda != null)
                {
                    txtEliminar.Text = valorCelda.ToString();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas realizar esta acción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                list.Eliminar(int.Parse(txtEliminar.Text));
                list.Mostrar(dgvRecordatorios);
            }
            txtEliminar.Clear();
        }

        private void txtTitulo_Enter(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "TITULO")
            {
                txtTitulo.Clear();
                txtTitulo.ForeColor = Color.LightGray;
            }
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "")
            {
                txtTitulo.Text = "TITULO";
                txtTitulo.ForeColor = Color.DimGray;
            }
        }

        private void txtEliminar_Enter(object sender, EventArgs e)
        {
            if (txtEliminar.Text == "ID RECORDATORIO")
            {
                txtEliminar.Clear();
                txtEliminar.ForeColor = Color.LightGray;
            }
        }

        private void txtEliminar_Leave(object sender, EventArgs e)
        {
            if (txtEliminar.Text == "")
            {
                txtEliminar.Text = "ID RECORDATORIO";
                txtEliminar.ForeColor = Color.DimGray;
            }
        }
    }
}
