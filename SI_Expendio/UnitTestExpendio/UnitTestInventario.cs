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
    public class UnitTestInventario
    {
        [TestMethod]
        public void TestInventarioCon6Parametros()
        {
            int id = 1;
            int id_producto = 2;
            int existencia = 3;
            Inventario inventario = new Inventario(id,id_producto,existencia);
            Assert.AreEqual(inventario.Id,id);
            Assert.AreEqual(inventario.productos_id_producto, id_producto);
            Assert.AreEqual(inventario.Existencias, existencia);
        }

        [TestMethod]
        public void TestAgregar()
        {

            Inventario inventario = new Inventario();
            inventario.productos_id_producto = 1;
            inventario.Existencias = 10;
            Assert.AreEqual(InventarioDAL.Agregar(inventario), 1);
        }

        [TestMethod]
        public void TestObtenerProducto()
        {

            Inventario inventario = new Inventario();
            inventario.productos_id_producto = 1;
            inventario.Existencias = 10;
            Assert.IsNotNull(InventarioDAL.ObtenerProducto(1));
            Assert.IsNotNull(InventarioDAL.ObtenerProducto(1).Id);
            Assert.IsNotNull(InventarioDAL.ObtenerProducto(1).Existencias);
        }

    }
}
