CREATE VIEW 
Productos_Categorias AS
SELECT p.id_producto, p.nombre, p.precio, c.nombre as Categorias
FROM productos as p
inner join categorias as c on p.Categorias_id_categoria = c.id_categoria;


CREATE VIEW 
Productos_Presentaciones_Categorias AS 
SELECT p.id_producto, p.nombre as productos, r.nombre as presentaciones, c.nombre as Categorias, p.Precio_compra, p.Precio_venta
FROM productos_has_presentaciones as x
RIGHT JOIN productos as p on p.id_producto = x.Productos_id_producto
LEFT JOIN presentaciones as r on x.Presentaciones_id_presentacion = r.id_presentacion
INNER JOIN categorias as c on p.Categorias_id_categoria = c.id_categoria;


CREATE VIEW 
Inventario_Productos AS 
SELECT p.id_producto , p.nombre as Productos, r.nombre as presentaciones, c.nombre as Categorias, i.existencias as inventario
FROM productos_has_presentaciones as x
RIGHT JOIN productos as p on x.Productos_id_producto = p.id_producto
LEFT JOIN presentaciones as r on x.Presentaciones_id_presentacion = r.id_presentacion
INNER JOIN categorias as c on p.Categorias_id_categoria = c.id_categoria
LEFT JOIN inventario as i on i.Productos_id_producto = p.id_producto;

CREATE VIEW 
Pedido_prductos AS 
SELECT p.id_producto, p.nombre as productos, r.nombre as presentaciones, i.existencias as inventario, t.Cantidad, s.numero as paquetes, p.Precio_compra, t.Total_compra, p.Precio_venta, t.Total_venta, t.Ganancia as pedidos_productos
FROM productos_has_presentaciones as x
RIGHT JOIN productos as p on p.id_producto = x.Productos_id_producto
LEFT JOIN presentaciones as r on x.Presentaciones_id_presentacion = r.id_presentacion
LEFT JOIN productos_has_paquetes as y on p.id_producto = y.Productos_id_producto
LEFT JOIN paquetes as s on s.id_paquete = y.Paquetes_id_paquete
INNER JOIN categorias as c on c.id_categoria = p.Categorias_id_categoria
INNER JOIN inventario as i on i.Productos_id_producto = p.id_producto
inner join pedidos_productos as t on t.Productos_id_producto = p.id_producto
where c.Nombre = 'Cerveza';
