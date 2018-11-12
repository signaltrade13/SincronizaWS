CREATE TABLE [dbo].[T_EstilosHilosDetTeor] (
    [EstiloID] NUMERIC (10)     NOT NULL,
    [Renglon]  INT              NOT NULL,
    [Orden]    INT              NOT NULL,
    [HiloID]   INT              NOT NULL,
    [Arriba]   BIT              NULL,
    [Act]      BIT              NULL,
    [rowguid]  UNIQUEIDENTIFIER CONSTRAINT [DF__T_Estilos__rowgu__3238E7EE] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_EstilosHilosDetTeor] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [Renglon] ASC, [Orden] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_826590133]
    ON [dbo].[T_EstilosHilosDetTeor]([rowguid] ASC) WITH (FILLFACTOR = 90);

