using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
   public class Pedidos
    {
        public int Id { get; set; }
        public int Id_Total_Pedido { get; set; }
        public int Id_Fecha_Pedido { get; set; }
        public int Id_Usuario_Pedido { get; set; }
        
        public double Total_Pedido { get; set; }
        public string Fecha_Pedido { get; set; }

        public Pedidos() { }

        public Pedidos(int pId, int pId_Total_Pedido, int pId_Fecha_Pedido, int pId_Usuario_Pedido)

        {
            this.Id = pId;
            this.Id_Total_Pedido = pId_Total_Pedido;
            this.Id_Fecha_Pedido = pId_Fecha_Pedido;
            this.Id_Usuario_Pedido = pId_Usuario_Pedido;
        }
    }
}
