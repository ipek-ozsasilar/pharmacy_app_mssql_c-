namespace eczane_veritabani_uygulamasi
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ilacidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ilacadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucretDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sonkullanmatarihiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kullanilmasikligiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ilacBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.pharmacyappDataSet8BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pharmacy_appDataSet8 = new eczane_veritabani_uygulamasi.pharmacy_appDataSet8();
            this.ilacBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pharmacyappDataSet8BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ilacTableAdapter = new eczane_veritabani_uygulamasi.pharmacy_appDataSet8TableAdapters.ilacTableAdapter();
            this.ilacBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pharmacy_appDataSet11 = new eczane_veritabani_uygulamasi.pharmacy_appDataSet11();
            this.ilacBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.ilacTableAdapter1 = new eczane_veritabani_uygulamasi.pharmacy_appDataSet11TableAdapters.ilacTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilacBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyappDataSet8BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacy_appDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilacBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyappDataSet8BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilacBindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacy_appDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilacBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hoşgeldiniz";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ilacidDataGridViewTextBoxColumn,
            this.ilacadDataGridViewTextBoxColumn,
            this.ucretDataGridViewTextBoxColumn,
            this.sonkullanmatarihiDataGridViewTextBoxColumn,
            this.kullanilmasikligiDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ilacBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(3, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(633, 485);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // ilacidDataGridViewTextBoxColumn
            // 
            this.ilacidDataGridViewTextBoxColumn.DataPropertyName = "ilac_id";
            this.ilacidDataGridViewTextBoxColumn.HeaderText = "ilac_id";
            this.ilacidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ilacidDataGridViewTextBoxColumn.Name = "ilacidDataGridViewTextBoxColumn";
            this.ilacidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ilacidDataGridViewTextBoxColumn.Width = 80;
            // 
            // ilacadDataGridViewTextBoxColumn
            // 
            this.ilacadDataGridViewTextBoxColumn.DataPropertyName = "ilac_ad";
            this.ilacadDataGridViewTextBoxColumn.HeaderText = "ilac_ad";
            this.ilacadDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ilacadDataGridViewTextBoxColumn.Name = "ilacadDataGridViewTextBoxColumn";
            this.ilacadDataGridViewTextBoxColumn.Width = 125;
            // 
            // ucretDataGridViewTextBoxColumn
            // 
            this.ucretDataGridViewTextBoxColumn.DataPropertyName = "ucret";
            this.ucretDataGridViewTextBoxColumn.HeaderText = "ucret";
            this.ucretDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ucretDataGridViewTextBoxColumn.Name = "ucretDataGridViewTextBoxColumn";
            this.ucretDataGridViewTextBoxColumn.Width = 125;
            // 
            // sonkullanmatarihiDataGridViewTextBoxColumn
            // 
            this.sonkullanmatarihiDataGridViewTextBoxColumn.DataPropertyName = "son_kullanma_tarihi";
            this.sonkullanmatarihiDataGridViewTextBoxColumn.HeaderText = "son_kullanma_tarihi";
            this.sonkullanmatarihiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sonkullanmatarihiDataGridViewTextBoxColumn.Name = "sonkullanmatarihiDataGridViewTextBoxColumn";
            this.sonkullanmatarihiDataGridViewTextBoxColumn.Width = 125;
            // 
            // kullanilmasikligiDataGridViewTextBoxColumn
            // 
            this.kullanilmasikligiDataGridViewTextBoxColumn.DataPropertyName = "kullanilma_sikligi";
            this.kullanilmasikligiDataGridViewTextBoxColumn.HeaderText = "kullanilma_sikligi";
            this.kullanilmasikligiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kullanilmasikligiDataGridViewTextBoxColumn.Name = "kullanilmasikligiDataGridViewTextBoxColumn";
            this.kullanilmasikligiDataGridViewTextBoxColumn.Width = 125;
            // 
            // ilacBindingSource2
            // 
            this.ilacBindingSource2.DataMember = "ilac";
            this.ilacBindingSource2.DataSource = this.pharmacyappDataSet8BindingSource1;
            // 
            // pharmacyappDataSet8BindingSource1
            // 
            this.pharmacyappDataSet8BindingSource1.DataSource = this.pharmacy_appDataSet8;
            this.pharmacyappDataSet8BindingSource1.Position = 0;
            // 
            // pharmacy_appDataSet8
            // 
            this.pharmacy_appDataSet8.DataSetName = "pharmacy_appDataSet8";
            this.pharmacy_appDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ilacBindingSource
            // 
            this.ilacBindingSource.DataMember = "ilac";
            this.ilacBindingSource.DataSource = this.pharmacy_appDataSet8;
            // 
            // pharmacyappDataSet8BindingSource
            // 
            this.pharmacyappDataSet8BindingSource.DataSource = this.pharmacy_appDataSet8;
            this.pharmacyappDataSet8BindingSource.Position = 0;
            // 
            // ilacTableAdapter
            // 
            this.ilacTableAdapter.ClearBeforeFill = true;
            // 
            // ilacBindingSource1
            // 
            this.ilacBindingSource1.DataMember = "ilac";
            this.ilacBindingSource1.DataSource = this.pharmacyappDataSet8BindingSource;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(808, 245);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(208, 82);
            this.richTextBox1.TabIndex = 24;
            this.richTextBox1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(916, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 36);
            this.button3.TabIndex = 25;
            this.button3.Text = "Sepete Ekle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "parol";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(857, 333);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 44);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(830, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 36);
            this.button1.TabIndex = 26;
            this.button1.Text = "Sepete Git";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(860, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 24);
            this.button2.TabIndex = 32;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(830, 403);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 24);
            this.button4.TabIndex = 31;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(890, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(808, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pharmacy_appDataSet11
            // 
            this.pharmacy_appDataSet11.DataSetName = "pharmacy_appDataSet11";
            this.pharmacy_appDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ilacBindingSource3
            // 
            this.ilacBindingSource3.DataMember = "ilac";
            this.ilacBindingSource3.DataSource = this.pharmacy_appDataSet11;
            // 
            // ilacTableAdapter1
            // 
            this.ilacTableAdapter1.ClearBeforeFill = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 589);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilacBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyappDataSet8BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacy_appDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilacBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyappDataSet8BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilacBindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacy_appDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilacBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource pharmacyappDataSet8BindingSource;
        private pharmacy_appDataSet8 pharmacy_appDataSet8;
        private System.Windows.Forms.BindingSource pharmacyappDataSet8BindingSource1;
        private System.Windows.Forms.BindingSource ilacBindingSource;
        private pharmacy_appDataSet8TableAdapters.ilacTableAdapter ilacTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource ilacBindingSource2;
        private System.Windows.Forms.BindingSource ilacBindingSource1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ilacidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ilacadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ucretDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sonkullanmatarihiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kullanilmasikligiDataGridViewTextBoxColumn;
        private pharmacy_appDataSet11 pharmacy_appDataSet11;
        private System.Windows.Forms.BindingSource ilacBindingSource3;
        private pharmacy_appDataSet11TableAdapters.ilacTableAdapter ilacTableAdapter1;
    }
}