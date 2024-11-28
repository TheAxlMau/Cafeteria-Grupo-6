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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            LlenarComboProductos();
            LlenarComboClientes();
            LlenarComboMetodosPago();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el producto seleccionado del ComboBox
                int productoId = Convert.ToInt32(cmbProductos.SelectedValue);
                string nombreProducto = cmbProductos.Text; // Nombre visible del producto

                // Crear un objeto de entProducto con los datos necesarios
                entProducto producto = new entProducto
                {
                    ProductoID = productoId,
                    NombreProducto = nombreProducto
                };

                // Verificar si el producto ya ha sido agregado
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    if (row.Cells["ProductoID"].Value != null && row.Cells["ProductoID"].Value.ToString() == producto.ProductoID.ToString())
                    {
                        MessageBox.Show("Este producto ya ha sido agregado.");
                        return;
                    }
                }

                // Agregar el producto al DataGridView
                dgvProductos.Rows.Add(producto.ProductoID, producto.NombreProducto);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvProductos.SelectedRows)
                    {
                        dgvProductos.Rows.Remove(row); // Eliminar la fila seleccionada
                    }

                    // Actualizar el monto total después de la eliminación
                    ActualizarMontoTotal();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un producto para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ActualizarMontoTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            txtMontoTotal.Text = total.ToString("F2"); // Monto total con 2 decimales
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay productos en el DataGridView
                if (dgvProductos.Rows.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto.");
                    return;
                }

                // Obtener el ClienteID y el MetodoPagoID de los controles
                int clienteId = Convert.ToInt32(cmbClientes.SelectedValue);
                int metodoPagoId = Convert.ToInt32(cmbPago.SelectedValue);
                DateTime fechaVenta = DateTime.Now; // Usar la fecha actual

                // Intentar convertir el texto de txtMontoTotal a decimal
                decimal montoTotal = 0;
                string montoTexto = txtMontoTotal.Text.Trim(); // Elimina espacios antes y después

                // Verificar si el texto se puede convertir a decimal
                if (!decimal.TryParse(montoTexto, out montoTotal))
                {
                    MessageBox.Show("El monto total no tiene un formato válido.");
                    return;
                }

                // Recorrer los productos en el DataGridView y registrar cada venta
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    int productoId = Convert.ToInt32(row.Cells["ProductoID"].Value);
                    // El monto total se toma del cuadro de texto txtMontoTotal
                    decimal subtotal = montoTotal;

                    // Crear la entidad de venta
                    entVenta venta = new entVenta
                    {
                        ClienteID = clienteId,
                        MetodopagoID = metodoPagoId,
                        ProductoID = productoId,
                        FechaVenta = fechaVenta,
                        MontoTotal = subtotal, // Cada venta tendrá su monto total
                        EstadoV = true // La venta es válida por defecto
                    };

                    // Registrar la venta en la base de datos
                    bool resultado = logVenta.Instancia.RegistrarVenta(venta);
                    if (!resultado)
                    {
                        MessageBox.Show("Error al registrar la venta.");
                        return;
                    }
                }

                // Si todas las ventas fueron exitosas
                MessageBox.Show("Venta realizada correctamente.");
                LimpiarCampos(); // Limpiar los campos después de realizar la venta
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private decimal GetPrecioProducto(int productoId)
        {
            // Llamada a la lógica que obtiene el precio de la base de datos
            entProducto producto = logProducto.Instancia.BuscarProductoId(productoId);
            return producto.Precio;
        }

        private void LimpiarCampos()
        {
            cmbClientes.SelectedIndex = -1;
            cmbProductos.SelectedIndex = -1;
            cmbPago.SelectedIndex = -1;
            txtCantidad.Clear();
            txtMontoTotal.Clear();
            dgvProductos.Rows.Clear();
        }


        private void LlenarComboProductos()
        {
            try
            {
                // Llamamos al método para obtener los productos
                List<entProducto> productos = logProducto.Instancia.ListarProductos();

                // Asignamos los productos al ComboBox
                cmbProductos.DataSource = productos;
                cmbProductos.DisplayMember = "NombreProducto"; // Campo a mostrar
                cmbProductos.ValueMember = "ProductoID"; // Campo que se utilizará al seleccionar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void LlenarComboClientes()
        {
            try
            {
                // Llamamos al método para obtener los clientes
                List<entCliente> clientes = logCliente.Instancia.ObtenerClientes();

                // Asignamos los clientes al ComboBox
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "NombreCliente"; // Campo a mostrar
                cmbClientes.ValueMember = "ClienteID"; // Campo que se utilizará al seleccionar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }

        private void LlenarComboMetodosPago()
        {
            try
            {
                // Llamamos al método para obtener los métodos de pago
                List<entMetodoPago> metodosPago = logVenta.Instancia.ListarMetodosPago();

                // Asignamos los métodos de pago al ComboBox
                cmbPago.DataSource = metodosPago;
                cmbPago.DisplayMember = "NombreMetodoPago"; // Campo a mostrar
                cmbPago.ValueMember = "MetodoPagoID"; // Campo que se utilizará al seleccionar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los métodos de pago: " + ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoGenerateColumns = false; // Deshabilitamos la auto-generación para manejar las columnas manualmente

            dgvProductos.Columns.Clear(); // Limpiar cualquier columna anterior

            // Agregar la columna ProductoID
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductoID",  // Este es el nombre de la columna
                DataPropertyName = "ProductoID",  // Esto se asocia a la propiedad ProductoID de la clase entProducto
                HeaderText = "Producto ID",        // El título de la columna
                Visible = true                  // Esta columna será visible
            });

            // Agregar la columna NombreProducto
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreProducto",
                DataPropertyName = "NombreProducto", // Esto se asocia a la propiedad NombreProducto
                HeaderText = "Producto"             // El título de la columna
            });
        }




    }
}
