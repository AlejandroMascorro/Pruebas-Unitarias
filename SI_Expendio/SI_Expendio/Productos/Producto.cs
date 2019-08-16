using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio_compra{ get; set; }
        public double Precio_venta { get; set; }
        public int Categoria { get; set; }
        public int Proveedor { get; set; }

        public int Id_producto_ultimo { get; set; }

        public Producto() { }

        public Producto(int pId, string pNombre, double pPrecio_compra,double pPrecio_venta, int pCategoria, int pProveedor)

        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Precio_compra= pPrecio_compra;
            this.Precio_venta = pPrecio_venta;
            this.Categoria = pCategoria;
            this.Proveedor = pProveedor;
        }
    }
}
