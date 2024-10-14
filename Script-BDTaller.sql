-- Crear la base de datos
DROP DATABASE IF EXISTS taller;
CREATE DATABASE taller;
USE taller;

CREATE TABLE Marcas (
    idMarca INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100),
    descripcion VARCHAR(255)
);

CREATE TABLE Refacciones (
    codigoBarras VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(100),
    descripcion VARCHAR(255),
    fkIdMarca INT,
    FOREIGN KEY (fkIdMarca) REFERENCES Marcas(idMarca)
);

CREATE TABLE Herramientas (
    codigoHerramienta VARCHAR(20) PRIMARY KEY,
    nombre VARCHAR(100),
    medida VARCHAR(50),
    fkIdMarca INT,
    descripcion VARCHAR(255),
    FOREIGN KEY (fkIdMarca) REFERENCES Marcas(idMarca)
);

DROP TABLE IF EXISTS usuarios;
CREATE TABLE Usuarios (
    idUsuario INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100),
    apellidoP VARCHAR(100),
    apellidoM VARCHAR(50),
    fechaNacimiento DATE,
    RFC VARCHAR(13),
    usuario VARCHAR(100) UNIQUE,
    contrasena VARCHAR(225)
);

CREATE TABLE Formularios (
    idFormulario INT PRIMARY KEY AUTO_INCREMENT,
    nombreFormulario VARCHAR(100)
);

CREATE TABLE Permisos (
    idPermiso INT PRIMARY KEY AUTO_INCREMENT,
    fkIdFormulario INT,
    fkIdUsuario INT,
    Lectura TINYINT(1),
    Escritura TINYINT(1),
    Eliminacion TINYINT(1),
    Actualizacion TINYINT(1),
    FOREIGN KEY (fkIdFormulario) REFERENCES Formularios(idFormulario),
    FOREIGN KEY (fkIdUsuario) REFERENCES Usuarios(idUsuario)
);

DELIMITER //
DROP PROCEDURE if EXISTS p_Validar;
CREATE PROCEDURE p_Validar 
(
	IN _usuario VARCHAR(100),
	IN _contrasena VARCHAR(255)
)
BEGIN
DECLARE x INT;
SELECT COUNT(*) FROM usuarios WHERE Usuario = _usuario AND Contrasena = _contrasena INTO X;

if X > 0 then
	SELECT 'C0rr3ct0' AS rs;
ELSE
	SELECT 'Error' AS rs, 0 AS tipo;
END if;
END //
DELIMITER ;
	

/*LLENADO DE INFORMACIÓN */
INSERT INTO usuarios VALUES (1, 'Manuel', 'Alba', 'Tabares', NULL, NULL, 'admin', SHA1('2004'));

INSERT INTO Marcas (nombre, descripcion)
VALUES
    ('Bosch', 'Líder mundial en herramientas eléctricas y accesorios.'),
    ('Stanley', 'Fabricante de herramientas manuales y equipos de seguridad.'),
    ('Milwaukee', 'Especializada en herramientas eléctricas profesionales.'),
    ('DeWalt', 'Marca reconocida por sus herramientas eléctricas de alto rendimiento.'),
    ('Makita', 'Productor de herramientas eléctricas portátiles y equipos de jardinería.'),
    ('Black+Decker', 'Ofrece una amplia gama de herramientas eléctricas para el hogar y el bricolaje.'),
    ('Irwin', 'Marca especializada en herramientas manuales y de medición.'),
    ('Klein Tools', 'Fabricante de herramientas manuales de alta calidad para electricistas.'),
    ('Crescent', 'Líder en herramientas manuales de alta calidad para profesionales.'),
    ('Snap-on', 'Marca premium conocida por sus herramientas para talleres mecánicos.');

DESCRIBE herramientas;
INSERT INTO Herramientas (codigoHerramienta, nombre, medida, fkIdMarca, descripcion)
VALUES
    ('H001', 'Martillo', '12 pulgadas', 1,'Martillo de carpintero'),
    ('H002', 'Destornillador', 'Phillips', 2,'Destornillador multiusos'),
    ('H003', 'Llave inglesa', '10mm', 3,'Llave ajustable'),
    ('H004', 'Sierra', 'Manual', 4,'Sierra para madera'),
    ('H005', 'Taladro', 'Inalámbrico', 5,'Taladro percutor'),
    ('H006', 'Alicate', 'Universal', 6,'Alicate de punta larga'),
    ('H007', 'Metro', '5 metros', 7,'Cinta métrica'),
    ('H008', 'Nivel', 'Burbuja', 8,'Nivel de burbuja'),
    ('H009', 'Lija', 'Grana 120', 9,'Lija para madera'),
    ('H010', 'Broca', 'Metal', 10,'Juego de brocas para metal');
    
INSERT INTO Refacciones (codigoBarras, nombre, descripcion, fkidmarca)
VALUES
  ('REF001', 'Filtro de aceite', 'Filtro de aceite para motor de gasolina',1),
  ('REF002', 'Bujía', 'Bujía de encendido estándar',1),
  ('REF003', 'Balata de freno', 'Balata de freno delantera',2),
  ('REF004', 'Pastilla de freno', 'Pastilla de freno trasera',3),
  ('REF005', 'Amortiguador', 'Amortiguador delantero',4),
  ('REF006', 'Batería', 'Batería de 12V para automóvil',7),
  ('REF007', 'Manguera de radiador', 'Manguera superior de radiador',8),
  ('REF008', 'Bomba de agua', 'Bomba de agua eléctrica',9),
  ('REF009', 'Sensor de oxígeno', 'Sensor de oxígeno delantero',10),
  ('REF010', 'Escobilla limpiaparabrisas', 'Juego de escobillas delanteras',2),
  ('REF011', 'Filtro de aire', 'Filtro de aire de motor',3),
  ('REF012', 'Bulbo de luz', 'Bulbo de luz H7 para faros',4),
  ('REF013', 'Correa de distribución', 'Correa de distribución para motor 1.6L',6),
  ('REF014', 'Tensor de correa', 'Tensor de correa de distribución',3),
  ('REF015', 'Rodamiento de rueda', 'Rodamiento de rueda delantera',8),
  ('REF016', 'Bujía de precalentamiento', 'Bujía de precalentamiento para diésel',2),
  ('REF017', 'Sensor de temperatura', 'Sensor de temperatura del motor',3),
  ('REF018', 'Bomba de combustible', 'Bomba de combustible eléctrica',5),
  ('REF019', 'Kit de embrague', 'Kit de embrague completo',7),
  ('REF020', 'Retén de aceite', 'Retén de aceite del cigüeñal',8)
;

INSERT INTO `formularios` (`idFormulario`, `nombreFormulario`) VALUES (1, 'Herramientas');
INSERT INTO `formularios` (`idFormulario`, `nombreFormulario`) VALUES (2, 'Productos');
INSERT INTO `formularios` (`idFormulario`, `nombreFormulario`) VALUES (3, 'Marcas');
INSERT INTO `formularios` (`idFormulario`, `nombreFormulario`) VALUES (4, 'Usuarios');



INSERT INTO permisos (fkIdFormulario, fkIdUsuario, Lectura, Escritura, Eliminacion, Actualizacion) VALUES
(1, 1, 1, 1, 1, 1),
(2, 1, 1, 1, 1, 1),
(3, 1, 1, 1, 1, 1),
(4, 1, 1, 1, 1, 1);

/*
DESCRIBE permisos;

SELECT * FROM herramientas;

SELECT idUsuario FROM Usuarios WHERE usuario = 'carlos';

SELECT * FROM usuarios;

UPDATE usuarios SET nombre = 'Jonathan', apellidoP = 'Alba', apellidoM = 'Tabares', fechaNacimiento = '2010-05-13', RFC = 'ABC123' WHERE idUsuario = 7;

UPDATE usuarios SET usuario = 'admin', contrasena = SHA1('2004') WHERE idUsuario = 9;

DESCRIBE refacciones;

SELECT r.codigoBarras, r.nombre, m.idMarca, m.nombre, r.descripcion FROM refacciones r JOIN marcas m WHERE fkIdMarca = IdMarca;

SELECT * FROM refacciones;

UPDATE refacciones SET nombre = 'Retén de aceite', descripcion = 'Retén de aceite compatible para el cigueñal', fkIdMarca = 8 WHERE codigoBarras = 'REF020';
*/