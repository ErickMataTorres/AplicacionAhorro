CREATE TABLE TablaUsuario
(
Id INT NOT NULL,
LoginUsuario VARCHAR(100) NOT NULL UNIQUE,
Contraseña VARCHAR(100) NOT NULL,
NombreCompleto VARCHAR(100)NOT NULL,
Sexo VARCHAR(10) NOT NULL,
UltimoAhorro DATETIME DEFAULT(NULL),
UltimoAhorrado DECIMAL(12,2) DEFAULT(0),
TotalAhorrado DECIMAL(12,2) DEFAULT(0),
FechaRegistro DATETIME NOT NULL,
Correo VARCHAR(100),
PRIMARY KEY(Id, UltimoAhorro)
)
ALTER PROCEDURE spRegistrarUsuario
@Id INT,
@LoginUsuario VARCHAR(100),
@Contraseña VARCHAR(100),
@NombreCompleto VARCHAR(100),
@Sexo VARCHAR(10),
@UltimoAhorrado DECIMAL(12,2),
@Correo VARCHAR(100)
AS
BEGIN
SELECT @Id=ISNULL(MAX(Id+1),1) FROM TablaUsuario
IF NOT EXISTS(SELECT @Id FROM TablaUsuario WHERE Id=@Id)
	INSERT INTO TablaUsuario (Id,LoginUsuario,Contraseña,NombreCompleto,Sexo,UltimoAhorro,UltimoAhorrado,TotalAhorrado,FechaRegistro,Correo) VALUES (@Id,@LoginUsuario,@Contraseña,@NombreCompleto,@Sexo,SYSDATETIME(),@UltimoAhorrado,@UltimoAhorrado,SYSDATETIME(),@Correo)
ELSE
	UPDATE TablaUsuario SET LoginUsuario=@LoginUsuario, Contraseña=@Contraseña, NombreCompleto=@NombreCompleto, Sexo=@Sexo, UltimoAhorro=SYSDATETIME(), UltimoAhorrado=@UltimoAhorrado, TotalAhorrado=(TotalAhorrado+@UltimoAhorrado), FechaRegistro=FechaRegistro, Correo=@Correo WHERE Id=@Id
END
ALTER PROCEDURE spConsultaLogin
@LoginUsuario VARCHAR(100),
@Contraseña VARCHAR(100)
AS
BEGIN
SELECT Id FROM TablaUsuario WHERE LoginUsuario=@LoginUsuario AND Contraseña=@Contraseña
END
ALTER PROCEDURE spListaUsuario
@Texto VARCHAR(100)
AS
BEGIN
	SELECT Id, LoginUsuario, NombreCompleto, Sexo, UltimoAhorro, UltimoAhorrado, TotalAhorrado, FechaRegistro, Correo FROM TablaUsuario WHERE NombreCompleto LIKE '%' + @Texto + '%' ORDER BY NombreCompleto
END
CREATE PROCEDURE spConsultarUsuario
@Id INT
AS
BEGIN
	SELECT Id,NombreCompleto, Sexo, UltimoAhorro, UltimoAhorrado, TotalAhorrado, FechaRegistro, Correo FROM TablaUsuario WHERE Id=@Id
END
INSERT INTO TablaUsuario VALUES (1,1,1,1,'M',SYSDATETIME(),1,SYSDATETIME(),1)
EXECUTE spConsultaLogin 1,2

CREATE TABLE TablaAhorro
(
Id INT,
LoginUsuario VARCHAR(100),
NombreCompleto VARCHAR(100),
UltimoAhorro DATETIME DEFAULT(NULL),
UltimoAhorrado DECIMAL(12,2) DEFAULT(0),
TotalAhorrado DECIMAL(12,2) DEFAULT(0),
FechaRegistro DATETIME DEFAULT(NULL),
Correo VARCHAR(100),
PRIMARY KEY(Id,UltimoAhorro)
)
CREATE TRIGGER TR_Usuario_AIU ON TablaUsuario
AFTER INSERT, UPDATE
AS
DECLARE @Id INT
DECLARE @LoginUsuario VARCHAR(100)
DECLARE @NombreCompleto VARCHAR(100)
DECLARE @UltimoAhorro DATETIME
DECLARE @UltimoAhorrado DECIMAL(12,2)
DECLARE @TotalAhorrado DECIMAL(12,2)
DECLARE @FechaRegistro DATETIME
DECLARE @Correo VARCHAR(100)
BEGIN
	SELECT TOP(1) @Id=Id FROM TablaUsuario ORDER BY UltimoAhorro DESC
	SELECT TOP(1) @LoginUsuario=LoginUsuario FROM TablaUsuario ORDER BY UltimoAhorro DESC
	SELECT TOP(1) @NombreCompleto=NombreCompleto FROM TablaUsuario ORDER BY UltimoAhorro DESC
	SELECT TOP(1) @UltimoAhorro=UltimoAhorro FROM TablaUsuario ORDER BY UltimoAhorro DESC
	SELECT TOP(1) @UltimoAhorrado=UltimoAhorrado FROM TablaUsuario ORDER BY UltimoAhorro DESC
	SELECT TOP(1) @TotalAhorrado=TotalAhorrado FROM TablaUsuario ORDER BY UltimoAhorro DESC
	SELECT TOP(1) @FechaRegistro=FechaRegistro FROM TablaUsuario ORDER BY UltimoAhorro DESC
	SELECT TOP(1) @Correo=Correo FROM TablaUsuario ORDER BY UltimoAhorro DESC
	INSERT INTO TablaAhorro (Id, LoginUsuario, NombreCompleto, UltimoAhorro, UltimoAhorrado, TotalAhorrado, FechaRegistro, Correo) VALUES (@Id, @LoginUsuario, @NombreCompleto, @UltimoAhorro, @UltimoAhorrado, @TotalAhorrado, @FechaRegistro, @Correo)
END
ALTER PROCEDURE spListaAhorro
@Id INT
AS
BEGIN
	SELECT * FROM TablaAhorro WHERE Id=@Id ORDER BY UltimoAhorro DESC
END

SELECT * FROM TablaAhorro WHERE Id=1 ORDER BY UltimoAhorro DESC

SELECT * FROM TABLAAHORRO
DECLARE @Cantidad DECIMAL(12,2)
SELECT @Cantidad=50
UPDATE TablaUsuario SET UltimoAhorro=TODATETIMEOFFSET(SYSDATETIME(),'-07:00'), UltimoAhorrado=@Cantidad, TotalAhorrado=(TotalAhorrado+@Cantidad) WHERE Id=1

UPDATE TablaUsuario SET UltimoAhorrado=50, TotalAhorrado=50 WHERE Id=1


DELETE FROM TABLAUSUARIO

SELECT * FROM TABLAUSUARIO
