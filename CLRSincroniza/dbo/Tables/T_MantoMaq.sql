CREATE TABLE [dbo].[T_MantoMaq] (
    [MantoId]      NUMERIC (18)     NOT NULL,
    [MaquinariaID] INT              NOT NULL,
    [Fecha]        CHAR (10)        NULL,
    [Motivo]       TEXT             NULL,
    [Total]        MONEY            NULL,
    [Tipo]         SMALLINT         NULL,
    [Cancelado]    BIT              NULL,
    [MotCancelado] VARCHAR (50)     NULL,
    [FechaCancel]  SMALLDATETIME    NULL,
    [MonedaID]     NUMERIC (18)     NULL,
    [TipoCambio]   MONEY            NULL,
    [rowguid]      UNIQUEIDENTIFIER CONSTRAINT [DF__T_MantoMa__rowgu__21C1BDAC] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_MantoMaq] PRIMARY KEY CLUSTERED ([MantoId] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1200775385]
    ON [dbo].[T_MantoMaq]([rowguid] ASC) WITH (FILLFACTOR = 90);

