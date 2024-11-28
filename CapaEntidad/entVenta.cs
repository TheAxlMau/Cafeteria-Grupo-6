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
        public string ClienteNombre { get; set; } // Para mostrar en listados
        public int MetodopagoID { get; set; }
        public string MetodoPagoNombre { get; set; } // Para mostrar en listados
        public int ProductoID { get; set; }
        public string ProductoNombre { get; set; } // Para mostrar en listados
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public bool EstadoV { get; set; }
    }
}
