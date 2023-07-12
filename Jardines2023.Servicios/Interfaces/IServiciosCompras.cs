using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Servicios.Interfaces
{
    public interface IServiciosCompras
    {
        void Borrar(int CompraId);
        bool Existe(Compra  compra);
        int GetCantidad();
        List<Compra> GetCompras();
        void Guardar(Compra compra);
    }
}
