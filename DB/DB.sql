-- 
DROP DATABASE IF EXISTS TiendaDB;

CREATE DATABASE IF NOT EXISTS TiendaDB;
USE TiendaDB;

DROP TABLE IF EXISTS client;
CREATE TABLE IF NOT EXISTS client(
ID INT PRIMARY KEY AUTO_INCREMENT,
Doc INT NULL,
email VARCHAR(100) NULL,
phone VARCHAR(15) NULL,
name VARCHAR(100) NULL,
address VARCHAR(100) NULL
);

DROP TABLE IF EXISTS supplier;
CREATE TABLE IF NOT EXISTS supplier(
ID INT PRIMARY KEY AUTO_INCREMENT,
email VARCHAR(100),
phone VARCHAR(15),
name VARCHAR(100),
description VARCHAR(200),
address VARCHAR(100)
);

DROP TABLE IF EXISTS product;
CREATE TABLE IF NOT EXISTS product(
ID INT PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(100),
address VARCHAR(100),
stock INT,
urlImage VARCHAR(200),
price INT,
creationDate DATE,
id_proveedor INT,
FOREIGN KEY (ID)
REFERENCES supplier(ID)
);

DROP PROCEDURE IF EXISTS ObtenerClientes;
DELIMITER //
CREATE PROCEDURE ObtenerClientes()
BEGIN
    SELECT 
		ID,
        Doc AS Documento,
        email AS Correo,
        phone AS Telefono,
        name AS Nombre,
        address AS Direccion
    FROM client
	ORDER BY ID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS ObtenerCliente;
DELIMITER //
CREATE PROCEDURE ObtenerCliente(IN _ID INT)
BEGIN
    SELECT 
		ID,
        Doc AS Documento,
        email AS Correo,
        phone AS Telefono,
        name AS Nombre,
        address AS Direccion
    FROM client
    WHERE ID = _ID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS EliminarCliente;
DELIMITER $$
CREATE PROCEDURE EliminarCliente(IN _ID INT)
BEGIN
    DELETE FROM client WHERE ID = _ID;
END$$
DELIMITER ;

DELIMITER //
CREATE PROCEDURE EditarCliente( IN _ID INT, IN _Doc INT, IN _email VARCHAR(100), IN _phone VARCHAR(15), IN _name VARCHAR(100), IN _address VARCHAR(100) ) 
BEGIN 
	UPDATE client 
	SET Doc = _Doc, email = _email, phone = _phone, name = _name, address = _address 
	WHERE ID = _ID;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE CrearCliente( IN _Doc INT, IN _email VARCHAR(100), IN _phone VARCHAR(15), IN _name VARCHAR(100), IN _address VARCHAR(100) ) 
BEGIN 
	INSERT INTO client (Doc, email, phone, name, address) 
    VALUES (_Doc, _email, _phone, _name, _address);
END //
DELIMITER ;

INSERT INTO client (Doc, email, phone, name, address) VALUES
(1, 'cliente1@example.com', '1234567890', 'Juan Pérez', 'Calle Falsa 123, Ciudad A'),
(2, 'cliente2@example.com', '0987654321', 'María López', 'Avenida Siempre Viva 742, Ciudad B'),
(3, 'cliente3@example.com', '1122334455', 'Carlos García', 'Boulevard de los Sueños Rotos, Ciudad C'),
(4, 'cliente4@example.com', '2233445566', 'Ana Torres', 'Plaza Mayor 456, Ciudad D'),
(5, 'cliente5@example.com', '3344556677', 'Luis Fernández', 'Calle de la Amargura 789, Ciudad E');

INSERT INTO supplier (email, phone, name, description, address) VALUES
('proveedor1@example.com', '5551234567', 'Proveedores S.A.', 'Distribuidor de productos para ciclistas', 'Calle Proveedor 1, Ciudad F'),
('proveedor2@example.com', '5552345678', 'Ciclismo Total', 'Venta de accesorios y bicicletas', 'Avenida Proveedor 2, Ciudad G'),
('proveedor3@example.com', '5553456789', 'Bicicletas Rápidas', 'Fabricante de bicicletas de alta gama', 'Boulevard Proveedor 3, Ciudad H'),
('proveedor4@example.com', '5554567890', 'Accesorios Ciclísticos', 'Accesorios y repuestos para bicicletas', 'Plaza Proveedor 4, Ciudad I'),
('proveedor5@example.com', '5555678901', 'Ciclismo y Más', 'Tienda de productos para ciclistas', 'Calle Proveedor 5, Ciudad J');

INSERT INTO product (name, address, stock, urlImage, price, creationDate, id_proveedor) VALUES
('Bicicleta de montaña', 'Calle Bicicleta 1', 10, 'http://example.com/bicicleta_montana.jpg', 500, '2023-01-01', 1),
('Casco de ciclismo', 'Calle Casco 2', 25, 'http://example.com/casco_ciclismo.jpg', 50, '2023-01-02', 2),
('Guantes de ciclismo', 'Calle Guantes 3', 30, 'http://example.com/guantes_ciclismo.jpg', 20, '2023-01-03', 3),
('Bomba de aire', 'Calle Bomba 4', 15, 'http://example.com/bomba_aire.jpg', 30, '2023-01-04', 4),
('Kit de parches', 'Calle Kit 5', 50, 'http://example.com/kit_parches.jpg', 10, '2023-01-05', 5);







