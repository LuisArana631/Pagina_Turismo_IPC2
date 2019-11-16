CREATE DATABASE Proyecto_201700988
GO

USE Proyecto_201700988
GO

CREATE TABLE Region(
	ID INT IDENTITY(1,1),
	PRIMARY KEY(ID),
	Nombre VARCHAR(50) NOT NULL
)

CREATE TABLE Sitio_Turistico(
	ID INT IDENTITY(1,1),
	PRIMARY KEY(ID),
	Nombre VARCHAR(50) NOT NULL,
	Descripcion TEXT,
	ID_Region INT,
	FOREIGN KEY(ID_Region) REFERENCES Region(ID)
)

CREATE TABLE Foto_Sitio(
	ID INT IDENTITY(1,1),
	Fotografia IMAGE,
	Pie VARCHAR(75) NOT NULL,
	ID_Sitio_Turistico INT,
	FOREIGN KEY(ID_Sitio_Turistico) REFERENCES Sitio_Turistico(ID),
	PRIMARY KEY(ID)
)

CREATE TABLE Estado(
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL
	PRIMARY KEY(ID)
)

CREATE TABLE Tipo_Usuario(
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Descripcion TEXT, 
	PRIMARY KEY(ID)
)

CREATE TABLE Tipo_Empresa(
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Descripcion TEXT,
	PRIMARY KEY(ID)
)

CREATE TABLE Usuario(
	DPI VARCHAR(50) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Correo VARCHAR(50),
	Telefono VARCHAR(20) NOT NULL,
	Usuario VARCHAR(50) NOT NULL,
	Contraseña VARCHAR(50) NOT NULL,
	ID_Tipo_Usuario INT,
	FOREIGN KEY(ID_Tipo_Usuario) REFERENCES Tipo_Usuario(ID),
	PRIMARY KEY(DPI)
)

CREATE TABLE Museo_Empresa(
	ID INT IDENTITY(1,1),
	Horario VARCHAR(50),
	Tarifa VARCHAR(50),
	PRIMARY KEY(ID)
)

CREATE TABLE Empresa(
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Direccion VARCHAR(50) NOT NULL,
	Telefono VARCHAR(50) NOT NULL,
	Correo VARCHAR(50),
	ID_Museo INT,
	FOREIGN KEY(ID_Museo) REFERENCES Museo_Empresa(ID),
	ID_Region INT NOT NULL,
	FOREIGN KEY(ID_Region) REFERENCES Region(ID),
	ID_Tipo_Empresa INT NOT NULL,
	FOREIGN KEY(ID_Tipo_Empresa) REFERENCES Tipo_Empresa(ID),
	ID_Estado INT NOT NULL,
	FOREIGN KEY(ID_Estado) REFERENCES Estado(ID),
	DPI_Usuario VARCHAR(50),
	FOREIGN KEY(DPI_Usuario) REFERENCES Usuario(DPI),
	PRIMARY KEY(ID)
)

CREATE TABLE Foto_Empresa(
	ID INT IDENTITY(1,1),
	ID_Empresa INT NOT NULL,
	FOREIGN KEY (ID_Empresa) REFERENCES Empresa(ID),
	Fotografia IMAGE,
	PRIMARY KEY(ID)
)

CREATE TABLE Recorrido(
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	FechaInicio DATE NOT NULL,
	FechaFin DATE NOT NULL,
	DPI_Usuario VARCHAR(50) NOT NULL,
	FOREIGN KEY(DPI_Usuario) REFERENCES Usuario(DPI),
	PRIMARY KEY(ID)
)

CREATE TABLE Empresa_Recorrido(
	ID INT IDENTITY(1,1),
	ID_Recorrido  INT NOT NULL,
	FOREIGN KEY(ID_Recorrido) REFERENCES Recorrido(ID),
	ID_Empresa INT NOT NULL,
	FOREIGN KEY(ID_Empresa) REFERENCES Empresa(ID),
	Aceptar CHAR NOT NULL,
	Comentario TEXT,
	PRIMARY KEY(ID)
)

CREATE TABLE Servicio_Empresa(
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Descripcion TEXT,
	PRIMARY KEY(ID)
)

CREATE TABLE Especialidad_Plato(
	ID INT IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Descripcion TEXT, 
	PRIMARY KEY(ID)
)

CREATE TABLE Empresa_Hotel(
	ID_Servicio INT NOT NULL,
	FOREIGN KEY(ID_Servicio) REFERENCES Servicio_Empresa(ID),
	ID_Empresa INT NOT NULL,
	FOREIGN KEY(ID_Empresa) REFERENCES Empresa(ID),
	Aceptar_Servicio CHAR,
	PRIMARY KEY(ID_Servicio, ID_Empresa)
)

CREATE TABLE Empresa_Especialidad(
	ID_Especialidad INT NOT NULL,
	FOREIGN KEY(ID_Especialidad) REFERENCES Especialidad_Plato(ID),
	ID_Empresa INT NOT NULL,
	FOREIGN KEY(ID_Empresa) REFERENCES Empresa(ID),
	Aceptar_Especialidad CHAR,
	PRIMARY KEY(ID_Especialidad, ID_Empresa)
)

CREATE TABLE Usuario_Publico(
	ID INT IDENTITY(1,1) NOT NULL,
	Usuario VARCHAR(50),
	Contraseña VARCHAR(50),
	PRIMARY KEY(ID)
)

CREATE TABLE Gusta_Sitio(
	ID_Sitio INT NOT NULL,
	FOREIGN KEY(ID_Sitio) REFERENCES Sitio_turistico(ID),
	ID_Usuario INT NOT NULL,
	FOREIGN KEY(ID_Usuario) REFERENCES Usuario_Publico(ID),
	PRIMARY KEY(ID_Sitio,ID_Usuario)
)

CREATE TABLE Gusta_Empresa(
	ID_Empresa INT NOT NULL,
	FOREIGN KEY(ID_Empresa) REFERENCES Empresa(ID),
	ID_Usuario INT NOT NULL,
	FOREIGN KEY(ID_Usuario) REFERENCES Usuario_Publico(ID),
	PRIMARY KEY(ID_Empresa,ID_Usuario)
)

CREATE TABLE Favorito_Sitio(
	ID_Sitio INT NOT NULL,
	FOREIGN KEY(ID_Sitio) REFERENCES Sitio_turistico(ID),
	ID_Usuario INT NOT NULL,
	FOREIGN KEY(ID_Usuario) REFERENCES Usuario_Publico(ID),
	PRIMARY KEY(ID_Sitio,ID_Usuario)
)

CREATE TABLE Favorito_Empresa(
	ID_Empresa INT NOT NULL,
	FOREIGN KEY(ID_Empresa) REFERENCES Empresa(ID),
	ID_Usuario INT NOT NULL,
	FOREIGN KEY(ID_Usuario) REFERENCES Usuario_Publico(ID),
	PRIMARY KEY(ID_Empresa,ID_Usuario)
)

CREATE TABLE Compartir_Empresa(
	ID_Empresa INT NOT NULL,
	FOREIGN KEY(ID_Empresa) REFERENCES Empresa(ID),
	ID_Emisor INT NOT NULL,
	FOREIGN KEY(ID_Emisor) REFERENCES Usuario_Publico(ID),
	ID_Receptor INT NOT NULL,
	FOREIGN KEY(ID_Receptor) REFERENCES Usuario_Publico(ID),
	PRIMARY KEY(ID_Empresa,ID_Emisor,ID_Receptor)
)

CREATE TABLE Compartir_Sitio(
	ID_Sitio INT NOT NULL,
	FOREIGN KEY(ID_Sitio) REFERENCES Sitio_turistico(ID),
	ID_Emisor INT NOT NULL,
	FOREIGN KEY(ID_Emisor) REFERENCES Usuario_Publico(ID),
	ID_Receptor INT NOT NULL,
	FOREIGN KEY(ID_Receptor) REFERENCES Usuario_Publico(ID),
	PRIMARY KEY(ID_Sitio,ID_Emisor,ID_Receptor)
)

CREATE TABLE Comentario_Empresa(
	ID_Empresa INT NOT NULL,
	FOREIGN KEY(ID_Empresa) REFERENCES Empresa(ID),
	ID_Usuario INT NOT NULL,
	FOREIGN KEY(ID_Usuario) REFERENCES Usuario_Publico(ID),
	Fecha DATE NOT NULL,
	Hora VARCHAR(25) NOT NULL,
	PRIMARY KEY(ID_Empresa,ID_Usuario)
)

CREATE TABLE Comentario_Sitio(
	ID_Sitio INT NOT NULL,
	FOREIGN KEY(ID_Sitio) REFERENCES Sitio_turistico(ID),
	ID_Usuario INT NOT NULL,
	FOREIGN KEY(ID_Usuario) REFERENCES Usuario_Publico(ID),
	Fecha DATE NOT NULL,
	Hora VARCHAR(25) NOT NULL,
	PRIMARY KEY(ID_Sitio,ID_Usuario)
)

CREATE TABLE Noticia(
	ID INT IDENTITY(1,1),
	Titulo NVARCHAR(50),
	Descripcion TEXT,
	Fecha NVARCHAR(50),
	Noticia TEXT,
	Fotografia IMAGE,
	PRIMARY KEY(ID)
)

INSERT INTO Tipo_Usuario(Nombre,Descripcion)
VALUES ('Agente','Realiza registros'),
('Técnico','Realiza evaluaciones'),
('Administrador','Administra los usuarios'),
('Público','Público en general');


INSERT INTO Usuario(DPI,Nombre,Correo,Telefono,Usuario,Contraseña,ID_Tipo_Usuario)
VALUES('10107486313215','Luis Arana','luis631arana@gmail.com','59486769','Luis','admin123',3);


INSERT INTO Museo_Empresa(Horario,Tarifa)
VALUES('8:00 a 17:00','50.00');

INSERT INTO Especialidad_Plato(Nombre,Descripcion)
VALUES ('Arroz En Leche','Rico arroz con un toque sutil de leche.'),
('Revolcado','Rico plato tipico.'),
('Shucos','Ricos shucos como los de la USAC.'),
('Tamales','Ricos tamales de cerdo o pollo.'),
('Kakik','Caldo de los favoritos por su carne de “chunto”'),
('Pepián','Uno de los recados tradicionales del país, el pepián de pollo y su consistencia  son un majar exquisito. Va muy bien con verduras, arroz y unas tortillas.');

INSERT INTO Servicio_Empresa(Nombre,Descripcion)
VALUES ('Piscina','Lugar para nadar.'),
('Internet','Buena conexion wifi.'),
('TV con Cable','Buena señal de televisión con una variedad de canales.'),
('Gimnasio','Sitio para poder ejercitarse.'),
('Agua Caliente','Las duchas cuentan con agua caliente.'),
('SPA','Lugar para relajarse.');

INSERT INTO Region(Nombre)
VALUES ('Norte'),
('Sur'),
('Este'),
('Oeste');

INSERT INTO Estado(Nombre)
VALUES ('Prevaluación'),
('En Evaluación'),
('Inscrita'),
('Rechazada');

INSERT INTO Tipo_Empresa(Nombre,Descripcion)
VALUES ('Museo','Lugar para dar una vuelta'),
('Restaurante','Lugar para comer'),
('Hotel','Lugar para descansar y pasar el tiempo');
