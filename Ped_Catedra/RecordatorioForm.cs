using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ped_Catedra.Modelo;
using Ped_Catedra.Controlador;

namespace Ped_Catedra
{
    public partial class RecordatorioForm : Form
    {
        public Usuario datosUsu;
        public RecordatorioControlador ctrlRecordatorio;
        public RecordatorioModel recordatorioModel;
        public RecordatorioForm()
        {
            InitializeComponent();
            ctrlRecordatorio = new RecordatorioControlador();
            recordatorioModel = new RecordatorioModel();   
        }

        //Inicializa los datos del usuario incluyendo sus recordatorios
        public void inicializarUsuario(Usuario usu)
        {
            datosUsu = usu; //Guarda el objeto usuario con toda su información
            lblNombre.Text = datosUsu.nombres + " " + datosUsu.apellidos; //Muestra el nombre del usuario
            ctrlRecordatorio.MostrarRecordatorios(pnlRecordatorios, datosUsu.id); //Muestra los recordatorios del usuario
            LlenarCmbRecordatorio();//Llena el cmb
            OcultarElementos(datosUsu.id);//Oculta o muestra los elementos para buscar o eliminar
            inicializarCmbRecordatorios(); //Inicializa al primer elemento del cmb
        }

        //Activa el formulario para agregar un nuevo recordatorio
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarRecordatorio agregarRecordatorio = new AgregarRecordatorio();
            agregarRecordatorio.inicializarUsuario(datosUsu, pnlRecordatorios, cmbRecordatorios);
            agregarRecordatorio.Show();
            
        }

        //Permite dibujar el recordatorio
        private void pnlRecordatorios_Paint_1(object sender, PaintEventArgs e)
        {
            pnlRecordatorios.Controls.Clear(); // Limpiar el panel
            ctrlRecordatorio.MostrarRecordatorios(pnlRecordatorios, datosUsu.id);
        }

        //Cerrar sesión
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        //Eliminar recordatorio
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            recordatorioModel.EliminarRecor(int.Parse(cmbRecordatorios.SelectedItem.ToString().Split('-')[0].Trim()));
            pnlRecordatorios.Invalidate();
            LlenarCmbRecordatorio();
            OcultarElementos(datosUsu.id);
        }

        //Mostrar detalles de un recordatorio
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DetalleRecordatorio detalleRecordatorio = new DetalleRecordatorio(pnlRecordatorios);
            detalleRecordatorio.LlenarCampos(int.Parse(cmbRecordatorios.SelectedItem.ToString().Split('-')[0].Trim()));
            detalleRecordatorio.Show();
        }

        //Inicializar cmbRecordatorios
        private void inicializarCmbRecordatorios()
        {
            if(ctrlRecordatorio.TotalRecordatorios(datosUsu.id) > 0)
            {
                cmbRecordatorios.SelectedIndex = 0;
            }
        }

        //Llena el cmbRecordatorios
        public void LlenarCmbRecordatorio()
        {
            ctrlRecordatorio.LlenarCmbRecordatorios(cmbRecordatorios, datosUsu.id);
            inicializarCmbRecordatorios();
        }

        //Oculta y muestra las opciones de eliminar y buscar
        public void OcultarElementos(string idUsuario)
        {
            if (ctrlRecordatorio.TotalRecordatorios(idUsuario) == 0)
            {
                cmbRecordatorios.Hide();
                btnBuscar.Hide();
                btnEliminar.Hide();
            }else
            {
                cmbRecordatorios.Show();
                btnBuscar.Show();
                btnEliminar.Show();

            }
        }

        private void btnPrioridad_Click(object sender, EventArgs e)
        {
            PrioridadForm prioridadForm = new PrioridadForm(datosUsu);
            prioridadForm.Show();
        }
    }
}
