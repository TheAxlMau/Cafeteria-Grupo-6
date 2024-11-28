using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datCliente
    {
        #region Singleton
        private static readonly datCliente _instancia = new datCliente();
        public static datCliente Instancia
        {
            get { return _instancia; }
        }
        #endregion Singleton

        // Método para registrar un cliente
        public void RegistrarCliente(entCliente cliente)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.conectar())
                {
                    SqlCommand cmd = new SqlCommand("spRegistrarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
                    cmd.Parameters.AddWithValue("@ApellidoCliente", cliente.ApellidoCliente);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@EstadoCliente", cliente.EstadoCliente);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para modificar un cliente
        public void ModificarCliente(entCliente cliente)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.conectar())
                {
                    SqlCommand cmd = new SqlCommand("spModificarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                    cmd.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
                    cmd.Parameters.AddWithValue("@ApellidoCliente", cliente.ApellidoCliente);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para inhabilitar un cliente
        public void InhabilitarCliente(int clienteID)
        {
            try
            {
                using (SqlConnection cn = Conexion.Instancia.conectar())
                {
                    SqlCommand cmd = new SqlCommand("spInhabilitarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para obtener todos los clientes
        public List<entCliente> ObtenerClientes()
        {
            List<entCliente> lista = new List<entCliente>();
            try
            {
                using (SqlConnection cn = Conexion.Instancia.conectar())
                {
                    SqlCommand cmd = new SqlCommand("spObtenerClientes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        entCliente cliente = new entCliente
                        {
                            ClienteID = Convert.ToInt32(dr["ClienteID"]),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            ApellidoCliente = dr["ApellidoCliente"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            EstadoCliente = Convert.ToBoolean(dr["EstadoCliente"])
                        };

                        lista.Add(cliente);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        // Método para obtener un cliente por ID
        public entCliente ObtenerClientePorID(int id)
        {
            entCliente cliente = null;
            try
            {
                using (SqlConnection cn = Conexion.Instancia.conectar())
                {
                    SqlCommand cmd = new SqlCommand("spObtenerClientePorID", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteID", id);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        cliente = new entCliente
                        {
                            ClienteID = Convert.ToInt32(dr["ClienteID"]),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            ApellidoCliente = dr["ApellidoCliente"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            EstadoCliente = Convert.ToBoolean(dr["EstadoCliente"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cliente;
        }
    }

}
