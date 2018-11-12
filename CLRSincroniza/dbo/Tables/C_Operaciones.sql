CREATE TABLE [dbo].[C_Operaciones] (
    [OperacionID]   INT              NOT NULL,
    [NumOper]       VARCHAR (10)     NULL,
    [Descripción]   NVARCHAR (50)    NULL,
    [AreaID]        INT              CONSTRAINT [DF__C_Operaci__AreaI__108B795B] DEFAULT ((0)) NULL,
    [TipoOper]      NVARCHAR (50)    NULL,
    [Tiempo]        REAL             NULL,
    [Consumo]       REAL             CONSTRAINT [DF__C_Operaci__Consu__117F9D94] DEFAULT ((0)) NULL,
    [TipoMaquinaID] INT              CONSTRAINT [DF__C_Operaci__Maqui__1273C1CD] DEFAULT ((0)) NULL,
    [Produccion]    REAL             CONSTRAINT [DF__C_Operaci__Produ__164452B1] DEFAULT ((0)) NULL,
    [Costoop]       REAL             CONSTRAINT [DF__C_Operaci__Costo__173876EA] DEFAULT ((0)) NULL,
    [Orden]         SMALLINT         NULL,
    [SueldoID]      INT              NULL,
    [Factor]        REAL             NULL,
    [ConsumoArriba] REAL             NULL,
    [ConsumoAbajo]  REAL             NULL,
    [Costura]       MONEY            NULL,
    [Activo]        BIT              CONSTRAINT [DF_C_Operaciones_Activo] DEFAULT ((1)) NOT NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__C_Operaci__rowgu__3805392F] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Operaciones_PK] PRIMARY KEY NONCLUSTERED ([OperacionID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_C_Operaciones] UNIQUE NONCLUSTERED ([Descripción] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE CLUSTERED INDEX [IX2_C_Operaciones]
    ON [dbo].[C_Operaciones]([OperacionID] ASC);


GO
CREATE NONCLUSTERED INDEX [AreaID]
    ON [dbo].[C_Operaciones]([AreaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [C_AreasC_Operaciones]
    ON [dbo].[C_Operaciones]([AreaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [C_MaquinariaC_Operaciones]
    ON [dbo].[C_Operaciones]([TipoMaquinaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1895677801]
    ON [dbo].[C_Operaciones]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [MaquinaID]
    ON [dbo].[C_Operaciones]([TipoMaquinaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [OperacionID]
    ON [dbo].[C_Operaciones]([OperacionID] ASC) WITH (FILLFACTOR = 90);

