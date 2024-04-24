namespace Ped_Catedra
{
    partial class Modal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.time = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescri = new System.Windows.Forms.TextBox();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.dgvRecordatorios = new System.Windows.Forms.DataGridView();
            this.txtEliminar = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.idUsu = new System.Windows.Forms.Label();
            this.CorreoUsu = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordatorios)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.BackColor = System.Drawing.Color.White;
            this.txtTitulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.ForeColor = System.Drawing.Color.Black;
            this.txtTitulo.Location = new System.Drawing.Point(175, 134);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(246, 26);
            this.txtTitulo.TabIndex = 2;
            this.txtTitulo.TabStop = false;
            // 
            // date
            // 
            this.date.CalendarMonthBackground = System.Drawing.SystemColors.MenuText;
            this.date.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonFace;
            this.date.CalendarTrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.date.Location = new System.Drawing.Point(175, 218);
            this.date.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(2024, 3, 19, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(246, 20);
            this.date.TabIndex = 6;
            // 
            // time
            // 
            this.time.CalendarMonthBackground = System.Drawing.SystemColors.MenuText;
            this.time.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonFace;
            this.time.CalendarTrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time.Location = new System.Drawing.Point(175, 244);
            this.time.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.time.MinDate = new System.DateTime(2024, 3, 19, 0, 0, 0, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(246, 20);
            this.time.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(175, 184);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(145, 19);
            this.textBox2.TabIndex = 8;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "FECHA Y HORA";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 64);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(643, -17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(220, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(417, 65);
            this.label4.TabIndex = 20;
            this.label4.Text = "RECORDATORIOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(483, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "DESCRIPCIÓN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(483, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "PRIORIDAD";
            // 
            // txtDescri
            // 
            this.txtDescri.BackColor = System.Drawing.Color.White;
            this.txtDescri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescri.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescri.ForeColor = System.Drawing.Color.Black;
            this.txtDescri.Location = new System.Drawing.Point(487, 204);
            this.txtDescri.Multiline = true;
            this.txtDescri.Name = "txtDescri";
            this.txtDescri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescri.Size = new System.Drawing.Size(283, 80);
            this.txtDescri.TabIndex = 16;
            this.txtDescri.TabStop = false;
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.BackColor = System.Drawing.SystemColors.Control;
            this.cmbPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPrioridad.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Location = new System.Drawing.Point(487, 136);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(283, 21);
            this.cmbPrioridad.TabIndex = 15;
            this.cmbPrioridad.SelectedIndexChanged += new System.EventHandler(this.cmbPrioridad_SelectedIndexChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(164)))));
            this.btnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(164)))));
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(487, 320);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(283, 31);
            this.btnIngresar.TabIndex = 19;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click_1);
            // 
            // dgvRecordatorios
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvRecordatorios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecordatorios.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecordatorios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecordatorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecordatorios.GridColor = System.Drawing.Color.Black;
            this.dgvRecordatorios.Location = new System.Drawing.Point(23, 366);
            this.dgvRecordatorios.Name = "dgvRecordatorios";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvRecordatorios.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecordatorios.Size = new System.Drawing.Size(881, 186);
            this.dgvRecordatorios.TabIndex = 21;
            this.dgvRecordatorios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecordatorios_CellClick);
            // 
            // txtEliminar
            // 
            this.txtEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.txtEliminar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEliminar.Enabled = false;
            this.txtEliminar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEliminar.ForeColor = System.Drawing.Color.White;
            this.txtEliminar.Location = new System.Drawing.Point(175, 270);
            this.txtEliminar.Name = "txtEliminar";
            this.txtEliminar.Size = new System.Drawing.Size(137, 19);
            this.txtEliminar.TabIndex = 22;
            this.txtEliminar.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkRed;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.LightGray;
            this.btnEliminar.Location = new System.Drawing.Point(175, 318);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(246, 31);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(175, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 19);
            this.textBox1.TabIndex = 24;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "TITULO";
            // 
            // idUsu
            // 
            this.idUsu.AutoSize = true;
            this.idUsu.ForeColor = System.Drawing.SystemColors.Control;
            this.idUsu.Location = new System.Drawing.Point(172, 292);
            this.idUsu.Name = "idUsu";
            this.idUsu.Size = new System.Drawing.Size(35, 13);
            this.idUsu.TabIndex = 25;
            this.idUsu.Text = "label1";
            // 
            // CorreoUsu
            // 
            this.CorreoUsu.AutoSize = true;
            this.CorreoUsu.ForeColor = System.Drawing.SystemColors.Control;
            this.CorreoUsu.Location = new System.Drawing.Point(213, 292);
            this.CorreoUsu.Name = "CorreoUsu";
            this.CorreoUsu.Size = new System.Drawing.Size(35, 13);
            this.CorreoUsu.TabIndex = 26;
            this.CorreoUsu.Text = "label1";
            // 
            // Modal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 588);
            this.Controls.Add(this.CorreoUsu);
            this.Controls.Add(this.idUsu);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtEliminar);
            this.Controls.Add(this.dgvRecordatorios);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.time);
            this.Controls.Add(this.txtDescri);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.date);
            this.Controls.Add(this.txtTitulo);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "Modal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modal";
            this.Load += new System.EventHandler(this.Modal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordatorios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescri;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvRecordatorios;
        private System.Windows.Forms.TextBox txtEliminar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label idUsu;
        private System.Windows.Forms.Label CorreoUsu;
    }
}