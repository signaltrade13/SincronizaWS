CREATE TABLE [dbo].[C_Personal] (
    [PersonalID]    INT              NOT NULL,
    [ModuloID]      INT              CONSTRAINT [DF__C_Persona__Modul__656C112C] DEFAULT ((0)) NULL,
    [SueldoID]      INT              CONSTRAINT [DF__C_Persona__Sueld__66603565] DEFAULT ((0)) NULL,
    [AreaID]        INT              NULL,
    [OperacionID]   INT              NULL,
    [Numero]        NVARCHAR (6)     NULL,
    [ApellidoP]     NVARCHAR (50)    NULL,
    [ApellidoM]     NVARCHAR (50)    NULL,
    [Nombre]        NVARCHAR (50)    NULL,
    [Calle]         NVARCHAR (50)    NULL,
    [NumeroExt]     NVARCHAR (10)    NULL,
    [Colonia]       NVARCHAR (50)    NULL,
    [Poblacion]     NVARCHAR (50)    NULL,
    [Ciudad]        NVARCHAR (50)    NULL,
    [Cp]            NVARCHAR (50)    NULL,
    [Telefono]      NVARCHAR (50)    NULL,
    [Emergencia]    NVARCHAR (50)    NULL,
    [TelEmergencia] NVARCHAR (50)    NULL,
    [Rfc]           NVARCHAR (50)    NULL,
    [Estatus]       SMALLINT         NULL,
    [FecNac]        SMALLDATETIME    NULL,
    [Dias]          MONEY            NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__C_Persona__rowgu__0A3E6E7F] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [PuestoID]      NUMERIC (18)     NULL,
    CONSTRAINT [aaaaaC_Personal_PK] PRIMARY KEY NONCLUSTERED ([PersonalID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [C_ModulosC_Personal]
    ON [dbo].[C_Personal]([ModuloID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [C_SueldosC_Personal]
    ON [dbo].[C_Personal]([SueldoID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1926297922]
    ON [dbo].[C_Personal]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [ModuloID]
    ON [dbo].[C_Personal]([ModuloID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [PersonalID]
    ON [dbo].[C_Personal]([PersonalID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [SueldoID]
    ON [dbo].[C_Personal]([SueldoID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE TRIGGER [T_C_Personal_DTrig] ON [dbo].[C_Personal] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Etiquetas' */
DELETE T_Etiquetas FROM deleted, T_Etiquetas WHERE deleted.PersonalID = T_Etiquetas.PersonalID








GO
CREATE TRIGGER [T_C_Personal_ITrig] ON [dbo].[C_Personal] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Sueldos' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Sueldos, inserted WHERE (C_Sueldos.SueldoID = inserted.SueldoID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Sueldos''.', 44447, 1)
        ROLLBACK TRANSACTION
    END









GO
CREATE TRIGGER [T_C_Personal_UTrig] ON [dbo].[C_Personal] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Etiquetas' */
IF UPDATE(PersonalID)
    BEGIN
       UPDATE T_Etiquetas
       SET T_Etiquetas.PersonalID = inserted.PersonalID
       FROM T_Etiquetas, deleted, inserted
       WHERE deleted.PersonalID = T_Etiquetas.PersonalID
    END

/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Sueldos' */
IF UPDATE(SueldoID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Sueldos, inserted WHERE (C_Sueldos.SueldoID = inserted.SueldoID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Sueldos''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END








