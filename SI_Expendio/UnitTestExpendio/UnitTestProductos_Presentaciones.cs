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
    public class UnitTestProductos_Presentaciones
    {
        [TestMethod]
        public void TestAgregar()
        {
            Productos_presentaciones pp = new Productos_presentaciones();
            pp.Id_producto = 1;
            pp.Id_presentacion = 1;
            Assert.AreEqual(Productos_presentaciones.Agregar_productos_presentaciones(pp),1);
        }
    }
}
