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
            this.btnCloseModal = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.time = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtDescri = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCloseModal
            // 
            this.btnCloseModal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCloseModal.Location = new System.Drawing.Point(213, 279);
            this.btnCloseModal.Name = "btnCloseModal";
            this.btnCloseModal.Size = new System.Drawing.Size(75, 23);
            this.btnCloseModal.TabIndex = 0;
            this.btnCloseModal.Text = "Cancelar";
            this.btnCloseModal.UseVisualStyleBackColor = true;
            this.btnCloseModal.Click += new System.EventHandler(this.btnCloseModal_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnIngresar.Location = new System.Drawing.Point(307, 279);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 1;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.ForeColor = System.Drawing.Color.DimGray;
            this.txtTitulo.Location = new System.Drawing.Point(46, 48);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(145, 19);
            this.txtTitulo.TabIndex = 2;
            this.txtTitulo.TabStop = false;
            this.txtTitulo.Text = "TITULO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(43, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "________________________";
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.BackColor = System.Drawing.SystemColors.ControlText;
            this.cmbPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrioridad.ForeColor = System.Drawing.SystemColors.Menu;
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.cmbPrioridad.Location = new System.Drawing.Point(307, 63);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(145, 21);
            this.cmbPrioridad.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(307, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 19);
            this.textBox1.TabIndex = 5;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "PRIORIDAD";
            // 
            // date
            // 
            this.date.CalendarMonthBackground = System.Drawing.SystemColors.MenuText;
            this.date.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonFace;
            this.date.CalendarTrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.date.Location = new System.Drawing.Point(46, 148);
            this.date.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(2024, 3, 19, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(208, 20);
            this.date.TabIndex = 6;
            // 
            // time
            // 
            this.time.CalendarMonthBackground = System.Drawing.SystemColors.MenuText;
            this.time.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonFace;
            this.time.CalendarTrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time.Location = new System.Drawing.Point(46, 174);
            this.time.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.time.MinDate = new System.DateTime(2024, 3, 19, 0, 0, 0, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(130, 20);
            this.time.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.DimGray;
            this.textBox2.Location = new System.Drawing.Point(46, 123);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(145, 19);
            this.textBox2.TabIndex = 8;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "FECHA Y HORA";
            // 
            // txtDescri
            // 
            this.txtDescri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtDescri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescri.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescri.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescri.Location = new System.Drawing.Point(307, 147);
            this.txtDescri.Multiline = true;
            this.txtDescri.Name = "txtDescri";
            this.txtDescri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescri.Size = new System.Drawing.Size(245, 80);
            this.txtDescri.TabIndex = 9;
            this.txtDescri.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.DimGray;
            this.textBox4.Location = new System.Drawing.Point(307, 122);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(145, 19);
            this.textBox4.TabIndex = 10;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "DESCRIPCIÓN";
            // 
            // Modal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(612, 355);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.txtDescri);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.time);
            this.Controls.Add(this.date);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmbPrioridad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnCloseModal);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Modal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseModal;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtDescri;
        private System.Windows.Forms.TextBox textBox4;
    }
}