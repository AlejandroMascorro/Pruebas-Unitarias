using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SI_Expendio
{
    public class EmpleadoDAL
    {
   
        public static int Agregar(Empleado pEmpleado)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into empleados (Nombre, Apellido_p, Apellido_m, Fecha_registro, RFC, NSS) values ('{0}','{1}','{2}', '{3}','{4}','{5}')",
             pEmpleado.Nombre, pEmpleado.Apelldo_p, pEmpleado.Apellido_m, pEmpleado.Fecha_registro, pEmpleado.RFC, pEmpleado.NSS), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static int Eliminar(int id)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("delete from empleados where id_empleado='{0}'", id), Conexion.ObtenerConexion());
            //comando.Parameters.Clear();
            //comando.Parameters.Add("e_id_empleado", MySqlDbType.Int32).Value = id;
            comando.CommandType = System.Data.CommandType.Text;
            int eliminado = comando.ExecuteNonQuery();
            return eliminado;
        }

        public static Empleado ObtenerEmpleado(int id)
        {
            Empleado pEmpleado = new Empleado();
            MySqlCommand comando = new MySqlCommand(String.Format("select * from empleados where id_empleado='{0}'", id), Conexion.ObtenerConexion());
            MySqlDataReader read = comando.ExecuteReader();
            while (read.Read())
            {
                pEmpleado.Id = read.GetInt32(0);
                pEmpleado.Nombre = read.GetString(1);
                pEmpleado.Apelldo_p = read.GetString(2);
                pEmpleado.Apellido_m = read.GetString(3);
                pEmpleado.Fecha_registro = read.GetString(4);
                pEmpleado.RFC = read.GetString(5);
                pEmpleado.NSS = read.GetString(6);
            }
            return pEmpleado;
        }
    }
}
