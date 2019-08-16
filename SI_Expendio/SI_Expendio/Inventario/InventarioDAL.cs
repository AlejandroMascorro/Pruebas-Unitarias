using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
    public class InventarioDAL
    {
        public static int Agregar(Inventario pInventario)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into inventario (productos_id_producto, existencias) values ('{0}','{1}')",
            pInventario.productos_id_producto, pInventario.Existencias), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }


        public static Inventario ObtenerProducto(int id)
        {
            Inventario pInventario = new Inventario();
            MySqlCommand comando = new MySqlCommand(String.Format("select * from inventario where id_inventario='{0}'", id), Conexion.ObtenerConexion());
            MySqlDataReader read = comando.ExecuteReader();
            while (read.Read())
            {
                pInventario.Id = read.GetInt32(0);
                pInventario.Existencias = read.GetInt32(2);
            }
            return pInventario;
        }

    }
}
