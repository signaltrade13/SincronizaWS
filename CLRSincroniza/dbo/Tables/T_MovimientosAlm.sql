CREATE TABLE [dbo].[T_MovimientosAlm] (
    [MovimientoID] NUMERIC (18)     NOT NULL,
    [Tipo]         VARCHAR (1)      NOT NULL,
    [AlmacenID]    NUMERIC (18)     NULL,
    [Fecha]        SMALLDATETIME    NULL,
    [Referencia]   VARCHAR (50)     NULL,
    [TotalU]       NUMERIC (18)     NULL,
    [TotalC]       MONEY            NULL,
    [MonedaID]     NUMERIC (18)     NULL,
    [TotalCDef]    MONEY            NULL,
    [Cancelado]    BIT              NULL,
    [Aplicado]     BIT              NULL,
    [TipoCambio]   MONEY            NULL,
    [rowguid]      UNIQUEIDENTIFIER CONSTRAINT [DF__T_Movimie__rowgu__7B863AD4] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_MovimientosAlm] PRIMARY KEY CLUSTERED ([MovimientoID] ASC, [Tipo] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_T_MovimientosAlm_T_Almacen] FOREIGN KEY ([AlmacenID]) REFERENCES [dbo].[C_Almacen] ([AlmacenID]) ON UPDATE CASCADE NOT FOR REPLICATION
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1842821627]
    ON [dbo].[T_MovimientosAlm]([rowguid] ASC) WITH (FILLFACTOR = 90);

