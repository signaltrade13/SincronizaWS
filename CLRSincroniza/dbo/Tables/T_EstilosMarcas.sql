CREATE TABLE [dbo].[T_EstilosMarcas] (
    [EstiloID] INT              NOT NULL,
    [MarcaID]  VARCHAR (12)     NOT NULL,
    [rowguid]  UNIQUEIDENTIFIER CONSTRAINT [DF__T_Estilos__rowgu__65E89C1B] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_EstilosMarcas] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [MarcaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1262197284]
    ON [dbo].[T_EstilosMarcas]([rowguid] ASC) WITH (FILLFACTOR = 90);

