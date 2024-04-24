using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ped_Catedra
{
    public partial class Modal : Form
    {
        private Lista list;
        Memberme mainMenu;
        public string Usuario { get; set; }


        public Modal()
        {
            InitializeComponent();
            list = new Lista();
            mainMenu = new Memberme();
            CargarPrioridades(); // Llama a la función para cargar las prioridades


        }

        private void btnCloseModal_Click(object sender, EventArgs e)
        {

            this.Close();

            // Habilitar el formulario principal nuevamente
            mainMenu.Enabled = true;
        }


        public void Limpiar()
        {
            txtTitulo.Clear();
            txtDescri.Clear();
            cmbPrioridad.SelectedIndex = 0;
        }

        private void dgvRecordatorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object valorCelda = dgvRecordatorios.Rows[e.RowIndex].Cells[0].Value;

                if (valorCelda != null)
                {
                    txtEliminar.Text = valorCelda.ToString();
                }
            }
        }


        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            // Validar el campo 'titulo'
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, ingrese un título.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar el campo 'descripcion'
            if (string.IsNullOrWhiteSpace(txtDescri.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener la hora actual
            TimeSpan horaActual = DateTime.Now.TimeOfDay;

            // Obtener la hora ingresada en el control 'time'
            TimeSpan horaIngresada = time.Value.TimeOfDay;

            // Validar que la hora ingresada no sea anterior a la hora actual
            if (horaIngresada < horaActual)
            {
                MessageBox.Show("La hora ingresada no puede ser anterior a la hora actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Recordatorio recordatorio = new Recordatorio();

            recordatorio.titulo = txtTitulo.Text;
            recordatorio.fecha = date.Value.Date.ToString("yyyy-MM-dd");
            recordatorio.hora = horaIngresada.ToString("hh\\:mm\\:ss");

            // Validar y establecer la prioridad
            if (cmbPrioridad.Items.Count > 0)
            {
                recordatorio.prioridad = cmbPrioridad.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("No hay prioridades disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            recordatorio.descripcion = txtDescri.Text;

            // Aquí se llama a la función Insertar de la lista
            list.Insertar(recordatorio, idUsu.Text);
            list.Mostrar(dgvRecordatorios, idUsu.Text);
            MessageBox.Show("¡Recordatorio agregado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (string.IsNullOrWhiteSpace(CorreoUsu.Text))
            {
                MessageBox.Show("No se pudo obtener el correo del usuario destinatario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            /*PRUEBA*/
            Conexion.EnviarCorreo("qukrhapiaxidtdfj", CorreoUsu.Text, "Nuevo Recordatorio", $"Se ha agregado un nuevo recordatorio:\n\nTítulo: {recordatorio.titulo}\nFecha: {recordatorio.fecha}\nHora: {recordatorio.hora}\nDescripción: {recordatorio.descripcion}");




            Limpiar();
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si el campo txtEliminar está vacío
            if (string.IsNullOrWhiteSpace(txtEliminar.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de registro a eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si el campo está vacío
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas realizar esta acción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Eliminar el registro solo si el campo txtEliminar no está vacío
                list.Eliminar(int.Parse(txtEliminar.Text));
                list.Mostrar(dgvRecordatorios, idUsu.Text);
            }

            txtEliminar.Clear();
        }


        private void Modal_Load(object sender, EventArgs e)
        {
            idUsu.Text = Usuario;

            string correoUsuario = Conexion.CorreoUsu(idUsu.Text);
            CorreoUsu.Text = correoUsuario;

            list.Mostrar(dgvRecordatorios, idUsu.Text);


        }

        private void cmbPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            // Guardar el ítem seleccionado antes de limpiar el ComboBox
            string itemSeleccionado = cmbPrioridad.SelectedItem != null ? cmbPrioridad.SelectedItem.ToString() : null;

            // Limpiar los ítems actuales del ComboBox
            cmbPrioridad.Items.Clear();

            // Obtener las prioridades disponibles desde la base de datos
            Dictionary<int, string> prioridades = Conexion.ObtenerPrioridades();

            // Agregar las prioridades como ítems al ComboBox
            foreach (KeyValuePair<int, string> prioridad in prioridades)
            {
                // Concatenar el ID y la prioridad con el formato deseado
                string item = $"{prioridad.Key} - {prioridad.Value}";

                // Agregar el ítem al ComboBox
                cmbPrioridad.Items.Add(item);
            }

            // Restablecer el ítem seleccionado si estaba seleccionado antes de limpiar
            if (itemSeleccionado != null && cmbPrioridad.Items.Contains(itemSeleccionado))
            {
                cmbPrioridad.SelectedItem = itemSeleccionado;
            }*/
        }

        //Cargar prioridades en el combobox
        private void CargarPrioridades()
        {
            Dictionary<int, string> prioridades = Conexion.ObtenerPrioridades();
            cmbPrioridad.Items.Clear();

            // Agregar las prioridades como ítems al ComboBox
            foreach (KeyValuePair<int, string> prioridad in prioridades)
            {
                // Concatenar el ID y la prioridad con el formato deseado
                string item = $"{prioridad.Key} - {prioridad.Value}";

                // Agregar el ítem al ComboBox
                cmbPrioridad.Items.Add(item);
            }

            // Establecer el índice seleccionado si hay elementos en el ComboBox
            if (cmbPrioridad.Items.Count > 0)
            {
                cmbPrioridad.SelectedIndex = 0; // Establece el primer elemento como seleccionado
            }
        }





    }
}
