CREATE TABLE [dbo].[T_EstilosDetTeor] (
    [EstiloID]    NUMERIC (10)     NOT NULL,
    [Renglon]     INT              NOT NULL,
    [OperacionID] INT              NOT NULL,
    [Orden]       SMALLINT         NULL,
    [Act]         BIT              NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Estilos__rowgu__332D0C27] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_EstilosDetTeor] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_810590076]
    ON [dbo].[T_EstilosDetTeor]([rowguid] ASC) WITH (FILLFACTOR = 90);

