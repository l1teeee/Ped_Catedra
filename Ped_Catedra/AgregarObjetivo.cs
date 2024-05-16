using Ped_Catedra.Controlador;
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

namespace Ped_Catedra
{
    public partial class AgregarObjetivo : Form
    {
        ObjetivoControlador objetivoControlador;
        ObjetivoModel objModel;
        Usuario User;

        public AgregarObjetivo(Usuario user)
        {
            InitializeComponent();
            User = user;
            objetivoControlador.LlenarCmbRecordatorios(cmbRecordatorios, User.id);
        }
    }
}
