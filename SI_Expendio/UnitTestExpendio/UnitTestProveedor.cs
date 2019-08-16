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
   public class UnitTestProveedor
    {
        [TestMethod]
        public void TestConstructorCon6Parametros()
        {
            int id = 1;
            string nombre = "j";
            string apellido = "f";
            string telefono = "123456";
            string correo = "lalala@gmail.com";
            string direccion = "#330 col. lomas ageo";
            Proveedor proveedor = new Proveedor(id,nombre,apellido,telefono,correo,direccion);
            Assert.AreEqual(proveedor.Id, id);
            Assert.AreEqual(proveedor.Nombre,nombre);
            Assert.AreEqual(proveedor.Apellido, apellido);
            Assert.AreEqual(proveedor.Telefono, telefono);
            Assert.AreEqual(proveedor.Correo, correo);
            Assert.AreEqual(proveedor.Direccion, direccion);

        }

        [TestMethod]
        public void TestAgregar()
        {
            //int id = 1;
            string nombre = "j";
            string apellido = "f";
            string telefono = "123456";
            string correo = "lalala@gmail.com";
            string direccion = "#330 col. lomas ageo";
            Proveedor proveedor = new Proveedor();
            proveedor.Nombre = nombre;
            proveedor.Apellido = apellido;
            proveedor.Telefono = telefono;
            proveedor.Correo = correo;
            proveedor.Direccion = direccion;
            Assert.AreEqual(ProveedorDAL.Agregar(proveedor),1);

        }

        //en este metodo comente areEqual con ese assert puedes verificar que los datos que te trae concuerdan con el id
        [TestMethod]
        public void TestObtenerProveedor()
        {
            //int id = 2;
            //string nombre = "j";
            //string apellido = "f";
            //string telefono = "123456";
            //string correo = "lalala@gmail.com";
            //string direccion = "#330 col. lomas ageo";
            Assert.IsNotNull(ProveedorDAL.ObtenerProveedor(2));
            Assert.IsNotNull(ProveedorDAL.ObtenerProveedor(2).Id);
            Assert.IsNotNull(ProveedorDAL.ObtenerProveedor(2).Nombre);
            Assert.IsNotNull(ProveedorDAL.ObtenerProveedor(2).Telefono);
            Assert.IsNotNull(ProveedorDAL.ObtenerProveedor(2).Apellido);
            Assert.IsNotNull(ProveedorDAL.ObtenerProveedor(2).Correo);
            Assert.IsNotNull(ProveedorDAL.ObtenerProveedor(2).Direccion);
            //Assert.AreEqual(ProveedorDAL.ObtenerProveedor(2).Id, id);
            //Assert.AreEqual(ProveedorDAL.ObtenerProveedor(2).Nombre, nombre);
            //Assert.AreEqual(ProveedorDAL.ObtenerProveedor(2).Apellido, apellido);
            //Assert.AreEqual(ProveedorDAL.ObtenerProveedor(2).Telefono, telefono);
            //Assert.AreEqual(ProveedorDAL.ObtenerProveedor(2).Correo, correo);
            //Assert.AreEqual(ProveedorDAL.ObtenerProveedor(2).Direccion, direccion);

        }

        
        [TestMethod]
        public void TestEliminar()
        {
            int id = 4;

            Assert.AreEqual(ProveedorDAL.Eliminar(id), 0);

        }

    }
}
