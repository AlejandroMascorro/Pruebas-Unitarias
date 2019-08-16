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
    public class UnitTestPedidosProductos
    {
        [TestMethod]
        public void TestConstructorCon6Parametros()
        {
            int id = 1;
            int id_producto = 1;
            int cantidad = 3;
            double total_compra = 1500.50;
            double total_venta = 2000.70;
            double ganancia = 500.00;
            Pedidos_productos pedido = new Pedidos_productos(id,id_producto,cantidad,total_compra,total_venta,ganancia);
            Assert.AreEqual(pedido.Id,id);
            Assert.AreEqual(pedido.Id_Producto,id_producto);
            Assert.AreEqual(pedido.Cantidad, cantidad);
            Assert.AreEqual(pedido.Total_compra,total_compra);
            Assert.AreEqual(pedido.Total_Venta,total_venta);
            Assert.AreEqual(pedido.Ganancia, ganancia);
        }

        [TestMethod]
        public void TestAgregarProducto()
        {
           
            int id_producto = 1;
            
            Pedidos_productos pedido = new Pedidos_productos();
            pedido.Id_Producto = id_producto;
            Assert.AreEqual(Pedidos_productosDAL.Agregar_producto(pedido),1);
            
        }

        [TestMethod]
        public void TestObtenerProducto()
        {

            int id_producto = 1;

            Pedidos_productos pedido = new Pedidos_productos();
            pedido.Id_Producto = id_producto;
            Assert.IsNotNull(Pedidos_productosDAL.ObtenerProducto(1).Id);
            Assert.IsNotNull(Pedidos_productosDAL.ObtenerProducto(1).Cantidad);
        }

        [TestMethod]
        public void TestTotalPrecioCompra()
        {

            int id_producto = 1;

            Pedidos_productos pedido = new Pedidos_productos();
            Assert.IsNotNull(Pedidos_productosDAL.TotalPrecioCompra(id_producto).Total_compra);
        }

        [TestMethod]
        public void TestTotalPrecioVenta()
        {

            int id_producto = 1;

            Pedidos_productos pedido = new Pedidos_productos();
            Assert.IsNotNull(Pedidos_productosDAL.TotalPrecioVenta(id_producto).Total_Venta);
        }

        [TestMethod]
        public void TestTotalGanancia()
        {

            int id_producto = 1;

            Pedidos_productos pedido = new Pedidos_productos();
            Assert.IsNotNull(Pedidos_productosDAL.TotalGanancia(id_producto).Ganancia);
        }
    }
}
