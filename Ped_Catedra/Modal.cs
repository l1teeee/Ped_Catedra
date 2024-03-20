using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            // Validar el campo 'titulo'
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, ingrese un título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(txtTitulo.Text, "^[A-Z][a-z]*$"))
            {
                MessageBox.Show("El título debe comenzar con mayúscula y contener solo letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el campo 'descripcion'
            if (string.IsNullOrWhiteSpace(txtDescri.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Recordatorio recordatorio = new Recordatorio();

            recordatorio.titulo = txtTitulo.Text;
            recordatorio.fecha = date.Value.Date.ToString("yyyy-MM-dd");

            // Obtener la hora actual
            TimeSpan horaActual = DateTime.Now.TimeOfDay;

            // Obtener la hora ingresada en el control 'time'
            TimeSpan horaIngresada = time.Value.TimeOfDay;

            // Validar que la hora ingresada no sea anterior a la hora actual
            if (horaIngresada < horaActual)
            {
                MessageBox.Show("La hora ingresada no puede ser anterior a la hora actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            recordatorio.hora = horaIngresada.ToString("hh\\:mm\\:ss");

            // Validar y establecer la prioridad
            if (cmbPrioridad.Items.Count > 0)
            {
                recordatorio.prioridad = cmbPrioridad.Items[0].ToString();
            }
            else
            {
                MessageBox.Show("No hay prioridades disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            recordatorio.descripcion = txtDescri.Text;

            list.Insertar(recordatorio);
            list.Mostrar(dgvRecordatorios);
            MessageBox.Show("¡Recordatorio agregado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
        }




        public void Limpiar()
        {
            txtTitulo.Clear();
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
            // Verificar si el campo txtEliminar está vacío
            if (string.IsNullOrWhiteSpace(txtEliminar.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de registro a eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si el campo está vacío
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas realizar esta acción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Eliminar el registro solo si el campo txtEliminar no está vacío
                list.Eliminar(int.Parse(txtEliminar.Text));
                list.Mostrar(dgvRecordatorios);
            }

            txtEliminar.Clear();
        }


        private void txtTitulo_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtEliminar_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtEliminar_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
