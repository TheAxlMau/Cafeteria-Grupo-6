using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datVenta
    {
        #region Singleton
        private static readonly datVenta _instancia = new datVenta();
        public static datVenta Instancia
        {
            get { return _instancia; }
        }
        #endregion Singleton

        #region Métodos

        // Método para registrar una venta
        public bool RegistrarVenta(entVenta venta)
        {
            SqlCommand cmd = null;
            bool registrado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("INSERT INTO Venta (ClienteID, MetodopagoID, ProductoID, FechaVenta, MontoTotal, EstadoV) " +
                                     "VALUES (@ClienteID, @MetodopagoID, @ProductoID, @FechaVenta, @MontoTotal, @EstadoV)", cn);
                cmd.Parameters.AddWithValue("@ClienteID", venta.ClienteID);
                cmd.Parameters.AddWithValue("@MetodopagoID", venta.MetodopagoID);
                cmd.Parameters.AddWithValue("@ProductoID", venta.ProductoID);
                cmd.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                cmd.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);
                cmd.Parameters.AddWithValue("@EstadoV", venta.EstadoV);

                cn.Open();
                registrado = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd?.Connection.Close();
            }
            return registrado;
        }

        // Método para listar ventas
        public List<entVenta> ListarVentas()
        {
            SqlCommand cmd = null;
            List<entVenta> lista = new List<entVenta>();

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("SELECT v.VentaID, c.NombreCliente, m.NombreMetodoPago, p.NombreProducto, " +
                                     "v.FechaVenta, v.MontoTotal, v.EstadoV " +
                                     "FROM Venta v " +
                                     "JOIN Cliente c ON v.ClienteID = c.ClienteID " +
                                     "JOIN Metodopago m ON v.MetodopagoID = m.MetodopagoID " +
                                     "JOIN Producto p ON v.ProductoID = p.ProductoID", cn);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new entVenta
                    {
                        VentaID = Convert.ToInt32(dr["VentaID"]),
                        ClienteNombre = dr["NombreCliente"].ToString(),
                        MetodoPagoNombre = dr["NombreMetodoPago"].ToString(),
                        ProductoNombre = dr["NombreProducto"].ToString(),
                        FechaVenta = Convert.ToDateTime(dr["FechaVenta"]),
                        MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                        EstadoV = Convert.ToBoolean(dr["EstadoV"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd?.Connection.Close();
            }
            return lista;
        }

        public List<entMetodoPago> ListarMetodosPago()
        {
            SqlCommand cmd = null;
            List<entMetodoPago> lista = new List<entMetodoPago>();

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("SELECT MetodopagoID, NombreMetodoPago, Descripcion FROM Metodopago WHERE EstadoMetodoP = 1", cn);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new entMetodoPago
                    {
                        MetodoPagoID = Convert.ToInt32(dr["MetodopagoID"]),
                        NombreMetodoPago = dr["NombreMetodoPago"].ToString(),
                        DescripcionMetodoPago = dr["Descripcion"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd?.Connection.Close();
            }
            return lista;
        }


        #endregion Métodos
    }
}
