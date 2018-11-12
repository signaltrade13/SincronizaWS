CREATE TABLE [dbo].[T_Cotizacion] (
    [CotizacionID]      NUMERIC (18)     NOT NULL,
    [EstiloID]          NUMERIC (10)     NULL,
    [Observaciones]     TEXT             NULL,
    [FechaCreacion]     SMALLDATETIME    NULL,
    [FechaModificacion] SMALLDATETIME    NULL,
    [rowguid]           UNIQUEIDENTIFIER CONSTRAINT [DF__T_Cotizac__rowgu__3B219CFC] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Cotizacion] PRIMARY KEY CLUSTERED ([CotizacionID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_739533718]
    ON [dbo].[T_Cotizacion]([rowguid] ASC) WITH (FILLFACTOR = 90);

