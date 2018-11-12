CREATE TABLE [dbo].[C_Almacen] (
    [AlmacenID] NUMERIC (18)     NOT NULL,
    [Almacen]   VARCHAR (50)     NULL,
    [Ubicacion] VARCHAR (50)     NULL,
    [rowguid]   UNIQUEIDENTIFIER CONSTRAINT [DF__C_Almacen__rowgu__75CD617E] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Almacen] PRIMARY KEY CLUSTERED ([AlmacenID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1762821342]
    ON [dbo].[C_Almacen]([rowguid] ASC) WITH (FILLFACTOR = 90);

