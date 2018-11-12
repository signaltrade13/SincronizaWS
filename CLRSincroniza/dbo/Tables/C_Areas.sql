CREATE TABLE [dbo].[C_Areas] (
    [AreaID]      INT              NOT NULL,
    [Descripción] NVARCHAR (50)    NOT NULL,
    [Orden]       SMALLINT         NULL,
    [Bono]        MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Areas__rowguid__6DA22FD1] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Areas_PK] PRIMARY KEY NONCLUSTERED ([AreaID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [AreaID] UNIQUE CLUSTERED ([AreaID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_C_Areas] UNIQUE NONCLUSTERED ([Descripción] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1655676946]
    ON [dbo].[C_Areas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_C_Areas_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:01 a.m. ******/
CREATE TRIGGER [T_C_Areas_DTrig] ON [dbo].[C_Areas] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'C_Operaciones' */
DELETE C_Operaciones FROM deleted, C_Operaciones WHERE deleted.AreaID = C_Operaciones.AreaID







GO
/****** Objeto:  desencadenador dbo.T_C_Areas_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:01 a.m. ******/
CREATE TRIGGER [T_C_Areas_UTrig] ON [dbo].[C_Areas] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'C_Operaciones' */
IF UPDATE(AreaID)
    BEGIN
       UPDATE C_Operaciones
       SET C_Operaciones.AreaID = inserted.AreaID
       FROM C_Operaciones, deleted, inserted
       WHERE deleted.AreaID = C_Operaciones.AreaID
    END






