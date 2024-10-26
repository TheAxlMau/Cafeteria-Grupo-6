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
    }
}
