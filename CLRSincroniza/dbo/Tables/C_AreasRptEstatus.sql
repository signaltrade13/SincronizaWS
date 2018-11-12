CREATE TABLE [dbo].[C_AreasRptEstatus] (
    [AreaOrdnId]     INT NOT NULL,
    [Orden]          INT NULL,
    [OrdenDelantero] INT NULL,
    [OrdenTrasero]   INT NULL,
    CONSTRAINT [PK_C_AreasRptEstatus] PRIMARY KEY CLUSTERED ([AreaOrdnId] ASC)
);

