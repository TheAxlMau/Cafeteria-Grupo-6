using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logVenta
    {
        #region Singleton
        private static readonly logVenta _instancia = new logVenta();
        public static logVenta Instancia
        {
            get { return _instancia; }
        }
        #endregion Singleton

        #region Métodos

        // Método para registrar una venta
        public bool RegistrarVenta(entVenta venta)
        {
            try
            {
                return datVenta.Instancia.RegistrarVenta(venta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para listar ventas
        public List<entVenta> ListarVentas()
        {
            try
            {
                return datVenta.Instancia.ListarVentas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<entMetodoPago> ListarMetodosPago()
        {
            return datVenta.Instancia.ListarMetodosPago(); // Asumiendo que tienes un datMetodoPago que obtiene los métodos de pago
        }

        #endregion Métodos
    }
}
