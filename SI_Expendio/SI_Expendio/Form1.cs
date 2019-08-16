using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SI_Expendio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Conexion.ObtenerConexion();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectectamos = new MySqlConnection();

            codigo.Connection = Conexion.ObtenerConexion();
            codigo.CommandText = ("select * from Usuarios where Nombre='" + usuario_txt.Text + "' and Clave='" + pass_txt.Text + "' ");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                MessageBox.Show("Bienvenido: " + usuario_txt.Text);
                this.Hide();
                Interface infz = new Interface();
                infz.Show();
            }
            else
            {
                MessageBox.Show("ERROR. USUARIO O CONTRASEÑA INVALIDOS");
            }
        }

        private void pbx_info_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
