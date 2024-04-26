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
    public partial class RecordatorioForm : Form
    {
        public Usuario datosUsu;
        public Lista list;
        public RecordatorioForm()
        {
            InitializeComponent();
            list = new Lista();
        }

        //Inicializa los datos del usuario incluyendo sus recordatorios
        public void inicializarUsuario(Usuario usu)
        {
            datosUsu = usu;
            lblNombre.Text = datosUsu.nombres + " " + datosUsu.apellidos;
            list.MostrarRecordatorios(pnlRecordatorios, datosUsu.id);
        }

        //Activa el formulario para agregar un nuevo recordatorio
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarRecordatorio agregarRecordatorio = new AgregarRecordatorio();
            agregarRecordatorio.inicializarUsuario(datosUsu, pnlRecordatorios);
            agregarRecordatorio.Show();
            
        }

        //Permite dibujar el recordatorio
        private void pnlRecordatorios_Paint_1(object sender, PaintEventArgs e)
        {
            list.MostrarRecordatorios(pnlRecordatorios, datosUsu.id);
        }
    }
}
