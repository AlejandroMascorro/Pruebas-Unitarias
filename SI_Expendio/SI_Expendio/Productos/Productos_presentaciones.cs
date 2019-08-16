using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
    public class Productos_presentaciones
    {
        public int Id_producto { get; set; }
        public int Id_presentacion { get; set; }

        public static int Agregar_productos_presentaciones(Productos_presentaciones pPP)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into productos_has_presentaciones (productos_id_producto, presentaciones_id_presentacion) values ('{0}','{1}')",
            pPP.Id_producto, pPP.Id_presentacion), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}
