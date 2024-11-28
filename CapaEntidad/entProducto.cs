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
        public int EstandaresproductoID { get; set; }
        public int TipoProductoID { get; set; }
        public string DescripcionProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public DateTime? FechaRegistroP { get; set; }
        public bool EstadoProducto { get; set; }
    }
}