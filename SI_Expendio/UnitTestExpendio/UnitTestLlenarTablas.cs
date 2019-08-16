using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SI_Expendio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Data;
using SI_Expendio;

namespace UnitTestExpendio
{
    [TestClass]
    public class UnitTestLlenarTablas
    {
        [TestMethod]
        public void TestLlenarDGVProveedores()
        {
            Llenar_tablas llenar = new Llenar_tablas();
            DataGridView dataGrid = new DataGridView();
            DataTable dataTable = llenar.GridView_proveedores(dataGrid);
            DataRow fila = dataTable.Rows[0];
            Assert.IsNotNull(fila["id_proveedor"]);
            Assert.IsNotNull(fila["Nombre"]);
            Assert.IsNotNull(fila["Apellidos"]);
            Assert.IsNotNull(fila["Telefono"]);
            Assert.IsNotNull(fila["Correo"]);
            Assert.IsNotNull(fila["Direccion"]);
        }

        [TestMethod]
        public void TestLlenarDGVEmpleados()
        {
            Llenar_tablas llenar = new Llenar_tablas();
            DataGridView dataGrid = new DataGridView();
            DataTable dataTable = llenar.GridView_empleados(dataGrid);
            DataRow fila = dataTable.Rows[0];
            Assert.IsNotNull(fila["id_empleado"]);
            Assert.IsNotNull(fila["Nombre"]);
            Assert.IsNotNull(fila["Apellido_p"]);
            Assert.IsNotNull(fila["Apellido_m"]);
            Assert.IsNotNull(fila["Fecha_registro"]);
            Assert.IsNotNull(fila["RFC"]);
            Assert.IsNotNull(fila["NSS"]);
        }

        [TestMethod]
        public void TestLlenarDGVProductos()
        {
            Llenar_tablas llenar = new Llenar_tablas();
            DataGridView dataGrid = new DataGridView();
            DataTable dataTable = llenar.GridView_productos(dataGrid);
            DataRow fila = dataTable.Rows[0];
            Assert.IsNotNull(fila["id_producto"]);
            Assert.IsNotNull(fila["productos"]);
            Assert.IsNotNull(fila["presentaciones"]);
            Assert.IsNotNull(fila["categorias"]);
            Assert.IsNotNull(fila["precio_compra"]);
            Assert.IsNotNull(fila["precio_venta"]);
        }

        [TestMethod]
        public void TestLlenarDGVInventario()
        {
            Llenar_tablas llenar = new Llenar_tablas();
            DataGridView dataGrid = new DataGridView();
            DataTable dataTable = llenar.GridView_inventario(dataGrid);
            DataRow fila = dataTable.Rows[0];
            Assert.IsNotNull(fila["id_producto"]);
            Assert.IsNotNull(fila["productos"]);
            Assert.IsNotNull(fila["presentaciones"]);
            Assert.IsNotNull(fila["categorias"]);
            Assert.IsNotNull(fila["inventario"]);
        }

        [TestMethod]
        public void TestLlenarDGVPedido()
        {
            Llenar_tablas llenar = new Llenar_tablas();
            DataGridView dataGrid = new DataGridView();
            DataTable dataTable = llenar.GridView_pedido(dataGrid);
            DataRow fila = dataTable.Rows[0];
            Assert.IsNotNull(fila["id_producto"]);
            Assert.IsNotNull(fila["productos"]);
            Assert.IsNotNull(fila["presentaciones"]);
            Assert.IsNotNull(fila["inventario"]);
            Assert.IsNotNull(fila["cantidad"]);
            Assert.IsNotNull(fila["paquetes"]);
            Assert.IsNotNull(fila["Precio_compra"]);
            Assert.IsNotNull(fila["Total_compra"]);
            Assert.IsNotNull(fila["Precio_venta"]);
            Assert.IsNotNull(fila["Total_venta"]);
            Assert.IsNotNull(fila["pedidos_productos"]);
        }
    }
}
