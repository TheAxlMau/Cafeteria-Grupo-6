using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logCliente
    {
        #region Singleton
        private static readonly logCliente _instancia = new logCliente();
        public static logCliente Instancia
        {
            get { return _instancia; }
        }
        #endregion Singleton

        // Método para registrar un cliente
        public void RegistrarCliente(string nombre, string apellido, string telefono, bool estado)
        {
            try
            {
                entCliente cliente = new entCliente
                {
                    NombreCliente = nombre,
                    ApellidoCliente = apellido,
                    Telefono = telefono,
                    EstadoCliente = estado
                };

                datCliente.Instancia.RegistrarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar cliente.", ex);
            }
        }

        // Método para modificar un cliente
        public void ModificarCliente(int id, string nombre, string apellido, string telefono)
        {
            try
            {
                entCliente cliente = new entCliente
                {
                    ClienteID = id,
                    NombreCliente = nombre,
                    ApellidoCliente = apellido,
                    Telefono = telefono
                };

                datCliente.Instancia.ModificarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar cliente.", ex);
            }
        }

        // Método para inhabilitar un cliente
        public void InhabilitarCliente(int id)
        {
            try
            {
                datCliente.Instancia.InhabilitarCliente(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inhabilitar cliente.", ex);
            }
        }
    }
}
