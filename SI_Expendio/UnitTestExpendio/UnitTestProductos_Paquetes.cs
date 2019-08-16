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
    public class UnitTestProductos_Paquetes
    {
        [TestMethod]
        public void TestAgregarProductos_Paquetes()
        {
            Productos_paquetes productos_Paquetes = new Productos_paquetes();
            productos_Paquetes.Id_paquete = 1;
            productos_Paquetes.Id_producto = 1;
            Assert.AreEqual(Productos_paquetes.Agregar_productos_paquetes(productos_Paquetes),1);
        }
    }
}
