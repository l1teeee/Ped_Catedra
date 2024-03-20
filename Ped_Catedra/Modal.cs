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
        public Modal()
        {
            InitializeComponent();
        }

        private void btnCloseModal_Click(object sender, EventArgs e)
        {

            Memberme mainMenu = new Memberme();

            // Cerrar el formulario modal
            this.Close();

            // Habilitar el formulario principal nuevamente
            mainMenu.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Modal_Load(object sender, EventArgs e)
        {

        }
    }
}
