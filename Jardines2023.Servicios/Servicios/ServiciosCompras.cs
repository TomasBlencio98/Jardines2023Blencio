using Jardines2023.Comun.Interfaces;
using Jardines2023.Comun.Repositorios;
using Jardines2023.Datos.Repositorios;
using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Servicios.Servicios
{
    public class ServiciosCompras : IServiciosCompras
    {
        private readonly IRepositorioCompras repoCompras;
        private readonly IRepositorioProveedores repoProveedores;

        public ServiciosCompras()
        {
            repoCompras = new RepositorioCompras();
            repoProveedores = new RepositorioProveedores();
        }
        public void Borrar(int CompraId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Compra compra)
        {
            try
            {
                return repoCompras.Existe(compra);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {
                return repoCompras.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Compra> GetCompras()
        {
            try
            {
                return repoCompras.GetCompras();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Compra compra)
        {
            throw new NotImplementedException();
        }
    }
}
