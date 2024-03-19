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
    public partial class Memberme : Form
    {
        public Memberme()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario modal
            Modal modalForm = new Modal();

            // Establecer la opacidad del formulario principal al 10%
            this.Opacity = 0.6;

            // Mostrar el formulario modal
            modalForm.ShowDialog();

            // Restaurar la opacidad del formulario principal al 100% después de cerrar el formulario modal
            this.Opacity = 1.0;
        }



    }
}
