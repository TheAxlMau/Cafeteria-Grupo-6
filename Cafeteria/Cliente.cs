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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
            ActualizarListaClientes();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string telefono = txtTelefono.Text;
                bool estado = Estado.Checked;

                // Llamar a la capa l贸gica para registrar un cliente
                logCliente.Instancia.RegistrarCliente(nombre, apellido, telefono, estado);

                MessageBox.Show("Cliente registrado exitosamente.");
                LimpiarCampos();
                ActualizarListaClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string telefono = txtTelefono.Text;

                // Llamar a la capa l贸gica para modificar un cliente
                logCliente.Instancia.ModificarCliente(id, nombre, apellido, telefono);

                MessageBox.Show("Cliente modificado exitosamente.");
                LimpiarCampos();
                ActualizarListaClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnInhabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);

                // Llamar a la capa l贸gica para inhabilitar un cliente
                logCliente.Instancia.InhabilitarCliente(id);

                MessageBox.Show("Cliente inhabilitado exitosamente.");
                LimpiarCampos();
                ActualizarListaClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }

        private void ActualizarListaClientes()
        {
            try
            {
                // Llamar a la capa l贸gica para obtener todos los clientes
                List<entCliente> clientes = logCliente.Instancia.ObtenerClientes();

                // Asignar la lista de clientes al DataGridView
                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los clientes: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            Estado.Checked = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvClientes.Rows[e.RowIndex];
                    txtID.Text = row.Cells["ClienteID"].Value.ToString();
                    txtNombre.Text = row.Cells["NombreCliente"].Value.ToString();
                    txtApellido.Text = row.Cells["ApellidoCliente"].Value.ToString();
                    txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                    Estado.Checked = Convert.ToBoolean(row.Cells["EstadoCliente"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
