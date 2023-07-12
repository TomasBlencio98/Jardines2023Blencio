using Jardines2023.Comun.Interfaces;
using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2023.Datos.Repositorios
{
    public class RepositorioCompras : IRepositorioCompras
    {
        private readonly string cadenaConexion;
        public RepositorioCompras()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings
                ["MiConexion"].ToString();
        }
        public void Agregar(Compra compra)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int CompraId)
        {
            throw new NotImplementedException();
        }

        public void Editar(Compra compra)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Compra compra)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                int Cantidad;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string selectQuery = "SELECT COUNT(*) FROM Compras";
                    using (var comando = new SqlCommand(selectQuery, conn))
                    {
                        Cantidad = (int)comando.ExecuteScalar();
                    }
                }
                return Cantidad;
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
                var listaCompras = new List<Compra>();

                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery = @"SELECT p.NombreProveedor, c.Total, c.FechaCompra, c.CompraId
                                            FROM Compras c 
                                            INNER JOIN Proveedores p
                                            ON c.ProveedorId = p.ProveedorId";
                    using (var cmd = new SqlCommand(SelectQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Compra compra = ConstruirCompra(reader);
                                listaCompras.Add(compra);
                            }
                        }
                    }
                }
                return listaCompras;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Compra ConstruirCompra(SqlDataReader reader)
        {
            return new Compra
            {
                NombreProveedor=reader.GetString(0),
                Total=reader.GetSqlMoney(1),
                FechaCompra=reader.GetDateTime(2),
                CompraId=reader.GetInt32(3)
            };
        }
    }
}
