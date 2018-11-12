CREATE TABLE [dbo].[T_EstilosHilosDet] (
    [EstiloID] NUMERIC (10)     CONSTRAINT [DF_T_EstilosHilosDet_EstiloID] DEFAULT ((0)) NOT NULL,
    [Renglon]  INT              NOT NULL,
    [Orden]    INT              NOT NULL,
    [HiloID]   INT              NOT NULL,
    [Arriba]   BIT              NULL,
    [Act]      BIT              NULL,
    [rowguid]  UNIQUEIDENTIFIER CONSTRAINT [DF__T_Estilos__rowgu__2121D3D7] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_EstilosHilosDet] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [Renglon] ASC, [Orden] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_T_EstilosHilosDet_T_EstilosDet] FOREIGN KEY ([EstiloID], [Renglon]) REFERENCES [dbo].[T_EstilosDet] ([EstiloID], [Renglon]) ON DELETE CASCADE ON UPDATE CASCADE NOT FOR REPLICATION
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_498816839]
    ON [dbo].[T_EstilosHilosDet]([rowguid] ASC) WITH (FILLFACTOR = 90);

