using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SI_Expendio
{
    public class ProveedorDAL
    {
        public static int Agregar(Proveedor pProveedor)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into proveedores (Nombre, Apellidos, Telefono, Correo, Direccion) values ('{0}','{1}','{2}', '{3}', '{4}')",
                pProveedor.Nombre, pProveedor.Apellido, pProveedor.Telefono, pProveedor.Correo, pProveedor.Direccion), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static Proveedor ObtenerProveedor(int id)
        {
            Proveedor pProv = new Proveedor();
            MySqlCommand comando = new MySqlCommand(String.Format("select * from proveedores where id_proveedor='{0}'", id), Conexion.ObtenerConexion());
            MySqlDataReader read = comando.ExecuteReader();
            while(read.Read())
            {
                pProv.Id = read.GetInt32(0);
                pProv.Nombre = read.GetString(1);
                pProv.Apellido = read.GetString(2);
                pProv.Telefono = read.GetString(3);
                pProv.Correo = read.GetString(4);
                pProv.Direccion = read.GetString(5);
            }
            return pProv;
        }

        public static int Eliminar(int id)
        {
            MySqlCommand comando = new MySqlCommand(String.Format("EliminarProveedor"), Conexion.ObtenerConexion());
            //comando.Parameters.Clear();
            comando.Parameters.Add("e_id_proveedor", MySqlDbType.VarChar).Value = id;
            comando.CommandType = CommandType.StoredProcedure;
            int eliminado = comando.ExecuteNonQuery();
            return eliminado;
        }
    }
}
