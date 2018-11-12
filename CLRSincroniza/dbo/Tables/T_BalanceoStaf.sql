CREATE TABLE [dbo].[T_BalanceoStaf] (
    [BalanceoID]  NUMERIC (18)     NOT NULL,
    [renglon]     NUMERIC (18)     NOT NULL,
    [Descripcion] VARCHAR (50)     NULL,
    [cant]        NUMERIC (18)     NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Balance__rowgu__2C938683] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_BalanceoStaf] PRIMARY KEY CLUSTERED ([BalanceoID] ASC, [renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_422292564]
    ON [dbo].[T_BalanceoStaf]([rowguid] ASC) WITH (FILLFACTOR = 90);

