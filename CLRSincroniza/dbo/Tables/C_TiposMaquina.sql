CREATE TABLE [dbo].[C_TiposMaquina] (
    [TipoMaquinaID] INT              NOT NULL,
    [Descripción]   VARCHAR (50)     NULL,
    [Factor]        REAL             NULL,
    [ConsumoArriba] REAL             NULL,
    [ConsumoAbajo]  REAL             NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__C_TiposMa__rowgu__2EB0D91F] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_TiposMaquina] PRIMARY KEY CLUSTERED ([TipoMaquinaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1815677516]
    ON [dbo].[C_TiposMaquina]([rowguid] ASC) WITH (FILLFACTOR = 90);

