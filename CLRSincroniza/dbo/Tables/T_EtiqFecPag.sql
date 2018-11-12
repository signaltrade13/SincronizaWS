CREATE TABLE [dbo].[T_EtiqFecPag] (
    [EtiquetaID] NUMERIC (18)     NOT NULL,
    [FechaPago]  SMALLDATETIME    NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__T_EtiqFec__rowgu__54AC64D5] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1388584035]
    ON [dbo].[T_EtiqFecPag]([rowguid] ASC) WITH (FILLFACTOR = 90);

