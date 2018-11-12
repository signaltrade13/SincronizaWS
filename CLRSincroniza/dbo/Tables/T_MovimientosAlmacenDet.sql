CREATE TABLE [dbo].[T_MovimientosAlmacenDet] (
    [MovimientoID] NUMERIC (18)     NOT NULL,
    [Tipo]         VARCHAR (1)      NOT NULL,
    [Renglon]      NUMERIC (18)     NOT NULL,
    [ArticuloID]   NUMERIC (18)     NOT NULL,
    [Cantidad]     NUMERIC (18)     NULL,
    [Costo]        MONEY            NULL,
    [Importe]      MONEY            NULL,
    [rowguid]      UNIQUEIDENTIFIER CONSTRAINT [DF__T_Movimie__rowgu__1BF30A66] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_MovimientosAlmacenDet] PRIMARY KEY CLUSTERED ([MovimientoID] ASC, [Tipo] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_T_MovimientosAlmacenDet_T_Articulos] FOREIGN KEY ([ArticuloID]) REFERENCES [dbo].[C_Articulos] ([ArticuloID]) ON UPDATE CASCADE NOT FOR REPLICATION,
    CONSTRAINT [FK_T_MovimientosAlmacenDet_T_MovimientosAlm] FOREIGN KEY ([MovimientoID], [Tipo]) REFERENCES [dbo].[T_MovimientosAlm] ([MovimientoID], [Tipo]) ON UPDATE CASCADE NOT FOR REPLICATION
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1874821741]
    ON [dbo].[T_MovimientosAlmacenDet]([rowguid] ASC) WITH (FILLFACTOR = 90);

