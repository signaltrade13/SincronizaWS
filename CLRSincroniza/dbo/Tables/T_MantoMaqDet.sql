CREATE TABLE [dbo].[T_MantoMaqDet] (
    [MantoId]     NUMERIC (18)     NOT NULL,
    [Renglon]     INT              NOT NULL,
    [Cantidad]    REAL             NULL,
    [RefaccionID] NUMERIC (18)     NULL,
    [costo]       MONEY            NULL,
    [CostoPesos]  MONEY            NULL,
    [TipoCambio]  MONEY            NULL,
    [Observacion] TEXT             NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_MantoMa__rowgu__35C8B659] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_MantoMaqDet] PRIMARY KEY CLUSTERED ([MantoId] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_976774587]
    ON [dbo].[T_MantoMaqDet]([rowguid] ASC) WITH (FILLFACTOR = 90);

