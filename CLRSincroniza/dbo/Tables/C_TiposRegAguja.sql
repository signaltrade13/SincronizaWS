CREATE TABLE [dbo].[C_TiposRegAguja] (
    [ReAguja] INT              NOT NULL,
    [TipoReg] VARCHAR (50)     NULL,
    [rowguid] UNIQUEIDENTIFIER CONSTRAINT [DF__C_TiposRe__rowgu__7CC54327] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_TiposRegAguja] PRIMARY KEY CLUSTERED ([ReAguja] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1360775955]
    ON [dbo].[C_TiposRegAguja]([rowguid] ASC) WITH (FILLFACTOR = 90);

