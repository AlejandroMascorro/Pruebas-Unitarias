using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SI_Expendio;
using MySql.Data.MySqlClient;
using System.Data;

namespace UnitTestExpendio

{
    [TestClass]
    public class UnitTestConexion
    {
        [TestMethod]
        public void TestObtenerConexion()
        {
            Conexion conexion = new Conexion();

            Assert.IsNotNull(Conexion.ObtenerConexion());
            Assert.AreEqual(Conexion.Estado, ConnectionState.Open);

        }

        [TestMethod]
        public void TestCerrarConexion()
        {
            Assert.IsNotNull(Conexion.CerrarConexion());
            Assert.AreEqual (Conexion.Estado, ConnectionState.Closed);

        }
    }
}
