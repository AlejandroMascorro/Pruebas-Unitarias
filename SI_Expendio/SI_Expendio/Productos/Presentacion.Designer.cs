namespace SI_Expendio
{
    partial class Presentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Presentacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancel_cat = new System.Windows.Forms.PictureBox();
            this.btn_guard_cat = new System.Windows.Forms.PictureBox();
            this.nombre_pres_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel_cat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_guard_cat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Location = new System.Drawing.Point(-1, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 28);
            this.panel1.TabIndex = 8;
            // 
            // btn_cancel_cat
            // 
            this.btn_cancel_cat.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel_cat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_cancel_cat.BackgroundImage")));
            this.btn_cancel_cat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel_cat.Location = new System.Drawing.Point(302, 86);
            this.btn_cancel_cat.Name = "btn_cancel_cat";
            this.btn_cancel_cat.Size = new System.Drawing.Size(95, 76);
            this.btn_cancel_cat.TabIndex = 7;
            this.btn_cancel_cat.TabStop = false;
            this.btn_cancel_cat.Click += new System.EventHandler(this.btn_cancel_cat_Click);
            // 
            // btn_guard_cat
            // 
            this.btn_guard_cat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_guard_cat.BackgroundImage")));
            this.btn_guard_cat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_guard_cat.Location = new System.Drawing.Point(154, 86);
            this.btn_guard_cat.Name = "btn_guard_cat";
            this.btn_guard_cat.Size = new System.Drawing.Size(95, 76);
            this.btn_guard_cat.TabIndex = 4;
            this.btn_guard_cat.TabStop = false;
            this.btn_guard_cat.Click += new System.EventHandler(this.btn_guard_cat_Click);
            // 
            // nombre_pres_txt
            // 
            this.nombre_pres_txt.Font = new System.Drawing.Font("Arial Narrow", 18F);
            this.nombre_pres_txt.Location = new System.Drawing.Point(154, 32);
            this.nombre_pres_txt.Name = "nombre_pres_txt";
            this.nombre_pres_txt.Size = new System.Drawing.Size(252, 35);
            this.nombre_pres_txt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo de\r\npresentacion";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Presentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(431, 196);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cancel_cat);
            this.Controls.Add(this.btn_guard_cat);
            this.Controls.Add(this.nombre_pres_txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Presentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presentacion";
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel_cat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_guard_cat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btn_cancel_cat;
        private System.Windows.Forms.PictureBox btn_guard_cat;
        private System.Windows.Forms.TextBox nombre_pres_txt;
        private System.Windows.Forms.Label label1;
    }
}