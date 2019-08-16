using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SI_Expendio;

namespace UnitTestExpendio
{
    [TestClass]
    public class UnitTestProducto
    {
        [TestMethod]
        public void TestConstructorCon6Parametros()
        {
            int id = 1;
            string nombre = "empanada";
            double precio_compra = 8.00;
            double precio_venta = 10.00;
            int categoria = 1;
            int proveedor = 1;
            Producto producto = new Producto(id,nombre,precio_compra,precio_venta,categoria,proveedor);

            Assert.AreEqual(producto.Id,id);
            Assert.AreEqual(producto.Nombre, nombre);
            Assert.AreEqual(producto.Precio_compra, precio_compra);
            Assert.AreEqual(producto.Precio_venta, precio_venta);
            Assert.AreEqual(producto.Categoria, categoria);
            Assert.AreEqual(producto.Proveedor, proveedor);
        }

        [TestMethod]
        public void TestAgregar()
        {
            //int id = 1;
            //string nombre = "empanada";
            //double precio_compra = 8.00;
            //double precio_venta = 10.00;
            //int categoria = 1;
            //int proveedor = 1;
            Producto producto = new Producto();
            producto.Nombre = "Empanada";
            producto.Precio_compra = 8.00;
            producto.Precio_venta = 10.00;
            producto.Categoria = 1;
            producto.Proveedor = 1;

            Assert.AreEqual(ProductoDAL.Agregar(producto), 1);
        }

        [TestMethod]
        public void TestObtenerultimoIDProducto()
        {
            Producto producto = new Producto();
            producto.Id_producto_ultimo = 2;
            Assert.AreEqual(ProductoDAL.ObtenerUltimoIDProducto().Id_producto_ultimo, 2);
        }
    }
}
