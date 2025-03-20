using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Principal
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();

            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(EliminarDatos);
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
            AgregarBotones();
        }

        private void CargarDatos()
        {
            try
            {
                ClienteController clienteController = new ClienteController();
                dataGridView1.DataSource = clienteController.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void AgregarBotones()
        {
            // Botón Editar
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Editar";
            btnEdit.Text = "Editar";
            btnEdit.Name = "Editar";
            btnEdit.FlatStyle=FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.DefaultCellStyle.BackColor = Color.RoyalBlue; // Color de fondo
            btnEdit.DefaultCellStyle.ForeColor = Color.White; // Color del texto
            btnEdit.DefaultCellStyle.SelectionBackColor = Color.DarkBlue; // Color de fondo al seleccionar
            btnEdit.DefaultCellStyle.SelectionForeColor = Color.White; // Color del texto al seleccionar
            dataGridView1.Columns.Add(btnEdit);

            // Botón Eliminar
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Eliminar";
            btnDelete.Text = "Eliminar";
            btnDelete.Name = "Eliminar";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.DefaultCellStyle.BackColor = Color.Red; // Color de fondo
            btnDelete.DefaultCellStyle.ForeColor = Color.White; // Color del texto
            btnDelete.DefaultCellStyle.SelectionBackColor = Color.Red; // Color de fondo al seleccionar
            btnDelete.DefaultCellStyle.SelectionForeColor = Color.White; // Color del texto al seleccionar
            dataGridView1.Columns.Add(btnDelete);
        }

        private void EliminarDatos(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                int Doc = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Documento"].Value);
                ClienteController clienteController = new ClienteController();
                clienteController.Delete(Doc);
                CargarDatos();
            }
        }
    }
}
