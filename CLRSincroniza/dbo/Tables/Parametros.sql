CREATE TABLE [dbo].[Parametros] (
    [Jornada]    SMALLINT         NULL,
    [TipoCambio] MONEY            NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__Parametro__rowgu__7247B4B4] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_128771566]
    ON [dbo].[Parametros]([rowguid] ASC) WITH (FILLFACTOR = 90);

