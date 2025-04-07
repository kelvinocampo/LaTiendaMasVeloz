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

DROP TABLE IF EXISTS worker;
CREATE TABLE IF NOT EXISTS worker(
    user_ID INT PRIMARY KEY,
    FOREIGN KEY (user_ID) REFERENCES user(ID) ON DELETE CASCADE
);

DROP TABLE IF EXISTS admin;
CREATE TABLE IF NOT EXISTS admin(
    user_ID INT PRIMARY KEY,
    FOREIGN KEY (user_ID) REFERENCES user(ID) ON DELETE CASCADE
);

DROP TABLE IF EXISTS client;
CREATE TABLE IF NOT EXISTS client(
    user_ID INT PRIMARY KEY,
    FOREIGN KEY (user_ID) REFERENCES user(ID) ON DELETE CASCADE
);

-- Tabla especializada para Proveedores (sin campos adicionales)
DROP TABLE IF EXISTS supplier;
CREATE TABLE IF NOT EXISTS supplier(
    user_ID INT PRIMARY KEY,
    FOREIGN KEY (user_ID) REFERENCES user(ID) ON DELETE CASCADE
);

DROP TABLE IF EXISTS product;
CREATE TABLE IF NOT EXISTS product(
ID INT PRIMARY KEY AUTO_INCREMENT,
name VARCHAR(100),
stock INT,
price INT,
creationDate DATE
);

-- Tabla FacturaEntrada
CREATE TABLE inputBill (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    supplierID INT NOT NULL, 
    creationDate DATE NOT NULL,
    workerID INT NOT NULL,
    FOREIGN KEY (supplierID) REFERENCES supplier(user_ID),
    FOREIGN KEY (workerID) REFERENCES worker(user_ID)
);

-- Tabla DetalleFacturaEntrada
CREATE TABLE detailsInputBill (
    billID INT NOT NULL, 
    productID INT NOT NULL, 
    quantity INT NOT NULL, 
    price INT,
    PRIMARY KEY (billID, productID),
    FOREIGN KEY (billID) REFERENCES inputBill(ID),
    FOREIGN KEY (productID) REFERENCES product(ID)
);

-- Tabla FacturaSalida
CREATE TABLE outputBill (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    workerID INT NOT NULL,
    clientID INT NOT NULL, 
    creationDate DATE NOT NULL,
    FOREIGN KEY (workerID) REFERENCES worker(user_ID),
    FOREIGN KEY (clientID) REFERENCES client(user_ID)
);

-- Tabla DetalleFacturaSalida
CREATE TABLE detailsOutputBill (
    billID INT NOT NULL, 
    productID INT NOT NULL, 
    quantity INT NOT NULL, 
    price INT, 
    PRIMARY KEY (billID, productID),
    FOREIGN KEY (billID) REFERENCES outputBill(ID),
    FOREIGN KEY (productID) REFERENCES product(ID)
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
	DECLARE new_user_id INT;
	
	INSERT INTO user (Doc, email, phone, name, address, role) 
    VALUES (_Doc, _email, _phone, _name, _address, _role);
    
    SET new_user_id = LAST_INSERT_ID();

    IF _role = 'Trabajador' THEN
        INSERT INTO worker (user_ID) VALUES (new_user_id);
    ELSEIF _role = 'Admin' THEN
        INSERT INTO admin (user_ID) VALUES (new_user_id);
    ELSEIF _role = 'Cliente' THEN
        INSERT INTO client (user_ID) VALUES (new_user_id);
    ELSEIF _role = 'Proveedor' THEN
        INSERT INTO supplier (user_ID) VALUES (new_user_id);
    END IF;
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

--
DROP PROCEDURE IF EXISTS ObtenerDetallesFactura;
DELIMITER //
CREATE PROCEDURE ObtenerDetallesFactura(IN _ID INT, IN _type ENUM("IN","OUT"))
BEGIN
	IF _type = "IN" THEN
		SELECT
			p.name AS Producto, 
			d.quantity AS Cantidad, 
			d.price AS Precio
		FROM detailsInputBill d
		JOIN product p ON p.ID = d.productID
		WHERE d.billID = _ID;
	ELSEIF _type = "OUT" THEN
		SELECT
			p.name AS Producto, 
			d.quantity AS Cantidad, 
			d.price AS Precio
		FROM detailsOutputBill d
		JOIN product p ON p.ID = d.productID
		WHERE d.billID = _ID;
	END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS ObtenerFactura;
DELIMITER //
CREATE PROCEDURE ObtenerFactura(IN _ID INT, IN _type ENUM("IN","OUT"))
BEGIN
	IF _type = "IN" THEN
		SELECT
			"Entrada" AS type,
			(SELECT u.name FROM supplier s JOIN user u ON u.ID = s.user_ID WHERE user_ID = b.supplierID ) AS Proveedor,
            (SELECT u.name FROM worker w JOIN user u ON u.ID = w.user_ID WHERE user_ID = b.workerID) AS Trabajador,
			creationDate AS Fecha_Creacion
		FROM inputBill b
		WHERE b.ID = _ID;
	ELSEIF _type = "OUT" THEN
		SELECT
			"Salida" AS type,
			(SELECT u.name FROM client c JOIN user u ON u.ID = c.user_ID WHERE user_ID = b.clientID ) AS Cliente,
            (SELECT u.name FROM worker w JOIN user u ON u.ID = w.user_ID WHERE user_ID = b.workerID ) AS Trabajador,
			creationDate AS Fecha_Creacion
		FROM outputBill b
		WHERE b.ID = _ID;
	END IF;
END //
DELIMITER ;

-- Inserts
INSERT INTO user (Doc, email, phone, name, address, role) VALUES
(1, 'trabajador1@example.com', '1234567890', 'Juan Pérez', 'Calle Falsa 123, Ciudad A', 'Trabajador'),
(2, 'admin1@example.com', '0987654321', 'María López', 'Avenida Siempre Viva 742, Ciudad B', 'Admin'),
(3, 'cliente1@example.com', '1122334455', 'Carlos García', 'Boulevard de los Sueños Rotos, Ciudad C', 'Cliente'),
(4, 'proveedor1@example.com', '2233445566', 'Ana Torres', 'Plaza Mayor 456, Ciudad D', 'Proveedor'),
(5, 'cliente2@example.com', '3344556677', 'Luis Fernández', 'Calle de la Amargura 789, Ciudad E', 'Cliente'),
(6, 'trabajador2@example.com', '4455667788', 'Pedro Martínez', 'Calle del Sol 101, Ciudad F', 'Trabajador'),
(7, 'cliente3@example.com', '5566778899', 'Sofía Ramírez', 'Calle de la Luna 202, Ciudad G', 'Cliente');

INSERT INTO client (user_ID) VALUES 
(3),  -- Carlos García
(5),  -- Luis Fernández
(7);  -- Sofía Ramírez
INSERT INTO worker (user_ID) VALUES 
(1),  -- Juan Pérez
(6);  -- Pedro Martínez
INSERT INTO supplier (user_ID) VALUES 
(4);  -- Ana Torres
INSERT INTO admin (user_ID) VALUES 
(2);  -- María López

INSERT INTO product (name, stock, price, creationDate) VALUES
('Bicicleta de montaña', 10, 500, '2023-01-01'),
('Casco de ciclismo', 25, 50, '2023-01-02'),
('Guantes de ciclismo', 30, 20, '2023-01-03'),
('Bomba de aire', 15, 30, '2023-01-04'),
('Kit de parches', 50, 10, '2023-01-05'),
('Camiseta de ciclismo', 20, 15, '2023-01-06'),
('Zapatillas de ciclismo', 5, 100, '2023-01-07');

INSERT INTO inputBill (supplierID, creationDate, workerID) VALUES
(4, '2023-01-10', 1),  -- Proveedor: Ana Torres, Trabajador: Juan Pérez
(4, '2023-01-15', 6);  -- Proveedor: Ana Torres, Trabajador: Pedro Martínez
INSERT INTO detailsInputBill (billID, productID, quantity, price) VALUES
(1, 1, 5, 450),  -- Bicicleta de montaña
(1, 2, 10, 45),  -- Casco de ciclismo
(2, 3, 15, 18);  -- Guantes de ciclismo

INSERT INTO outputBill (workerID, clientID, creationDate) VALUES
(1, 3, '2023-01-20'),  -- Trabajador: Juan Pérez, Cliente: Carlos García
(6, 5, '2023-01-25');  -- Trabajador: Pedro Martínez, Cliente: Luis Fernández
INSERT INTO detailsOutputBill (billID, productID, quantity, price) VALUES
(1, 1, 2, 600),  -- Bicicleta de montaña
(1, 2, 5, 55),   -- Casco de ciclismo
(2, 3, 3, 25);   -- Guantes de ciclismo






