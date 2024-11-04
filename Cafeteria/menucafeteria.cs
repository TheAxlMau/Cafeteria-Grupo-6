using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafeteria
{
    public partial class menucafeteria : Form
    {
        public menucafeteria()
        {
            InitializeComponent();
        }

        private void AbrirVentanas(object formhija)
        {
            if (this.Panelmenu.Controls.Count > 0)
                this.Panelmenu.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panelmenu.Controls.Add(fh);
            this.Panelmenu.Tag = fh;
            fh.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new ProductosVenta());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new Cliente());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new Produccion());
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new NotaDeIngresoInsumo());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new Inventario());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new Ventas());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new Proveedores());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
