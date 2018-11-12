CREATE TABLE [dbo].[C_Monedas] (
    [MonedaID]    NUMERIC (18)     NOT NULL,
    [Descripción] VARCHAR (50)     NULL,
    [TipoCambio]  MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Monedas__rowgu__2102A39D] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_monedas] PRIMARY KEY CLUSTERED ([MonedaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1473492378]
    ON [dbo].[C_Monedas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_736773732]
    ON [dbo].[C_Monedas]([rowguid] ASC) WITH (FILLFACTOR = 90);

