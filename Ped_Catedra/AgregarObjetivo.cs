using Ped_Catedra.Clases;
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
        Panel pnlRecordatorio;
        ObjetivoModel objetivoModel;
        ObjetivoModel objModel;
        Usuario User;

        public AgregarObjetivo(Usuario user)
        {
            InitializeComponent();
            User = user;
            objetivoModel = new ObjetivoModel();
            objetivoControlador = new ObjetivoControlador();

            objetivoControlador.LlenarCmbRecordatorios(cmbRecordatorios, User.id);
            
        }

        public void inicializarUsuario(Usuario usu, Panel panel, ComboBox cmb)
        {
            User = usu;
            pnlRecordatorio = panel;
            
            objetivoControlador.LlenarCmbRecordatorios(cmbRecordatorios, User.id);
            cmbRecordatorios.SelectedIndex = 0;
        }

        private void btnIngresarObjetivo_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Objetivos obj = new Objetivos();
                obj.titulo = txtTitulo.Text;
                obj.descrip = txtDescri.Text;
                obj.idRecordatorio = int.Parse(cmbRecordatorios.SelectedItem.ToString().ToString().Split('-')[0].Trim());

                if (objetivoModel.InsertarObj(obj))
                {
                    MessageBox.Show("¡Objetivo agregado a " + cmbRecordatorios.SelectedItem + "!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RecordatorioForm form2 = Application.OpenForms.OfType<RecordatorioForm>().FirstOrDefault();
                
            }
        }

        private bool ValidarDatos()
        {
            if(cmbRecordatorios.SelectedIndex == -1) 
            {
                MessageBox.Show("Favor, seleccione un recordatorio para asginarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Favor, ingrese un titulo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescri.Text))
            {
                MessageBox.Show("Favor, ingrese una descripcion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
