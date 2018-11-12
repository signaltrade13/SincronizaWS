CREATE TABLE [dbo].[C_OperacionHilos] (
    [OperacionID] INT              NOT NULL,
    [HiloID]      INT              NOT NULL,
    [Indice]      INT              NOT NULL,
    [Arriba]      BIT              NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Operaci__rowgu__0FF747D5] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_OperacionHilos] PRIMARY KEY CLUSTERED ([OperacionID] ASC, [HiloID] ASC, [Indice] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_2118298606]
    ON [dbo].[C_OperacionHilos]([rowguid] ASC) WITH (FILLFACTOR = 90);

