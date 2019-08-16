using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
    public class Pedidos_productos
    {
        public int Id { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public double Total_compra { get; set; }
        public double Total_Venta { get; set; }
        public double Ganancia { get; set; }

        public Pedidos_productos() { }

        public Pedidos_productos(int pId, int pId_Producto, int pCantidad, double pTotal_compra, double pTotal_venta, double pGanancia)

        {
            this.Id = pId;
            this.Id_Producto = pId_Producto;
            this.Cantidad = pCantidad;
            this.Total_compra = pTotal_compra;
            this.Total_Venta = pTotal_venta;
            this.Ganancia = pGanancia;
        }
    }
}
