USE [BDHardwareFinal]
GO

/* ============================================================
   DIGITO VERIFICADOR - TABLA USUARIO
   ============================================================
   Este script agrega una validación simple de integridad:

   - DVH: Dígito Verificador Horizontal por cada usuario.
   - DVV: Dígito Verificador Vertical de toda la tabla Usuario.

   Algoritmo utilizado:
   suma de códigos ASCII/Unicode de NombreUsuario + Contraseña.

   Es intencionalmente simple para poder explicarlo en examen.
   ============================================================ */

IF COL_LENGTH('dbo.Usuario', 'DVH') IS NULL
BEGIN
    ALTER TABLE dbo.Usuario
    ADD DVH INT NOT NULL CONSTRAINT DF_Usuario_DVH DEFAULT(0);
END
GO

IF OBJECT_ID('dbo.DigitoVerificadorVertical', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.DigitoVerificadorVertical
    (
        Entidad VARCHAR(50) NOT NULL CONSTRAINT PK_DigitoVerificadorVertical PRIMARY KEY,
        Valor INT NOT NULL,
        FechaActualizacion DATETIME NOT NULL CONSTRAINT DF_DVV_Fecha DEFAULT(GETDATE())
    );
END
GO

CREATE OR ALTER FUNCTION dbo.fn_CalcularDigitoVerificadorTexto
(
    @Texto NVARCHAR(MAX)
)
RETURNS INT
AS
BEGIN
    DECLARE @Resultado INT = 0;
    DECLARE @Indice INT = 1;
    DECLARE @Largo INT = LEN(ISNULL(@Texto, ''));

    WHILE @Indice <= @Largo
    BEGIN
        SET @Resultado = @Resultado + UNICODE(SUBSTRING(@Texto, @Indice, 1));
        SET @Indice = @Indice + 1;
    END

    RETURN @Resultado;
END
GO

CREATE OR ALTER FUNCTION dbo.fn_CalcularDVHUsuario
(
    @NombreUsuario VARCHAR(20),
    @Contrasenia VARCHAR(100)
)
RETURNS INT
AS
BEGIN
    RETURN dbo.fn_CalcularDigitoVerificadorTexto(
        LTRIM(RTRIM(ISNULL(@NombreUsuario, ''))) +
        LTRIM(RTRIM(ISNULL(@Contrasenia, '')))
    );
END
GO

-- Inicializa/recalcula DVH de usuarios existentes.
UPDATE dbo.Usuario
SET DVH = dbo.fn_CalcularDVHUsuario(NombreUsuario, Contraseña);
GO

CREATE OR ALTER PROCEDURE dbo.s_DigitoVerificador_Usuario_Recalcular
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Usuario
    SET DVH = dbo.fn_CalcularDVHUsuario(NombreUsuario, Contraseña);

    DECLARE @DVV INT;

    SELECT @DVV = ISNULL(SUM(DVH), 0)
    FROM dbo.Usuario;

    IF EXISTS (SELECT 1 FROM dbo.DigitoVerificadorVertical WHERE Entidad = 'Usuario')
    BEGIN
        UPDATE dbo.DigitoVerificadorVertical
        SET Valor = @DVV,
            FechaActualizacion = GETDATE()
        WHERE Entidad = 'Usuario';
    END
    ELSE
    BEGIN
        INSERT INTO dbo.DigitoVerificadorVertical (Entidad, Valor)
        VALUES ('Usuario', @DVV);
    END
END
GO

EXEC dbo.s_DigitoVerificador_Usuario_Recalcular;
GO

CREATE OR ALTER PROCEDURE dbo.s_DigitoVerificador_Usuario_Verificar
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DVVCalculado INT;
    DECLARE @DVVPersistido INT;

    SELECT @DVVCalculado = ISNULL(SUM(DVH), 0)
    FROM dbo.Usuario;

    SELECT @DVVPersistido = Valor
    FROM dbo.DigitoVerificadorVertical
    WHERE Entidad = 'Usuario';

    SELECT
        ISNULL(@DVVCalculado, 0) AS DVVCalculado,
        ISNULL(@DVVPersistido, 0) AS DVVPersistido,
        CASE WHEN ISNULL(@DVVCalculado, 0) = ISNULL(@DVVPersistido, 0)
             THEN CAST(1 AS BIT)
             ELSE CAST(0 AS BIT)
        END AS IntegridadOK;
END
GO

/* ============================================================
   Stored Procedures de Usuario actualizados para devolver DVH
   y mantener actualizado el DVV después de insertar usuarios.
   ============================================================ */

CREATE OR ALTER PROCEDURE dbo.s_Usuario_Crear
    @NombreUsuario VARCHAR(20),
    @Contraseña VARCHAR(100),
    @DVH INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Usuario (NombreUsuario, Contraseña, DVH)
    VALUES (@NombreUsuario, @Contraseña, @DVH);

    EXEC dbo.s_DigitoVerificador_Usuario_Recalcular;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Usuario_ObtenerPorNombre
    @NombreUsuario VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IDUser,
        NombreUsuario,
        Contraseña,
        DVH
    FROM dbo.Usuario
    WHERE LTRIM(RTRIM(NombreUsuario)) = LTRIM(RTRIM(@NombreUsuario));
END
GO

CREATE OR ALTER PROCEDURE dbo.s_ListarUnUser
    @Username VARCHAR(20),
    @Password VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IDUser,
        NombreUsuario,
        Contraseña,
        DVH
    FROM dbo.Usuario
    WHERE LTRIM(RTRIM(NombreUsuario)) = LTRIM(RTRIM(@Username))
      AND Contraseña = @Password;
END
GO

CREATE OR ALTER PROCEDURE dbo.S_Usuarios_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IDUser,
        NombreUsuario,
        Contraseña,
        DVH
    FROM dbo.Usuario
    ORDER BY IDUser;
END
GO
