namespace Principal
{
    partial class Clientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            LinkClientes = new Label();
            LinkProveedores = new Label();
            LinkProductos = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            splitContainer2 = new SplitContainer();
            splitContainer4 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            pictureBox2 = new PictureBox();
            Title = new Label();
            FormInsert = new GroupBox();
            dataGridView1 = new DataGridView();
            jeje = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1108, 636);
            splitContainer1.SplitterDistance = 263;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.IsSplitterFixed = true;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(jeje);
            splitContainer3.Panel1.Controls.Add(LinkClientes);
            splitContainer3.Panel1.Controls.Add(LinkProveedores);
            splitContainer3.Panel1.Controls.Add(LinkProductos);
            splitContainer3.Panel1.Controls.Add(label2);
            splitContainer3.Panel1.Controls.Add(label1);
            splitContainer3.Panel1.Padding = new Padding(20);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(pictureBox1);
            splitContainer3.Size = new Size(263, 636);
            splitContainer3.SplitterDistance = 417;
            splitContainer3.TabIndex = 6;
            // 
            // LinkClientes
            // 
            LinkClientes.AutoSize = true;
            LinkClientes.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LinkClientes.ForeColor = Color.RoyalBlue;
            LinkClientes.Location = new Point(29, 137);
            LinkClientes.Name = "LinkClientes";
            LinkClientes.Size = new Size(64, 23);
            LinkClientes.TabIndex = 5;
            LinkClientes.Text = "Clientes";
            // 
            // LinkProveedores
            // 
            LinkProveedores.AutoSize = true;
            LinkProveedores.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LinkProveedores.ForeColor = Color.FromArgb(64, 64, 64);
            LinkProveedores.Location = new Point(29, 179);
            LinkProveedores.Name = "LinkProveedores";
            LinkProveedores.Size = new Size(93, 23);
            LinkProveedores.TabIndex = 3;
            LinkProveedores.Text = "Proveedores";
            // 
            // LinkProductos
            // 
            LinkProductos.AutoSize = true;
            LinkProductos.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LinkProductos.ForeColor = Color.FromArgb(64, 64, 64);
            LinkProductos.Location = new Point(29, 90);
            LinkProductos.Name = "LinkProductos";
            LinkProductos.Size = new Size(76, 23);
            LinkProductos.TabIndex = 2;
            LinkProductos.Text = "Productos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans Ultra Bold", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.OrangeRed;
            label2.Location = new Point(165, 20);
            label2.Name = "label2";
            label2.Size = new Size(75, 26);
            label2.TabIndex = 1;
            label2.Text = "Veloz";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans Ultra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(145, 23);
            label1.TabIndex = 0;
            label1.Text = "La Tienda Mas";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(263, 215);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer4);
            splitContainer2.Panel1.Padding = new Padding(20);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dataGridView1);
            splitContainer2.Panel2.Padding = new Padding(20);
            splitContainer2.Size = new Size(841, 636);
            splitContainer2.SplitterDistance = 375;
            splitContainer2.TabIndex = 8;
            // 
            // splitContainer4
            // 
            splitContainer4.Dock = DockStyle.Fill;
            splitContainer4.Location = new Point(20, 20);
            splitContainer4.Name = "splitContainer4";
            splitContainer4.Orientation = Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            splitContainer4.Panel1.Controls.Add(splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(FormInsert);
            splitContainer4.Size = new Size(801, 335);
            splitContainer4.SplitterDistance = 96;
            splitContainer4.TabIndex = 6;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.IsSplitterFixed = true;
            splitContainer5.Location = new Point(0, 0);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(pictureBox2);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(Title);
            splitContainer5.Size = new Size(801, 96);
            splitContainer5.SplitterDistance = 108;
            splitContainer5.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(108, 96);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Gill Sans MT", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title.ForeColor = Color.RoyalBlue;
            Title.Location = new Point(572, 30);
            Title.Name = "Title";
            Title.Size = new Size(114, 40);
            Title.TabIndex = 6;
            Title.Text = "Clientes";
            // 
            // FormInsert
            // 
            FormInsert.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormInsert.Location = new Point(0, 3);
            FormInsert.Name = "FormInsert";
            FormInsert.Size = new Size(798, 232);
            FormInsert.TabIndex = 0;
            FormInsert.TabStop = false;
            FormInsert.Text = "Insertar Cliente";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.WhiteSmoke;
            dataGridView1.Location = new Point(20, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(801, 217);
            dataGridView1.TabIndex = 7;
            // 
            // jeje
            // 
            jeje.AutoSize = true;
            jeje.Location = new Point(83, 287);
            jeje.Name = "jeje";
            jeje.Size = new Size(38, 15);
            jeje.TabIndex = 6;
            jeje.Text = "label3";
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 636);
            Controls.Add(splitContainer1);
            Name = "Clientes";
            Text = "Clientes";
            Load += Clientes_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Label LinkProveedores;
        private Label LinkProductos;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private DataGridView dataGridView1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private GroupBox FormInsert;
        private SplitContainer splitContainer5;
        private Label LinkClientes;
        private Label Title;
        private Label jeje;
    }
}