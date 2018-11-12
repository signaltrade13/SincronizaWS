CREATE TABLE [dbo].[T_CotizacionDet] (
    [CotizacionID] NUMERIC (18)     NOT NULL,
    [Renglon]      NUMERIC (18)     NOT NULL,
    [Equivalencia] INT              NULL,
    [HiloID]       INT              NULL,
    [Aplic]        VARCHAR (50)     NULL,
    [Cod]          VARCHAR (50)     NULL,
    [Metros]       MONEY            NULL,
    [Costo]        MONEY            NULL,
    [Total]        MONEY            NULL,
    [TotalConos]   MONEY            NULL,
    [MtsCono]      INT              NULL,
    [rowguid]      UNIQUEIDENTIFIER CONSTRAINT [DF__T_Cotizac__rowgu__691D71D6] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_CotizacionDet] PRIMARY KEY CLUSTERED ([CotizacionID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_803533946]
    ON [dbo].[T_CotizacionDet]([rowguid] ASC) WITH (FILLFACTOR = 90);

