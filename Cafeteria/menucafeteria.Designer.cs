namespace Cafeteria
{
    partial class menucafeteria
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panelmenu = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panelmenu
            // 
            this.Panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Panelmenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panelmenu.Location = new System.Drawing.Point(173, 51);
            this.Panelmenu.Name = "Panelmenu";
            this.Panelmenu.Size = new System.Drawing.Size(824, 465);
            this.Panelmenu.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Teal;
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.button7);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.btnProductos);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(173, 465);
            this.panel4.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 41);
            this.button2.TabIndex = 0;
            this.button2.Text = "Orden Venta";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 357);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(162, 41);
            this.button6.TabIndex = 0;
            this.button6.Text = "Proveedores";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(78, 299);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "Nota ingreso";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Inventario";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 241);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(162, 41);
            this.button5.TabIndex = 0;
            this.button5.Text = "Inventario";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 194);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 41);
            this.button4.TabIndex = 0;
            this.button4.Text = "Producción";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 147);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 41);
            this.button3.TabIndex = 0;
            this.button3.Text = "Cliente";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(8, 53);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(162, 41);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 51);
            this.panel1.TabIndex = 3;
            // 
            // menucafeteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 516);
            this.Controls.Add(this.Panelmenu);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "menucafeteria";
            this.Text = "Form1";
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panelmenu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel panel1;
    }
}

