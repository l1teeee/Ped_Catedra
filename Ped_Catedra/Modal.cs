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
        public Modal()
        {
            InitializeComponent();
            cmbPrioridad.SelectedIndex = 0;
            list = new Lista();
            mainMenu = new Memberme();
        }

        public Modal(DataGridView tabla)
        {
            
        }

        private void btnCloseModal_Click(object sender, EventArgs e)
        {

            

            // Cerrar el formulario modal
            this.Close();

            // Habilitar el formulario principal nuevamente
            mainMenu.Enabled = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Recordatorio recordatorio = new Recordatorio();

            recordatorio.titulo = txtTitulo.Text;
            recordatorio.fecha = date.Value.Date.ToString();
            recordatorio.hora = time.Value.TimeOfDay.ToString();
            recordatorio.prioridad = cmbPrioridad.Text;
            recordatorio.descripcion = txtDescri.Text;

            list.Insertar(recordatorio);
            list.Mostrar(dataGridView1);
        }


    }
}
