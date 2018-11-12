CREATE TABLE [dbo].[C_AreaModulo] (
    [ModuloID] INT              NOT NULL,
    [AreaID]   INT              NULL,
    [rowguid]  UNIQUEIDENTIFIER CONSTRAINT [DF__C_AreaMod__rowgu__68C508C6] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1677743017]
    ON [dbo].[C_AreaModulo]([rowguid] ASC) WITH (FILLFACTOR = 90);

