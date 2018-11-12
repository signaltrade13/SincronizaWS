CREATE TABLE [dbo].[C_Articulos] (
    [ArticuloID]  NUMERIC (18)     NOT NULL,
    [LineaID]     NUMERIC (18)     NULL,
    [MonedaID]    NUMERIC (18)     NULL,
    [Clave]       VARCHAR (50)     NULL,
    [Descripcion] VARCHAR (50)     NULL,
    [Costo]       MONEY            NULL,
    [unidad]      VARCHAR (5)      NULL,
    [Ubicacion]   VARCHAR (50)     NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Articul__rowgu__108157BA] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Articulos] PRIMARY KEY CLUSTERED ([ArticuloID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_C_Articulos_C_Monedas] FOREIGN KEY ([MonedaID]) REFERENCES [dbo].[C_Monedas] ([MonedaID]) ON UPDATE CASCADE NOT FOR REPLICATION,
    CONSTRAINT [FK_T_Articulos_T_Lineas] FOREIGN KEY ([LineaID]) REFERENCES [dbo].[C_Lineas] ([LineaID]) ON UPDATE CASCADE NOT FOR REPLICATION
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1810821513]
    ON [dbo].[C_Articulos]([rowguid] ASC) WITH (FILLFACTOR = 90);

