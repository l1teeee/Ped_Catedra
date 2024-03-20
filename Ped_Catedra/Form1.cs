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
        Modal modalForm = new Modal();

        public Memberme()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.2;
            modalForm.ShowDialog();
            this.Opacity = 1.0;
        }

        private void Memberme_Load(object sender, EventArgs e)
        {

        }
    }
}
