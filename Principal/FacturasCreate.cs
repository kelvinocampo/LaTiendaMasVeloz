using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Logica;

namespace Principal
{
    public partial class FacturasCreate : Form
    {
        public FacturasCreate()
        {
            InitializeComponent();
        }

        private void AgregarBotones()
        {
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                Name = "Eliminar",
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = true,
                DefaultCellStyle = { BackColor = Color.Red, ForeColor = Color.White, SelectionBackColor = Color.Red, SelectionForeColor = Color.White }
            };
            dataGridView1.Columns.Add(btnDelete);
        }

        private void RemoveButtonsAction()
        {
            dataGridView1.Columns.Remove("Eliminar");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FacturasRead facturasRead = new FacturasRead();
            facturasRead.Show();
            this.Hide();
        }

        private void ButtonsActions(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Cantidad"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= TextBox_KeyPress;
                    tb.KeyPress += TextBox_KeyPress;
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FacturasCreate_Load(object sender, EventArgs e)
        {
            ProductoController controller = new ProductoController();
            var dt = controller.GetAll();

            if (!dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Add("ID", "ID");
            }
            dataGridView1.Columns["ID"].ReadOnly = true;

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn
            {
                Name = "Producto",
                HeaderText = "Producto",
                DataPropertyName = "Producto",
                DefaultCellStyle = { BackColor = Color.LightBlue, ForeColor = Color.Black, SelectionBackColor = Color.DarkBlue, SelectionForeColor = Color.White }
            };

            foreach (DataRow row in dt.Rows)
            {
                cmb.Items.Add(row["Nombre"].ToString());
            }
            dataGridView1.Columns.Add(cmb);

            DataGridViewTextBoxColumn cantidadColumn = new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad"
            };
            dataGridView1.Columns.Add(cantidadColumn);

            DataGridViewTextBoxColumn precioColumn = new DataGridViewTextBoxColumn
            {
                Name = "Precio",
                HeaderText = "Precio",
                DataPropertyName = "Precio",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(precioColumn);

            AgregarBotones();

            dataGridView1.CellDoubleClick += ButtonsActions;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["Producto"].Index) return;

            var cellValue = dataGridView1.Rows[e.RowIndex].Cells["Producto"].Value;

            if (cellValue == null)
            {
                return;
            }

            string selectedProductName = cellValue.ToString();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index != e.RowIndex && row.Cells["Producto"].Value != null && row.Cells["Producto"].Value.ToString() == selectedProductName)
                {
                    MessageBox.Show("Este producto ya ha sido agregado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.Rows[e.RowIndex].Cells["Producto"].Value = null;
                    return;
                }
            }

            ProductoController controller = new ProductoController();
            var dt = controller.GetAll();

            foreach (DataRow row in dt.Rows)
            {
                if (row["Nombre"].ToString() == selectedProductName)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["ID"].Value = row["ID"].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value = row["Precio"].ToString();
                    break;
                }
            }
        }

        private void typeTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeTB.SelectedItem != null)
            {
                string selectedValue = typeTB.SelectedItem.ToString();
                UsuarioController usuarioController = new UsuarioController();
                var dt = usuarioController.GetAll();

                typeEntity.Items.Clear();
                worker.Items.Clear();

                DataView filteredView = new DataView(dt);

                if (selectedValue == "Entrada")
                {
                    labelEntity.Text = "Proveedor/ID:";
                    filteredView.RowFilter = "Rol = 'Proveedor'";
                }
                else if (selectedValue == "Salida")
                {
                    labelEntity.Text = "Cliente/ID:";
                    filteredView.RowFilter = "Rol = 'Cliente'";
                }

                DataView workerView = new DataView(dt);
                workerView.RowFilter = "Rol = 'Trabajador'";

                foreach (DataRowView row in filteredView)
                {
                    string displayText = $"{row["Nombre"]} - {row["ID"]}";
                    typeEntity.Items.Add(displayText);
                }

                foreach (DataRowView workerRow in workerView)
                {
                    string displayText = $"{workerRow["Nombre"]} - {workerRow["ID"]}";
                    worker.Items.Add(displayText);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                FacturaController controller = new FacturaController();

                if (dataGridView1.Rows.Count == 0 || (dataGridView1.Rows.Count == 1 && dataGridView1.Rows[0].IsNewRow))
                {
                    MessageBox.Show("No hay productos para crear la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (string.IsNullOrWhiteSpace(row.Cells["Cantidad"].Value?.ToString()))
                    {
                        MessageBox.Show("Por favor, ingrese la cantidad para todos los productos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (string.IsNullOrWhiteSpace(typeTB.Text))
                {
                    MessageBox.Show("Por favor, seleccione un tipo de factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(worker.Text) || !int.TryParse(worker.Text.Split('-')[1].Trim(), out int workerID))
                {
                    MessageBox.Show("Por favor, seleccione un trabajador válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(typeEntity.Text) || !int.TryParse(typeEntity.Text.Split('-')[1].Trim(), out int entityID))
                {
                    MessageBox.Show("Por favor, seleccione los datos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime currentDateTime = DateTime.Now;

                int billID = controller.Create(workerID, currentDateTime, entityID, typeTB.Text);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (int.TryParse(row.Cells["ID"].Value.ToString(), out int productID) &&
                        int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int quantity) &&
                        int.TryParse(row.Cells["Precio"].Value.ToString(), out int price))
                    {
                        controller.CreateDetail(billID, price, productID, quantity, typeTB.Text);
                    }
                    else
                    {
                        MessageBox.Show("Datos de producto no válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Factura creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error en el formato de los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al crear la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}