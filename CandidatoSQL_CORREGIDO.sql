CREATE TABLE Persona
(
    IdPer INT IDENTITY,
    FRegistro DATETIME, -- default 
    FActualizacion DATETIME,
    Nombre VARCHAR(50),
    Paterno VARCHAR(50),
    Materno VARCHAR(50),
    RFC VARCHAR(13),
    FNacimiento DATE,
    Usuario INT,
    Activo BIT 
);

ALTER TABLE Persona
ADD CONSTRAINT [PK_Persona]
    PRIMARY KEY (IdPer);

ALTER TABLE Persona
ADD CONSTRAINT [DF_Persona_FRegistro]
    DEFAULT (GETDATE()) FOR FRegistro;

ALTER TABLE Persona
ADD CONSTRAINT [DF_Persona_Activo]
    DEFAULT (1) FOR Activo;
GO
-- ===================================================================
CREATE PROCEDURE dbo.SP_NuevaPersona
(
    @Nombre VARCHAR(50),
    @Paterno VARCHAR(50),
    @Materno VARCHAR(50),
    @RFC VARCHAR(13),
    @FNacimiento DATE,
    @Usuario INT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ID INT,
            @ERROR VARCHAR(500);
    BEGIN TRY
        IF LEN(@RFC) != 13
        BEGIN
            SELECT @ERROR = 'El RFC no es válido';
            THROW 50000, @ERROR, 1;
        END;
        IF EXISTS
        (
            SELECT *
            FROM dbo.Persona
            WHERE RFC = @RFC
                  AND Activo = 1
        )
        BEGIN
            SELECT @ERROR = 'El RFC ya existe en el sistema';
            THROW 50000, @ERROR, 1;
        END;

        INSERT INTO dbo.Persona
        (
            FRegistro,
            FActualizacion,
            Nombre,
            Paterno,
            Materno,
            RFC,
            FNacimiento,
            Usuario,
            Activo
        )
        VALUES
        (   GETDATE(),        -- FechaRegistro - datetime
            NULL,             -- FechaActualizacion - datetime
            @Nombre,          -- Nombre - varchar(50)
            @Paterno,		  -- ApellidoPaterno - varchar(50)
            @Materno,		  -- ApellidoMaterno - varchar(50)
            @RFC,             -- RFC - varchar(13)
            @FNacimiento,	  -- FechaNacimiento - date
            @Usuario,		  -- UsuarioAgrega - int
            1                 -- Activo - bit
            );

        SELECT @ID = SCOPE_IDENTITY();
        SELECT @ID AS ERROR,
               'Registro exitoso' AS MENSAJEERROR;
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
        SELECT ERROR_NUMBER() * -1 AS ERROR,
               ISNULL(@ERROR, 'Error al guardar el registro.') AS MENSAJEERROR;
    END CATCH;
END;
GO

CREATE PROCEDURE dbo.SP_Actualizar
(
    @IdPer INT,
    @Nombre VARCHAR(50),
    @Paterno VARCHAR(50),
    @Materno VARCHAR(50),
    @RFC VARCHAR(13),
    @FNacimiento DATE,
    @Usuario INT
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ID INT,
            @ERROR VARCHAR(500);
    BEGIN TRY
        IF NOT EXISTS
        (
            SELECT *
            FROM dbo.Persona
            WHERE IdPer = @IdPer
                  AND Activo = 1
        )
        BEGIN
            SELECT @ERROR = 'La persona fisica no existe.';
            THROW 50000, @ERROR, 1;
        END;

        UPDATE dbo.Persona
        SET Nombre = @Nombre,
            Paterno = @Paterno,
            Materno = @Materno,
            RFC = @RFC,
            FNacimiento = @FNacimiento,
            FActualizacion = GETDATE()
        WHERE IdPer = @IdPer;
        SELECT @IdPer AS ERROR,
               'Registro exitoso' AS MENSAJEERROR;
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
        SELECT ERROR_NUMBER() * -1 AS ERROR,
               ISNULL(@ERROR, 'Error al actualizar el registro.') AS MENSAJEERROR;
    END CATCH;
END;
GO


CREATE PROCEDURE dbo.SP_Eliminar
(@IdPer INT)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @ID INT,
            @ERROR VARCHAR(500);
    BEGIN TRY
        IF NOT EXISTS
        (
            SELECT *
            FROM dbo.Persona
            WHERE IdPer = @IdPer
                  AND Activo = 1
        )
        BEGIN
            SELECT @ERROR = 'La persona fisica no existe.';
            THROW 50000, @ERROR, 1;
        END;

        UPDATE dbo.Persona
        SET Activo = 0
        WHERE IdPer = @IdPer;
        SELECT @IdPer AS ERROR,
               'Eliminacion exitosa' AS MENSAJEERROR;
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
        SELECT ERROR_NUMBER() * -1 AS ERROR,
               ISNULL(@ERROR, 'Error al actualizar el registro.') AS MENSAJEERROR;
    END CATCH;
END;
GO

-------------------------------------------------------- NOTA ----------------------------------------------
---------------------------------SI HAY ERRORES LOGICOS HAY QUE CORREGIRLOS---------------------------------