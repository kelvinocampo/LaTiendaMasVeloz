using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Principal
{
    public partial class FacturasRead : Form
    {
        public FacturasRead()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            dataGridView1.ReadOnly = true;
            FacturaController facturaController = new FacturaController();

            if (string.IsNullOrWhiteSpace(IDTB.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ID;
            if (!int.TryParse(IDTB.Text, out ID))
            {
                MessageBox.Show("El ID debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string type = typeTB.Text.Trim();
            if (string.IsNullOrWhiteSpace(type) || (type != "Entrada" && type != "Salida"))
            {
                MessageBox.Show("Por favor, ingrese un tipo válido ('Entrada' o 'Salida').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dataFactura = facturaController.Get(ID, type);
            if (dataFactura == null)
            {
                MessageBox.Show("la factura con esta ID no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            labelEntity.Text = dataFactura.type == "Entrada" ? "Proveedor:" : "Cliente:";
            worker.Text = Convert.ToString(dataFactura.worker);
            typeEntity.Text = Convert.ToString(dataFactura.entity);
            dataGridView1.DataSource = facturaController.GetAll(ID, type);
            dtBill.Text = Convert.ToString(dataFactura.creationDate);
        }

        private void LinkDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void search_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FacturasCreate facturasCreate = new FacturasCreate();
            facturasCreate.Show();
            this.Hide();
        }
    }
}
