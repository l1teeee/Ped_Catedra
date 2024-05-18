using Ped_Catedra.Clases;
using Ped_Catedra.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ped_Catedra.Controlador
{
    public class ObjetivoControlador
    {
        ObjetivoModel objModel;
        public ObjetivoControlador()
        {
            objModel = new ObjetivoModel();
        }

        public void LlenarCmbRecordatorios(ComboBox cmb, string usuario)
        {
            Lista listaRecordatorios = objModel.ObtenerRecordatorios(usuario);
            Nodo puntero = listaRecordatorios.inicio;

            cmb.Items.Clear();
            while(puntero != null)
            {
                Recordatorio recordatorio = puntero.recordatorio;
                cmb.Items.Add(recordatorio.id + " - " + recordatorio.titulo);
                puntero = puntero.siguiente;
            }
        }

        public void LlenatDataGrid(DataGridView dg, string record)
        {
            Lista listaObjetivos = objModel.obtenerObjetviosRecord(record);
            Nodo puntero = listaObjetivos.inicio;
            dg.Rows.Clear();
            while(puntero != null)
            {
                Objetivos obj = puntero.
            }
        }
    }
}
