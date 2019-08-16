using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace SI_Expendio
{
    public class ProductoDAL
    {
        public static int Agregar(Producto pProducto)
        {
            int retorno = 0;

           MySqlCommand comando = new MySqlCommand(string.Format("Insert into productos (Nombre, Precio_compra, Precio_venta, " +
               " Proveedores_id_proveedor, Categorias_id_categoria) values ('{0}','{1}','{2}','{3}','{4}')",
            pProducto.Nombre, pProducto.Precio_compra,pProducto.Precio_venta, pProducto.Proveedor, pProducto.Categoria), Conexion.ObtenerConexion());
            comando.CommandType = CommandType.Text;
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static Producto ObtenerUltimoIDProducto()
        {
            Producto pProducto = new Producto();
            MySqlCommand comando = new MySqlCommand(String.Format("select max(id_producto + 1) from productos"), Conexion.ObtenerConexion());
            MySqlDataReader read = comando.ExecuteReader();
            while (read.Read())
            {
                pProducto.Id_producto_ultimo = read.GetInt32(0);
            }
            return pProducto;
        }
    }
}
