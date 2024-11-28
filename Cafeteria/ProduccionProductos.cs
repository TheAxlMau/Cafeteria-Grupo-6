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
    public partial class ProduccionProductos : Form
    {
        public ProduccionProductos()
        {
            InitializeComponent();
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

                // Limpiar los TextBox después de agregar el producto
                txtNombreProducto.Text = "";
                txtDescripcionProducto.Text = "";
            

        }
    }
}
