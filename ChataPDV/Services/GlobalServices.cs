using ChataPDV.BO;
using ChataPDV.DAO;
using System;
using System.Collections.Generic;

namespace ChataPDV.Services
{
    public class GlobalServices
    {
        private GlobalDao _dao;
        public GlobalServices()
        {
            _dao = new GlobalDao();
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return _dao.ObtenerUsuarios();
        }
        public IEnumerable<Producto> ObtenerProductos()
        {
            return _dao.ObtenerProductos();
        }
        public Producto ObtenerProductoPorId(int productoId)
        {
            return _dao.ObtenerProductoPorId(productoId);
        }
        public void GuardarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }
            var userLogueado = 1;//Aqui deberia buscar este valor de algun Static o algo parecido para obtener el usuario actualmente logueado            
            if (producto.ProductoId == null)
            {
                producto.InsertUserId = userLogueado;
                producto.InsertDate = DateTime.Now;


                _dao.AgregarProducto(producto);
            }
            else
            {
                producto.UpdateUserId = userLogueado;
                producto.UpdateDate = DateTime.Now;
                //Significa que se actualizara la informacion . . . .
                _dao.ActualizarProducto(producto);
            }

        }
    }
}
