using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SI_Expendio;
using MySql.Data.MySqlClient;
using System.Data;

namespace UnitTestExpendio
{
    [TestClass]
    public class UnitTestEmpleado
    {

        [TestMethod]
        public void TestConstructorCon7parametros()
        {
            int id = 1;
            string nombre = "juan";
            string apellido_paterno = "gar";
            string apellido_materno = "gon";
            string fecha_registro = "2019-06-08";
            string rfc = "123456789";
            string nss = "123456789";
            Empleado empleado = new Empleado(id,nombre,apellido_paterno,apellido_materno,fecha_registro,rfc,nss);
            Assert.AreEqual(empleado.Id,id);
            Assert.AreEqual(empleado.Nombre,nombre);
            Assert.AreEqual(empleado.Apelldo_p,apellido_paterno);
            Assert.AreEqual(empleado.Apellido_m,apellido_materno);
            Assert.AreEqual(empleado.Fecha_registro,fecha_registro);
            Assert.AreEqual(empleado.RFC, rfc);
            Assert.AreEqual(empleado.NSS, nss);

        }

        [TestMethod]
        public void TestEliminar()
        {
            Assert.AreEqual(EmpleadoDAL.Eliminar(2), 1);
        }

        [TestMethod]
        public void TestInsertar()
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = "Mascorro";
            empleado.Apelldo_p = "Alex";
            empleado.Apellido_m = "ga";
            empleado.Fecha_registro = "2019-04-06";
            empleado.RFC = "15646481";
            empleado.NSS = "54511515";
            Assert.AreEqual(EmpleadoDAL.Agregar(empleado), 1);
        }

        [TestMethod]
        public void TestObtenerEmpleado()
        {

            int id = 1;
            string nombre = "Mascorro";
            string apellido_paterno = "Alex";
            string apellido_materno = "ga";
            string fecha_registro = "06/04/2019 12:00:00a.m.";
            string rfc = "15646481";
            string nss = "54511515";
            
            Empleado pEmpleado = new Empleado(id,nombre,apellido_paterno,apellido_materno,fecha_registro,rfc,nss);
            Assert.AreEqual(EmpleadoDAL.ObtenerEmpleado(id).Id, pEmpleado.Id);
            Assert.AreEqual(EmpleadoDAL.ObtenerEmpleado(id).Nombre, pEmpleado.Nombre);
            Assert.AreEqual(EmpleadoDAL.ObtenerEmpleado(id).Apelldo_p, pEmpleado.Apelldo_p);
            Assert.AreEqual(EmpleadoDAL.ObtenerEmpleado(id).Apellido_m, pEmpleado.Apellido_m);
            Assert.AreEqual(EmpleadoDAL.ObtenerEmpleado(id).RFC, pEmpleado.RFC);
            Assert.AreEqual(EmpleadoDAL.ObtenerEmpleado(id).NSS, pEmpleado.NSS);

        }
    }
}
