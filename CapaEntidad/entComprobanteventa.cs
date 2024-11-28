using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entComprobanteventa
    {
        public int ComprovanteventaID { get; set; }
        public int VentaID { get; set; }
        public DateTime FechaComprobante { get; set; }
        public bool EstadoComprobanteV { get; set; }
    }
}
