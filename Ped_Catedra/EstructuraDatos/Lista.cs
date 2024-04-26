using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ped_Catedra.Modelo;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Ped_Catedra
{
    public class Lista
    {
        public Nodo inicio;
        int totalnodos;
        RecordatorioModel recordatorioModel;


        public Lista()
        {
            recordatorioModel = new RecordatorioModel();
            this.inicio = null;
            this.totalnodos = 0;

        }

        public int TotalNodos()
        {
            return this.totalnodos;
        }


        public void Insertar(Recordatorio recor)
        {
            Nodo auxiliar = new Nodo(recor);

            if (inicio == null)
            {
                inicio = auxiliar;
            }
            else
            {
                Nodo puntero = inicio;
                while (puntero.siguiente != null)
                {
                    puntero = puntero.siguiente;
                }
                puntero.siguiente = auxiliar;
            }
            this.totalnodos++;
        }

        public void LimpiarLista()
        {
            while (inicio != null)
            {
                EliminarI();
            }
        }


        public Nodo EliminarI()
        {
            Nodo aux = null;
            if (inicio != null)
            {
                aux = inicio;
                inicio = inicio.siguiente;
                this.totalnodos--;
            }
            return aux;
        }


        public void Eliminar(int idRecordatorio)
        {
            recordatorioModel.EliminarRecor(idRecordatorio);
        }

        public void MostrarRecordatorios(Panel panel, string usuario)
        {
            Graphics lienzo = panel.CreateGraphics();

            lienzo.Clear(ColorTranslator.FromHtml("#FFFFFF"));

            int x = 10;
            int y = 20;

            int ancho = 250;
            int alto = 220;
            int separacion = 300;
            int ySeparacion = 240;

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
                    "\n\nHora: " + recordatorio.hora +
                    "\n\nDescripción: " + recordatorio.descripcion +
                    "\n\nObjetivos: " + recordatorio.objetivosId
                    , nodoFont, Brushes.White, x + 5, y + 5);
                if(contador % 3 == 0)
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
    }
}
