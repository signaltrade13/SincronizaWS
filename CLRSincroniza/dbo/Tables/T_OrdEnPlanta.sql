CREATE TABLE [dbo].[T_OrdEnPlanta] (
    [OrdenID]  INT              NOT NULL,
    [Cantidad] INT              NULL,
    [Fecha]    SMALLDATETIME    NULL,
    [rowguid]  UNIQUEIDENTIFIER CONSTRAINT [DF__T_OrdEnPl__rowgu__3559446E] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_879042613]
    ON [dbo].[T_OrdEnPlanta]([rowguid] ASC) WITH (FILLFACTOR = 90);

