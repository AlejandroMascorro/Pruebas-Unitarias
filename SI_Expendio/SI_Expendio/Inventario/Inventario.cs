using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
    public class Inventario
    {
        public int Id { get; set; }
        public int productos_id_producto { get; set; }
        public int Existencias { get; set; }

        public Inventario() {}

        public Inventario(int pId, int pProductos_id_producto, int pExistencas)
        {
            this.Id = pId;
            this.productos_id_producto = pProductos_id_producto;
            this.Existencias = pExistencas;
        }
    }
}
