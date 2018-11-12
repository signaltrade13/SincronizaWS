CREATE TABLE [dbo].[C_Modulos] (
    [ModuloID]    INT              NOT NULL,
    [Descripción] NVARCHAR (50)    NULL,
    [Bono]        MONEY            CONSTRAINT [DF__C_Modulos__Bono__0BC6C43E] DEFAULT ((0)) NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Modulos__rowgu__4B4D17CD] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Modulos_PK] PRIMARY KEY NONCLUSTERED ([ModuloID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_C_Modulos] UNIQUE NONCLUSTERED ([Descripción] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_96719397]
    ON [dbo].[C_Modulos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [ModuloID]
    ON [dbo].[C_Modulos]([ModuloID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE TRIGGER [T_C_Modulos_DTrig] ON [dbo].[C_Modulos] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'C_Personal' */
DELETE C_Personal FROM deleted, C_Personal WHERE deleted.ModuloID = C_Personal.ModuloID







GO
CREATE TRIGGER [T_C_Modulos_UTrig] ON [dbo].[C_Modulos] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'C_Personal' */
IF UPDATE(ModuloID)
    BEGIN
       UPDATE C_Personal
       SET C_Personal.ModuloID = inserted.ModuloID
       FROM C_Personal, deleted, inserted
       WHERE deleted.ModuloID = C_Personal.ModuloID
    END






