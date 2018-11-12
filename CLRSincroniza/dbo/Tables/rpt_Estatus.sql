CREATE TABLE [dbo].[rpt_Estatus] (
    [OrdenID]     INT              NOT NULL,
    [Cantidad]    INT              NULL,
    [UsuarioID]   INT              NULL,
    [Descripcion] VARCHAR (50)     NULL,
    [OrdenArea]   INT              NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__rpt_Estat__rowgu__6994D527] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_670833652]
    ON [dbo].[rpt_Estatus]([rowguid] ASC) WITH (FILLFACTOR = 90);

