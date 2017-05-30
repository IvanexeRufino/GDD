CREATE SCHEMA OVERFANTASY;
GO

BEGIN TRAN

CREATE TABLE OVERFANTASY.Funcionalidad(
Funcionalidad_Descripcion nvarchar(255),
Primary Key (Funcionalidad_Descripcion)
)

INSERT INTO OVERFANTASY.Funcionalidad
VALUES ('Registro de Viaje'), ('ABM Automovil'), ('ABM Rol'), ('ABM Chofer'), ('ABM Turno'), ('ABM Clientes'), ('Rendicion de Cuentas'), ('Facturacion a Cliente'), ('Listado Estadistico')

CREATE TABLE OVERFANTASY.Rol(
Rol_Id numeric(18,0) IDENTITY(1,1) NOT NULL,
Rol_Nombre nvarchar(30) UNIQUE Not Null,
Rol_Estado char(1) CHECK (Rol_Estado IN('H','I')) DEFAULT 'H'
Primary Key (Rol_Id)
)

INSERT INTO OVERFANTASY.Rol(Rol_Nombre)
VALUES ('Cliente'), ('Chofer'), ('Administrador')

CREATE TABLE OVERFANTASY.Funcionalidad_Por_Rol(
Rol_Id numeric(18,0) Not Null,
Funcionalidad_Descripcion nvarchar(255) Not Null,
Primary Key (Rol_Id,Funcionalidad_Descripcion),
Foreign Key (Rol_Id) References OVERFANTASY.Rol,
Foreign Key (Funcionalidad_Descripcion) References OVERFANTASY.Funcionalidad
)

INSERT INTO OVERFANTASY.Funcionalidad_Por_Rol
VALUES (2,'Registro de Viaje'), (2,'ABM Automovil'), (3,'ABM Rol'), (3,'ABM Chofer'), (3,'ABM Turno'), (3,'ABM Clientes'), (3,'Rendicion de Cuentas'), (3,'Facturacion a Cliente'), (3,'Listado Estadistico')

CREATE TABLE OVERFANTASY.Usuario(
Usuario_Username nvarchar(50) Not Null,
Usuario_Password nvarchar(max) Not Null,
Usuario_Estado char(1) Check(Usuario_Estado IN('H','I')) DEFAULT 'H',
Usuario_Inhab_Intentos smallint DEFAULT 0,
Usuario_Fecha_Creacion datetime DEFAULT GETDATE(),
Primary Key (Usuario_Username)
)

INSERT INTO OVERFANTASY.Usuario (Usuario_Username, Usuario_Password)
SELECT DISTINCT(Cliente_Dni), '1' FROM gd_esquema.Maestra
WHERE Cliente_Mail IS NOT NULL
order by 1

INSERT INTO OVERFANTASY.Usuario (Usuario_Username, Usuario_Password)
SELECT DISTINCT(Chofer_Dni), '1' FROM gd_esquema.Maestra
WHERE Chofer_Mail IS NOT NULL
order by 1

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
Cliente_telefono nvarchar(50) NOT NULL UNIQUE,
Cliente_Localidad nvarchar(255) NOT NULL
Primary Key (Usuario_Username),
Foreign Key (Usuario_Username) References OVERFANTASY.Usuario
)

CREATE TABLE OVERFANTASY.Chofer(
Usuario_Username nvarchar(50) Not Null,
Chofer_Nombre varchar(255) Not Null,
Chofer_Apellido varchar(255) Not Null,
Chofer_DNI numeric(18,0) Not Null UNIQUE,
Chofer_FechaNacimiento datetime Not Null,
Chofer_Direccion nvarchar(255) NOT NULL,
Chofer_Piso numeric(18,0) NOT NULL,
Chofer_Departamento nvarchar(50) NOT NULL,
Chofer_CodigoPostal nvarchar(50) NOT NULL,
Chofer_Mail nvarchar(255) NOT NULL,
Chofer_telefono nvarchar(50) NOT NULL,
Chofer_Localidad nvarchar(255) NOT NULL
Primary Key (Usuario_Username),
Foreign Key (Usuario_Username) References OVERFANTASY.Usuario
)

INSERT INTO OVERFANTASY.Cliente
SELECT DISTINCT(Cliente_Dni), Cliente_Nombre, Cliente_Apellido, Cliente_Dni, Cliente_Fecha_Nac, Cliente_Direccion, Piso = 0, Depto = 0, Cod_Postal = 0, Cliente_Mail, Cliente_Telefono, localidad = 'N/A' FROM gd_esquema.Maestra
WHERE Cliente_Dni IS NOT NULL
order by 1

INSERT INTO OVERFANTASY.Chofer
SELECT DISTINCT(Chofer_Dni), Chofer_Nombre, Chofer_Apellido, Chofer_Dni, Chofer_Fecha_Nac, Chofer_Direccion, Piso = 0, Depto = 0, Cod_Postal = 0, Chofer_Mail, Chofer_Telefono, localidad = 'N/A' FROM gd_esquema.Maestra
WHERE Chofer_Dni IS NOT NULL
order by 1


CREATE TABLE OVERFANTASY.Rol_Por_Usuario(
Rol_Id numeric(18,0) Not Null,
Usuario_Username nvarchar(50) Not Null,
Primary Key (Rol_Id,Usuario_Username),
Foreign Key (Rol_Id) References OVERFANTASY.Rol,
Foreign Key (Usuario_Username) References OVERFANTASY.Usuario
)

INSERT INTO OVERFANTASY.Rol_Por_Usuario(Usuario_Username, Rol_Id)
SELECT DISTINCT(Cliente_Dni), rol = 1 FROM gd_esquema.Maestra
WHERE Cliente_Dni IS NOT NULL
order by 1

INSERT INTO OVERFANTASY.Rol_Por_Usuario(Usuario_Username, Rol_Id)
SELECT DISTINCT(Chofer_Dni), rol = 2 FROM gd_esquema.Maestra
WHERE Chofer_Dni IS NOT NULL
order by 1

CREATE TABLE OVERFANTASY.Turno(
Turno_Descripcion varchar(255) NOT NULL,
Turno_Horario_Inicio numeric(18,0),
Turno_Horario_Fin numeric(18,0),
Turno_Precio_Base numeric(18,2),
Turno_Valor_Kilometro numeric(18,2),
Turno_Estado char(1) CHECK(Turno_Estado IN ('H', 'I')) DEFAULT 'H',
Primary Key (Turno_Descripcion)
)

INSERT INTO OVERFANTASY.Turno(Turno_Descripcion,Turno_Horario_Inicio, Turno_Horario_Fin, Turno_Precio_Base, Turno_Valor_Kilometro)
SELECT DISTINCT(Turno_Descripcion), Turno_Hora_Inicio, Turno_Hora_Fin, Turno_Precio_Base, Turno_Valor_Kilometro
FROM gd_esquema.Maestra

UPDATE OVERFANTASY.Turno
SET Turno_Descripcion = 'Turno Mañana'
WHERE Turno_Descripcion = 'Turno Mañna'

CREATE TABLE OVERFANTASY.Automovil(
Automovil_Patente varchar(10) UNIQUE NOT NULL,
Automovil_Marca varchar(255) NOT NULL,
Automovil_Modelo varchar(255) NOT NULL,
Automovil_Estado char(1) CHECK (Automovil_Estado IN('H','I')) DEFAULT 'H',
Turno_Descripcion varchar(255) NOT NULL,
Chofer_Username nvarchar(50) NOT NULL
Primary Key (Automovil_Patente),
Foreign Key (Turno_Descripcion) References OVERFANTASY.Turno,
Foreign Key (Chofer_Username) References OVERFANTASY.Chofer(Usuario_Username)
)

INSERT INTO OVERFANTASY.Automovil(Automovil_Patente, Automovil_Marca, Automovil_Modelo, Turno_Descripcion, Chofer_Username)
SELECT DISTINCT(Auto_Patente), Auto_Marca, Auto_Modelo, turno = 'Turno Mañana', Chofer_Dni
FROM gd_esquema.Maestra

CREATE TABLE OVERFANTASY.Rendicion(
Rendicion_Nro numeric(18,0) Identity(1,1) NOT NULL,
Chofer_Username nvarchar(50) Not Null,
Turno_Descripcion varchar(255) NOT NULL,
Rendicion_Fecha datetime DEFAULT GETDATE() NOT NULL,
Rendicion_Total numeric(18,2) NOT NULL,
Primary Key (Rendicion_Nro),
Foreign Key (Turno_Descripcion) References OVERFANTASY.Turno,
Foreign Key (Chofer_Username) References OVERFANTASY.Chofer(Usuario_Username)
)

SET IDENTITY_INSERT OVERFANTASY.Rendicion ON
INSERT INTO OVERFANTASY.Rendicion(Rendicion_Nro, Chofer_Username, Turno_Descripcion, Rendicion_Fecha, Rendicion_Total)
SELECT DISTINCT(Rendicion_Nro), Chofer_Dni, turno = CASE Turno_Descripcion  WHEN 'Turno Mañna' THEN 'Turno Mañana'
																			ELSE Turno_Descripcion
																			END , Rendicion_Fecha, importe = SUM(DISTINCT (Rendicion_Importe)) FROM gd_esquema.Maestra
WHERE Rendicion_Nro IS NOT NULL
GROUP BY Rendicion_Nro, Chofer_Dni, Turno_Descripcion, Rendicion_Fecha
order by 1
SET IDENTITY_INSERT OVERFANTASY.Rendicion OFF

CREATE TABLE OVERFANTASY.Factura(
Factura_Nro numeric(18,0) Identity(1,1) NOT NULL,
Factura_Fecha_Inicio datetime NOT NULL,
Factura_Fecha_Fin datetime NOT NULL,
Factura_Cantidad_Viajes numeric(18,0) NOT NULL,
Factura_Total numeric(18,2) NOT NULL,
Usuario_Username nvarchar(50) Not Null,
Primary Key (Factura_Nro),
Foreign Key (Usuario_Username) References OVERFANTASY.Cliente,
)

SET IDENTITY_INSERT OVERFANTASY.Factura ON
INSERT INTO OVERFANTASY.Factura(Factura_Nro, Factura_Fecha_Inicio, Factura_Fecha_Fin, Factura_Cantidad_Viajes, Factura_Total, Usuario_Username)
SELECT Factura_Nro, Factura_Fecha_Inicio, Factura_Fecha_Fin, viajes = COUNT(Turno_Precio_Base), total = SUM(Turno_Precio_Base + Viaje_Cant_Kilometros * Turno_Valor_Kilometro), Cliente_Dni FROM gd_esquema.Maestra
WHERE Factura_Nro IS NOT NULL
GROUP BY Factura_Nro, Factura_Fecha_Inicio, Factura_Fecha_Fin, Cliente_Dni
order by Factura_Nro
SET IDENTITY_INSERT OVERFANTASY.Factura OFF

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
Primary Key (Viaje_Id),
Foreign Key (Automovil_Patente) References OVERFANTASY.Automovil,
Foreign Key(Chofer_Username) References OVERFANTASY.Chofer(Usuario_Username),
Foreign Key(Cliente_Username) References OVERFANTASY.Cliente(Usuario_Username),
Foreign Key (Turno_Descripcion) References OVERFANTASY.Turno,
Foreign Key (Rendicion_Nro) References OVERFANTASY.Rendicion,
Foreign Key (Factura_Nro) References OVERFANTASY.Factura
)

INSERT INTO OVERFANTASY.Viaje(Viaje_Cantidad_Kilometros, Viaje_Hora_Inicio, Viaje_Hora_Fin, Automovil_Patente,Chofer_Username, Cliente_Username, Turno_Descripcion, Rendicion_Nro, Factura_Nro)
SELECT  Viaje_Cant_Kilometros, Viaje_Fecha, Viaje_Fecha, Auto_Patente,Chofer_Dni, Cliente_Dni,turno = CASE Turno_Descripcion  WHEN 'Turno Mañna' THEN 'Turno Mañana'
																			ELSE Turno_Descripcion
																			END , Rendicion_Nro, Factura_Nro FROM gd_esquema.Maestra
WHERE Rendicion_nro IS NOT NULL
order by Rendicion_Nro

COMMIT TRAN
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

CREATE PROCEDURE OVERFANTASY.updatePasswordChofer
AS
BEGIN
	DECLARE @user nvarchar(max)
	DECLARE @pass nvarchar(max)
	DECLARE cursorPassword CURSOR FOR
	SELECT U.Usuario_Username, Usuario_Password FROM OVERFANTASY.Usuario U JOIN OVERFANTASY.Chofer C ON (U.Usuario_Username = C.Usuario_Username) ORDER BY Usuario_Username
	OPEN cursorPassword
	FETCH NEXT FROM cursorPassword INTO @user, @pass
	WHILE @@FETCH_STATUS=0
	BEGIN
		UPDATE OVERFANTASY.Usuario
		SET Usuario_Password = (SELECT CONVERT(nvarchar(max), HASHBYTES('SHA2_256', Chofer_Mail),2) FROM OVERFANTASY.Chofer WHERE Usuario_Username = @user)
		WHERE Usuario_Username = @User
		FETCH NEXT FROM cursorPassword INTO @user, @pass
	END
	CLOSE cursorPassword
	DEALLOCATE cursorPassword
END
GO


CREATE PROCEDURE OVERFANTASY.updatePasswordCliente
AS
BEGIN
	DECLARE @user nvarchar(max)
	DECLARE @pass nvarchar(max)
	DECLARE cursorPassword CURSOR FOR
	SELECT U.Usuario_Username, Usuario_Password FROM OVERFANTASY.Usuario U JOIN OVERFANTASY.Cliente C ON (U.Usuario_Username = C.Usuario_Username) ORDER BY Usuario_Username
	OPEN cursorPassword
	FETCH NEXT FROM cursorPassword INTO @user, @pass
	WHILE @@FETCH_STATUS=0
	BEGIN
		UPDATE OVERFANTASY.Usuario
		SET Usuario_Password = (SELECT CONVERT(nvarchar(max), HASHBYTES('SHA2_256', Cliente_Mail),2) FROM OVERFANTASY.Cliente WHERE Usuario_Username = @user)
		WHERE Usuario_Username = @User
		FETCH NEXT FROM cursorPassword INTO @user, @pass
	END
	CLOSE cursorPassword
	DEALLOCATE cursorPassword
END
GO

exec OVERFANTASY.updatePasswordCliente
exec OVERFANTASY.updatePasswordChofer
GO

CREATE TRIGGER OVERFANTASY.HashContraseña ON OVERFANTASY.Usuario
INSTEAD OF INSERT
AS
BEGIN
DECLARE @Username nvarchar(max), @pass nvarchar(max)
SET @Username = (SELECT Usuario_Username FROM inserted)
SET @pass = (SELECT Usuario_Password FROM inserted)
INSERT INTO OVERFANTASY.Usuario (Usuario_Username, Usuario_Password)
VALUES (@username, CONVERT(nvarchar(max), HASHBYTES('SHA2_256', @pass),2))
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

INSERT INTO OVERFANTASY.Usuario(Usuario_Username, Usuario_Password)
VALUES ('admin', 'w23e')

INSERT INTO OVERFANTASY.Rol(Rol_Nombre)
VALUES('Administrador General')

INSERT INTO OVERFANTASY.Funcionalidad_Por_Rol
VALUES (4,'Registro de Viaje'), (4,'ABM Automovil'), (4,'ABM Rol'), (4,'ABM Chofer'), (4,'ABM Turno'), (4,'ABM Clientes'), (4, 'Rendicion de Cuentas'), (4,'Facturacion a Cliente'), (4,'Listado Estadistico')

INSERT INTO OVERFANTASY.Rol_Por_Usuario(Usuario_Username, Rol_Id)
VALUES ('admin', 4)

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
DROP PROCEDURE OVERFANTASY.verificarLogIn
DROP PROCEDURE OVERFANTASY.updatePasswordChofer
DROP PROCEDURE OVERFANTASY.updatePasswordCliente
DROP TRIGGER OVERFANTASY.HashContraseña
DROP TRIGGER OVERFANTASY.InhabilitarTurno
DROP TRIGGER OVERFANTASY.InhabilitarRol

SELECT Funcionalidad_Descripcion FROM OVERFANTASY.Funcionalidad

SELECT Funcionalidad_Descripcion FROM OVERFANTASY.Funcionalidad_Por_rol WHERE ROL_Id = '20'

SELECT Rol_Id FROM OVERFANTASY.Rol WHERE Rol_Nombre = 'otro'