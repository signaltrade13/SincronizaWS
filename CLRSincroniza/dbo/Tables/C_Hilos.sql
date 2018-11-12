CREATE TABLE [dbo].[C_Hilos] (
    [HiloID]      INT              NOT NULL,
    [Clave]       VARCHAR (50)     NULL,
    [Descripcion] VARCHAR (100)    NULL,
    [Calibre]     NVARCHAR (50)    NULL,
    [CveColor]    NVARCHAR (50)    NULL,
    [Prov]        NVARCHAR (50)    NULL,
    [Marca]       NVARCHAR (50)    NULL,
    [Tipo]        NVARCHAR (50)    NULL,
    [Yardas]      REAL             CONSTRAINT [DF__C_Hilos__Yardas__023D5A04] DEFAULT ((0)) NULL,
    [Costo]       MONEY            CONSTRAINT [DF__C_Hilos__Costo__03317E3D] DEFAULT ((0)) NULL,
    [unidad]      SMALLINT         NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Hilos__rowguid__5105F123] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Hilos_PK] PRIMARY KEY NONCLUSTERED ([HiloID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [HiloID]
    ON [dbo].[C_Hilos]([HiloID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_130815528]
    ON [dbo].[C_Hilos]([rowguid] ASC) WITH (FILLFACTOR = 90);

