using ChataPDV.BO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChataPDV.DAO
{
    public class GlobalDao
    {
        private string _connectionString = "";


        public GlobalDao()
        {
            _connectionString = System.Configuration.ConfigurationManager.
                    ConnectionStrings["ChataPDV"].ConnectionString;
        }



        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();


                var resultado = connection.Query<Usuario>("SELECT * FROM Usuarios");

                return resultado;

            }


        }
        public IEnumerable<Producto> ObtenerProductos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();


                var resultado = connection.Query<Producto>("SELECT * FROM Productos");

                return resultado;

            }


        }
        public Producto ObtenerProductoPorId(int productoId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var resultado = connection.QueryFirstOrDefault<Producto>("SELECT * FROM Productos WHERE ProductoId = @Id", new
                {
                    Id = productoId
                });

                return resultado;

            }
        }

        public void AgregarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }
            if (string.IsNullOrEmpty(producto.Descripcion))
            {
                throw new ArgumentNullException(nameof(producto.Descripcion));
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute(@"INSERT INTO Productos(Descripcion,PrecioUnitario,InsertDate,InsertUserId)   
                                        VALUES(@Descripcion,@PrecioUni,@InsertDate,@InsertUserId)",
                                        new
                                        {
                                            Descripcion = producto.Descripcion,
                                            PrecioUni = producto.PrecioUnitario,
                                            producto.InsertDate,
                                            producto.InsertUserId
                                        });

            }


        }
        public void ActualizarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }
            if (producto.ProductoId == null)
                throw new ArgumentNullException(nameof(producto.ProductoId));
            if (string.IsNullOrEmpty(producto.Descripcion))
            {
                throw new ArgumentNullException(nameof(producto.Descripcion));
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute(@"UPDATE Productos SET Descripcion = @Descripcion,
                                                PrecioUnitario=@PrecioUnitario,
                                                UpdateDate = @UpdateDate,
                                                UpdateUserId = @UpdateUserId   
                                        WHERE ProductoId = @ProductoId",
                                        new
                                        {
                                            Descripcion = producto.Descripcion,
                                            PrecioUnitario = producto.PrecioUnitario,
                                            producto.UpdateDate,
                                            producto.UpdateUserId,
                                            ProductoId = producto.ProductoId
                                        });

            }


        }
    }
}
