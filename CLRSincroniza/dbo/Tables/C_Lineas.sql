CREATE TABLE [dbo].[C_Lineas] (
    [LineaID]        NUMERIC (18)     NOT NULL,
    [Descripcion]    VARCHAR (50)     NULL,
    [ValidaSolomon]  BIT              NULL,
    [ValidaCatalogo] BIT              NULL,
    [Catalogo]       VARCHAR (50)     NULL,
    [rowguid]        UNIQUEIDENTIFIER CONSTRAINT [DF__C_Lineas__rowgui__5378497A] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Lineas] PRIMARY KEY CLUSTERED ([LineaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1778821399]
    ON [dbo].[C_Lineas]([rowguid] ASC) WITH (FILLFACTOR = 90);

