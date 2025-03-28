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
role ENUM("Trabajador","Admin","Cliente","Proveedor")
);

DROP TABLE IF EXISTS product;
CREATE TABLE IF NOT EXISTS product(
ID INT PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(100),
address VARCHAR(100),
stock INT,
price INT,
creationDate DATE,
id_proveedor INT,
FOREIGN KEY (ID)
REFERENCES user(ID)
);

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

INSERT INTO user (Doc, email, phone, name, address, role) VALUES
(1, 'cliente1@example.com', '1234567890', 'Juan Pérez', 'Calle Falsa 123, Ciudad A', "Trabajador"),
(2, 'cliente2@example.com', '0987654321', 'María López', 'Avenida Siempre Viva 742, Ciudad B', "Admin"),
(3, 'cliente3@example.com', '1122334455', 'Carlos García', 'Boulevard de los Sueños Rotos, Ciudad C', "Cliente"),
(4, 'cliente4@example.com', '2233445566', 'Ana Torres', 'Plaza Mayor 456, Ciudad D', "Proveedor"),
(5, 'cliente5@example.com', '3344556677', 'Luis Fernández', 'Calle de la Amargura 789, Ciudad E', "Cliente");

INSERT INTO product (name, address, stock, price, creationDate, id_proveedor) VALUES
('Bicicleta de montaña', 'Calle Bicicleta 1', 10, 500, '2023-01-01', 1),
('Casco de ciclismo', 'Calle Casco 2', 25, 50, '2023-01-02', 2),
('Guantes de ciclismo', 'Calle Guantes 3', 30, 20, '2023-01-03', 3),
('Bomba de aire', 'Calle Bomba 4', 15, 30, '2023-01-04', 4),
('Kit de parches', 'Calle Kit 5', 50, 10, '2023-01-05', 5);







