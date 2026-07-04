USE [BDHardwareFinal]
GO

/*=============================================================================
  MODULO DE PERMISOS - PATRON COMPOSITE
  Proyecto: LegalCaseManagment / BDHardwareFinal

  Este script agrega las tablas y stored procedures necesarios para persistir:
  - Patentes: permisos hoja.
  - Familias: grupos/roles de permisos.
  - FamiliaPatente: relacion Familia -> Patente.
  - FamiliaFamilia: relacion Familia -> Familia para composite recursivo.
  - UsuarioFamilia: asignacion de familias a usuarios.

  Es un script NO destructivo: no borra tablas existentes ni datos actuales.
=============================================================================*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*=============================================================================
  VALIDACIONES BASICAS
=============================================================================*/
IF OBJECT_ID(N'dbo.Usuario', N'U') IS NULL
BEGIN
    RAISERROR('No existe la tabla dbo.Usuario. Ejecutar primero el script base de la BD.', 16, 1);
    RETURN;
END
GO

IF COL_LENGTH('dbo.Usuario', 'IDUser') IS NULL
BEGIN
    RAISERROR('La tabla dbo.Usuario no tiene la columna IDUser esperada por el proyecto.', 16, 1);
    RETURN;
END
GO

/*=============================================================================
  TABLAS
=============================================================================*/
IF OBJECT_ID(N'dbo.Patente', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Patente
    (
        IDPatente   INT IDENTITY(1,1) NOT NULL,
        Id          UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Patente_Id DEFAULT NEWID(),
        Nombre      VARCHAR(100) NOT NULL,
        Codigo      VARCHAR(50) NOT NULL,
        TipoPermiso INT NULL,
        Activo      BIT NOT NULL CONSTRAINT DF_Patente_Activo DEFAULT (1),
        CONSTRAINT PK_Patente PRIMARY KEY CLUSTERED (IDPatente ASC),
        CONSTRAINT UQ_Patente_Id UNIQUE (Id),
        CONSTRAINT UQ_Patente_Codigo UNIQUE (Codigo)
    );
END
GO

IF OBJECT_ID(N'dbo.Familia', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Familia
    (
        IDFamilia INT IDENTITY(1,1) NOT NULL,
        Id        UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Familia_Id DEFAULT NEWID(),
        Nombre    VARCHAR(100) NOT NULL,
        Activo    BIT NOT NULL CONSTRAINT DF_Familia_Activo DEFAULT (1),
        CONSTRAINT PK_Familia PRIMARY KEY CLUSTERED (IDFamilia ASC),
        CONSTRAINT UQ_Familia_Id UNIQUE (Id),
        CONSTRAINT UQ_Familia_Nombre UNIQUE (Nombre)
    );
END
GO

IF OBJECT_ID(N'dbo.FamiliaPatente', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FamiliaPatente
    (
        IDFamilia INT NOT NULL,
        IDPatente INT NOT NULL,
        CONSTRAINT PK_FamiliaPatente PRIMARY KEY CLUSTERED (IDFamilia ASC, IDPatente ASC),
        CONSTRAINT FK_FamiliaPatente_Familia FOREIGN KEY (IDFamilia)
            REFERENCES dbo.Familia(IDFamilia),
        CONSTRAINT FK_FamiliaPatente_Patente FOREIGN KEY (IDPatente)
            REFERENCES dbo.Patente(IDPatente)
    );
END
GO

IF OBJECT_ID(N'dbo.FamiliaFamilia', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.FamiliaFamilia
    (
        IDFamiliaPadre INT NOT NULL,
        IDFamiliaHija  INT NOT NULL,
        CONSTRAINT PK_FamiliaFamilia PRIMARY KEY CLUSTERED (IDFamiliaPadre ASC, IDFamiliaHija ASC),
        CONSTRAINT FK_FamiliaFamilia_Padre FOREIGN KEY (IDFamiliaPadre)
            REFERENCES dbo.Familia(IDFamilia),
        CONSTRAINT FK_FamiliaFamilia_Hija FOREIGN KEY (IDFamiliaHija)
            REFERENCES dbo.Familia(IDFamilia),
        CONSTRAINT CK_FamiliaFamilia_NoAutoRelacion CHECK (IDFamiliaPadre <> IDFamiliaHija)
    );
END
GO

IF OBJECT_ID(N'dbo.UsuarioFamilia', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.UsuarioFamilia
    (
        IDUser    INT NOT NULL,
        IDFamilia INT NOT NULL,
        CONSTRAINT PK_UsuarioFamilia PRIMARY KEY CLUSTERED (IDUser ASC, IDFamilia ASC),
        CONSTRAINT FK_UsuarioFamilia_Usuario FOREIGN KEY (IDUser)
            REFERENCES dbo.Usuario(IDUser),
        CONSTRAINT FK_UsuarioFamilia_Familia FOREIGN KEY (IDFamilia)
            REFERENCES dbo.Familia(IDFamilia)
    );
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_Patente_TipoPermiso_NotNull' AND object_id = OBJECT_ID(N'dbo.Patente'))
BEGIN
    CREATE UNIQUE INDEX UX_Patente_TipoPermiso_NotNull
    ON dbo.Patente(TipoPermiso)
    WHERE TipoPermiso IS NOT NULL;
END
GO

/*=============================================================================
  INDICES AUXILIARES
=============================================================================*/
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_FamiliaPatente_IDPatente' AND object_id = OBJECT_ID(N'dbo.FamiliaPatente'))
BEGIN
    CREATE INDEX IX_FamiliaPatente_IDPatente ON dbo.FamiliaPatente(IDPatente);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_FamiliaFamilia_IDFamiliaHija' AND object_id = OBJECT_ID(N'dbo.FamiliaFamilia'))
BEGIN
    CREATE INDEX IX_FamiliaFamilia_IDFamiliaHija ON dbo.FamiliaFamilia(IDFamiliaHija);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_UsuarioFamilia_IDFamilia' AND object_id = OBJECT_ID(N'dbo.UsuarioFamilia'))
BEGIN
    CREATE INDEX IX_UsuarioFamilia_IDFamilia ON dbo.UsuarioFamilia(IDFamilia);
END
GO

/*=============================================================================
  STORED PROCEDURES - PATENTE
=============================================================================*/
CREATE OR ALTER PROCEDURE dbo.s_Patente_Crear
    @Nombre VARCHAR(100),
    @Codigo VARCHAR(50),
    @TipoPermiso INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.Patente WHERE Codigo = @Codigo)
    BEGIN
        RAISERROR('Ya existe una patente con ese Codigo.', 16, 1);
        RETURN;
    END

    IF @TipoPermiso IS NOT NULL
       AND EXISTS (SELECT 1 FROM dbo.Patente WHERE TipoPermiso = @TipoPermiso)
    BEGIN
        RAISERROR('Ya existe una patente con ese TipoPermiso.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.Patente (Nombre, Codigo, TipoPermiso, Activo)
    VALUES (@Nombre, @Codigo, @TipoPermiso, 1);

    SELECT SCOPE_IDENTITY() AS IDPatente;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Patente_Modificar
    @IDPatente INT,
    @Nombre VARCHAR(100),
    @Codigo VARCHAR(50),
    @TipoPermiso INT = NULL,
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Patente WHERE IDPatente = @IDPatente)
    BEGIN
        RAISERROR('No existe la patente indicada.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.Patente WHERE Codigo = @Codigo AND IDPatente <> @IDPatente)
    BEGIN
        RAISERROR('Ya existe otra patente con ese Codigo.', 16, 1);
        RETURN;
    END

    IF @TipoPermiso IS NOT NULL
       AND EXISTS (SELECT 1 FROM dbo.Patente WHERE TipoPermiso = @TipoPermiso AND IDPatente <> @IDPatente)
    BEGIN
        RAISERROR('Ya existe otra patente con ese TipoPermiso.', 16, 1);
        RETURN;
    END

    UPDATE dbo.Patente
    SET Nombre = @Nombre,
        Codigo = @Codigo,
        TipoPermiso = @TipoPermiso,
        Activo = @Activo
    WHERE IDPatente = @IDPatente;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Patente_Eliminar
    @IDPatente INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Patente
    SET Activo = 0
    WHERE IDPatente = @IDPatente;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Patente_Listar
    @SoloActivos BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IDPatente, Id, Nombre, Codigo, TipoPermiso, Activo
    FROM dbo.Patente
    WHERE (@SoloActivos = 0 OR Activo = 1)
    ORDER BY Nombre;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Patente_ObtenerPorId
    @IDPatente INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IDPatente, Id, Nombre, Codigo, TipoPermiso, Activo
    FROM dbo.Patente
    WHERE IDPatente = @IDPatente;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Patente_ObtenerPorTipoPermiso
    @TipoPermiso INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IDPatente, Id, Nombre, Codigo, TipoPermiso, Activo
    FROM dbo.Patente
    WHERE TipoPermiso = @TipoPermiso;
END
GO

/*=============================================================================
  STORED PROCEDURES - FAMILIA
=============================================================================*/
CREATE OR ALTER PROCEDURE dbo.s_Familia_Crear
    @Nombre VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.Familia WHERE Nombre = @Nombre)
    BEGIN
        RAISERROR('Ya existe una familia con ese nombre.', 16, 1);
        RETURN;
    END

    INSERT INTO dbo.Familia (Nombre, Activo)
    VALUES (@Nombre, 1);

    SELECT SCOPE_IDENTITY() AS IDFamilia;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_Modificar
    @IDFamilia INT,
    @Nombre VARCHAR(100),
    @Activo BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Familia WHERE IDFamilia = @IDFamilia)
    BEGIN
        RAISERROR('No existe la familia indicada.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM dbo.Familia WHERE Nombre = @Nombre AND IDFamilia <> @IDFamilia)
    BEGIN
        RAISERROR('Ya existe otra familia con ese nombre.', 16, 1);
        RETURN;
    END

    UPDATE dbo.Familia
    SET Nombre = @Nombre,
        Activo = @Activo
    WHERE IDFamilia = @IDFamilia;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_Eliminar
    @IDFamilia INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Familia
    SET Activo = 0
    WHERE IDFamilia = @IDFamilia;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_Listar
    @SoloActivos BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IDFamilia, Id, Nombre, Activo
    FROM dbo.Familia
    WHERE (@SoloActivos = 0 OR Activo = 1)
    ORDER BY Nombre;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_ObtenerPorId
    @IDFamilia INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IDFamilia, Id, Nombre, Activo
    FROM dbo.Familia
    WHERE IDFamilia = @IDFamilia;
END
GO

/*=============================================================================
  STORED PROCEDURES - RELACIONES FAMILIA/PATENTE Y FAMILIA/FAMILIA
=============================================================================*/
CREATE OR ALTER PROCEDURE dbo.s_Familia_AgregarPatente
    @IDFamilia INT,
    @IDPatente INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Familia WHERE IDFamilia = @IDFamilia AND Activo = 1)
    BEGIN
        RAISERROR('No existe la familia indicada o se encuentra inactiva.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Patente WHERE IDPatente = @IDPatente AND Activo = 1)
    BEGIN
        RAISERROR('No existe la patente indicada o se encuentra inactiva.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.FamiliaPatente WHERE IDFamilia = @IDFamilia AND IDPatente = @IDPatente)
    BEGIN
        INSERT INTO dbo.FamiliaPatente (IDFamilia, IDPatente)
        VALUES (@IDFamilia, @IDPatente);
    END
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_QuitarPatente
    @IDFamilia INT,
    @IDPatente INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.FamiliaPatente
    WHERE IDFamilia = @IDFamilia
      AND IDPatente = @IDPatente;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_AgregarFamilia
    @IDFamiliaPadre INT,
    @IDFamiliaHija INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @IDFamiliaPadre = @IDFamiliaHija
    BEGIN
        RAISERROR('Una familia no puede contenerse a si misma.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Familia WHERE IDFamilia = @IDFamiliaPadre AND Activo = 1)
    BEGIN
        RAISERROR('No existe la familia padre indicada o se encuentra inactiva.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Familia WHERE IDFamilia = @IDFamiliaHija AND Activo = 1)
    BEGIN
        RAISERROR('No existe la familia hija indicada o se encuentra inactiva.', 16, 1);
        RETURN;
    END

    ;WITH Descendientes AS
    (
        SELECT IDFamiliaHija
        FROM dbo.FamiliaFamilia
        WHERE IDFamiliaPadre = @IDFamiliaHija

        UNION ALL

        SELECT FF.IDFamiliaHija
        FROM dbo.FamiliaFamilia FF
        INNER JOIN Descendientes D
            ON FF.IDFamiliaPadre = D.IDFamiliaHija
    )
    SELECT IDFamiliaHija INTO #Descendientes FROM Descendientes;

    IF EXISTS (SELECT 1 FROM #Descendientes WHERE IDFamiliaHija = @IDFamiliaPadre)
    BEGIN
        DROP TABLE #Descendientes;
        RAISERROR('La relacion generaria un ciclo en el arbol de familias.', 16, 1);
        RETURN;
    END

    DROP TABLE #Descendientes;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.FamiliaFamilia
        WHERE IDFamiliaPadre = @IDFamiliaPadre
          AND IDFamiliaHija = @IDFamiliaHija
    )
    BEGIN
        INSERT INTO dbo.FamiliaFamilia (IDFamiliaPadre, IDFamiliaHija)
        VALUES (@IDFamiliaPadre, @IDFamiliaHija);
    END
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_QuitarFamilia
    @IDFamiliaPadre INT,
    @IDFamiliaHija INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.FamiliaFamilia
    WHERE IDFamiliaPadre = @IDFamiliaPadre
      AND IDFamiliaHija = @IDFamiliaHija;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_ListarPatentes
    @IDFamilia INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT P.IDPatente, P.Id, P.Nombre, P.Codigo, P.TipoPermiso, P.Activo
    FROM dbo.FamiliaPatente FP
    INNER JOIN dbo.Patente P
        ON FP.IDPatente = P.IDPatente
    WHERE FP.IDFamilia = @IDFamilia
    ORDER BY P.Nombre;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_ListarFamiliasHijas
    @IDFamilia INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT F.IDFamilia, F.Id, F.Nombre, F.Activo
    FROM dbo.FamiliaFamilia FF
    INNER JOIN dbo.Familia F
        ON FF.IDFamiliaHija = F.IDFamilia
    WHERE FF.IDFamiliaPadre = @IDFamilia
    ORDER BY F.Nombre;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_ListarRelaciones
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        FP.IDFamilia AS IDFamiliaPadre,
        'P' AS TipoHijo,
        FP.IDPatente AS IDHijo,
        P.Id AS GuidHijo,
        P.Nombre AS NombreHijo,
        P.Codigo,
        P.TipoPermiso,
        P.Activo
    FROM dbo.FamiliaPatente FP
    INNER JOIN dbo.Patente P ON FP.IDPatente = P.IDPatente

    UNION ALL

    SELECT
        FF.IDFamiliaPadre,
        'F' AS TipoHijo,
        FF.IDFamiliaHija AS IDHijo,
        F.Id AS GuidHijo,
        F.Nombre AS NombreHijo,
        NULL AS Codigo,
        NULL AS TipoPermiso,
        F.Activo
    FROM dbo.FamiliaFamilia FF
    INNER JOIN dbo.Familia F ON FF.IDFamiliaHija = F.IDFamilia

    ORDER BY IDFamiliaPadre, TipoHijo, NombreHijo;
END
GO

/*=============================================================================
  STORED PROCEDURES - USUARIO/FAMILIA
=============================================================================*/
CREATE OR ALTER PROCEDURE dbo.s_UsuarioFamilia_Asignar
    @IDUser INT,
    @IDFamilia INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM dbo.Usuario WHERE IDUser = @IDUser)
    BEGIN
        RAISERROR('No existe el usuario indicado.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.Familia WHERE IDFamilia = @IDFamilia AND Activo = 1)
    BEGIN
        RAISERROR('No existe la familia indicada o se encuentra inactiva.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM dbo.UsuarioFamilia WHERE IDUser = @IDUser AND IDFamilia = @IDFamilia)
    BEGIN
        INSERT INTO dbo.UsuarioFamilia (IDUser, IDFamilia)
        VALUES (@IDUser, @IDFamilia);
    END
END
GO

CREATE OR ALTER PROCEDURE dbo.s_UsuarioFamilia_Quitar
    @IDUser INT,
    @IDFamilia INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.UsuarioFamilia
    WHERE IDUser = @IDUser
      AND IDFamilia = @IDFamilia;
END
GO

CREATE OR ALTER PROCEDURE dbo.s_UsuarioFamilia_Listar
    @IDUser INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT F.IDFamilia, F.Id, F.Nombre, F.Activo
    FROM dbo.UsuarioFamilia UF
    INNER JOIN dbo.Familia F
        ON UF.IDFamilia = F.IDFamilia
    WHERE UF.IDUser = @IDUser
    ORDER BY F.Nombre;
END
GO

/*=============================================================================
  STORED PROCEDURES - CONSULTAS RECURSIVAS PARA AUTORIZACION
=============================================================================*/
CREATE OR ALTER PROCEDURE dbo.s_Usuario_Permisos_Listar
    @IDUser INT
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH FamiliasUsuario AS
    (
        SELECT F.IDFamilia, F.Id, F.Nombre, F.Activo, 0 AS Nivel
        FROM dbo.UsuarioFamilia UF
        INNER JOIN dbo.Familia F
            ON UF.IDFamilia = F.IDFamilia
        WHERE UF.IDUser = @IDUser
          AND F.Activo = 1

        UNION ALL

        SELECT FH.IDFamilia, FH.Id, FH.Nombre, FH.Activo, FU.Nivel + 1
        FROM FamiliasUsuario FU
        INNER JOIN dbo.FamiliaFamilia FF
            ON FU.IDFamilia = FF.IDFamiliaPadre
        INNER JOIN dbo.Familia FH
            ON FF.IDFamiliaHija = FH.IDFamilia
        WHERE FH.Activo = 1
    )
    SELECT DISTINCT
        'F' AS TipoComponente,
        FU.IDFamilia AS IDComponente,
        FU.Id AS GuidComponente,
        FU.Nombre,
        NULL AS Codigo,
        NULL AS TipoPermiso,
        FU.Nivel
    FROM FamiliasUsuario FU

    UNION ALL

    SELECT DISTINCT
        'P' AS TipoComponente,
        P.IDPatente AS IDComponente,
        P.Id AS GuidComponente,
        P.Nombre,
        P.Codigo,
        P.TipoPermiso,
        FU.Nivel + 1 AS Nivel
    FROM FamiliasUsuario FU
    INNER JOIN dbo.FamiliaPatente FP
        ON FU.IDFamilia = FP.IDFamilia
    INNER JOIN dbo.Patente P
        ON FP.IDPatente = P.IDPatente
    WHERE P.Activo = 1

    ORDER BY TipoComponente, Nombre
    OPTION (MAXRECURSION 100);
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Usuario_TienePermiso
    @IDUser INT,
    @TipoPermiso INT
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH FamiliasUsuario AS
    (
        SELECT F.IDFamilia
        FROM dbo.UsuarioFamilia UF
        INNER JOIN dbo.Familia F
            ON UF.IDFamilia = F.IDFamilia
        WHERE UF.IDUser = @IDUser
          AND F.Activo = 1

        UNION ALL

        SELECT FH.IDFamilia
        FROM FamiliasUsuario FU
        INNER JOIN dbo.FamiliaFamilia FF
            ON FU.IDFamilia = FF.IDFamiliaPadre
        INNER JOIN dbo.Familia FH
            ON FF.IDFamiliaHija = FH.IDFamilia
        WHERE FH.Activo = 1
    )
    SELECT
        CASE WHEN EXISTS
        (
            SELECT 1
            FROM FamiliasUsuario FU
            INNER JOIN dbo.FamiliaPatente FP
                ON FU.IDFamilia = FP.IDFamilia
            INNER JOIN dbo.Patente P
                ON FP.IDPatente = P.IDPatente
            WHERE P.Activo = 1
              AND P.TipoPermiso = @TipoPermiso
        )
        THEN CAST(1 AS BIT)
        ELSE CAST(0 AS BIT)
        END AS TienePermiso
    OPTION (MAXRECURSION 100);
END
GO

CREATE OR ALTER PROCEDURE dbo.s_Familia_PermisosPlano_Listar
    @IDFamilia INT
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH Familias AS
    (
        SELECT F.IDFamilia, F.Id, F.Nombre, F.Activo, 0 AS Nivel
        FROM dbo.Familia F
        WHERE F.IDFamilia = @IDFamilia
          AND F.Activo = 1

        UNION ALL

        SELECT FH.IDFamilia, FH.Id, FH.Nombre, FH.Activo, FA.Nivel + 1
        FROM Familias FA
        INNER JOIN dbo.FamiliaFamilia FF
            ON FA.IDFamilia = FF.IDFamiliaPadre
        INNER JOIN dbo.Familia FH
            ON FF.IDFamiliaHija = FH.IDFamilia
        WHERE FH.Activo = 1
    )
    SELECT DISTINCT
        P.IDPatente,
        P.Id,
        P.Nombre,
        P.Codigo,
        P.TipoPermiso,
        P.Activo
    FROM Familias F
    INNER JOIN dbo.FamiliaPatente FP
        ON F.IDFamilia = FP.IDFamilia
    INNER JOIN dbo.Patente P
        ON FP.IDPatente = P.IDPatente
    WHERE P.Activo = 1
    ORDER BY P.Nombre
    OPTION (MAXRECURSION 100);
END
GO

/*=============================================================================
  DATOS INICIALES COMPATIBLES CON BE.TipoPermiso

  En tu enum actual:
    GestorPermiso = 0
    GestorUsuario = 1
=============================================================================*/
IF NOT EXISTS (SELECT 1 FROM dbo.Patente WHERE Codigo = 'GESTOR_PERMISO')
BEGIN
    INSERT INTO dbo.Patente (Nombre, Codigo, TipoPermiso, Activo)
    VALUES ('Puede gestionar permisos', 'GESTOR_PERMISO', 0, 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Patente WHERE Codigo = 'GESTOR_USUARIO')
BEGIN
    INSERT INTO dbo.Patente (Nombre, Codigo, TipoPermiso, Activo)
    VALUES ('Puede gestionar usuarios', 'GESTOR_USUARIO', 1, 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Familia WHERE Nombre = 'Gestores de permisos')
BEGIN
    INSERT INTO dbo.Familia (Nombre, Activo)
    VALUES ('Gestores de permisos', 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Familia WHERE Nombre = 'Gestores de usuarios')
BEGIN
    INSERT INTO dbo.Familia (Nombre, Activo)
    VALUES ('Gestores de usuarios', 1);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Familia WHERE Nombre = 'Administradores')
BEGIN
    INSERT INTO dbo.Familia (Nombre, Activo)
    VALUES ('Administradores', 1);
END
GO

DECLARE @IDFamiliaGestorPermiso INT,
        @IDFamiliaGestorUsuario INT,
        @IDFamiliaAdmin INT,
        @IDPatenteGestorPermiso INT,
        @IDPatenteGestorUsuario INT,
        @IDAdminUser INT;

SELECT @IDFamiliaGestorPermiso = IDFamilia FROM dbo.Familia WHERE Nombre = 'Gestores de permisos';
SELECT @IDFamiliaGestorUsuario = IDFamilia FROM dbo.Familia WHERE Nombre = 'Gestores de usuarios';
SELECT @IDFamiliaAdmin = IDFamilia FROM dbo.Familia WHERE Nombre = 'Administradores';

SELECT @IDPatenteGestorPermiso = IDPatente FROM dbo.Patente WHERE Codigo = 'GESTOR_PERMISO';
SELECT @IDPatenteGestorUsuario = IDPatente FROM dbo.Patente WHERE Codigo = 'GESTOR_USUARIO';

IF @IDFamiliaGestorPermiso IS NOT NULL AND @IDPatenteGestorPermiso IS NOT NULL
   AND NOT EXISTS (SELECT 1 FROM dbo.FamiliaPatente WHERE IDFamilia = @IDFamiliaGestorPermiso AND IDPatente = @IDPatenteGestorPermiso)
BEGIN
    INSERT INTO dbo.FamiliaPatente (IDFamilia, IDPatente)
    VALUES (@IDFamiliaGestorPermiso, @IDPatenteGestorPermiso);
END

IF @IDFamiliaGestorUsuario IS NOT NULL AND @IDPatenteGestorUsuario IS NOT NULL
   AND NOT EXISTS (SELECT 1 FROM dbo.FamiliaPatente WHERE IDFamilia = @IDFamiliaGestorUsuario AND IDPatente = @IDPatenteGestorUsuario)
BEGIN
    INSERT INTO dbo.FamiliaPatente (IDFamilia, IDPatente)
    VALUES (@IDFamiliaGestorUsuario, @IDPatenteGestorUsuario);
END

IF @IDFamiliaAdmin IS NOT NULL AND @IDFamiliaGestorPermiso IS NOT NULL
   AND NOT EXISTS (SELECT 1 FROM dbo.FamiliaFamilia WHERE IDFamiliaPadre = @IDFamiliaAdmin AND IDFamiliaHija = @IDFamiliaGestorPermiso)
BEGIN
    EXEC dbo.s_Familia_AgregarFamilia @IDFamiliaAdmin, @IDFamiliaGestorPermiso;
END

IF @IDFamiliaAdmin IS NOT NULL AND @IDFamiliaGestorUsuario IS NOT NULL
   AND NOT EXISTS (SELECT 1 FROM dbo.FamiliaFamilia WHERE IDFamiliaPadre = @IDFamiliaAdmin AND IDFamiliaHija = @IDFamiliaGestorUsuario)
BEGIN
    EXEC dbo.s_Familia_AgregarFamilia @IDFamiliaAdmin, @IDFamiliaGestorUsuario;
END

SELECT @IDAdminUser = IDUser
FROM dbo.Usuario
WHERE LTRIM(RTRIM(NombreUsuario)) = 'admin';

IF @IDAdminUser IS NOT NULL AND @IDFamiliaAdmin IS NOT NULL
   AND NOT EXISTS (SELECT 1 FROM dbo.UsuarioFamilia WHERE IDUser = @IDAdminUser AND IDFamilia = @IDFamiliaAdmin)
BEGIN
    INSERT INTO dbo.UsuarioFamilia (IDUser, IDFamilia)
    VALUES (@IDAdminUser, @IDFamiliaAdmin);
END
GO

/*=============================================================================
  PRUEBA RAPIDA
  Descomentar para validar luego de ejecutar:

  DECLARE @IDAdmin INT;
  SELECT @IDAdmin = IDUser FROM dbo.Usuario WHERE LTRIM(RTRIM(NombreUsuario)) = 'admin';
  EXEC dbo.s_Usuario_Permisos_Listar @IDAdmin;
  EXEC dbo.s_Usuario_TienePermiso @IDAdmin, 0; -- GestorPermiso
  EXEC dbo.s_Usuario_TienePermiso @IDAdmin, 1; -- GestorUsuario
=============================================================================*/
