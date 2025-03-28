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
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
            AgregarBotones();
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(ButtonsActions);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.ReadOnly = true;
            }
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

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.ReadOnly = true;
            }
            dataGridView1.Columns["ID"].ReadOnly = true;

        }

        private void AgregarBotones()
        {
            // Botón Editar
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Editar";
            btnEdit.Text = "Editar";
            btnEdit.Name = "Editar";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.DefaultCellStyle.BackColor = Color.RoyalBlue; // Color de fondo
            btnEdit.DefaultCellStyle.ForeColor = Color.White; // Color del texto
            btnEdit.DefaultCellStyle.SelectionBackColor = Color.DarkBlue; // Color de fondo al seleccionar
            btnEdit.DefaultCellStyle.SelectionForeColor = Color.White; // Color del texto al seleccionar
            dataGridView1.Columns.Add(btnEdit);

            // Botón Eliminar
            DataGridViewButtonColumn btnSave = new DataGridViewButtonColumn();
            btnSave.HeaderText = "Guardar";
            btnSave.Text = "Guardar";
            btnSave.Name = "Guardar";
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.UseColumnTextForButtonValue = true;
            btnSave.DefaultCellStyle.BackColor = Color.Green; // Color de fondo
            btnSave.DefaultCellStyle.ForeColor = Color.White; // Color del texto
            btnSave.DefaultCellStyle.SelectionBackColor = Color.GreenYellow; // Color de fondo al seleccionar
            btnSave.DefaultCellStyle.SelectionForeColor = Color.White; // Color del texto al seleccionar
            dataGridView1.Columns.Add(btnSave);

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

        private void ButtonsActions(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
            {
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                ClienteController clienteController = new ClienteController();
                clienteController.Delete(ID);

                CargarDatos();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.ReadOnly = true;
                }
                dataGridView1.Rows[e.RowIndex].ReadOnly = false;
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Guardar"].Index)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.ReadOnly = true;
                }

                ClienteController clienteController = new ClienteController();
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                int Doc = (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Documento"].Value));
                string email = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Correo"].Value);
                string phone = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Telefono"].Value);
                string name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value);
                string address = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Direccion"].Value);
                clienteController.Update(ID, Doc, email, phone, name, address);

                CargarDatos();
            }
        }

        private void AllowAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = !(dataGridView1.AllowUserToAddRows);
        }
    }
}