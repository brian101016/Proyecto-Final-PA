SET NOCOUNT ON
GO

SET DATEFORMAT dmy

USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE NAME='ProyectoPA')
BEGIN
	RAISERROR('Dropping existing ProyectoPA database...', 0, 1)
	DROP DATABASE ProyectoPA
END
GO

CHECKPOINT
GO

RAISERROR('Creating ProyectoPA database...', 0, 1)
GO

CREATE DATABASE ProyectoPA
GO

CHECKPOINT
GO

USE ProyectoPA
GO

IF db_name() <> 'ProyectoPA'
	RAISERROR('Error in InstPubs.SQL, ''USE pubs'' failed!  Killing the SPID now.'
            ,22,127) WITH log
GO

-- ##################################################################################

CREATE TABLE [Puesto] (
    [ID]		int 			IDENTITY(1, 1) PRIMARY KEY,
    [Nombre]	varchar(32)		UNIQUE NOT NULL,
)

CREATE TABLE [Estado] (
    [ID]		int				IDENTITY(1, 1) PRIMARY KEY,
    [Nombre]	varchar(32)		UNIQUE NOT NULL,
)

CREATE TABLE [Marca] (
    [ID]		int				IDENTITY(1, 1) PRIMARY KEY,
    [Nombre]	varchar(32)		UNIQUE NOT NULL,
)

CREATE TABLE [Carroceria] (
    [ID]		int				IDENTITY(1, 1) PRIMARY KEY,
    [Nombre]	varchar(32)		UNIQUE NOT NULL ,
)

CREATE TABLE [Persona] (
    [ID]		int				IDENTITY(1, 1) PRIMARY KEY,
    [Nombre]	varchar(50)		NOT NULL ,
    [Apellido]	varchar(50)		NOT NULL ,
    [Email]		varchar(50)		NULL ,
    [Telefono]	varchar(50)		NULL ,
    [Direccion] varchar(200)	NULL ,
    [PuestoID]	int				NOT NULL
		FOREIGN KEY REFERENCES [Puesto](ID),
)

CREATE TABLE [Auto] (
    [ID]			int			IDENTITY(1, 1) PRIMARY KEY,
    [Nombre]		varchar(32)	NOT NULL ,
    [Precio]		int			NOT NULL
		CHECK ([Precio] > 0),
	[Manual]		bit			NOT NULL ,
    [ProveedorID]	int			NOT NULL
		FOREIGN KEY REFERENCES [Persona](ID),
    [MarcaID]		int			NOT NULL
		FOREIGN KEY REFERENCES [Marca](ID),
    [CarroceriaID]	int			NOT NULL
		FOREIGN KEY REFERENCES [Carroceria](ID),
)

CREATE TABLE [Venta] (
    [ID]			int			IDENTITY(1, 1) PRIMARY KEY,
	[Fecha]			datetime	NOT NULL
		DEFAULT	(getdate())
		CHECK	([Fecha] <= getdate()),
    [ClienteID]		int			NOT NULL
		FOREIGN KEY REFERENCES [Persona](ID),
    [VendedorID]	int			NOT NULL
		FOREIGN KEY REFERENCES [Persona](ID),
    [EstadoID]		int			NOT NULL
		FOREIGN KEY REFERENCES [Estado](ID),
    [AutoID]		int			NOT NULL
		FOREIGN KEY REFERENCES [Auto](ID),
)
GO

-- ##################################################################################

INSERT [Puesto](Nombre) VALUES('Cliente')
INSERT [Puesto](Nombre) VALUES('Vendedor')
INSERT [Puesto](Nombre) VALUES('Proveedor')
GO

INSERT [Estado](Nombre) VALUES('En Proceso')
INSERT [Estado](Nombre) VALUES('Vendido')
INSERT [Estado](Nombre) VALUES('Cancelado')
GO

INSERT [Marca](Nombre) VALUES('Nissan')
INSERT [Marca](Nombre) VALUES('Toyota')
INSERT [Marca](Nombre) VALUES('KIA')
INSERT [Marca](Nombre) VALUES('Volkswagen')
INSERT [Marca](Nombre) VALUES('Mazda')
INSERT [Marca](Nombre) VALUES('Ford')
INSERT [Marca](Nombre) VALUES('Suzuki')
INSERT [Marca](Nombre) VALUES('Honda')
INSERT [Marca](Nombre) VALUES('Renault')
GO

INSERT [Carroceria](Nombre)	VALUES('Sedan')
INSERT [Carroceria](Nombre)	VALUES('Hatchback')
INSERT [Carroceria](Nombre)	VALUES('Suv')
INSERT [Carroceria](Nombre)	VALUES('Crossover')
INSERT [Carroceria](Nombre)	VALUES('Coupe')
INSERT [Carroceria](Nombre)	VALUES('Pick-up')
INSERT [Carroceria](Nombre)	VALUES('Roadster')
INSERT [Carroceria](Nombre)	VALUES('Minivan')
INSERT [Carroceria](Nombre)	VALUES('Convertible')
GO

INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Pepe', 'Ruíz', 'pruiz@outlook.com', '(17) 2918-7938', '87101-037, Av. Vieira, 4 Santa Adriana do Norte - RS', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Rosa', 'Mendoza', 'rosa.mendoza@hotmail.com', '(53) 92214-6726', '01985-114, Largo Assunção, 43194. Fundos Vitória do Sul - AL', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Mariana', 'Rivera', 'zmaia@gmail.com', '(43) 4426-9329', '80963-086, Avenida Emanuel Ferreira, 626 São Alexandre - RS', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Natalia', 'Romero', 'natrom@outlook.com', '(89) 98787-1936', '26867-946, Av. Joaquin, 64 Queirós d''Oeste - BA', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Manuel', 'López', 'vieira.thiago@cervantes.com', '(62) 98898-8797', '72776-948, Avenida Ketlin, 6. Apto 85 Vila Melissa do Leste - RJ', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Juan Carlos', 'Aguilar', 'gabriel.quintana@gmail.com', '(61) 91121-3788', '78697-696, Rua Barros, 84471 São Gabriel - SE', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Constanza', 'Muñoz', 'pzamana@yahoo.com', '(94) 4110-7716', '76886-687, Largo Ramos, 96 Santa Ziraldo do Sul - SE', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('María José', 'Piña', 'thales04@ig.com.br', '(12) 92130-3733', '35308-436, Av. Martinho, 043. Apto 19 Sara do Sul - TO', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Alejandra', 'Jiménez', 'maximiano.benites@marin.com', '(31) 2648-8734', '18049-592, Avenida Micaela, 238 Vila Ana do Norte - PR', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Enrique', 'Pastrana', 'isabella.teles@delvalle.com.br', '(22) 4246-6614', '57588-791, Largo Maximiano Queirós, 49499 Vila Joana do Sul - DF', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Melanie', 'Hernández', 'bonilha.joaquin@cordeiro.net', '(42) 93996-7333', '38303-489, Rua Dante, 9. Apto 46 Delvalle do Norte - RO', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('José Francisco', 'Luna', 'daniela22@solano.net', '(18) 3617-1416', '61297-679, Rua Barros, 62 Miguel do Norte - ES', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Andrés', 'Contreras', 'isadora.martines@pontes.org', '(12) 95882-2455', '85141-788, Largo Ivan, 2 Mendes do Sul - MT', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('María Guadalupe', 'Díaz', 'paula00@r7.com', '(37) 4343-0117', '40994-380, Largo Alonso, 80369 Amélia d''Oeste - BA', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Daniel', 'González', 'daniel.gonzalez@outlook.br', '(54) 2949-3467', '14973-185, Avenida Regina Padrão, 2 Corona do Sul - RS', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Alejandra', 'Ortíz', 'natal51@leon.com', '(97) 94120-2597', '82608-737, Largo Sara Romero, 1614 Porto Noelí do Sul - MT', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Emmanuel', 'Herrera', 'dpereira@padilha.net', '(84) 94372-1458', '68606-796, Av. Salgado, 76309. 84º Andar Soares do Norte - SE', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Alan', 'Fernández', 'luara24@yahoo.com', '(93) 94534-6926', '26199-972, Rua Beatriz, 19390. Bc. 79 Ap. 05 Ortega d''Oeste - MG', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Lucía', 'Castillo', 'gian66@rezende.br', '(73) 4123-0554', '79931-632, Av. Emília, 4533 Hugo do Norte - RS', 1)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Mateo', 'Chávez', 'cristovao47@cortes.net', '(15) 92467-6859', '42235-253, Largo Maximiano Rocha, 82 Solano do Norte - PR', 1)
GO

INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Gabriel', 'García', 'jqueiros@darosa.net', '(86) 91714-1849', '49513-623, Avenida Esteves, 8289. Apto 58 Colaço do Norte - MG', 2)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Emmanuel', 'Contreras', 'isabel.reis@carrara.org', '(96) 97153-5600', '70321-435, Largo Pedro Pacheco, 56 Santa Sabrina - SC', 2)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Sabastián', 'Velázquez', 'miranda89@gmail.com', '(15) 90680-2829', '87623-078, Avenida Josué Faria, 11091 Fernandes do Norte - GO', 2)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Rosa', 'Cortés', 'fatima.furtado@saraiva.com', '(28) 90305-3762', '36487-993, Rua Maximiano Neves, 3477 Vila Simon - CE', 2)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Nicolás', 'Contreras', 'ramires.giovane@duarte.com', '(66) 98724-8014', '35432-310, Rua Franco, 6. Bc. 41 Ap. 72 Vila Taís - RR', 2)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Luna', 'Estrada', 'samanta.batista@hotmail.com', '(77) 3865-3134', '30401-313, Largo Franco Pontes, 882 Santa Sara - TO', 2)
GO

INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Valeria', 'Moreno', 'carla.urias@ig.com.br', '(19) 4038-2873', '02797-405, R. Maitê Matos, 27 Sales do Norte - PR', 3)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Natalia', 'Luna', 'ornela.saraiva@terra.com.br', '(62) 3964-9542', '31024-247, R. Henrique Santiago, 854 Porto Leandro - AM', 3)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Gustavo', 'Guerrero', 'guilherme87@galindo.net.br', '(89) 3178-4273', '40058-613, Av. Miranda, 0985. Anexo Guilherme do Norte - DF', 3)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Jessica', 'Rojas', 'samuel.matias@salgado.net', '(86) 96186-9949', '42045-575, Av. Ziraldo Faro, 0. F São Valentin do Norte - RO', 3)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Alicia', 'Mendoza', 'ypaz@gmail.com', '(61) 96099-9673', '87413-909, Travessa Demian, 3 Maia d''Oeste - PI', 3)
INSERT [Persona](Nombre, Apellido, Email, Telefono, Direccion, PuestoID)
VALUES('Ximena', 'Castro', 'rafael.vale@terra.com.br', '(19) 97054-1757', '09219-735, R. Daniel Ávila, 71240 Vila Gabriel - RR', 3)
GO

INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('Boss 429', 12900, 0, 27, 1, 1)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('GTO', 15600, 0, 29, 3, 6)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('Shelby GT 500', 29800, 1, 29, 5, 3)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('SS 69', 11900, 0, 30, 4, 2)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('Yenko L78', 14000, 0, 31, 3, 6)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('Super Bee', 17980, 0, 29, 8, 7)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('Stingray C3', 23900, 1, 28, 3, 1)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('Hemi Cuda', 21600, 1, 32, 1, 5)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('Mach 1', 28999, 0, 27, 6, 6)
INSERT [Auto](Nombre, Precio, [Manual], ProveedorID, MarcaID, CarroceriaID)
VALUES('Barracuda', 25190, 1, 28, 4, 6)
GO

INSERT [Venta](Fecha, ClienteID, VendedorID, EstadoID, AutoID)
VALUES('31/12/2022', 1, 21, 2, 1)
INSERT [Venta](Fecha, ClienteID, VendedorID, EstadoID, AutoID)
VALUES('14/01/2023', 5, 23, 2, 4)
INSERT [Venta](Fecha, ClienteID, VendedorID, EstadoID, AutoID)
VALUES('21/01/2023', 3, 21, 1, 8)
INSERT [Venta](Fecha, ClienteID, VendedorID, EstadoID, AutoID)
VALUES('02/02/2023', 7, 22, 2, 4)
INSERT [Venta](Fecha, ClienteID, VendedorID, EstadoID, AutoID)
VALUES('07/02/2023', 12, 21, 3, 3)
INSERT [Venta](Fecha, ClienteID, VendedorID, EstadoID, AutoID)
VALUES('19/02/2023', 17, 25, 1, 6)
GO
