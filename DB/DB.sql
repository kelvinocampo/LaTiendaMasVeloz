-- 
DROP DATABASE IF EXISTS TiendaDB;

CREATE DATABASE IF NOT EXISTS TiendaDB;
USE TiendaDB;

DROP TABLE IF EXISTS user;
CREATE TABLE IF NOT EXISTS user(
ID INT PRIMARY KEY AUTO_INCREMENT,
Doc INT NULL,
email VARCHAR(100) NULL,
phone VARCHAR(15) NULL,
name VARCHAR(100) NULL,
address VARCHAR(100) NULL,
role ENUM("Trabajador", "Admin", "Cliente", "Proveedor")
);

DROP TABLE IF EXISTS product;
CREATE TABLE IF NOT EXISTS product(
ID INT PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(100),
stock INT,
price INT,
creationDate DATE
);

-- SP Usuarios
DROP PROCEDURE IF EXISTS ObtenerUsuarios;
DELIMITER //
CREATE PROCEDURE ObtenerUsuarios()
BEGIN
    SELECT 
		ID,
        Doc AS Documento,
        email AS Correo,
        phone AS Telefono,
        name AS Nombre,
        address AS Direccion,
        role AS Rol
    FROM user
	ORDER BY ID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS ObtenerUsuario;
DELIMITER //
CREATE PROCEDURE ObtenerUsuario(IN _ID INT)
BEGIN
    SELECT 
		ID,
        Doc AS Documento,
        email AS Correo,
        phone AS Telefono,
        name AS Nombre,
        address AS Direccion,
		role AS Rol
    FROM user
    WHERE ID = _ID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS EliminarUsuario;
DELIMITER $$
CREATE PROCEDURE EliminarUsuario(IN _ID INT)
BEGIN
    DELETE FROM user WHERE ID = _ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS EditarUsuario;
DELIMITER //
CREATE PROCEDURE EditarUsuario( IN _ID INT, IN _Doc INT, IN _email VARCHAR(100), IN _phone VARCHAR(15), IN _name VARCHAR(100), IN _address VARCHAR(100), IN _role ENUM("Trabajador","Admin","Cliente","Proveedor") ) 
BEGIN 
	UPDATE user 
	SET Doc = _Doc, email = _email, phone = _phone, name = _name, address = _address , role = _role
	WHERE ID = _ID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS CrearUsuario;
DELIMITER //
CREATE PROCEDURE CrearUsuario( IN _Doc INT, IN _email VARCHAR(100), IN _phone VARCHAR(15), IN _name VARCHAR(100), IN _address VARCHAR(100), IN _role ENUM("Trabajador","Admin","Cliente","Proveedor") ) 
BEGIN 
	INSERT INTO user (Doc, email, phone, name, address, role) 
    VALUES (_Doc, _email, _phone, _name, _address, _role);
END //
DELIMITER ;

-- SP Productos
DROP PROCEDURE IF EXISTS ObtenerProductos;
DELIMITER //
CREATE PROCEDURE ObtenerProductos()
BEGIN
    SELECT 
		ID,
        name AS Nombre,
        stock AS Cantidad,
        price AS Precio,
        creationDate AS Fecha_Creacion
    FROM product
	ORDER BY ID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS ObtenerProducto;
DELIMITER //
CREATE PROCEDURE ObtenerProducto(IN _ID INT)
BEGIN
    SELECT 
		ID,
        name AS Nombre,
        stock AS Cantidad,
        price AS Precio,
        creationDate AS Fecha_Creacion
    FROM product
    WHERE ID = _ID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS EliminarProducto;
DELIMITER $$
CREATE PROCEDURE EliminarProducto(IN _ID INT)
BEGIN
    DELETE FROM product WHERE ID = _ID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS EditarProducto;
DELIMITER //
CREATE PROCEDURE EditarProducto( IN _ID INT, IN _name VARCHAR(100), IN _stock INT, IN _price INT, IN _creationDate DATE) 
BEGIN 
	UPDATE product 
	SET name = _name, stock = _stock, price = _price, creationDate = _creationDate
	WHERE ID = _ID;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS CrearProducto;
DELIMITER //
CREATE PROCEDURE CrearProducto( IN _name VARCHAR(100), IN _stock INT, IN _price INT, IN _creationDate DATE) 
BEGIN 
	INSERT INTO product (name, stock, price, creationDate) 
    VALUES (_name, _stock, _price, _creationDate);
END //
DELIMITER ;

-- Inserts
INSERT INTO user (Doc, email, phone, name, address, role) VALUES
(1, 'cliente1@example.com', '1234567890', 'Juan Pérez', 'Calle Falsa 123, Ciudad A', "Trabajador"),
(2, 'cliente2@example.com', '0987654321', 'María López', 'Avenida Siempre Viva 742, Ciudad B', "Admin"),
(3, 'cliente3@example.com', '1122334455', 'Carlos García', 'Boulevard de los Sueños Rotos, Ciudad C', "Cliente"),
(4, 'cliente4@example.com', '2233445566', 'Ana Torres', 'Plaza Mayor 456, Ciudad D', "Proveedor"),
(5, 'cliente5@example.com', '3344556677', 'Luis Fernández', 'Calle de la Amargura 789, Ciudad E', "Cliente");

INSERT INTO product (name, stock, price, creationDate) VALUES
('Bicicleta de montaña', 10, 500, '2023-01-01'),
('Casco de ciclismo', 25, 50, '2023-01-02'),
('Guantes de ciclismo', 30, 20, '2023-01-03'),
('Bomba de aire', 15, 30, '2023-01-04'),
('Kit de parches', 50, 10, '2023-01-05');







