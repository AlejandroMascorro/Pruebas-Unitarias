using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
    public class Productos_paquetes
    {
        public int Id_producto { get; set; }
        public int Id_paquete { get; set; }

        public static int Agregar_productos_paquetes(Productos_paquetes pPPack)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into productos_has_paquetes (Productos_id_producto, Paquetes_id_paquete) values ('{0}','{1}')",
            pPPack.Id_producto, pPPack.Id_paquete), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
