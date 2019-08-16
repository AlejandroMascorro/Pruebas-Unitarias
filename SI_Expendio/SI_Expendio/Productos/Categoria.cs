using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SI_Expendio
{
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public Categoria(int pId, string pNombre)

        {
            this.Id = pId;
            this.Nombre = pNombre;
        }

        public static int Agregar(Categoria pCategoria)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into categorias (Nombre) values ('{0}')",
            pCategoria.Nombre), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        private void btn_guard_cat_Click(object sender, EventArgs e)
        {
            Categoria pCategoria = new Categoria();
            pCategoria.Nombre = nombre_cat_txt.Text.Trim();
            int resultado = Categoria.Agregar(pCategoria);
            if (resultado > 0)
            {
                MessageBox.Show("Categoria Guardada Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nombre_cat_txt.Text = "";
                Interface inte = new Interface();
                inte.ActualizarComboBoxProductos();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la Categoria", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_cancel_cat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Interface inte = new Interface();
            inte.ActualizarComboBoxProductos();
        }

    }
}
