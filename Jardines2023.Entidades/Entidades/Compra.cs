using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Entidades.Entidades
{
    public class Compra
    {
        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public SqlMoney Total { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
