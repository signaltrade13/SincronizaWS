CREATE TABLE [dbo].[T_BalanceoOtros] (
    [BalanceoID]  NUMERIC (18)     NOT NULL,
    [renglon]     NUMERIC (18)     NOT NULL,
    [Descripcion] VARCHAR (50)     NULL,
    [cant]        NUMERIC (18)     NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Balance__rowgu__324C5FD9] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_BalanceoOtros] PRIMARY KEY CLUSTERED ([BalanceoID] ASC, [renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_406292507]
    ON [dbo].[T_BalanceoOtros]([rowguid] ASC) WITH (FILLFACTOR = 90);

