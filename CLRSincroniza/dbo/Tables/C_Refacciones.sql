CREATE TABLE [dbo].[C_Refacciones] (
    [RefaccionID] NUMERIC (18)     NOT NULL,
    [Clave]       VARCHAR (20)     NULL,
    [Descripcion] VARCHAR (100)    NULL,
    [MonedaID]    NUMERIC (18)     NULL,
    [Costo]       MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Refacci__rowgu__6C59D134] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_Refacciones] PRIMARY KEY CLUSTERED ([RefaccionID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_912774359]
    ON [dbo].[C_Refacciones]([rowguid] ASC) WITH (FILLFACTOR = 90);

