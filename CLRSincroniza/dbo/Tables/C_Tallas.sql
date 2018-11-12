CREATE TABLE [dbo].[C_Tallas] (
    [TallaID] NUMERIC (18)     NOT NULL,
    [Largo]   VARCHAR (10)     NULL,
    [Ancho]   VARCHAR (10)     NULL,
    [rowguid] UNIQUEIDENTIFIER CONSTRAINT [DF__C_Tallas__rowgui__3469B275] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_Tallas] PRIMARY KEY CLUSTERED ([TallaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1799677459]
    ON [dbo].[C_Tallas]([rowguid] ASC) WITH (FILLFACTOR = 90);

