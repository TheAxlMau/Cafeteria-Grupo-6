using CapaEntidad;
using CapaLogica;
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
    public partial class MantenedorProducto : Form
    {
        public MantenedorProducto()
        {
            InitializeComponent();
            CargarTiposProducto();
            CargarEstandaresProducto();
            CargarProductos();
        }

        private void CargarTiposProducto()
        {
            try
            {
                var tipos = logProducto.Instancia.ObtenerTiposProducto();
                cmbProducto.DataSource = tipos;
                cmbProducto.DisplayMember = "Value"; // Nombre del tipo de producto
                cmbProducto.ValueMember = "Key";    // ID del tipo de producto
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de producto: " + ex.Message);
            }
        }

        private void CargarEstandaresProducto()
        {
            try
            {
                var estandares = logProducto.Instancia.ObtenerEstandaresProducto();
                cmbEstandares.DataSource = estandares;
                cmbEstandares.DisplayMember = "Value"; // Nombre del estándar
                cmbEstandares.ValueMember = "Key";    // ID del estándar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estándares de producto: " + ex.Message);
            }
        }

        private void CargarProductos()
        {
            try
            {
                dgvProductos.DataSource = logProducto.Instancia.ListarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btnInhabilitar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                entProducto producto = new entProducto
                {
                    NombreProducto = txtNombre.Text,
                    TipoProductoID = Convert.ToInt32(cmbProducto.SelectedValue), // ID del tipo seleccionado
                    EstandaresproductoID = Convert.ToInt32(cmbEstandares.SelectedValue), // ID del estándar seleccionado
                    DescripcionProducto = txtDescripcion.Text,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    FechaRegistroP = DateTime.Now,
                    EstadoProducto = true // Activo por defecto
                };

                if (logProducto.Instancia.AgregarProducto(producto))
                {
                    MessageBox.Show("Producto agregado correctamente.");
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al agregar el producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
