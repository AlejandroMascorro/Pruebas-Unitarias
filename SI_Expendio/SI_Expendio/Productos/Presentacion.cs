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
    public partial class Presentacion : Form
    {
        public Presentacion()
        {
            InitializeComponent();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public Presentacion(int pId, string pNombre)

        {
            this.Id = pId;
            this.Nombre = pNombre;
        }

        public static int Agregar(Presentacion pPresentacion)
        {
            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into presentaciones(Nombre)values ('{0}')",
                pPresentacion.Nombre), Conexion.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        private void btn_guard_cat_Click(object sender, EventArgs e)
        {
            Presentacion pPresentacion = new Presentacion();
            pPresentacion.Nombre = nombre_pres_txt.Text.Trim();
            int resultado = Presentacion.Agregar(pPresentacion);
            if (resultado > 0)
            {
                MessageBox.Show("Presentacion Guardada Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nombre_pres_txt.Text = "";
                Interface inte = new Interface();
                inte.ActualizarComboBoxProductos();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la Presentacion", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
