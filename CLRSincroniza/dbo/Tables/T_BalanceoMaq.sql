CREATE TABLE [dbo].[T_BalanceoMaq] (
    [BalanceoID]    NUMERIC (18)     NOT NULL,
    [Renglon]       NUMERIC (18)     NULL,
    [TipoMaquinaID] INT              NOT NULL,
    [cantidad]      INT              NULL,
    [Invent]        INT              NULL,
    [Dif]           INT              NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__T_Balance__rowgu__4EE89E87] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_BalanceoMaq] PRIMARY KEY CLUSTERED ([BalanceoID] ASC, [TipoMaquinaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_374292393]
    ON [dbo].[T_BalanceoMaq]([rowguid] ASC) WITH (FILLFACTOR = 90);

