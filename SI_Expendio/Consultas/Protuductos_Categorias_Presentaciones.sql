SELECT * FROM productos
inner join productos_has_presentaciones
on productos_has_presentaciones.Productos_id_producto = productos.id_producto
left join presentaciones
on productos_has_presentaciones.Presentaciones_id_presentacion = presentaciones.id_presentacion;

SELECT * FROM productos_has_presentaciones
right join productos
on productos_has_presentaciones.Productos_id_producto = productos.id_producto
inner join categorias
on productos.Categorias_id_categoria = categorias.id_categoria
left join presentaciones
on productos_has_presentaciones.Presentaciones_id_presentacion = presentaciones.id_presentacion;