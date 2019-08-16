using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SI_Expendio
{
    public class Llenar_tablas
    {
        public DataTable GridView_proveedores(DataGridView grid)
        {
            MySqlCommand cm = new MySqlCommand("SELECT * FROM proveedores", Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            Conexion.CerrarConexion();
            return dt;
        }

        public DataTable GridView_empleados(DataGridView grid)
        {
                MySqlCommand cm = new MySqlCommand("SELECT * FROM empleados", Conexion.ObtenerConexion());
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid.DataSource = dt;
                Conexion.CerrarConexion();
                return dt;
           
        }

        public DataTable GridView_productos(DataGridView grid)
        {
            MySqlCommand cm = new MySqlCommand("SELECT * FROM expendio.productos_presentaciones_categorias;", Conexion.ObtenerConexion());
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            Conexion.CerrarConexion();
            return dt;

        }


        public DataTable GridView_inventario(DataGridView grid)
        {
            
                MySqlCommand cm = new MySqlCommand("SELECT * FROM expendio.inventario_productos;", Conexion.ObtenerConexion());
                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid.DataSource = dt;
                Conexion.CerrarConexion();
            return dt;
          
        }

        public DataTable GridView_pedido(DataGridView grid)
        {
            
              MySqlCommand cm = new MySqlCommand("SELECT* FROM expendio.pedido_prductos;", Conexion.ObtenerConexion());
              MySqlDataAdapter da = new MySqlDataAdapter(cm);
              DataTable dt = new DataTable();
              da.Fill(dt);
              grid.DataSource = dt;
              Conexion.CerrarConexion();
              return dt;
        }

    }
}
