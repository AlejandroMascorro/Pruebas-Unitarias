namespace SI_Expendio
{
    partial class Categoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categoria));
            this.label1 = new System.Windows.Forms.Label();
            this.nombre_cat_txt = new System.Windows.Forms.TextBox();
            this.btn_guard_cat = new System.Windows.Forms.PictureBox();
            this.btn_cancel_cat = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.btn_guard_cat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel_cat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la\r\nCategoria\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombre_cat_txt
            // 
            this.nombre_cat_txt.Font = new System.Drawing.Font("Arial Narrow", 18F);
            this.nombre_cat_txt.Location = new System.Drawing.Point(148, 32);
            this.nombre_cat_txt.Name = "nombre_cat_txt";
            this.nombre_cat_txt.Size = new System.Drawing.Size(252, 35);
            this.nombre_cat_txt.TabIndex = 1;
            // 
            // btn_guard_cat
            // 
            this.btn_guard_cat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_guard_cat.BackgroundImage")));
            this.btn_guard_cat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_guard_cat.Location = new System.Drawing.Point(148, 86);
            this.btn_guard_cat.Name = "btn_guard_cat";
            this.btn_guard_cat.Size = new System.Drawing.Size(95, 76);
            this.btn_guard_cat.TabIndex = 0;
            this.btn_guard_cat.TabStop = false;
            this.btn_guard_cat.Click += new System.EventHandler(this.btn_guard_cat_Click);
            // 
            // btn_cancel_cat
            // 
            this.btn_cancel_cat.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel_cat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_cancel_cat.BackgroundImage")));
            this.btn_cancel_cat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel_cat.Location = new System.Drawing.Point(296, 86);
            this.btn_cancel_cat.Name = "btn_cancel_cat";
            this.btn_cancel_cat.Size = new System.Drawing.Size(95, 76);
            this.btn_cancel_cat.TabIndex = 2;
            this.btn_cancel_cat.TabStop = false;
            this.btn_cancel_cat.Click += new System.EventHandler(this.btn_cancel_cat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Location = new System.Drawing.Point(-3, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 28);
            this.panel1.TabIndex = 3;
            // 
            // Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(431, 196);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cancel_cat);
            this.Controls.Add(this.btn_guard_cat);
            this.Controls.Add(this.nombre_cat_txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Categoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categoria";
            ((System.ComponentModel.ISupportInitialize)(this.btn_guard_cat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel_cat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombre_cat_txt;
        private System.Windows.Forms.PictureBox btn_guard_cat;
        private System.Windows.Forms.PictureBox btn_cancel_cat;
        private System.Windows.Forms.Panel panel1;
    }
}