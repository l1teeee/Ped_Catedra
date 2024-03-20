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
        Lista list;
        public Memberme()
        {
            InitializeComponent();
            list = new Lista();
            list.Mostrar(dgvRecordatorio);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modal modalForm = new Modal(dgvRecordatorio);
            this.Opacity = 0.2;
            modalForm.ShowDialog();
            this.Opacity = 1.0;
            this.Close();
        }

    }
}
