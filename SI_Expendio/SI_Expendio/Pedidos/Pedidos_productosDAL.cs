using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
   public class Pedidos_productosDAL
    {
        public static int Agregar_producto(Pedidos_productos pPedidos)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into pedidos_productos(productos_id_producto) values ('{0}')",
             pPedidos.Id_Producto), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static Pedidos_productos ObtenerProducto(int id)
        {
            Pedidos_productos pPedidosProducto = new Pedidos_productos();
            MySqlCommand comando = new MySqlCommand(String.Format("select * from expendio.pedido_prductos where id_producto='{0}'", id), Conexion.ObtenerConexion());
            MySqlDataReader read = comando.ExecuteReader();
            while (read.Read())
            {
                pPedidosProducto.Id = read.GetInt32(0);
                pPedidosProducto.Cantidad = read.GetInt32(4);
            }
            return pPedidosProducto;
        }

        public static Pedidos_productos TotalPrecioCompra(int id)
        {
            Pedidos_productos pPedidos_Productos = new Pedidos_productos();
            MySqlCommand comando_compra = new MySqlCommand(String.Format("SELECT  cantidad * paquetes * precio_compra from expendio.pedido_prductos where id_producto='{0}'", id), Conexion.ObtenerConexion());
            MySqlDataReader read_compra = comando_compra.ExecuteReader();
            while (read_compra.Read())
            {
                pPedidos_Productos.Total_compra = read_compra.GetDouble(0);
            }
            return pPedidos_Productos;
        }

        public static Pedidos_productos TotalPrecioVenta(int id)
        {
            Pedidos_productos pPedidos_Productos = new Pedidos_productos();
            MySqlCommand comando_venta = new MySqlCommand(String.Format("SELECT  cantidad * paquetes * precio_venta  from expendio.pedido_prductos where id_producto='{0}'", id), Conexion.ObtenerConexion());
            MySqlDataReader read_venta = comando_venta.ExecuteReader();
            while (read_venta.Read())
            {
                pPedidos_Productos.Total_Venta = read_venta.GetDouble(0);
            }
            return pPedidos_Productos;
        }

        public static Pedidos_productos TotalGanancia(int id)
        {
            Pedidos_productos pPedidos_Productos = new Pedidos_productos();
            MySqlCommand comando = new MySqlCommand(String.Format("select (total_venta - total_compra) as Ganancia from expendio.pedido_prductos where id_producto=1;'{0}'", id), Conexion.ObtenerConexion());
            MySqlDataReader read_venta = comando.ExecuteReader();
            while (read_venta.Read())
            {
                pPedidos_Productos.Ganancia = read_venta.GetDouble(0);
            }
            return pPedidos_Productos;
        }

    }
}
