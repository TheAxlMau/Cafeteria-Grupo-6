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
            AbrirVentanas(new MantenedorProducto());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new Cliente());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            AbrirVentanas(new ProduccionProductos());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirVentanas(new Produccion());
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

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Obtener los datos del producto
            string nombreProducto = txtNombreProducto.Text;
            string descripcionProducto = txtDescripcionProducto.Text;

            // Crear un panel para representar el producto
            Panel panelProducto = new Panel();
            panelProducto.Size = new Size(150, 100); // Tamaño del cuadro de producto
            panelProducto.BackColor = Color.Gray; // Color de fondo del cuadro
            panelProducto.Margin = new Padding(10); // Espacio entre cuadros

            // Crear el Label para el nombre del producto
            Label labelNombre = new Label();
            labelNombre.Text = nombreProducto;
            labelNombre.ForeColor = Color.White;
            labelNombre.Font = new Font("Arial", 10, FontStyle.Bold);
            labelNombre.Dock = DockStyle.Top;
            labelNombre.TextAlign = ContentAlignment.MiddleCenter;

            // Crear el Label para la descripción del producto
            Label labelDescripcion = new Label();
            labelDescripcion.Text = descripcionProducto;
            labelDescripcion.ForeColor = Color.White;
            labelDescripcion.Font = new Font("Arial", 8, FontStyle.Regular);
            labelDescripcion.Dock = DockStyle.Fill;
            labelDescripcion.TextAlign = ContentAlignment.TopCenter;

            // Agregar los labels al panel de producto
            panelProducto.Controls.Add(labelDescripcion);
            panelProducto.Controls.Add(labelNombre);

            // Agregar un evento para eliminar el panel cuando se hace clic
            panelProducto.MouseClick += (s, args) =>
            {
                // Confirmar si deseas eliminar el producto
                var result = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Eliminar producto", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    flowLayoutPanelProductos.Controls.Remove(panelProducto); // Eliminar el panel
                    panelProducto.Dispose(); // Liberar los recursos asociados al panel
                }
            };

            // Agregar el panel de producto al FlowLayoutPanel
            flowLayoutPanelProductos.Controls.Add(panelProducto);

            // Limpiar los TextBox después de agregar el producto
            txtNombreProducto.Text = "";
            txtDescripcionProducto.Text = "";
        }

        private void flowLayoutPanelProductos_MouseClick(object sender, MouseEventArgs e)
        {
            // Suscribirse al evento MouseClick para eliminar el panel
            flowLayoutPanelProductos.MouseClick += (s, args) =>
            {
                // Mostrar un cuadro de diálogo de confirmación
                var result = MessageBox.Show("¿Seguro que deseas eliminar este producto?", "Eliminar producto", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Eliminar el panel del FlowLayoutPanel
                    flowLayoutPanelProductos.Controls.Remove(flowLayoutPanelProductos);
                    // Liberar los recursos asociados al panel
                    flowLayoutPanelProductos.Dispose();
                }
            };

        }

        private void flowLayoutPanelProductos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
