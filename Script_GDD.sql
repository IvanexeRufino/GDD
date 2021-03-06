CREATE SCHEMA OVERFANTASY;
GO

CREATE TABLE OVERFANTASY.Funcionalidad(
Funcionalidad_Descripcion nvarchar(255) NOT NULL,
)

CREATE TABLE OVERFANTASY.Rol(
Rol_Id numeric(18,0) IDENTITY(1,1) NOT NULL,
Rol_Nombre nvarchar(30) UNIQUE Not Null,
Rol_Estado char(1) CHECK (Rol_Estado IN('H','I')) DEFAULT 'H'
)

CREATE TABLE OVERFANTASY.Funcionalidad_Por_Rol(
Rol_Id numeric(18,0) Not Null,
Funcionalidad_Descripcion nvarchar(255) Not Null,
)

CREATE TABLE OVERFANTASY.Usuario(
Usuario_Username nvarchar(50) Not Null,
Usuario_Password nvarchar(max) Not Null,
Usuario_Estado char(1) Check(Usuario_Estado IN('H','I')) DEFAULT 'H',
Usuario_Inhab_Intentos smallint DEFAULT 0,
Usuario_Fecha_Creacion datetime DEFAULT GETDATE(),
)

CREATE TABLE OVERFANTASY.Cliente(
Usuario_Username nvarchar(50) Not Null,
Cliente_Nombre varchar(255) Not Null,
Cliente_Apellido varchar(255) Not Null,
Cliente_DNI numeric(18,0) Not Null,
Cliente_FechaNacimiento datetime Not Null,
Cliente_Direccion nvarchar(255) NOT NULL,
Cliente_Piso numeric(18,0) NOT NULL,
Cliente_Departamento nvarchar(50) NOT NULL,
Cliente_CodigoPostal nvarchar(50) NOT NULL,
Cliente_Mail nvarchar(255),
Cliente_telefono numeric(18,0) NOT NULL UNIQUE,
Cliente_Localidad nvarchar(255) NOT NULL
)

CREATE TABLE OVERFANTASY.Chofer(
Usuario_Username nvarchar(50) Not Null,
Chofer_Nombre varchar(255) Not Null,
Chofer_Apellido varchar(255) Not Null,
Chofer_DNI numeric(18,0) Not Null,
Chofer_FechaNacimiento datetime Not Null,
Chofer_Direccion nvarchar(255) NOT NULL,
Chofer_Piso numeric(18,0) NOT NULL,
Chofer_Departamento nvarchar(50) NOT NULL,
Chofer_CodigoPostal nvarchar(50) NOT NULL,
Chofer_Mail nvarchar(255) NOT NULL,
Chofer_telefono numeric(18,0) NOT NULL UNIQUE,
Chofer_Localidad nvarchar(255) NOT NULL
)

CREATE TABLE OVERFANTASY.Rol_Por_Usuario(
Rol_Id numeric(18,0) Not Null,
Usuario_Username nvarchar(50) Not Null,
)

CREATE TABLE OVERFANTASY.Turno(
Turno_Descripcion varchar(255) NOT NULL,
Turno_Horario_Inicio numeric(18,0),
Turno_Horario_Fin numeric(18,0),
Turno_Precio_Base numeric(18,2),
Turno_Valor_Kilometro numeric(18,2),
Turno_Estado char(1) CHECK(Turno_Estado IN ('H', 'I')) DEFAULT 'H',
)

CREATE TABLE OVERFANTASY.Automovil(
Automovil_Patente varchar(10) UNIQUE NOT NULL,
Automovil_Marca varchar(255) NOT NULL,
Automovil_Modelo varchar(255) NOT NULL,
Automovil_Estado char(1) CHECK (Automovil_Estado IN('H','I')) DEFAULT 'H',
Turno_Descripcion varchar(255) NOT NULL,
Chofer_Username nvarchar(50) NOT NULL
)

CREATE TABLE OVERFANTASY.Rendicion(
Rendicion_Nro numeric(18,0) Identity(1,1) NOT NULL,
Chofer_Username nvarchar(50) Not Null,
Turno_Descripcion varchar(255) NOT NULL,
Rendicion_Fecha datetime DEFAULT GETDATE() NOT NULL,
Rendicion_Total numeric(18,2) NOT NULL,
)

CREATE TABLE OVERFANTASY.Factura(
Factura_Nro numeric(18,0) Identity(1,1) NOT NULL,
Factura_Fecha_Inicio datetime NOT NULL,
Factura_Fecha_Fin datetime NOT NULL,
Cliente_Username nvarchar(50) Not Null,
Factura_Total numeric(18,2) NOT NULL,
)

CREATE TABLE OVERFANTASY.Viaje(
Viaje_Id numeric(18,0) Identity(1,1) NOT NULL,
Viaje_Cantidad_Kilometros numeric(18,0) NOT NULL,
Viaje_Hora_Inicio datetime NOT NULL,
Viaje_Hora_Fin datetime NOT NULL,
Automovil_Patente varchar(10) NOT NULL,
Chofer_Username nvarchar(50) Not Null,
Cliente_Username nvarchar(50) Not Null,
Turno_Descripcion varchar(255) NOT NULL,
Rendicion_Nro numeric(18,0),
Factura_Nro numeric(18,0),
Viaje_Total numeric(18,2)
)
GO

CREATE VIEW OVERFANTASY.ClienteCompleto
AS
SELECT c.Usuario_Username, Cliente_Nombre, Cliente_Apellido, Cliente_DNI, Cliente_FechaNacimiento, Cliente_Direccion, Cliente_Piso, Cliente_Departamento, Cliente_CodigoPostal, Cliente_Mail, Cliente_telefono, Cliente_Localidad, Usuario_Estado
FROM OVERFANTASY.Cliente c join OVERFANTASY.Usuario u on c.Usuario_Username = u.Usuario_Username
GO

CREATE VIEW OVERFANTASY.ChoferCompleto
AS
SELECT c.Usuario_Username, Chofer_Nombre, Chofer_Apellido, Chofer_DNI, Chofer_FechaNacimiento, Chofer_Direccion, Chofer_Piso, Chofer_Departamento, Chofer_CodigoPostal, Chofer_Mail, Chofer_telefono, Chofer_Localidad, Usuario_Estado
FROM OVERFANTASY.Chofer c join OVERFANTASY.Usuario u on c.Usuario_Username = u.Usuario_Username
GO

ALTER TABLE OVERFANTASY.Funcionalidad
ADD Primary Key (Funcionalidad_Descripcion)

ALTER TABLE OVERFANTASY.Rol
ADD Primary Key (Rol_Id)

ALTER TABLE OVERFANTASY.Funcionalidad_Por_Rol
ADD Primary Key (Rol_Id,Funcionalidad_Descripcion),
Foreign Key (Rol_Id) References OVERFANTASY.Rol,
Foreign Key (Funcionalidad_Descripcion) References OVERFANTASY.Funcionalidad

ALTER TABLE OVERFANTASY.Usuario
ADD Primary Key (Usuario_Username)

ALTER TABLE OVERFANTASY.Cliente
ADD Primary Key (Usuario_Username),
Foreign Key (Usuario_Username) References OVERFANTASY.Usuario

ALTER TABLE OVERFANTASY.Chofer
ADD Primary Key (Usuario_Username),
Foreign Key (Usuario_Username) References OVERFANTASY.Usuario

ALTER TABLE OVERFANTASY.Rol_Por_Usuario
ADD Primary Key (Rol_Id,Usuario_Username),
Foreign Key (Rol_Id) References OVERFANTASY.Rol,
Foreign Key (Usuario_Username) References OVERFANTASY.Usuario

ALTER TABLE OVERFANTASY.Turno
ADD Primary Key (Turno_Descripcion)

ALTER TABLE OVERFANTASY.Automovil
ADD Primary Key (Automovil_Patente),
Foreign Key (Turno_Descripcion) References OVERFANTASY.Turno,
Foreign Key (Chofer_Username) References OVERFANTASY.Chofer(Usuario_Username)

ALTER TABLE OVERFANTASY.Rendicion
ADD Primary Key (Rendicion_Nro),
Foreign Key (Turno_Descripcion) References OVERFANTASY.Turno,
Foreign Key (Chofer_Username) References OVERFANTASY.Chofer(Usuario_Username)

ALTER TABLE OVERFANTASY.Factura
ADD Primary Key (Factura_Nro),
Foreign Key (Cliente_Username) References OVERFANTASY.Cliente(Usuario_Username)

ALTER TABLE OVERFANTASY.Viaje
ADD Primary Key (Viaje_Id),
Foreign Key (Automovil_Patente) References OVERFANTASY.Automovil,
Foreign Key(Chofer_Username) References OVERFANTASY.Chofer(Usuario_Username),
Foreign Key(Cliente_Username) References OVERFANTASY.Cliente(Usuario_Username),
Foreign Key (Turno_Descripcion) References OVERFANTASY.Turno,
Foreign Key (Rendicion_Nro) References OVERFANTASY.Rendicion,
Foreign Key (Factura_Nro) References OVERFANTASY.Factura
GO

CREATE TRIGGER OVERFANTASY.HashContraseña ON OVERFANTASY.Usuario
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @Username nvarchar(max), @pass nvarchar(max)
	DECLARE cursorPassword CURSOR FOR
	SELECT Usuario_Username, Usuario_Password FROM inserted
	OPEN cursorPassword
	FETCH NEXT FROM cursorPassword INTO @Username, @pass
	WHILE @@FETCH_STATUS=0
	BEGIN	
		INSERT INTO OVERFANTASY.Usuario (Usuario_Username, Usuario_Password)
		VALUES (@Username, CONVERT(nvarchar(max), HASHBYTES('SHA2_256', @pass),2))
		FETCH NEXT FROM cursorPassword INTO @Username, @pass
	END
	CLOSE cursorPassword
	DEALLOCATE cursorPassword
END
GO

CREATE TRIGGER OVERFANTASY.InhabilitarTurno ON OVERFANTASY.Turno
INSTEAD OF DELETE
AS
BEGIN
DECLARE @Turno_Descripcion nvarchar(max)
SET @Turno_Descripcion = (SELECT Turno_Descripcion FROM deleted)
UPDATE OVERFANTASY.Turno
SET Turno_Estado = 'I'
WHERE Turno_Descripcion = @Turno_Descripcion
END
GO

CREATE TRIGGER OVERFANTASY.InhabilitarRol ON OVERFANTASY.Rol
INSTEAD OF DELETE
AS
BEGIN
DECLARE @Rol_Id numeric(18,0)
SET @Rol_Id = (SELECT Rol_Id FROM deleted)
UPDATE OVERFANTASY.Rol
SET Rol_Estado = 'I'
WHERE Rol_Id = @Rol_Id
DELETE FROM OVERFANTASY.Rol_Por_Usuario
WHERE Rol_Id = @Rol_Id
END
GO

CREATE TRIGGER OVERFANTASY.InhabilitarCliente ON OVERFANTASY.Cliente
INSTEAD OF DELETE
AS
BEGIN
DECLARE @User varchar(50)
SET @User = (Select Usuario_Username from deleted)
UPDATE OVERFANTASY.Usuario
SET Usuario_Estado = 'I'
WHERE Usuario_Username = @User
END
GO

CREATE TRIGGER OVERFANTASY.InhabilitarChofer ON OVERFANTASY.Chofer
INSTEAD OF DELETE
AS
BEGIN
DECLARE @User varchar(50)
SET @User = (Select Usuario_Username from deleted)
UPDATE OVERFANTASY.Usuario
SET Usuario_Estado = 'I'
WHERE Usuario_Username = @User
END
GO

CREATE TRIGGER OVERFANTASY.RendirYActualizarViajes ON OVERFANTASY.Rendicion
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @id numeric(18,0), @turno nvarchar(50), @fecha datetime, @Chofer nvarchar(50), @Total numeric(18,2)
	SELECT @fecha = Rendicion_Fecha, @Chofer = Chofer_Username, @turno = Turno_Descripcion, @Total = Rendicion_Total FROM inserted	
	INSERT INTO OVERFANTASY.Rendicion(Chofer_Username, Turno_Descripcion, Rendicion_Fecha, Rendicion_Total)
	VALUES(@Chofer, @turno, CONVERT(date,GETDATE()), @Total)
	SET @id = @@IDENTITY
	UPDATE OVERFANTASY.Viaje
	SET Rendicion_Nro = @id
	WHERE CONVERT(date, Viaje_Hora_Inicio) = CONVERT(date, @fecha)
	AND Chofer_Username = @Chofer
	AND Turno_Descripcion = @turno
END
GO

CREATE TRIGGER OVERFANTASY.FacturarYActualizarViajes ON OVERFANTASY.Factura
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @id numeric(18,0), @Factura_Fecha_Inicio datetime, @Factura_Fecha_Fin datetime, @Cliente_Username nvarchar(50), @Total numeric(18,2)
	SELECT @Factura_Fecha_Inicio = Factura_Fecha_Inicio, @Factura_Fecha_Fin = Factura_Fecha_Fin, @Cliente_Username = Cliente_Username, @Total = Factura_Total FROM inserted
	INSERT INTO OVERFANTASY.Factura(Cliente_Username, Factura_Fecha_Inicio, Factura_Fecha_Fin, Factura_Total)
	VALUES(@Cliente_Username, @Factura_Fecha_Inicio, @Factura_Fecha_Fin, @Total)
	SET @id = @@IDENTITY
	UPDATE OVERFANTASY.Viaje
	SET Factura_Nro = @id
	WHERE CONVERT(date, Viaje_Hora_Inicio) BETWEEN CONVERT(date, @Factura_Fecha_Inicio) AND CONVERT(date, @Factura_Fecha_Fin)
	AND Cliente_Username = @Cliente_Username
END
GO

CREATE TRIGGER OVERFANTASY.InsertarClienteCompleto ON OVERFANTASY.ClienteCompleto
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @username nvarchar(50)
	SET @username = (Select Usuario_Username from inserted)
	INSERT INTO OVERFANTASY.Usuario (Usuario_Username, Usuario_Password) 
	VALUES (@username , @username)
	INSERT INTO OVERFANTASY.Cliente
	SELECT  Usuario_Username, Cliente_Nombre, Cliente_Apellido, Cliente_DNI, Cliente_FechaNacimiento, Cliente_Direccion, Cliente_Piso, Cliente_Departamento, Cliente_CodigoPostal, Cliente_Mail, Cliente_telefono, Cliente_Localidad from inserted
	INSERT INTO OVERFANTASY.Rol_Por_Usuario 
	VALUES (1, @username)
END
GO

CREATE TRIGGER OVERFANTASY.InsertarChoferCompleto ON OVERFANTASY.ChoferCompleto
INSTEAD OF INSERT
AS
BEGIN
	DECLARE @username nvarchar(50)
	SET @username = (SELECT Usuario_Username FROM inserted)
	INSERT INTO OVERFANTASY.Usuario (Usuario_Username, Usuario_Password)
	VALUES (@username, @username)
	INSERT INTO OVERFANTASY.Chofer
	SELECT Usuario_Username, Chofer_Nombre, Chofer_Apellido, Chofer_DNI, Chofer_FechaNacimiento, Chofer_Direccion, Chofer_Piso, Chofer_Departamento, Chofer_CodigoPostal, Chofer_Mail, Chofer_telefono, Chofer_Localidad FROM inserted
	INSERT INTO OVERFANTASY.Rol_Por_Usuario
	VALUES (2, @username)
END
GO

CREATE TRIGGER OVERFANTASY.InhabilitarAutomovil ON OVERFANTASY.Automovil
INSTEAD OF DELETE
AS
BEGIN
	DECLARE @Patente varchar(10)
	SET @Patente = (Select Automovil_Patente from deleted)
	UPDATE OVERFANTASY.Automovil
	SET Automovil_Estado = 'I'
	WHERE Automovil_Patente = @Patente
END
GO

CREATE TRIGGER OVERFANTASY.CambiarPatente on OVERFANTASY.Automovil
INSTEAD OF UPDATE
AS
BEGIN
	DECLARE @patenteNueva varchar(10), @patenteVieja varchar(10), @estado char(1), @marca varchar(255), @modelo varchar(255), @turno varchar(255), @chofer varchar(50)
	SELECT @patenteNueva = Automovil_Patente, @estado = Automovil_Estado, @marca = Automovil_Marca, @modelo = Automovil_Modelo, @turno = Turno_Descripcion, @chofer = Chofer_Username from inserted
	set @patenteVieja =(SELECT Automovil_patente from deleted)
	IF (@patentevieja <> @patenteNueva)
	BEGIN
		INSERT INTO OVERFANTASY.Automovil 
		SELECT Automovil_Patente, Automovil_Marca, Automovil_Modelo, Automovil_Estado, Turno_Descripcion, Chofer_Username FROM inserted
		UPDATE OVERFANTASY.Viaje
		SET Automovil_patente = @patenteNueva
		WHERE Automovil_Patente = @PatenteVieja
		delete from OVERFANTASY.Automovil
		where Automovil_Patente = @patenteVieja
	END
	ELSE
	BEGIN
		UPDATE OVERFANTASY.Automovil
		SET Automovil_Marca = @Marca, Automovil_Modelo = @Modelo, Automovil_Estado = @Estado, Turno_Descripcion = @Turno, Chofer_Username = @Chofer
		WHERE Automovil_Patente = @patenteNueva
	END
END
GO

CREATE PROCEDURE OVERFANTASY.UnicidadDeTelefonos (@telefono nvarchar(max))
AS
BEGIN
	IF ((@telefono IN (SELECT Cliente_telefono FROM OVERFANTASY.Cliente)) OR (@telefono IN (SELECT Chofer_telefono FROM OVERFANTASY.Chofer)))
	BEGIN
	RAISERROR ('Error numero de telefono NO unico', 16, 1);  
	END
END
GO

CREATE PROCEDURE OVERFANTASY.verificarLogIn (@username nvarchar(max), @password nvarchar(max))
AS
BEGIN
	DECLARE @passHash nvarchar(max), @passlocal nvarchar(max)
	SET @passHash = CONVERT(nvarchar(max), HASHBYTES('SHA2_256', @password),2)
	SET @passlocal = (SELECT Usuario_Password FROM OVERFANTASY.Usuario WHERE Usuario_Username = @username)
	IF (@passHash = @passlocal)
		UPDATE OVERFANTASY.Usuario 
		SET Usuario_Inhab_Intentos = 0 
		WHERE Usuario_Username = @username
	ELSE
		UPDATE OVERFANTASY.Usuario 
		SET Usuario_Inhab_Intentos = Usuario_Inhab_Intentos + 1
		WHERE Usuario_Username = @username
		if((Select Usuario_Inhab_Intentos FROM OVERFANTASY.Usuario WHERE Usuario_Username = @username) = 3)
			UPDATE OVERFANTASY.Usuario
			SET Usuario_Estado = 'I' 
			WHERE Usuario_Username = @username

END
GO

CREATE PROCEDURE OVERFANTASY.MigracionDeDatos
AS
BEGIN

INSERT INTO OVERFANTASY.Usuario (Usuario_Username, Usuario_Password)
SELECT DISTINCT(Cliente_Telefono), Cliente_Telefono FROM gd_esquema.Maestra
order by 1

INSERT INTO OVERFANTASY.Usuario (Usuario_Username, Usuario_Password)
SELECT DISTINCT(Chofer_Telefono), Chofer_Telefono FROM gd_esquema.Maestra
order by 1

INSERT INTO OVERFANTASY.Cliente
SELECT DISTINCT(Cliente_Telefono), Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Fecha_Nac, Cliente_Direccion, Piso = 0, Depto = 0, Cod_Postal = 0, Cliente_Mail, Cliente_Telefono, localidad = 'N/A' FROM gd_esquema.Maestra
order by 1

INSERT INTO OVERFANTASY.Chofer
SELECT DISTINCT(Chofer_Telefono), Chofer_Nombre, Chofer_Apellido, Chofer_Dni, Chofer_Fecha_Nac, Chofer_Direccion, Piso = 0, Depto = 0, Cod_Postal = 0, Chofer_Mail, Chofer_Telefono, localidad = 'N/A' FROM gd_esquema.Maestra
order by 1

INSERT INTO OVERFANTASY.Turno(Turno_Descripcion,Turno_Horario_Inicio, Turno_Horario_Fin, Turno_Precio_Base, Turno_Valor_Kilometro)
SELECT DISTINCT(Turno_Descripcion), Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Precio_Base, Turno_Valor_Kilometro
FROM gd_esquema.Maestra

UPDATE OVERFANTASY.Turno
SET Turno_Descripcion = 'Turno Mañana'
WHERE Turno_Descripcion = 'Turno Mañna'

INSERT INTO OVERFANTASY.Automovil(Automovil_Patente, Automovil_Marca, Automovil_Modelo, Turno_Descripcion, Chofer_Username)
SELECT DISTINCT(Auto_Patente), Auto_Marca, Auto_Modelo, turno = 'Turno Mañana', Chofer_Telefono
FROM gd_esquema.Maestra

SET IDENTITY_INSERT OVERFANTASY.Rendicion ON
INSERT INTO OVERFANTASY.Rendicion(Rendicion_Nro, Chofer_Username, Turno_Descripcion, Rendicion_Fecha, Rendicion_Total)
SELECT DISTINCT(Rendicion_Nro), Chofer_Telefono, turno = CASE Turno_Descripcion  WHEN 'Turno Mañna' THEN 'Turno Mañana'
																				ELSE Turno_Descripcion
																				END , Rendicion_Fecha, importe = SUM(Rendicion_Importe) FROM gd_esquema.Maestra
WHERE Rendicion_Nro IS NOT NULL
GROUP BY Rendicion_Nro, Chofer_Telefono, Turno_Descripcion, Rendicion_Fecha
order by 1
SET IDENTITY_INSERT OVERFANTASY.Rendicion OFF

SET IDENTITY_INSERT OVERFANTASY.Factura ON
INSERT INTO OVERFANTASY.Factura (Factura_Nro, Factura_Fecha_Inicio, Factura_Fecha_Fin, Cliente_Username, Factura_Total)
SELECT Factura_Nro, Factura_Fecha_Inicio, Fecha_Fin = DATEADD(Hour, 23, g.Factura_Fecha_Fin), Cliente_Telefono, 
total = CONVERT(numeric(18,2),(SELECT SUM(Turno_Precio_Base + (Turno_Valor_Kilometro*Viaje_Cant_Kilometros)) FROM gd_esquema.Maestra g1
WHERE Cliente_Telefono = CONVERT(nvarchar(50), g.Cliente_Telefono)
AND Rendicion_Nro IS NOT NULL
AND Viaje_Fecha BETWEEN g.Factura_Fecha_Inicio AND DATEADD(Hour, 23, g.Factura_Fecha_Fin)))
FROM gd_esquema.Maestra g
WHERE Factura_Nro IS NOT NULL
GROUP BY Factura_Nro, Factura_Fecha_Inicio, Factura_Fecha_Fin, Cliente_Telefono
order by Factura_Nro
SET IDENTITY_INSERT OVERFANTASY.Factura OFF

INSERT INTO OVERFANTASY.Viaje(Viaje_Cantidad_Kilometros, Viaje_Hora_Inicio, Viaje_Hora_Fin, Automovil_Patente,Chofer_Username, Cliente_Username, Turno_Descripcion, Rendicion_Nro, Factura_Nro, Viaje_Total)
SELECT  Viaje_Cant_Kilometros, Viaje_Fecha, Viaje_Fecha, Auto_Patente,Chofer_Telefono, Cliente_Telefono,turno = CASE Turno_Descripcion  WHEN 'Turno Mañna' THEN 'Turno Mañana'
																			ELSE Turno_Descripcion
																			END , 
Rendicion_Nro, Factura_Nro = (SELECT TOP 1 Factura_Nro FROM gd_esquema.Maestra g2 WHERE g1.Cliente_Telefono = g2.Cliente_Telefono AND g1.Chofer_Telefono = g2.Chofer_Telefono AND Factura_Nro IS NOT NULL AND g1.Viaje_Fecha = g2.Viaje_Fecha),
(Turno_Precio_Base + (Turno_Valor_Kilometro*Viaje_Cant_Kilometros)) FROM gd_esquema.Maestra g1
WHERE Rendicion_nro IS NOT NULL
order by Rendicion_Nro

END
GO

CREATE PROCEDURE OVERFANTASY.CreacionDeRolesYFuncionalidades
AS
BEGIN

INSERT INTO OVERFANTASY.Funcionalidad
VALUES ('Registro de Viaje'), ('ABM Automovil'), ('ABM Rol'), ('ABM Chofer'), ('ABM Turno'), ('ABM Clientes'), ('Rendicion de Cuentas'), ('Facturacion a Cliente'), ('Listado Estadistico')

INSERT INTO OVERFANTASY.Rol(Rol_Nombre)
VALUES ('Cliente'), ('Chofer'), ('Administrador')

INSERT INTO OVERFANTASY.Funcionalidad_Por_Rol
VALUES (1,'Registro de Viaje'), (2,'Registro de Viaje'), (3,'ABM Rol'), (3,'ABM Chofer'), (3,'ABM Turno'), (3,'ABM Clientes'), (3, 'ABM Automovil'), (3,'Rendicion de Cuentas'), (3,'Facturacion a Cliente'), (3,'Listado Estadistico')

INSERT INTO OVERFANTASY.Rol_Por_Usuario(Usuario_Username, Rol_Id)
SELECT DISTINCT(Cliente_Telefono), rol = 1 FROM gd_esquema.Maestra
order by 1

INSERT INTO OVERFANTASY.Rol_Por_Usuario(Usuario_Username, Rol_Id)
SELECT DISTINCT(Chofer_Telefono), rol = 2 FROM gd_esquema.Maestra
order by 1

INSERT INTO OVERFANTASY.Usuario(Usuario_Username, Usuario_Password)
VALUES ('admin', 'w23e')

INSERT INTO OVERFANTASY.Rol(Rol_Nombre)
VALUES('Administrador General')

INSERT INTO OVERFANTASY.Funcionalidad_Por_Rol
VALUES (4,'Registro de Viaje'), (4,'ABM Automovil'), (4,'ABM Rol'), (4,'ABM Chofer'), (4,'ABM Turno'), (4,'ABM Clientes'), (4, 'Rendicion de Cuentas'), (4,'Facturacion a Cliente'), (4,'Listado Estadistico')

INSERT INTO OVERFANTASY.Rol_Por_Usuario(Usuario_Username, Rol_Id)
VALUES ('admin', 4)

END
GO

DISABLE TRIGGER OVERFANTASY.FacturarYActualizarViajes ON OVERFANTASY.Factura;  
GO 

DISABLE TRIGGER OVERFANTASY.RendirYActualizarViajes ON OVERFANTASY.Rendicion;  
GO 

exec OVERFANTASY.MigracionDeDatos
exec OVERFANTASY.CreacionDeRolesYFuncionalidades
GO

ENABLE TRIGGER OVERFANTASY.FacturarYActualizarViajes ON OVERFANTASY.Factura;
GO

ENABLE TRIGGER OVERFANTASY.RendirYActualizarViajes ON OVERFANTASY.Rendicion;
GO

DROP TABLE OVERFANTASY.Viaje
DROP TABLE OVERFANTASY.Factura
DROP TABLE OVERFANTASY.Rendicion
DROP TABLE OVERFANTASY.Automovil
DROP TABLE OVERFANTASY.Turno
DROP TABLE OVERFANTASY.Rol_Por_Usuario
DROP TABLE OVERFANTASY.Funcionalidad_Por_Rol
DROP TABLE OVERFANTASY.Funcionalidad
DROP TABLE OVERFANTASY.Rol
DROP TABLE OVERFANTASY.Chofer
DROP TABLE OVERFANTASY.Cliente
DROP TABLE OVERFANTASY.Usuario
DROP VIEW OVERFANTASY.ClienteCompleto
DROP VIEW OVERFANTASY.ChoferCompleto
DROP PROCEDURE OVERFANTASY.verificarLogIn
DROP PROCEDURE OVERFANTASY.CreacionDeRolesYFuncionalidades
DROP PROCEDURE OVERFANTASY.MigracionDeDatos
DROP PROCEDURE OVERFANTASY.UnicidadDeTelefonos