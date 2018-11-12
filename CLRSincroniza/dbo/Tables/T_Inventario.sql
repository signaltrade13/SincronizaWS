CREATE TABLE [dbo].[T_Inventario] (
    [ArticuloID]      NUMERIC (18)     NOT NULL,
    [AlmacenID]       NUMERIC (18)     NOT NULL,
    [Existencia]      NUMERIC (18)     NULL,
    [EntradaUnidad]   NUMERIC (18)     NULL,
    [EntradaValor]    MONEY            NULL,
    [SalidaUnidad]    NUMERIC (18)     NULL,
    [SalidaValor]     MONEY            NULL,
    [ExtDum]          NUMERIC (18)     NULL,
    [CostoPromedio]   MONEY            NULL,
    [CostoReposicion] MONEY            NULL,
    [rowguid]         UNIQUEIDENTIFIER CONSTRAINT [DF__T_Inventa__rowgu__163A3110] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Inventario] PRIMARY KEY CLUSTERED ([ArticuloID] ASC, [AlmacenID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_T_Inventario_T_Almacen] FOREIGN KEY ([AlmacenID]) REFERENCES [dbo].[C_Almacen] ([AlmacenID]) ON UPDATE CASCADE NOT FOR REPLICATION,
    CONSTRAINT [FK_T_Inventario_T_Articulos] FOREIGN KEY ([ArticuloID]) REFERENCES [dbo].[C_Articulos] ([ArticuloID]) ON UPDATE CASCADE NOT FOR REPLICATION
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1858821684]
    ON [dbo].[T_Inventario]([rowguid] ASC) WITH (FILLFACTOR = 90);

