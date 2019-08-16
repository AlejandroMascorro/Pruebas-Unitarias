using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SI_Expendio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace UnitTestExpendio
{
    [TestClass]
    public class UnitTestPedidos
    {
        [TestMethod]
        public void TestConstructorCon4Parametros()
        {
            int id = 1;
            int total_pedido = 100000;
            int fecha_pedido = 1;
            int id_usuario = 1;
            Pedidos pedido = new Pedidos(id,total_pedido, fecha_pedido, id_usuario);
            Assert.AreEqual(pedido.Id,id);
            Assert.AreEqual(pedido.Id_Fecha_Pedido,fecha_pedido);
            Assert.AreEqual(pedido.Id_Total_Pedido, total_pedido);
            Assert.AreEqual(pedido.Id_Usuario_Pedido, id_usuario);
        }

        [TestMethod]
        public void TestInsertarFecha()
        {
            
            string fecha_pedido = "2019-08-15";
            
            Pedidos pedido = new Pedidos();
            pedido.Fecha_Pedido = fecha_pedido;
            Assert.AreEqual(PedidosDAL.InsertarFecha(pedido),1);  
        }

        [TestMethod]
        public void TestInsertarTotal()
        {

            double total = 1500.23;

            Pedidos pedido = new Pedidos();
            pedido.Total_Pedido = total;
            Assert.AreEqual(PedidosDAL.InsertarTotal(pedido), 1);
        }

        [TestMethod]
        public void TestAgregar()
        {

            int id_total = 1;
            int id_fecha = 1;
            int id_usuario = 1;

            Pedidos pedido = new Pedidos();
            pedido.Id_Total_Pedido = id_total;
            pedido.Id_Fecha_Pedido = id_fecha;
            pedido.Id_Usuario_Pedido = id_usuario;
            Assert.AreEqual(PedidosDAL.Agregar(pedido),1);
        }

        [TestMethod]
        public void TestObtenerUltimoIDTotal()
        {


            int total = 1;
            Pedidos pedido = new Pedidos();
            Assert.AreEqual(PedidosDAL.ObtenerUltimoIDTotal().Id_Total_Pedido,total);
        }

        [TestMethod]
        public void TestObtenerUltimoIDFecha()
        {


            int fecha = 1;
            Pedidos pedido = new Pedidos();
            Assert.AreEqual(PedidosDAL.ObtenerUltimoIDFecha().Id_Fecha_Pedido, fecha);
        }

        [TestMethod]
        public void TestObtenerSumaInventario()
        {
            List<int> lista = PedidosDAL.ObtenerSumaInventario();
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void TestLimpiarPedido()
        {
            Assert.AreEqual(PedidosDAL.LimpiarPedido(),1);
        }
    }
}
