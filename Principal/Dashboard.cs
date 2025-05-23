﻿using System;
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
    public partial class Dashboard : Form
    {
        public string entity = "Productos";
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CargarDatos();
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
                Title.Text = entity;
                dataGridView1.DataSource = null;
                if (entity == "Usuarios")
                {
                    AllowAdd.Text = "Crear usuario";
                    LinkUsuario.ForeColor = Color.RoyalBlue;
                    LinkProductos.ForeColor = Color.FromArgb(64, 64, 64);

                    UsuarioController usuarioController = new UsuarioController();
                    DataTable usuarios = usuarioController.GetAll();
                    dataGridView1.DataSource = usuarios;
                    dataGridView1.Columns.Remove("Rol");
                    DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn
                    {
                        Name = "Rol",
                        HeaderText = "Rol",
                        DataPropertyName = "Rol"
                    };
                    cmb.DefaultCellStyle.BackColor = Color.LightBlue; // Color de fondo
                    cmb.DefaultCellStyle.ForeColor = Color.Black; // Color de texto
                    cmb.DefaultCellStyle.SelectionBackColor = Color.DarkBlue; // Color de fondo al seleccionar
                    cmb.DefaultCellStyle.SelectionForeColor = Color.White; // Color de texto al seleccionar
                    cmb.Items.Add("Trabajador");
                    cmb.Items.Add("Admin");
                    cmb.Items.Add("Cliente");
                    cmb.Items.Add("Proveedor");
                    dataGridView1.Columns.Add(cmb);
                }
                else if (entity == "Productos")
                {
                    AllowAdd.Text = "Crear producto";
                    LinkProductos.ForeColor = Color.RoyalBlue;
                    LinkUsuario.ForeColor = Color.FromArgb(64, 64, 64);
                    ProductoController productoController = new ProductoController();
                    DataTable productos = productoController.GetAll();
                    dataGridView1.DataSource = productos;
                }

                AgregarBotones();
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

                if (entity == "Usuarios")
                {
                    UsuarioController usuarioController = new UsuarioController();
                    usuarioController.Delete(ID);
                }
                else if (entity == "Productos")
                {
                    ProductoController productoController = new ProductoController();
                    productoController.Delete(ID);
                }

                RemoveButtonsAction();
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

                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                if (entity == "Usuarios")
                {
                    UsuarioController usuarioController = new UsuarioController();
                    int Doc = (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Documento"].Value));
                    string email = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Correo"].Value);
                    string phone = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Telefono"].Value);
                    string name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value);
                    string address = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Direccion"].Value);
                    string role = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Rol"].Value);
                    usuarioController.Update(ID, Doc, email, phone, name, address, role);
                }
                else if (entity == "Productos")
                {
                    ProductoController productoController = new ProductoController();
                    string name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value);
                    int price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value);
                    DateTime creationDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Fecha_Creacion"].Value);
                    int stock = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value);
                    productoController.Update(ID, name, price, stock, creationDate);
                }

                RemoveButtonsAction();
                CargarDatos();
            }
        }

        private void AllowAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = !(dataGridView1.AllowUserToAddRows);
        }

        private void LinkUsuario_Click(object sender, EventArgs e)
        {
            entity = "Usuarios";
            RemoveButtonsAction();
            CargarDatos();
        }

        private void LinkProductos_Click(object sender, EventArgs e)
        {
            entity = "Productos";
            RemoveButtonsAction();
            CargarDatos();
        }

        private void RemoveButtonsAction()
        {
            dataGridView1.Columns.Remove("Editar");
            dataGridView1.Columns.Remove("Eliminar");
            dataGridView1.Columns.Remove("Guardar");
        }

        private void LinkFacturas_Click(object sender, EventArgs e)
        {
            FacturasRead facturas = new FacturasRead();
            facturas.Show();
            this.Hide();
        }
    }
}