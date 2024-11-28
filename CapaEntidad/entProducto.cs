using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProducto
    {
        public int ProductoID { get; set; }
        public int EstandaresProductoID { get; set; }
        public int TipoProductoID { get; set; }
        public String DescripcionProducto { get; set; }
        public float Precio { get; set; }
        public DateTime FechaRegistroP { get; set; }
        public bool EstadoProducto { get; set; }
    }
}