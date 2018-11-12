CREATE TABLE [dbo].[T_Nomina] (
    [NominaID]    NUMERIC (18)     NOT NULL,
    [Semana]      VARCHAR (4)      NULL,
    [FechaInicio] SMALLDATETIME    NULL,
    [FechaFin]    SMALLDATETIME    NULL,
    [Fecha]       SMALLDATETIME    NULL,
    [TotalNomina] MONEY            NULL,
    [Cancelado]   BIT              NULL,
    [Motivo]      VARCHAR (50)     NULL,
    [FechaCancel] SMALLDATETIME    NULL,
    [BalanceoId]  NUMERIC (18)     NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Nomina__rowgui__12149A71] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Nomina] PRIMARY KEY CLUSTERED ([NominaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1666821000]
    ON [dbo].[T_Nomina]([rowguid] ASC) WITH (FILLFACTOR = 90);

