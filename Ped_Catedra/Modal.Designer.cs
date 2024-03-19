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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCloseModal
            // 
            this.btnCloseModal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCloseModal.Location = new System.Drawing.Point(123, 231);
            this.btnCloseModal.Name = "btnCloseModal";
            this.btnCloseModal.Size = new System.Drawing.Size(75, 23);
            this.btnCloseModal.TabIndex = 0;
            this.btnCloseModal.Text = "Cancelar";
            this.btnCloseModal.UseVisualStyleBackColor = true;
            this.btnCloseModal.Click += new System.EventHandler(this.btnCloseModal_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(215, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Modal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 277);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCloseModal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Modal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCloseModal;
        private System.Windows.Forms.Button button1;
    }
}