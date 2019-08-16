using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 
using System.Windows.Forms;
using System.Data;

namespace SI_Expendio
{
    public class Conexion
    {
        static ConnectionState estado;

        public static ConnectionState Estado
        {
            get { return estado; }
            set { estado = value; }
        }   

        public static MySqlConnection ObtenerConexion()
        {
             MySqlConnection conexion = new MySqlConnection("server=127.0.0.1;database=expendio;Uid=root;pwd=;");
        
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();

                Conexion.Estado = conexion.State;
            }
            return conexion;
        }

        public static  MySqlConnection CerrarConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=127.0.0.1;database=expendio;Uid=root;pwd=;");
            Conexion con = new Conexion();

            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                Conexion.Estado = conexion.State;
            }
            return conexion;
        }
    }
}