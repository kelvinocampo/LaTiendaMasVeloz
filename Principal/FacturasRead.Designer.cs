namespace Principal
{
    partial class FacturasRead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturasRead));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            label6 = new Label();
            LinkDashboard = new Label();
            LinkFacturas = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            splitContainer2 = new SplitContainer();
            splitContainer5 = new SplitContainer();
            pictureBox2 = new PictureBox();
            Title = new Label();
            splitContainer4 = new SplitContainer();
            typeEntity = new Label();
            worker = new Label();
            label3 = new Label();
            typeTB = new ComboBox();
            search = new Button();
            label4 = new Label();
            label5 = new Label();
            labelEntity = new Label();
            IDTB = new TextBox();
            dataGridView1 = new DataGridView();
            dtBill = new Label();
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
            ((System.ComponentModel.ISupportInitialize)splitContainer5).BeginInit();
            splitContainer5.Panel1.SuspendLayout();
            splitContainer5.Panel2.SuspendLayout();
            splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer4).BeginInit();
            splitContainer4.Panel1.SuspendLayout();
            splitContainer4.Panel2.SuspendLayout();
            splitContainer4.SuspendLayout();
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
            splitContainer1.Size = new Size(1490, 636);
            splitContainer1.SplitterDistance = 264;
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
            splitContainer3.Panel1.Controls.Add(label6);
            splitContainer3.Panel1.Controls.Add(LinkDashboard);
            splitContainer3.Panel1.Controls.Add(LinkFacturas);
            splitContainer3.Panel1.Controls.Add(label2);
            splitContainer3.Panel1.Controls.Add(label1);
            splitContainer3.Panel1.Padding = new Padding(20);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(pictureBox1);
            splitContainer3.Size = new Size(264, 636);
            splitContainer3.SplitterDistance = 417;
            splitContainer3.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(64, 64, 64);
            label6.Location = new Point(23, 128);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 10;
            label6.Text = "Crear Factura";
            label6.Click += label6_Click;
            // 
            // LinkDashboard
            // 
            LinkDashboard.AutoSize = true;
            LinkDashboard.Cursor = Cursors.Hand;
            LinkDashboard.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LinkDashboard.ForeColor = Color.FromArgb(64, 64, 64);
            LinkDashboard.Location = new Point(23, 175);
            LinkDashboard.Name = "LinkDashboard";
            LinkDashboard.Size = new Size(138, 23);
            LinkDashboard.TabIndex = 9;
            LinkDashboard.Text = "Productos/Usuarios";
            LinkDashboard.Click += LinkDashboard_Click;
            // 
            // LinkFacturas
            // 
            LinkFacturas.AutoSize = true;
            LinkFacturas.Cursor = Cursors.Hand;
            LinkFacturas.Font = new Font("Gill Sans MT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LinkFacturas.ForeColor = Color.RoyalBlue;
            LinkFacturas.Location = new Point(23, 83);
            LinkFacturas.Name = "LinkFacturas";
            LinkFacturas.Size = new Size(132, 23);
            LinkFacturas.TabIndex = 8;
            LinkFacturas.Text = "Consultar Facturas";
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
            pictureBox1.Size = new Size(264, 215);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer5);
            splitContainer2.Panel1.Padding = new Padding(20);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer4);
            splitContainer2.Panel2.Padding = new Padding(20);
            splitContainer2.Size = new Size(1222, 636);
            splitContainer2.SplitterDistance = 151;
            splitContainer2.TabIndex = 0;
            // 
            // splitContainer5
            // 
            splitContainer5.Dock = DockStyle.Fill;
            splitContainer5.IsSplitterFixed = true;
            splitContainer5.Location = new Point(20, 20);
            splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            splitContainer5.Panel1.Controls.Add(pictureBox2);
            // 
            // splitContainer5.Panel2
            // 
            splitContainer5.Panel2.Controls.Add(Title);
            splitContainer5.Size = new Size(1182, 111);
            splitContainer5.SplitterDistance = 147;
            splitContainer5.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = Properties.Resources.bici;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(147, 111);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Gill Sans MT", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Title.ForeColor = Color.RoyalBlue;
            Title.Location = new Point(869, 35);
            Title.Name = "Title";
            Title.Size = new Size(115, 40);
            Title.TabIndex = 6;
            Title.Text = "Facturas";
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
            splitContainer4.Panel1.Controls.Add(dtBill);
            splitContainer4.Panel1.Controls.Add(typeEntity);
            splitContainer4.Panel1.Controls.Add(worker);
            splitContainer4.Panel1.Controls.Add(label3);
            splitContainer4.Panel1.Controls.Add(typeTB);
            splitContainer4.Panel1.Controls.Add(search);
            splitContainer4.Panel1.Controls.Add(label4);
            splitContainer4.Panel1.Controls.Add(label5);
            splitContainer4.Panel1.Controls.Add(labelEntity);
            splitContainer4.Panel1.Controls.Add(IDTB);
            splitContainer4.Panel1.Padding = new Padding(20);
            // 
            // splitContainer4.Panel2
            // 
            splitContainer4.Panel2.Controls.Add(dataGridView1);
            splitContainer4.Size = new Size(1182, 441);
            splitContainer4.SplitterDistance = 119;
            splitContainer4.TabIndex = 0;
            // 
            // typeEntity
            // 
            typeEntity.AutoSize = true;
            typeEntity.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeEntity.Location = new Point(611, 69);
            typeEntity.Name = "typeEntity";
            typeEntity.Size = new Size(105, 25);
            typeEntity.TabIndex = 14;
            typeEntity.Text = "(Consultar)";
            // 
            // worker
            // 
            worker.AutoSize = true;
            worker.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            worker.Location = new Point(611, 20);
            worker.Name = "worker";
            worker.Size = new Size(114, 25);
            worker.TabIndex = 13;
            worker.Text = "(Trabajador)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 72);
            label3.Name = "label3";
            label3.Size = new Size(145, 25);
            label3.TabIndex = 10;
            label3.Text = "Tipo de Factura:";
            // 
            // typeTB
            // 
            typeTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeTB.FormattingEnabled = true;
            typeTB.Items.AddRange(new object[] { "Entrada", "Salida" });
            typeTB.Location = new Point(174, 69);
            typeTB.Name = "typeTB";
            typeTB.Size = new Size(268, 33);
            typeTB.TabIndex = 9;
            // 
            // search
            // 
            search.BackColor = Color.RoyalBlue;
            search.Cursor = Cursors.Hand;
            search.FlatAppearance.BorderSize = 0;
            search.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            search.ForeColor = Color.White;
            search.Location = new Point(898, 58);
            search.Name = "search";
            search.Padding = new Padding(8, 10, 8, 10);
            search.Size = new Size(116, 49);
            search.TabIndex = 8;
            search.Text = "Consultar";
            search.UseVisualStyleBackColor = false;
            search.Click += search_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 20);
            label4.Name = "label4";
            label4.Size = new Size(34, 25);
            label4.TabIndex = 8;
            label4.Text = "ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(499, 20);
            label5.Name = "label5";
            label5.Size = new Size(106, 25);
            label5.TabIndex = 7;
            label5.Text = "Trabajador:";
            // 
            // labelEntity
            // 
            labelEntity.AutoSize = true;
            labelEntity.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEntity.Location = new Point(499, 69);
            labelEntity.Name = "labelEntity";
            labelEntity.Size = new Size(109, 25);
            labelEntity.TabIndex = 6;
            labelEntity.Text = "(Consultar):";
            // 
            // IDTB
            // 
            IDTB.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IDTB.Location = new Point(80, 17);
            IDTB.Name = "IDTB";
            IDTB.PlaceholderText = "ID de Factura";
            IDTB.Size = new Size(362, 33);
            IDTB.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
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
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1182, 318);
            dataGridView1.TabIndex = 7;
            // 
            // dtBill
            // 
            dtBill.AutoSize = true;
            dtBill.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtBill.Location = new Point(875, 20);
            dtBill.Name = "dtBill";
            dtBill.Size = new Size(151, 25);
            dtBill.TabIndex = 15;
            dtBill.Text = "Fecha de factura";
            // 
            // FacturasRead
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1490, 636);
            Controls.Add(splitContainer1);
            Name = "FacturasRead";
            Text = "Clientes";
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
            splitContainer5.Panel1.ResumeLayout(false);
            splitContainer5.Panel2.ResumeLayout(false);
            splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer5).EndInit();
            splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            splitContainer4.Panel1.ResumeLayout(false);
            splitContainer4.Panel1.PerformLayout();
            splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer4).EndInit();
            splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Label LinkProveedores;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private DataGridView dataGridView1;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer5;
        private Label Title;
        private SplitContainer splitContainer2;
        private Label LinkFacturas;
        private Label LinkDashboard;
        private SplitContainer splitContainer4;
        private TextBox IDTB;
        private Label labelEntity;
        private Label label5;
        private Label label4;
        private Button search;
        private Label label3;
        private ComboBox typeTB;
        private Label label6;
        private Label typeEntity;
        private Label worker;
        private Label dtBill;
    }
}