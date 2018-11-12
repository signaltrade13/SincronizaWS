CREATE TABLE [dbo].[T_OrdOrdenesProduccion] (
    [OrdenID]   INT              NOT NULL,
    [Orden]     INT              NULL,
    [Periodo]   VARCHAR (10)     NULL,
    [Auditoria] INT              NULL,
    [rowguid]   UNIQUEIDENTIFIER CONSTRAINT [DF__T_OrdOrde__rowgu__072F59AF] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_764021953]
    ON [dbo].[T_OrdOrdenesProduccion]([rowguid] ASC) WITH (FILLFACTOR = 90);

