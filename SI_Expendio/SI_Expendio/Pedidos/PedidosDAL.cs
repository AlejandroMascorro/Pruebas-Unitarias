using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
    public class PedidosDAL
    {
        public static int InsertarFecha(Pedidos pPedidos)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into fechas_pedidos(Fecha_pedido) values ('{0}')",
            pPedidos.Fecha_Pedido), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int InsertarTotal(Pedidos pPedidos)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into totales_pedidos(Total) values ('{0}')",
            pPedidos.Total_Pedido), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int Agregar(Pedidos pPedidos)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into pedidos(Totales_pedidos_id_total_pedido, Fechas_pedidos_id_Fecha_pedido, Usuarios_id_usuario) values ('{0}','{1}','{2}')",
            pPedidos.Id_Total_Pedido, pPedidos.Id_Fecha_Pedido, pPedidos.Id_Usuario_Pedido), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static Pedidos ObtenerUltimoIDTotal()
        {
            Pedidos pPedidos = new Pedidos();
            MySqlCommand comando = new MySqlCommand(String.Format("select max(id_total_pedido) from totales_pedidos"), Conexion.ObtenerConexion());
            MySqlDataReader read = comando.ExecuteReader();
            while (read.Read())
            {
                pPedidos.Id_Total_Pedido = read.GetInt32(0);
            }
            return pPedidos;
        }

        public static Pedidos ObtenerUltimoIDFecha()
        {
            Pedidos pPedidos = new Pedidos();
            MySqlCommand comando = new MySqlCommand(String.Format("select max(id_Fecha_pedido) from fechas_pedidos"), Conexion.ObtenerConexion());
            MySqlDataReader read = comando.ExecuteReader();
            while (read.Read())
            {
                pPedidos.Id_Fecha_Pedido = read.GetInt32(0);
            }
            return pPedidos;
        }

        
        public static List<int> ObtenerSumaInventario()
        {
            List<int> resultado = new List<int>();

            MySqlCommand comando = new MySqlCommand(String.Format("select sum(inventario + cantidad) from pedido_prductos as Inventario group by inventario order by id_producto asc"), Conexion.ObtenerConexion());
            MySqlDataReader read = comando.ExecuteReader();
            while (read.Read())
            {
                resultado.Add(Convert.ToInt32(read["Inventario)"]));
            }
            return resultado;
        }

        public static int LimpiarPedido()
        {
            MySqlCommand comando = new MySqlCommand(string.Format("UPDATE pedidos_productos SET cantidad = '0', Total_compra = '0' where id_pedido_producto > 0"), Conexion.ObtenerConexion());
           int resultado = comando.ExecuteNonQuery();
            return resultado;
        }
    }
}
