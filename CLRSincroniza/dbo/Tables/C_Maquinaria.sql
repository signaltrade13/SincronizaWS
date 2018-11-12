CREATE TABLE [dbo].[C_Maquinaria] (
    [MaquinariaID]  INT              NOT NULL,
    [TipoMaquinaID] INT              NULL,
    [NoInventario]  NVARCHAR (10)    NOT NULL,
    [Descripción]   NVARCHAR (40)    NULL,
    [Marca]         NVARCHAR (20)    NULL,
    [Modelo]        NVARCHAR (30)    NULL,
    [Serie]         NVARCHAR (20)    NULL,
    [Propiedad]     INT              NULL,
    [Ubicación]     INT              NULL,
    [ModuloID]      INT              NULL,
    [Observaciones] TEXT             NULL,
    [Estatus]       SMALLINT         NULL,
    [Factor]        REAL             NULL,
    [ConsumoArriba] REAL             NULL,
    [ConsumoAbajo]  REAL             NULL,
    [FechaAlta]     DATETIME         NULL,
    [Rentada]       SMALLINT         CONSTRAINT [DF_C_Maquinaria_Rentada] DEFAULT ((0)) NULL,
    [Costo]         MONEY            NULL,
    [ProveedorID]   NUMERIC (18)     NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__C_Maquina__rowgu__3DBE1285] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [IX_C_Maquinaria_1] UNIQUE NONCLUSTERED ([NoInventario] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [MaquinariaID] UNIQUE CLUSTERED ([MaquinariaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1879677744]
    ON [dbo].[C_Maquinaria]([rowguid] ASC) WITH (FILLFACTOR = 90);

