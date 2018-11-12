CREATE TABLE [dbo].[T_Balanceo] (
    [BalanceoID]    NUMERIC (18)     NOT NULL,
    [EstiloID]      NUMERIC (10)     NOT NULL,
    [Fecha]         SMALLDATETIME    NULL,
    [Observaciones] TEXT             NULL,
    [MinTurno]      INT              NULL,
    [Produccion]    INT              NULL,
    [porcentaje]    MONEY            NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__T_Balance__rowgu__04859529] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Balanceo] PRIMARY KEY CLUSTERED ([BalanceoID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_358292336]
    ON [dbo].[T_Balanceo]([rowguid] ASC) WITH (FILLFACTOR = 90);

