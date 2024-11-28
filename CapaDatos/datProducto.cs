using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datProducto
    {
        #region Singleton
        private static readonly datProducto _instancia = new datProducto();
        public static datProducto Instancia
        {
            get { return _instancia; }
        }
        #endregion

        #region Métodos
        // Método para agregar un producto
        public bool AgregarProducto(entProducto producto)
        {
            SqlCommand cmd = null;
            bool result = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("INSERT INTO Producto (EstandaresproductoID, TipoProductoID, NombreProducto, DescripcionProducto, Precio, FechaRegistroP, EstadoProducto) " +
                                     "VALUES (@EstandaresproductoID, @TipoProductoID, @NombreProducto, @DescripcionProducto, @Precio, @FechaRegistroP, @EstadoProducto)", cn);
                cmd.Parameters.AddWithValue("@EstandaresproductoID", producto.EstandaresproductoID);
                cmd.Parameters.AddWithValue("@TipoProductoID", producto.TipoProductoID);
                cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@DescripcionProducto", producto.DescripcionProducto);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@FechaRegistroP", producto.FechaRegistroP);
                cmd.Parameters.AddWithValue("@EstadoProducto", producto.EstadoProducto);
                cn.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd?.Connection.Close();
            }
            return result;
        }


        // Método para buscar un producto por ID
        public entProducto BuscarProductoPorID(int productoID)
        {
            SqlCommand cmd = null;
            entProducto producto = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("SELECT * FROM Producto WHERE ProductoID = @ProductoID", cn);
                cmd.Parameters.AddWithValue("@ProductoID", productoID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    producto = new entProducto
                    {
                        ProductoID = Convert.ToInt32(dr["ProductoID"]),
                        EstandaresproductoID = Convert.ToInt32(dr["EstandaresproductoID"]),
                        TipoProductoID = Convert.ToInt32(dr["TipoProductoID"]),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        DescripcionProducto = dr["DescripcionProducto"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"]),
                        FechaRegistroP = dr["FechaRegistroP"] != DBNull.Value ? Convert.ToDateTime(dr["FechaRegistroP"]) : (DateTime?)null,
                        EstadoProducto = Convert.ToBoolean(dr["EstadoProducto"])
                    };
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
            return producto;
        }

        public bool EditarProducto(entProducto producto)
        {
            SqlCommand cmd = null;
            bool result = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("UPDATE Producto SET EstandaresproductoID = @EstandaresproductoID, TipoProductoID = @TipoProductoID, NombreProducto = @NombreProducto, DescripcionProducto = @DescripcionProducto, Precio = @Precio, EstadoProducto = @EstadoProducto WHERE ProductoID = @ProductoID", cn);
                cmd.Parameters.AddWithValue("@EstandaresproductoID", producto.EstandaresproductoID);
                cmd.Parameters.AddWithValue("@TipoProductoID", producto.TipoProductoID);
                cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
                cmd.Parameters.AddWithValue("@DescripcionProducto", producto.DescripcionProducto);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@EstadoProducto", producto.EstadoProducto);
                cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                cn.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd?.Connection.Close();
            }
            return result;
        }


        public List<entProducto> ListarProductos()
        {
            SqlCommand cmd = null;
            List<entProducto> lista = new List<entProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("SELECT * FROM Producto", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProducto producto = new entProducto
                    {
                        ProductoID = Convert.ToInt32(dr["ProductoID"]),
                        EstandaresproductoID = Convert.ToInt32(dr["EstandaresproductoID"]),
                        TipoProductoID = Convert.ToInt32(dr["TipoProductoID"]),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        DescripcionProducto = dr["DescripcionProducto"].ToString(),
                        Precio = Convert.ToDecimal(dr["Precio"]),
                        FechaRegistroP = dr["FechaRegistroP"] != DBNull.Value ? Convert.ToDateTime(dr["FechaRegistroP"]) : (DateTime?)null,
                        EstadoProducto = Convert.ToBoolean(dr["EstadoProducto"])
                    };
                    lista.Add(producto);
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

        public bool InhabilitarProducto(int productoID)
        {
            SqlCommand cmd = null;
            bool result = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("UPDATE Producto SET EstadoProducto = 0 WHERE ProductoID = @ProductoID", cn);
                cmd.Parameters.AddWithValue("@ProductoID", productoID);
                cn.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd?.Connection.Close();
            }
            return result;
        }

        #endregion
    }
}
