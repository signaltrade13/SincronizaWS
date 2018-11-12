CREATE TABLE [dbo].[C_Sueldos] (
    [SueldoID]  INT              NOT NULL,
    [Categoria] NVARCHAR (2)     NULL,
    [Monto]     MONEY            CONSTRAINT [DF__C_Sueldos__Monto__239E4DCF] DEFAULT ((0)) NULL,
    [Bono]      MONEY            CONSTRAINT [DF__C_Sueldos__Bono__24927208] DEFAULT ((0)) NULL,
    [rowguid]   UNIQUEIDENTIFIER CONSTRAINT [DF__C_Sueldos__rowgu__3FDB6521] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Sueldos_PK] PRIMARY KEY NONCLUSTERED ([SueldoID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_112719454]
    ON [dbo].[C_Sueldos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [SueldoID]
    ON [dbo].[C_Sueldos]([SueldoID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE TRIGGER [T_C_Sueldos_DTrig] ON [dbo].[C_Sueldos] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'C_Personal' */
DELETE C_Personal FROM deleted, C_Personal WHERE deleted.SueldoID = C_Personal.SueldoID







GO
CREATE TRIGGER [T_C_Sueldos_UTrig] ON [dbo].[C_Sueldos] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'C_Personal' */
IF UPDATE(SueldoID)
    BEGIN
       UPDATE C_Personal
       SET C_Personal.SueldoID = inserted.SueldoID
       FROM C_Personal, deleted, inserted
       WHERE deleted.SueldoID = C_Personal.SueldoID
    END






