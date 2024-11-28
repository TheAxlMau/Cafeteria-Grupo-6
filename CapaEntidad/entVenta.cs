using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entVenta
    {
        public int VentaID { get; set; }
        public int ClienteID { get; set; }
        public int MetodoPagoID { get; set; }
        public int ProductoID { get; set; }
        public DateTime FechaVenta { get; set; }
        public float MontoTotal { get; set; }
        public bool EstadoV { get; set; }
    }
}
