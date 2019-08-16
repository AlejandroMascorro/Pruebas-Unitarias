using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SI_Expendio
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
            label43.SetBounds(229, 33, 168, 57);
        }
        public Empleado EmpleadoSeleccionado { get; set; }
        public Proveedor ProveedorSelecionado { get; set; }
        public Inventario InventarioSeleccionado { get; set; }
        public Pedidos_productos PedidoProductoSelect { get; set; }

        Llenar_tablas llenar = new Llenar_tablas();

        public void ActualizarComboBoxProductos()
        {
            try
            {
                cbx_provedores.Text = "Selecciona el proveedor";
                cbx_provedores.Items.Clear();
                Conexion.ObtenerConexion();
                MySqlCommand comando = new MySqlCommand("Select Nombre, Apellidos from proveedores order by id_proveedor asc;", Conexion.ObtenerConexion());
                MySqlDataReader almacena = comando.ExecuteReader();
                while (almacena.Read())
                {
                    cbx_provedores.Refresh();
                    cbx_provedores.Items.Add(almacena.GetValue(0).ToString() + " " + almacena.GetValue(1));
                }

                cbx_categorias.Text = "Selecciona una categoria";
                cbx_categorias.Items.Clear();
                Conexion.ObtenerConexion();
                MySqlCommand catego = new MySqlCommand("Select Nombre from Categorias order by id_categoria asc", Conexion.ObtenerConexion());
                MySqlDataReader almacena_Cat = catego.ExecuteReader();
                while (almacena_Cat.Read())
                {
                    cbx_categorias.Refresh();
                    cbx_categorias.Items.Add(almacena_Cat.GetValue(0).ToString());
                }

                cbx_presentacion.Text = "Litros / Mililitros";
                cbx_presentacion.Items.Clear();
                Conexion.ObtenerConexion();
                MySqlCommand pres = new MySqlCommand("Select Nombre from Presentaciones order by id_presentacion asc", Conexion.ObtenerConexion());
                MySqlDataReader almacena_pres = pres.ExecuteReader();
                while (almacena_pres.Read())
                {
                    cbx_presentacion.Refresh();
                    cbx_presentacion.Items.Add(almacena_pres.GetValue(0).ToString());
                }

                cbx_paquete.Text = "Selecciona una presentacion";
                cbx_paquete.Items.Clear();
                Conexion.ObtenerConexion();
                MySqlCommand paquetes = new MySqlCommand("Select Numero from paquetes order by id_paquete asc", Conexion.ObtenerConexion());
                MySqlDataReader almacen_paquete = paquetes.ExecuteReader();
                while (almacen_paquete.Read())
                {
                    cbx_paquete.Refresh();
                    cbx_paquete.Items.Add(almacen_paquete.GetValue(0).ToString());
                }
                Conexion.CerrarConexion();
            }
            catch (MySqlException r)
            {
                MessageBox.Show("ERROR en conexion a Base de Datos. ComboBox vacios.");
            }
        }

        private void registrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_pedidos.Visible = false;
            panel_inventario.Visible = false;
            panel_productos.Visible = false;
            panel_empleados.Visible = false;
            panel_proveedores.Visible = true;
            llenar.GridView_proveedores(dgv_proveedores);
        }

        private void registrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_pedidos.Visible = false;
            panel_inventario.Visible = false;
            panel_proveedores.Visible = false;
            panel_empleados.Visible = false;
            panel_productos.Visible = true;
            cbx_presentacion.Visible = false;
            lbl_contenidoNet.Visible = false;
            cbx_paquete.Visible = false;
            lbl_presentacion.Visible = false;
            llenar.GridView_productos(dgv_productos);
            ActualizarComboBoxProductos();
        }
        
        public void Limpiar()
        {
            nombre_prod_txt.Text = "";
            precio_compra_txt.Text = "";
            cbx_categorias.Text = "Selecciona una categoria";
            cbx_provedores.Text = "Selecciona un proveedor";

            nombre_emp_txt.Text = "";
            ap_empleado_txt.Text = "";
            am_empleado_txt.Text = "";
            dtpFecha_Reg.Text = dtpFecha_Reg.Value.Date.ToString();
            rfc_empleado_txt.Text = "";
            nss_empleado_txt.Text = "";

            nombre_emp_act.Text = "";
            ap_emp_act.Text = "";
            am_emp_act.Text = "";
            rfc_emp_act.Text = "";
            nss_emp_act.Text = "";

            nombre_prov_txt.Text = "";
            apellido_prov_txt.Text = "";
            telefono_prov_txt.Text = "";
            correo_prov_txt.Text = "";
            direccion_prov_txt.Text = "";
            
        }

        public void EsconderIconosInventario()
        {
            pbx_inventario.Visible = true;
            lbl_inventario.Visible = true;
            pictureBox9.Visible = true;
            label39.Visible = true;
            lbl_cantidad_inventario.Visible = false;
            lbl_ok.Visible = false;
            lbl_cancel.Visible = false;
            pbx_ok_inventario.Visible = false;
            pbx_cancel_inventario.Visible = false;
            cantidad_txt.Visible = false;
        }

        public void SumarTotalPedido()
        {
            double sumatoria = 0;
            foreach (DataGridViewRow row in dgv_pedidos.Rows)
            {
                sumatoria += Convert.ToDouble(row.Cells[7].Value);
            }
            Total_pedido_txt.Text = sumatoria.ToString();
            cantidad_piezas_txt.Text = "";
        }

        public void SumarGanaciaPedido()
        {
            double sumatoria_compra = 0;
            foreach (DataGridViewRow row in dgv_pedidos.Rows)
            {
                sumatoria_compra += Convert.ToDouble(row.Cells[7].Value);
            }

            double sumatoria_venta = 0;
            foreach (DataGridViewRow row in dgv_pedidos.Rows)
            {
                sumatoria_venta += Convert.ToDouble(row.Cells[9].Value);
            }
            double sumatoria_ganancia = sumatoria_venta - sumatoria_compra;
            total_ganancia_txt.Text = sumatoria_ganancia.ToString();
        }

        private void btn_agregar_prod_Click(object sender, EventArgs e)
        {
            int categoria = cbx_categorias.SelectedIndex + 1;
            int proveedor = cbx_provedores.SelectedIndex + 1;
            int presentacion = cbx_presentacion.SelectedIndex + 1;
            int paquete = cbx_paquete.SelectedIndex + 1;
            double precio_compra = double.Parse(precio_compra_txt.Text.Trim());
            double precio_venta = double.Parse(precio_venta_txt.Text.Trim());

            //try
            //{
                Inventario pInventario = new Inventario();
                Producto pProducto = new Producto();
                Productos_presentaciones pPP = new Productos_presentaciones();
                Productos_paquetes pPack = new Productos_paquetes();
                Pedidos_productos pPed_Prod = new Pedidos_productos();
                int id_ultimo = Convert.ToInt32(ProductoDAL.ObtenerUltimoIDProducto().Id_producto_ultimo);

                pProducto.Nombre = nombre_prod_txt.Text.Trim();
                //pProducto.Precio_compra = precio_compra;
                //pProducto.Precio_venta = precio_venta;
                pProducto.Categoria = categoria;
                pProducto.Proveedor = proveedor;
                int insert_producto = ProductoDAL.Agregar(pProducto); //AGREGAR PRODUCTO
            
                pPP.Id_producto = id_ultimo;
                pPP.Id_presentacion = presentacion; //AGREGAR CONTENIDO NETO FK

                pPack.Id_producto = id_ultimo;
                pPack.Id_paquete = paquete;        //AGREGARR PAQUETE FK

                pInventario.productos_id_producto = id_ultimo;
                pInventario.Existencias = Int32.Parse(existencias_txt.Text.Trim()); //AGREGAR INVENTARIO FK
                
                pPed_Prod.Id_Producto = id_ultimo; //AGREGAR PRODUCTO A PEDIDOS FK
            
                int inset_invent = InventarioDAL.Agregar(pInventario);
                int inset_pedidos_productos = Pedidos_productosDAL.Agregar_producto(pPed_Prod);

            if (insert_producto > 0 && inset_invent > 0 && inset_pedidos_productos > 0)
                {
                    MessageBox.Show("Producto Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenar.GridView_productos(dgv_productos);
                    Limpiar();

                if (cbx_categorias.SelectedIndex == 0 || cbx_categorias.SelectedIndex == 1 || cbx_categorias.SelectedIndex == 2)
                {
                    int insert_prodcuto_pesent = Productos_presentaciones.Agregar_productos_presentaciones(pPP);
                    int insert_producto_paquete = Productos_paquetes.Agregar_productos_paquetes(pPack);
                        if (insert_prodcuto_pesent > 0 && insert_producto_paquete > 0)
                        {
                            MessageBox.Show("Producto con Presentacion Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            llenar.GridView_productos(dgv_productos);
                            ActualizarComboBoxProductos();
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el Producto con Presentacion", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ActualizarComboBoxProductos();
                            llenar.GridView_productos(dgv_productos);
                        }
                    }
                }

                else
                {
                    MessageBox.Show("No se pudo guardar el Producto Normal", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ActualizarComboBoxProductos();
                    llenar.GridView_productos(dgv_productos);
                }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("ERROR. Completa los campos correspondientes");
            //}
        }

        private void btn_agregar_cat_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.Show();
        }

        private void cbx_categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_categorias.SelectedIndex == 0 || cbx_categorias.SelectedIndex == 1 || cbx_categorias.SelectedIndex == 2)
            {
                cbx_presentacion.Visible = true;
                lbl_contenidoNet.Visible = true;
                pbx_add_pres.Visible = true;
                cbx_paquete.Visible = true;
                lbl_presentacion.Visible = true;

            }
            else
            {
                cbx_presentacion.Visible = false;
                lbl_contenidoNet.Visible = false;
                cbx_paquete.Visible = false;
                lbl_presentacion.Visible = false;
                pbx_add_pres.Visible = false;
            }
        }

        private void consultarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_pedidos.Visible = false;
            panel_empleados.Visible = false;
            panel_proveedores.Visible = false;
            panel_productos.Visible = false;
            panel_inventario.Visible = true;
            llenar.GridView_inventario(dgv_inventario);
        }

        private void registrarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_pedidos.Visible = false;
            panel_inventario.Visible = false;
            panel_productos.Visible = false;
            panel_proveedores.Visible = false;
            panel_empleados.Visible = true;
            llenar.GridView_empleados(dgv_empleados);
            Limpiar();
        }

        private void pbx_guardar_empleado_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado pEmpleado = new Empleado();
                pEmpleado.Nombre = nombre_emp_txt.Text.Trim();
                pEmpleado.Apelldo_p = ap_empleado_txt.Text.Trim();
                pEmpleado.Apellido_m = am_empleado_txt.Text.Trim();
                pEmpleado.Fecha_registro = dtpFecha_Reg.Value.Year + "/" + dtpFecha_Reg.Value.Month + "/" + dtpFecha_Reg.Value.Day;

                if (nombre_emp_txt.Text == "" || ap_empleado_txt.Text == "" || am_empleado_txt.Text == "" || dtpFecha_Reg.Text == "")
                {
                    MessageBox.Show("ERROR. Complete todos los campos");
                }
                else
                {
                    int resultado = EmpleadoDAL.Agregar(pEmpleado);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Empleado Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        llenar.GridView_empleados(dgv_empleados);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar registro de empleado", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR. Llena los campos correspondientes");
            }
        }

        private void pbx_cancelar_empleado_Click(object sender, EventArgs e)
        {
            panel_registrar_empleado.Visible = false;
            panel_opc_empleados.Visible = true;
            Limpiar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel_modificar_empleado.Visible = false;
            panel_registrar_empleado.Visible = true;
            Limpiar();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel_modificar_empleado.Visible = false;
            Limpiar();
        }

        private void pbx_mdf_emp_Click(object sender, EventArgs e)
        {
            try
            {
                string Actualizar = "UPDATE empleados set id_empleado=@id, nombre=@nombre, apellido_p=@apellido_p, apellido_m=@apellido_m, rfc=@rfc, nss=@nss WHERE id_empleado=@id";
                MySqlCommand cdm = new MySqlCommand(Actualizar, Conexion.ObtenerConexion());
                int id = Convert.ToInt32(dgv_empleados.CurrentRow.Cells[0].Value);
                cdm.Parameters.AddWithValue("@id", id);
                cdm.Parameters.AddWithValue("@nombre", nombre_emp_act.Text);
                cdm.Parameters.AddWithValue("@apellido_p", ap_emp_act.Text);
                cdm.Parameters.AddWithValue("@apellido_m", am_emp_act.Text);
                cdm.Parameters.AddWithValue("@rfc", rfc_emp_act.Text);
                cdm.Parameters.AddWithValue("@nss", nss_emp_act.Text);
                cdm.ExecuteNonQuery();
                Conexion.CerrarConexion();
                MessageBox.Show("Datos actualizados con exito !!");
                Limpiar();
                llenar.GridView_empleados(dgv_empleados);
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR. Llena los campos correspondientes");
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            try {
            if (dgv_empleados.SelectedRows.Count == 1)
            {
                panel_modificar_empleado.Visible = true;
                panel_registrar_empleado.Visible = false;
                int id = Convert.ToInt32(dgv_empleados.CurrentRow.Cells[0].Value);
                nombre_emp_act.Text = EmpleadoDAL.ObtenerEmpleado(id).Nombre;
                ap_emp_act.Text = EmpleadoDAL.ObtenerEmpleado(id).Apelldo_p;
                am_emp_act.Text = EmpleadoDAL.ObtenerEmpleado(id).Apellido_m;
                rfc_emp_act.Text = EmpleadoDAL.ObtenerEmpleado(id).RFC;
                nss_emp_act.Text = EmpleadoDAL.ObtenerEmpleado(id).NSS;
            }
            else
            {
                MessageBox.Show("Seleccione un registro para modificar.");
            }
                }
            catch (Exception)
            {
                MessageBox.Show("ERROR. Llena los campos correspondientes");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                if (nombre_prov_txt.Text == "" || apellido_prov_txt.Text == "" || telefono_prov_txt.Text == "")
                {
                    MessageBox.Show("ERROR. Llena los cmapos correspondientes");
                }
                else {
                    Proveedor pProveedor = new Proveedor();
                    pProveedor.Nombre = nombre_prov_txt.Text.Trim();
                    pProveedor.Apellido = apellido_prov_txt.Text.Trim();
                    pProveedor.Telefono = telefono_prov_txt.Text.Trim();
                    pProveedor.Correo = correo_prov_txt.Text.Trim();
                    pProveedor.Direccion = direccion_prov_txt.Text.Trim();
                    int resultado = ProveedorDAL.Agregar(pProveedor);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Proveedor Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        llenar.GridView_proveedores(dgv_proveedores);
                        panel_registrar_prov.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el Proveedor", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("ERROR. Llena los campos correspondientes");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Limpiar();
            panel_registrar_prov.Visible = true;
            pbx_guardar_prov.Visible = true;
            pbx_actualizar_prov.Visible = false;
            label29.Visible = true;
            label36.Visible = false;
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            panel_registrar_prov.Visible = false;
            Limpiar();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (dgv_proveedores.SelectedRows.Count == 1)
            {
                panel_registrar_prov.Visible = true;
                pbx_guardar_prov.Visible = false;
                label36.Visible = true;
                label29.Visible = false;
                pbx_actualizar_prov.Visible = true;
                int id = Convert.ToInt32(dgv_proveedores.CurrentRow.Cells[0].Value);
                ProveedorSelecionado = ProveedorDAL.ObtenerProveedor(id);
                nombre_prov_txt.Text = ProveedorDAL.ObtenerProveedor(id).Nombre;
                apellido_prov_txt.Text = ProveedorDAL.ObtenerProveedor(id).Apellido;
                telefono_prov_txt.Text = ProveedorDAL.ObtenerProveedor(id).Telefono;
                correo_prov_txt.Text = ProveedorDAL.ObtenerProveedor(id).Correo;
                direccion_prov_txt.Text = ProveedorDAL.ObtenerProveedor(id).Direccion;
            }

            else
            {
                MessageBox.Show("Seleccione un registro para modificar.");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try {
            if (dgv_proveedores.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgv_proveedores.CurrentRow.Cells[0].Value);
                int eliminado = ProveedorDAL.Eliminar(id);
                MessageBox.Show("Registro eliinado correctamente");
                Limpiar();
                llenar.GridView_proveedores(dgv_proveedores);
            }
            else
            {
                MessageBox.Show("Error al eliminar registro");
            }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR. Al conectar a la Base de Datos");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try {
                if (nombre_prov_txt.Text == "" || apellido_prov_txt.Text == "" || telefono_prov_txt.Text == "")
                {
                    MessageBox.Show("ERROR. Llene los campos correpondientes.");
                }
                else {
                    string Actualizar = "UPDATE proveedores set id_proveedor=@id, nombre=@nombre, apellidos=@apellidos, telefono=@telefono, correo=@correo, direccion=@direccion WHERE id_proveedor=@id";
                    MySqlCommand cdm = new MySqlCommand(Actualizar, Conexion.ObtenerConexion());
                    int id = Convert.ToInt32(dgv_empleados.CurrentRow.Cells[0].Value);
                    cdm.Parameters.AddWithValue("@id", id);
                    cdm.Parameters.AddWithValue("@nombre", nombre_prov_txt.Text);
                    cdm.Parameters.AddWithValue("@apellidos", apellido_prov_txt.Text);
                    cdm.Parameters.AddWithValue("@telefono", telefono_prov_txt.Text);
                    cdm.Parameters.AddWithValue("@correo", correo_prov_txt.Text);
                    cdm.Parameters.AddWithValue("@direccion", direccion_prov_txt.Text);

                    cdm.ExecuteNonQuery();
                    Conexion.CerrarConexion();
                    MessageBox.Show("Datos actualizados con exito !!");
                    Limpiar();
                    llenar.GridView_proveedores(dgv_proveedores);
                    panel_registrar_prov.Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR. Llena los campos correspondientes");
            }
        }

        private void pbx_elim_emp_Click(object sender, EventArgs e)
        {
            try {
                if (dgv_empleados.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt32(dgv_empleados.CurrentRow.Cells[0].Value);
                    int eliminado = EmpleadoDAL.Eliminar(id);
                    MessageBox.Show("Registro eliinado correctamente");
                    llenar.GridView_empleados(dgv_empleados);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al eliminar registro");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR. Elimine primero el usuario asignado al empleado");
            }
        }

        private void pbx_add_pres_Click(object sender, EventArgs e)
        {
            Presentacion presentacion = new Presentacion();
            presentacion.Show();
        }

        private void pbx_inventario_Click(object sender, EventArgs e)
        {
            if (dgv_inventario.SelectedRows.Count == 1)
            {
                label39.Visible = false;
                pictureBox9.Visible = false;
                pbx_inventario.Visible = false;
                lbl_inventario.Visible = false;
                lbl_cantidad_inventario.Visible = true;
                lbl_ok.Visible = true;
                lbl_cancel.Visible = true;
                pbx_ok_inventario.Visible = true;
                pbx_cancel_inventario.Visible = true;
                cantidad_txt.Visible = true;
                int id = Convert.ToInt32(dgv_inventario.CurrentRow.Cells[0].Value);

                InventarioSeleccionado = InventarioDAL.ObtenerProducto(id);
                cantidad_txt.Text = InventarioDAL.ObtenerProducto(id).Existencias.ToString();
            }
            else
            {
                MessageBox.Show("Selecciona un producto para modificar");
            }
        }

        private void pbx_cancel_inventario_Click(object sender, EventArgs e)
        {
            EsconderIconosInventario();
        }

        private void pbx_ok_inventario_Click_1(object sender, EventArgs e)
        {
            string Actualizar = "UPDATE Inventario set id_inventario=@id, existencias=@existencias WHERE id_inventario=@id";
            MySqlCommand cdm = new MySqlCommand(Actualizar, Conexion.ObtenerConexion());
            int id = Convert.ToInt32(dgv_inventario.CurrentRow.Cells[0].Value);
            cdm.Parameters.AddWithValue("@id", id);
            cdm.Parameters.AddWithValue("@existencias", cantidad_txt.Text);
            cdm.ExecuteNonQuery();
            Conexion.CerrarConexion();
            MessageBox.Show("Datos actualizados con exito !!");
            llenar.GridView_inventario(dgv_inventario);
            EsconderIconosInventario();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            cat.Show();
        }

        private void crearPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_inventario.Visible = false;
            panel_productos.Visible = false;
            panel_empleados.Visible = false;
            panel_proveedores.Visible = false;
            panel_pedidos.Visible = true;
            llenar.GridView_pedido(dgv_pedidos);
        }

        private void pbx_modificar_pedido_Click(object sender, EventArgs e)
        {
            if (dgv_pedidos.SelectedRows.Count == 1)
            {
                dgv_pedidos.SetBounds(304, 95, 936, 399);
                label43.SetBounds(300, 32, 168, 57);
                panel_opc_pedidos.Visible = false;
                panel_modif_pedidos.Visible = true;
                int id = Convert.ToInt32(dgv_pedidos.CurrentRow.Cells[0].Value);

                PedidoProductoSelect = Pedidos_productosDAL.ObtenerProducto(id);
                cantidad_piezas_txt.Text = Pedidos_productosDAL.ObtenerProducto(id).Cantidad.ToString();
            }
            else
            {
                MessageBox.Show("Selecciona un producto para modificar");
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (cantidad_piezas_txt.Text == "")
                {
                    MessageBox.Show("ERROR. No puede dejar en blanco la cantidad de pieza");
                }
                else
                {
                    int id = Convert.ToInt32(dgv_pedidos.CurrentRow.Cells[0].Value);
                    string Actualizar = "UPDATE pedidos_productos set Cantidad=@Cantidad WHERE id_pedido_producto=@id";
                    MySqlCommand cdm = new MySqlCommand(Actualizar, Conexion.ObtenerConexion());
                    cdm.Parameters.AddWithValue("@id", id);
                    cdm.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(cantidad_piezas_txt.Text));
                    cdm.ExecuteNonQuery();
                    Conexion.CerrarConexion();

                    double Total_compra = Pedidos_productosDAL.TotalPrecioCompra(id).Total_compra;
                    double Total_venta = Pedidos_productosDAL.TotalPrecioVenta(id).Total_Venta;

                string Actualizar_total_compra = "UPDATE pedidos_productos set total_compra=@Total_compra WHERE id_pedido_producto=@id";
                    MySqlCommand cdm_total_compra = new MySqlCommand(Actualizar_total_compra, Conexion.ObtenerConexion());
                    cdm_total_compra.Parameters.AddWithValue("@id", id);
                    cdm_total_compra.Parameters.AddWithValue("@Total_compra", Total_compra);
                    cdm_total_compra.ExecuteNonQuery();

                string Actualizar_total_venta = "UPDATE pedidos_productos set total_venta=@Total_venta WHERE id_pedido_producto=@id";
                MySqlCommand cdm_total_venta = new MySqlCommand(Actualizar_total_venta, Conexion.ObtenerConexion());
                cdm_total_venta.Parameters.AddWithValue("@id", id);
                cdm_total_venta.Parameters.AddWithValue("@Total_venta", Total_venta);
                cdm_total_venta.ExecuteNonQuery();

                double Ganancia = Pedidos_productosDAL.TotalGanancia(id).Ganancia;
                string Actualizar_ganancia = "UPDATE pedidos_productos set ganancia=@Ganancia WHERE id_pedido_producto=@id";
                MySqlCommand cdm_ganancia = new MySqlCommand(Actualizar_ganancia, Conexion.ObtenerConexion());
                cdm_ganancia.Parameters.AddWithValue("@id", id);
                cdm_ganancia.Parameters.AddWithValue("@Ganancia", Ganancia);
                cdm_ganancia.ExecuteNonQuery();

                Conexion.CerrarConexion();
                    MessageBox.Show("Datos actualizados con exito !!");
                    llenar.GridView_pedido(dgv_pedidos);
                    panel_modif_pedidos.Visible = false;
                    panel_opc_pedidos.Visible = true;
                    SumarTotalPedido();
                    SumarGanaciaPedido();
            }
        //}
        //    catch (Exception)
        //    {
        //        MessageBox.Show("ERROR. Llena los campos correspondientes");
        //    }
}


        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            cantidad_piezas_txt.Text = "";
            panel_modif_pedidos.Visible = false;
            panel_opc_pedidos.Visible = true;
        }

        private void pictureBox4_Click_2(object sender, EventArgs e)
        {
            panel_modif_pedidos.Visible = false;
            panel_opc_pedidos.Visible = true;
            dgv_pedidos.SetBounds(239, 95,1001, 399);
            label43.SetBounds(229, 33, 168, 57);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            dgv_pedidos.SetBounds(256, 95, 984, 399);
        }

        private void pbx_guardar_pedido_Click(object sender, EventArgs e)
        {
            try
            {
                Pedidos pPedidos = new Pedidos();
                PedidosDAL pedidoAcc = new PedidosDAL();
                pPedidos.Total_Pedido = Convert.ToDouble(Total_pedido_txt.Text.Trim());
                int insert_total = PedidosDAL.InsertarTotal(pPedidos);

                pPedidos.Fecha_Pedido = dtp_pedidos.Value.Year + "/" + dtp_pedidos.Value.Month + "/" + dtp_pedidos.Value.Day;
                int insert_fecha = PedidosDAL.InsertarFecha(pPedidos);

                int id_totallast = PedidosDAL.ObtenerUltimoIDTotal().Id_Total_Pedido;
                pPedidos.Id_Total_Pedido = id_totallast;

                int id_fechalast = PedidosDAL.ObtenerUltimoIDFecha().Id_Fecha_Pedido;
                pPedidos.Id_Fecha_Pedido = id_fechalast;
                pPedidos.Id_Usuario_Pedido = 1;
                PedidosDAL.Agregar(pPedidos);

                PedidosDAL.LimpiarPedido();
                MessageBox.Show("Pedido Generado con exito");
                Conexion.CerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR. Comprueba que todos los datos son correctos");
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            panel_reg_prod.Visible = false;
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            panel_reg_prod.Visible = true;
        }
    }

}
