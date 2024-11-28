using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entMetodoPago
    {
        public int metodoPagoID { get; set; }
        public String NombreMetodoPago { get; set; }
        public String Descripcion { get; set; }
        public bool EstadoMetodoP { get; set; }
    }
}
