CREATE TABLE [dbo].[T_CostosMonedas] (
    [ArticuloID]      NUMERIC (18)     NOT NULL,
    [AlmacenID]       NUMERIC (18)     NOT NULL,
    [MonedaID]        NUMERIC (18)     NOT NULL,
    [Existencia]      NUMERIC (18)     NULL,
    [EntradaUnidad]   NUMERIC (18)     NULL,
    [EntradaValor]    MONEY            NULL,
    [SalidaUnidad]    NUMERIC (18)     NULL,
    [SalidaValor]     MONEY            NULL,
    [ExtDum]          NUMERIC (18)     NULL,
    [CostoPromedio]   MONEY            NULL,
    [CostoReposicion] MONEY            NULL,
    [rowguid]         UNIQUEIDENTIFIER CONSTRAINT [DF__T_CostosM__rowgu__0AC87E64] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_CostosMonedas] PRIMARY KEY CLUSTERED ([ArticuloID] ASC, [AlmacenID] ASC, [MonedaID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_T_CostosMonedas_C_Almacen] FOREIGN KEY ([AlmacenID]) REFERENCES [dbo].[C_Almacen] ([AlmacenID]) ON UPDATE CASCADE NOT FOR REPLICATION,
    CONSTRAINT [FK_T_CostosMonedas_C_Monedas] FOREIGN KEY ([MonedaID]) REFERENCES [dbo].[C_Monedas] ([MonedaID]) ON UPDATE CASCADE NOT FOR REPLICATION
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1826821570]
    ON [dbo].[T_CostosMonedas]([rowguid] ASC) WITH (FILLFACTOR = 90);

