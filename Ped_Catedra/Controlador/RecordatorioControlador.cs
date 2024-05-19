using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Ped_Catedra.Modelo;

namespace Ped_Catedra.Controlador
{
    public class RecordatorioControlador
    {
        RecordatorioModel recordatorioModel;
        UsuarioModel usuarioModel;
        public RecordatorioControlador()
        {
            recordatorioModel = new RecordatorioModel();
            usuarioModel = new UsuarioModel();
        }

        //Dibuja los recordatorios del usuario
        public void MostrarRecordatorios(Panel panel, string usuario)
        {
            Graphics lienzo = panel.CreateGraphics();

            lienzo.Clear(ColorTranslator.FromHtml("#FFFFFF"));

            int x = 10;
            int y = 20;

            int ancho = 250;
            int alto = 150;
            int separacion = 300;
            int ySeparacion = 170;

            Font nodoFont = new Font("Nirmala UI", 11, FontStyle.Bold);

            Lista listaRecordatorios = recordatorioModel.ObtenerRecordatorios(usuario);

            // Iterar sobre los elementos de la lista y mostrarlos en la consola
            Nodo puntero = listaRecordatorios.inicio;
            int contador = 0;
          
            while (puntero != null)
            {
                contador++;
                Recordatorio recordatorio = puntero.recordatorio;
                lienzo.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#007ACC")), x, y, ancho, alto);
                lienzo.DrawString(
                    "Titulo: " + recordatorio.titulo +
                    "\n\nPrioridad: " + recordatorio.prioridadName +
                    "\n\nFecha: " + recordatorio.fecha +
                    "\n\nHora: " + recordatorio.hora, nodoFont, Brushes.White, x + 5, y + 5);
              
                if (contador % 3 == 0)
                {
                    y += ySeparacion;
                    x = 10;
                }
                else
                {
                    x += separacion;
                }
                puntero = puntero.siguiente;
            }
            panel.Height = y + ySeparacion;
           
            
            
        }

        //Llena el comboBox con los recordatorios del usuario
        public void LlenarCmbRecordatorios(ComboBox cmb, string usuario)
        {
            Lista listaRecordatorios = recordatorioModel.ObtenerRecordatorios(usuario);

            Nodo puntero = listaRecordatorios.inicio;
            cmb.Items.Clear();
            while (puntero != null)
            {
                Recordatorio recordatorio = puntero.recordatorio;
                cmb.Items.Add(recordatorio.id + " - " + recordatorio.titulo);
                puntero = puntero.siguiente;
            }
        }

        //Regresa el total de recordatorios
        public int TotalRecordatorios(string usuario)
        {
            Lista listaRecordatorios = recordatorioModel.ObtenerRecordatorios(usuario);

            return listaRecordatorios.TotalNodos();
        }

    }
}
