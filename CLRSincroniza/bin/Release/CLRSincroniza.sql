/*
Script de implementación para CLRSincroniza_1

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "CLRSincroniza_1"
:setvar DefaultFilePrefix "CLRSincroniza_1"
:setvar DefaultDataPath "C:\Users\Maceesoft\AppData\Local\Microsoft\VisualStudio\SSDT\SincronizaWS.Servicio"
:setvar DefaultLogPath "C:\Users\Maceesoft\AppData\Local\Microsoft\VisualStudio\SSDT\SincronizaWS.Servicio"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
PRINT N'Creando [dbo].[C_Almacen]...';


GO
CREATE TABLE [dbo].[C_Almacen] (
    [AlmacenID] NUMERIC (18)     NOT NULL,
    [Almacen]   VARCHAR (50)     NULL,
    [Ubicacion] VARCHAR (50)     NULL,
    [rowguid]   UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Almacen] PRIMARY KEY CLUSTERED ([AlmacenID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Almacen].[index_1762821342]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1762821342]
    ON [dbo].[C_Almacen]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_AreaModulo]...';


GO
CREATE TABLE [dbo].[C_AreaModulo] (
    [ModuloID] INT              NOT NULL,
    [AreaID]   INT              NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[C_AreaModulo].[index_1677743017]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1677743017]
    ON [dbo].[C_AreaModulo]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Areas]...';


GO
CREATE TABLE [dbo].[C_Areas] (
    [AreaID]      INT              NOT NULL,
    [Descripción] NVARCHAR (50)    NOT NULL,
    [Orden]       SMALLINT         NULL,
    [Bono]        MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Areas_PK] PRIMARY KEY NONCLUSTERED ([AreaID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [AreaID] UNIQUE CLUSTERED ([AreaID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_C_Areas] UNIQUE NONCLUSTERED ([Descripción] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Areas].[index_1655676946]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1655676946]
    ON [dbo].[C_Areas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_AreasRptEstatus]...';


GO
CREATE TABLE [dbo].[C_AreasRptEstatus] (
    [AreaOrdnId]     INT NOT NULL,
    [Orden]          INT NULL,
    [OrdenDelantero] INT NULL,
    [OrdenTrasero]   INT NULL,
    CONSTRAINT [PK_C_AreasRptEstatus] PRIMARY KEY CLUSTERED ([AreaOrdnId] ASC)
);


GO
PRINT N'Creando [dbo].[C_Articulos]...';


GO
CREATE TABLE [dbo].[C_Articulos] (
    [ArticuloID]  NUMERIC (18)     NOT NULL,
    [LineaID]     NUMERIC (18)     NULL,
    [MonedaID]    NUMERIC (18)     NULL,
    [Clave]       VARCHAR (50)     NULL,
    [Descripcion] VARCHAR (50)     NULL,
    [Costo]       MONEY            NULL,
    [unidad]      VARCHAR (5)      NULL,
    [Ubicacion]   VARCHAR (50)     NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Articulos] PRIMARY KEY CLUSTERED ([ArticuloID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Articulos].[index_1810821513]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1810821513]
    ON [dbo].[C_Articulos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Bihorarios]...';


GO
CREATE TABLE [dbo].[C_Bihorarios] (
    [BihorarioID]    INT        NOT NULL,
    [HoraInicio]     DATETIME   NULL,
    [HoraFin]        DATETIME   NULL,
    [CantHrsLab]     FLOAT (53) NULL,
    [HoraIniReal]    DATETIME   NULL,
    [HoraFinReal]    DATETIME   NULL,
    [HoraIniRealAnt] DATETIME   NULL,
    [HoraFinRealAnt] DATETIME   NULL,
    CONSTRAINT [PK_C_Bihorarios] PRIMARY KEY CLUSTERED ([BihorarioID] ASC)
);


GO
PRINT N'Creando [dbo].[C_Conceptos]...';


GO
CREATE TABLE [dbo].[C_Conceptos] (
    [ConceptoID] INT              NOT NULL,
    [Tipo]       NVARCHAR (1)     NULL,
    [Concepto]   NVARCHAR (50)    NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Conceptos_PK] PRIMARY KEY NONCLUSTERED ([ConceptoID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Conceptos].[ConceptoID]...';


GO
CREATE NONCLUSTERED INDEX [ConceptoID]
    ON [dbo].[C_Conceptos]([ConceptoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Conceptos].[index_1687677060]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1687677060]
    ON [dbo].[C_Conceptos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_ConceptosP]...';


GO
CREATE TABLE [dbo].[C_ConceptosP] (
    [ConceptoPID] INT              NOT NULL,
    [Descripción] VARCHAR (50)     NULL,
    [Tipo]        BIT              NULL,
    [Monto]       MONEY            NULL,
    [Formula]     VARCHAR (50)     NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_ConceptosP] PRIMARY KEY CLUSTERED ([ConceptoPID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_C_ConceptosP] UNIQUE NONCLUSTERED ([Descripción] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_ConceptosP].[index_80719340]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_80719340]
    ON [dbo].[C_ConceptosP]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_EmpresaP]...';


GO
CREATE TABLE [dbo].[C_EmpresaP] (
    [EmpresaID] INT              NOT NULL,
    [Dias]      INT              NULL,
    [PorMax]    INT              NULL,
    [rowguid]   UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[C_EmpresaP].[index_1693743074]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1693743074]
    ON [dbo].[C_EmpresaP]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Empresas]...';


GO
CREATE TABLE [dbo].[C_Empresas] (
    [EmpresaID]      INT              NOT NULL,
    [Nombre]         VARCHAR (50)     NULL,
    [NombreBd]       VARCHAR (50)     NULL,
    [Dirección]      VARCHAR (100)    NULL,
    [Telefono]       VARCHAR (50)     NULL,
    [Fax]            CHAR (10)        NULL,
    [Mail]           VARCHAR (100)    NULL,
    [rfc]            VARCHAR (20)     NULL,
    [Jornada]        INT              NULL,
    [Pago]           SMALLINT         NULL,
    [Porcentajeop]   MONEY            NULL,
    [Porcentajearea] MONEY            NULL,
    [TotalPiezas]    INT              NULL,
    [rowguid]        UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_Empresas] PRIMARY KEY CLUSTERED ([EmpresaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Empresas].[index_1719677174]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1719677174]
    ON [dbo].[C_Empresas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_GrosorAgujas]...';


GO
CREATE TABLE [dbo].[C_GrosorAgujas] (
    [GrosorID] NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Grosor]   VARCHAR (50)     NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_GrosorAgujas] PRIMARY KEY CLUSTERED ([GrosorID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_GrosorAgujas].[index_800773960]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_800773960]
    ON [dbo].[C_GrosorAgujas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Hilos]...';


GO
CREATE TABLE [dbo].[C_Hilos] (
    [HiloID]      INT              NOT NULL,
    [Clave]       VARCHAR (50)     NULL,
    [Descripcion] VARCHAR (100)    NULL,
    [Calibre]     NVARCHAR (50)    NULL,
    [CveColor]    NVARCHAR (50)    NULL,
    [Prov]        NVARCHAR (50)    NULL,
    [Marca]       NVARCHAR (50)    NULL,
    [Tipo]        NVARCHAR (50)    NULL,
    [Yardas]      REAL             NULL,
    [Costo]       MONEY            NULL,
    [unidad]      SMALLINT         NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Hilos_PK] PRIMARY KEY NONCLUSTERED ([HiloID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Hilos].[HiloID]...';


GO
CREATE NONCLUSTERED INDEX [HiloID]
    ON [dbo].[C_Hilos]([HiloID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Hilos].[index_130815528]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_130815528]
    ON [dbo].[C_Hilos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Lineas]...';


GO
CREATE TABLE [dbo].[C_Lineas] (
    [LineaID]        NUMERIC (18)     NOT NULL,
    [Descripcion]    VARCHAR (50)     NULL,
    [ValidaSolomon]  BIT              NULL,
    [ValidaCatalogo] BIT              NULL,
    [Catalogo]       VARCHAR (50)     NULL,
    [rowguid]        UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Lineas] PRIMARY KEY CLUSTERED ([LineaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Lineas].[index_1778821399]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1778821399]
    ON [dbo].[C_Lineas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Maquinaria]...';


GO
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
    [Rentada]       SMALLINT         NULL,
    [Costo]         MONEY            NULL,
    [ProveedorID]   NUMERIC (18)     NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [IX_C_Maquinaria_1] UNIQUE NONCLUSTERED ([NoInventario] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [MaquinariaID] UNIQUE CLUSTERED ([MaquinariaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Maquinaria].[index_1879677744]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1879677744]
    ON [dbo].[C_Maquinaria]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Marcas]...';


GO
CREATE TABLE [dbo].[C_Marcas] (
    [MARCAID] VARCHAR (12)     NOT NULL,
    [MARCA]   VARCHAR (50)     NULL,
    [rowguid] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED ([MARCAID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Marcas].[index_1230197170]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1230197170]
    ON [dbo].[C_Marcas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_MarcasAgujas]...';


GO
CREATE TABLE [dbo].[C_MarcasAgujas] (
    [MarcaID] NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Marca]   VARCHAR (50)     NULL,
    [rowguid] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_MarcasAgujas] PRIMARY KEY CLUSTERED ([MarcaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_MarcasAgujas].[index_1536776582]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1536776582]
    ON [dbo].[C_MarcasAgujas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_ModeloAguja]...';


GO
CREATE TABLE [dbo].[C_ModeloAguja] (
    [ModeloID] NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Modelo]   VARCHAR (50)     NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_ModeloAguja] PRIMARY KEY CLUSTERED ([ModeloID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_ModeloAguja].[index_768773846]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_768773846]
    ON [dbo].[C_ModeloAguja]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Modulos]...';


GO
CREATE TABLE [dbo].[C_Modulos] (
    [ModuloID]    INT              NOT NULL,
    [Descripción] NVARCHAR (50)    NULL,
    [Bono]        MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Modulos_PK] PRIMARY KEY NONCLUSTERED ([ModuloID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_C_Modulos] UNIQUE NONCLUSTERED ([Descripción] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Modulos].[index_96719397]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_96719397]
    ON [dbo].[C_Modulos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Modulos].[ModuloID]...';


GO
CREATE NONCLUSTERED INDEX [ModuloID]
    ON [dbo].[C_Modulos]([ModuloID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Monedas]...';


GO
CREATE TABLE [dbo].[C_Monedas] (
    [MonedaID]    NUMERIC (18)     NOT NULL,
    [Descripción] VARCHAR (50)     NULL,
    [TipoCambio]  MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_monedas] PRIMARY KEY CLUSTERED ([MonedaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Monedas].[index_1473492378]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1473492378]
    ON [dbo].[C_Monedas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Monedas].[index_736773732]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_736773732]
    ON [dbo].[C_Monedas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Operaciones]...';


GO
CREATE TABLE [dbo].[C_Operaciones] (
    [OperacionID]   INT              NOT NULL,
    [NumOper]       VARCHAR (10)     NULL,
    [Descripción]   NVARCHAR (50)    NULL,
    [AreaID]        INT              NULL,
    [TipoOper]      NVARCHAR (50)    NULL,
    [Tiempo]        REAL             NULL,
    [Consumo]       REAL             NULL,
    [TipoMaquinaID] INT              NULL,
    [Produccion]    REAL             NULL,
    [Costoop]       REAL             NULL,
    [Orden]         SMALLINT         NULL,
    [SueldoID]      INT              NULL,
    [Factor]        REAL             NULL,
    [ConsumoArriba] REAL             NULL,
    [ConsumoAbajo]  REAL             NULL,
    [Costura]       MONEY            NULL,
    [Activo]        BIT              NOT NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Operaciones_PK] PRIMARY KEY NONCLUSTERED ([OperacionID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_C_Operaciones] UNIQUE NONCLUSTERED ([Descripción] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Operaciones].[IX2_C_Operaciones]...';


GO
CREATE UNIQUE CLUSTERED INDEX [IX2_C_Operaciones]
    ON [dbo].[C_Operaciones]([OperacionID] ASC);


GO
PRINT N'Creando [dbo].[C_Operaciones].[AreaID]...';


GO
CREATE NONCLUSTERED INDEX [AreaID]
    ON [dbo].[C_Operaciones]([AreaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Operaciones].[C_AreasC_Operaciones]...';


GO
CREATE NONCLUSTERED INDEX [C_AreasC_Operaciones]
    ON [dbo].[C_Operaciones]([AreaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Operaciones].[C_MaquinariaC_Operaciones]...';


GO
CREATE NONCLUSTERED INDEX [C_MaquinariaC_Operaciones]
    ON [dbo].[C_Operaciones]([TipoMaquinaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Operaciones].[index_1895677801]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1895677801]
    ON [dbo].[C_Operaciones]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Operaciones].[MaquinaID]...';


GO
CREATE NONCLUSTERED INDEX [MaquinaID]
    ON [dbo].[C_Operaciones]([TipoMaquinaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Operaciones].[OperacionID]...';


GO
CREATE NONCLUSTERED INDEX [OperacionID]
    ON [dbo].[C_Operaciones]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_OperacionHilos]...';


GO
CREATE TABLE [dbo].[C_OperacionHilos] (
    [OperacionID] INT              NOT NULL,
    [HiloID]      INT              NOT NULL,
    [Indice]      INT              NOT NULL,
    [Arriba]      BIT              NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_OperacionHilos] PRIMARY KEY CLUSTERED ([OperacionID] ASC, [HiloID] ASC, [Indice] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_OperacionHilos].[index_2118298606]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_2118298606]
    ON [dbo].[C_OperacionHilos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Pantallas]...';


GO
CREATE TABLE [dbo].[C_Pantallas] (
    [PantallaID]  INT              IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Descripción] NVARCHAR (50)    NULL,
    [Indice]      INT              NULL,
    [Menu]        CHAR (1)         NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Pantallas_PK] PRIMARY KEY NONCLUSTERED ([PantallaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Pantallas].[index_1767677345]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1767677345]
    ON [dbo].[C_Pantallas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Pantallas].[ModuloID]...';


GO
CREATE NONCLUSTERED INDEX [ModuloID]
    ON [dbo].[C_Pantallas]([PantallaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Personal]...';


GO
CREATE TABLE [dbo].[C_Personal] (
    [PersonalID]    INT              NOT NULL,
    [ModuloID]      INT              NULL,
    [SueldoID]      INT              NULL,
    [AreaID]        INT              NULL,
    [OperacionID]   INT              NULL,
    [Numero]        NVARCHAR (6)     NULL,
    [ApellidoP]     NVARCHAR (50)    NULL,
    [ApellidoM]     NVARCHAR (50)    NULL,
    [Nombre]        NVARCHAR (50)    NULL,
    [Calle]         NVARCHAR (50)    NULL,
    [NumeroExt]     NVARCHAR (10)    NULL,
    [Colonia]       NVARCHAR (50)    NULL,
    [Poblacion]     NVARCHAR (50)    NULL,
    [Ciudad]        NVARCHAR (50)    NULL,
    [Cp]            NVARCHAR (50)    NULL,
    [Telefono]      NVARCHAR (50)    NULL,
    [Emergencia]    NVARCHAR (50)    NULL,
    [TelEmergencia] NVARCHAR (50)    NULL,
    [Rfc]           NVARCHAR (50)    NULL,
    [Estatus]       SMALLINT         NULL,
    [FecNac]        SMALLDATETIME    NULL,
    [Dias]          MONEY            NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    [PuestoID]      NUMERIC (18)     NULL,
    CONSTRAINT [aaaaaC_Personal_PK] PRIMARY KEY NONCLUSTERED ([PersonalID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Personal].[C_ModulosC_Personal]...';


GO
CREATE NONCLUSTERED INDEX [C_ModulosC_Personal]
    ON [dbo].[C_Personal]([ModuloID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Personal].[C_SueldosC_Personal]...';


GO
CREATE NONCLUSTERED INDEX [C_SueldosC_Personal]
    ON [dbo].[C_Personal]([SueldoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Personal].[index_1926297922]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1926297922]
    ON [dbo].[C_Personal]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Personal].[ModuloID]...';


GO
CREATE NONCLUSTERED INDEX [ModuloID]
    ON [dbo].[C_Personal]([ModuloID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Personal].[PersonalID]...';


GO
CREATE NONCLUSTERED INDEX [PersonalID]
    ON [dbo].[C_Personal]([PersonalID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Personal].[SueldoID]...';


GO
CREATE NONCLUSTERED INDEX [SueldoID]
    ON [dbo].[C_Personal]([SueldoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_PersonalFechas]...';


GO
CREATE TABLE [dbo].[C_PersonalFechas] (
    [PersonalID] INT              NOT NULL,
    [Tipo]       SMALLINT         NULL,
    [Fecha]      SMALLDATETIME    NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[C_PersonalFechas].[index_1166015285]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1166015285]
    ON [dbo].[C_PersonalFechas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Proveedores]...';


GO
CREATE TABLE [dbo].[C_Proveedores] (
    [ProveedorID] NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Descripción] VARCHAR (100)    NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_Proveedores] PRIMARY KEY CLUSTERED ([ProveedorID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Proveedores].[index_157295670]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_157295670]
    ON [dbo].[C_Proveedores]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Puestos]...';


GO
CREATE TABLE [dbo].[C_Puestos] (
    [PuestoID] NUMERIC (18)     NOT NULL,
    [Puesto]   VARCHAR (50)     NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[C_Puestos].[index_912826414]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_912826414]
    ON [dbo].[C_Puestos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_PuntasAgujas]...';


GO
CREATE TABLE [dbo].[C_PuntasAgujas] (
    [PuntaID] NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Punta]   VARCHAR (50)     NULL,
    [rowguid] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_PuntasAgujas] PRIMARY KEY CLUSTERED ([PuntaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_PuntasAgujas].[index_1584776753]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1584776753]
    ON [dbo].[C_PuntasAgujas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Refacciones]...';


GO
CREATE TABLE [dbo].[C_Refacciones] (
    [RefaccionID] NUMERIC (18)     NOT NULL,
    [Clave]       VARCHAR (20)     NULL,
    [Descripcion] VARCHAR (100)    NULL,
    [MonedaID]    NUMERIC (18)     NULL,
    [Costo]       MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_Refacciones] PRIMARY KEY CLUSTERED ([RefaccionID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Refacciones].[index_912774359]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_912774359]
    ON [dbo].[C_Refacciones]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Semanas]...';


GO
CREATE TABLE [dbo].[C_Semanas] (
    [SemanaID]    INT      NOT NULL,
    [FechaInicio] DATETIME NULL,
    [FechaFinal]  DATETIME NULL,
    CONSTRAINT [PK_C_Semanas] PRIMARY KEY CLUSTERED ([SemanaID] ASC)
);


GO
PRINT N'Creando [dbo].[C_Sueldos]...';


GO
CREATE TABLE [dbo].[C_Sueldos] (
    [SueldoID]  INT              NOT NULL,
    [Categoria] NVARCHAR (2)     NULL,
    [Monto]     MONEY            NULL,
    [Bono]      MONEY            NULL,
    [rowguid]   UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Sueldos_PK] PRIMARY KEY NONCLUSTERED ([SueldoID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Sueldos].[index_112719454]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_112719454]
    ON [dbo].[C_Sueldos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Sueldos].[SueldoID]...';


GO
CREATE NONCLUSTERED INDEX [SueldoID]
    ON [dbo].[C_Sueldos]([SueldoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Tallas]...';


GO
CREATE TABLE [dbo].[C_Tallas] (
    [TallaID] NUMERIC (18)     NOT NULL,
    [Largo]   VARCHAR (10)     NULL,
    [Ancho]   VARCHAR (10)     NULL,
    [rowguid] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_Tallas] PRIMARY KEY CLUSTERED ([TallaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Tallas].[index_1799677459]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1799677459]
    ON [dbo].[C_Tallas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_TiposMaquina]...';


GO
CREATE TABLE [dbo].[C_TiposMaquina] (
    [TipoMaquinaID] INT              NOT NULL,
    [Descripción]   VARCHAR (50)     NULL,
    [Factor]        REAL             NULL,
    [ConsumoArriba] REAL             NULL,
    [ConsumoAbajo]  REAL             NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_TiposMaquina] PRIMARY KEY CLUSTERED ([TipoMaquinaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_TiposMaquina].[index_1815677516]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1815677516]
    ON [dbo].[C_TiposMaquina]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_TiposRegAguja]...';


GO
CREATE TABLE [dbo].[C_TiposRegAguja] (
    [ReAguja] INT              NOT NULL,
    [TipoReg] VARCHAR (50)     NULL,
    [rowguid] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_TiposRegAguja] PRIMARY KEY CLUSTERED ([ReAguja] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_TiposRegAguja].[index_1360775955]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1360775955]
    ON [dbo].[C_TiposRegAguja]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Usuarios]...';


GO
CREATE TABLE [dbo].[C_Usuarios] (
    [UsuarioID]  INT              NOT NULL,
    [Usuario]    NVARCHAR (50)    NULL,
    [Contraseña] NVARCHAR (50)    NULL,
    [Nombre]     NVARCHAR (50)    NULL,
    [Activo]     BIT              NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Usuarios_PK] PRIMARY KEY NONCLUSTERED ([UsuarioID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[C_Usuarios].[Clave]...';


GO
CREATE NONCLUSTERED INDEX [Clave]
    ON [dbo].[C_Usuarios]([Usuario] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Usuarios].[index_1831677573]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1831677573]
    ON [dbo].[C_Usuarios]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[C_Usuarios].[UsuarioID]...';


GO
CREATE NONCLUSTERED INDEX [UsuarioID]
    ON [dbo].[C_Usuarios]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[Parametros]...';


GO
CREATE TABLE [dbo].[Parametros] (
    [Jornada]    SMALLINT         NULL,
    [TipoCambio] MONEY            NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[Parametros].[index_128771566]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_128771566]
    ON [dbo].[Parametros]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[rpt_Estatus]...';


GO
CREATE TABLE [dbo].[rpt_Estatus] (
    [OrdenID]     INT              NOT NULL,
    [Cantidad]    INT              NULL,
    [UsuarioID]   INT              NULL,
    [Descripcion] VARCHAR (50)     NULL,
    [OrdenArea]   INT              NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[rpt_Estatus].[index_670833652]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_670833652]
    ON [dbo].[rpt_Estatus]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Agujas]...';


GO
CREATE TABLE [dbo].[T_Agujas] (
    [Folio]         NUMERIC (18)     NOT NULL,
    [MaquinariaID]  INT              NOT NULL,
    [MarcaID]       NUMERIC (18)     NULL,
    [ModeloID]      NUMERIC (18)     NULL,
    [GrosorID]      NUMERIC (18)     NULL,
    [PuntaID]       NUMERIC (18)     NULL,
    [Motivo]        TEXT             NULL,
    [Fecha]         SMALLDATETIME    NULL,
    [Observaciones] TEXT             NULL,
    [Tipo]          SMALLINT         NULL,
    [cancelado]     BIT              NULL,
    [FechaCancel]   SMALLDATETIME    NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Agujas] PRIMARY KEY CLUSTERED ([Folio] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Agujas].[index_1600776810]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1600776810]
    ON [dbo].[T_Agujas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Balanceo]...';


GO
CREATE TABLE [dbo].[T_Balanceo] (
    [BalanceoID]    NUMERIC (18)     NOT NULL,
    [EstiloID]      NUMERIC (10)     NOT NULL,
    [Fecha]         SMALLDATETIME    NULL,
    [Observaciones] TEXT             NULL,
    [MinTurno]      INT              NULL,
    [Produccion]    INT              NULL,
    [porcentaje]    MONEY            NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Balanceo] PRIMARY KEY CLUSTERED ([BalanceoID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Balanceo].[index_358292336]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_358292336]
    ON [dbo].[T_Balanceo]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_BalanceoMaq]...';


GO
CREATE TABLE [dbo].[T_BalanceoMaq] (
    [BalanceoID]    NUMERIC (18)     NOT NULL,
    [Renglon]       NUMERIC (18)     NULL,
    [TipoMaquinaID] INT              NOT NULL,
    [cantidad]      INT              NULL,
    [Invent]        INT              NULL,
    [Dif]           INT              NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_BalanceoMaq] PRIMARY KEY CLUSTERED ([BalanceoID] ASC, [TipoMaquinaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_BalanceoMaq].[index_374292393]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_374292393]
    ON [dbo].[T_BalanceoMaq]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_BalanceoOpDet]...';


GO
CREATE TABLE [dbo].[T_BalanceoOpDet] (
    [BalanceoID]  NUMERIC (18)     NOT NULL,
    [OperacionID] INT              NOT NULL,
    [Renglon]     INT              NOT NULL,
    [std]         REAL             NULL,
    [stda]        REAL             NULL,
    [prodh]       REAL             NULL,
    [prodt]       REAL             NULL,
    [tiempon]     REAL             NULL,
    [operariost]  REAL             NULL,
    [operariorr]  INT              NULL,
    [mintd]       REAL             NULL,
    [desocu]      REAL             NULL,
    [maquinas]    INT              NULL,
    [Manuales]    INT              NULL,
    [asistente]   INT              NULL,
    [bultero]     INT              NULL,
    [sup]         INT              NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_BalanceoOpDet] PRIMARY KEY CLUSTERED ([BalanceoID] ASC, [OperacionID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_BalanceoOpDet].[index_390292450]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_390292450]
    ON [dbo].[T_BalanceoOpDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_BalanceoOtros]...';


GO
CREATE TABLE [dbo].[T_BalanceoOtros] (
    [BalanceoID]  NUMERIC (18)     NOT NULL,
    [renglon]     NUMERIC (18)     NOT NULL,
    [Descripcion] VARCHAR (50)     NULL,
    [cant]        NUMERIC (18)     NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_BalanceoOtros] PRIMARY KEY CLUSTERED ([BalanceoID] ASC, [renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_BalanceoOtros].[index_406292507]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_406292507]
    ON [dbo].[T_BalanceoOtros]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_BalanceoStaf]...';


GO
CREATE TABLE [dbo].[T_BalanceoStaf] (
    [BalanceoID]  NUMERIC (18)     NOT NULL,
    [renglon]     NUMERIC (18)     NOT NULL,
    [Descripcion] VARCHAR (50)     NULL,
    [cant]        NUMERIC (18)     NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_BalanceoStaf] PRIMARY KEY CLUSTERED ([BalanceoID] ASC, [renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_BalanceoStaf].[index_422292564]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_422292564]
    ON [dbo].[T_BalanceoStaf]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Bitacora]...';


GO
CREATE TABLE [dbo].[T_Bitacora] (
    [BitacoraID]  NUMERIC (10)     NOT NULL,
    [UsuarioID]   INT              NULL,
    [Fecha]       DATETIME         NULL,
    [Hora]        DATETIME         NULL,
    [Descripción] VARCHAR (100)    NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[T_Bitacora].[C_UsuariosT_Bitacora]...';


GO
CREATE NONCLUSTERED INDEX [C_UsuariosT_Bitacora]
    ON [dbo].[T_Bitacora]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Bitacora].[index_1506820430]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1506820430]
    ON [dbo].[T_Bitacora]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Bitacora].[UsuarioID]...';


GO
CREATE NONCLUSTERED INDEX [UsuarioID]
    ON [dbo].[T_Bitacora]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Bultos]...';


GO
CREATE TABLE [dbo].[T_Bultos] (
    [BultoID]  NUMERIC (10)     NOT NULL,
    [NoBulto]  NUMERIC (18)     NULL,
    [Serie]    VARCHAR (5)      NULL,
    [OrdenID]  INT              NOT NULL,
    [Cantidad] INT              NULL,
    [FechaEnt] DATETIME         NULL,
    [TallaID]  NUMERIC (18)     NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Bultos] PRIMARY KEY CLUSTERED ([BultoID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Bultos].[BultoID]...';


GO
CREATE NONCLUSTERED INDEX [BultoID]
    ON [dbo].[T_Bultos]([BultoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Bultos].[index_562817067]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_562817067]
    ON [dbo].[T_Bultos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Bultos].[OrdenID]...';


GO
CREATE NONCLUSTERED INDEX [OrdenID]
    ON [dbo].[T_Bultos]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Bultos].[T_OrdenesProduccionT_Bultos]...';


GO
CREATE NONCLUSTERED INDEX [T_OrdenesProduccionT_Bultos]
    ON [dbo].[T_Bultos]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_CostosMonedas]...';


GO
CREATE TABLE [dbo].[T_CostosMonedas] (
    [ArticuloID]      NUMERIC (18)     NOT NULL,
    [AlmacenID]       NUMERIC (18)     NOT NULL,
    [MonedaID]        NUMERIC (18)     NOT NULL,
    [Existencia]      NUMERIC (18)     NULL,
    [EntradaUnidad]   NUMERIC (18)     NULL,
    [EntradaValor]    MONEY            NULL,
    [SalidaUnidad]    NUMERIC (18)     NULL,
    [SalidaValor]     MONEY            NULL,
    [ExtDum]          NUMERIC (18)     NULL,
    [CostoPromedio]   MONEY            NULL,
    [CostoReposicion] MONEY            NULL,
    [rowguid]         UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_CostosMonedas] PRIMARY KEY CLUSTERED ([ArticuloID] ASC, [AlmacenID] ASC, [MonedaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_CostosMonedas].[index_1826821570]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1826821570]
    ON [dbo].[T_CostosMonedas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Cotizacion]...';


GO
CREATE TABLE [dbo].[T_Cotizacion] (
    [CotizacionID]      NUMERIC (18)     NOT NULL,
    [EstiloID]          NUMERIC (10)     NULL,
    [Observaciones]     TEXT             NULL,
    [FechaCreacion]     SMALLDATETIME    NULL,
    [FechaModificacion] SMALLDATETIME    NULL,
    [rowguid]           UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Cotizacion] PRIMARY KEY CLUSTERED ([CotizacionID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Cotizacion].[index_739533718]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_739533718]
    ON [dbo].[T_Cotizacion]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_CotizacionDet]...';


GO
CREATE TABLE [dbo].[T_CotizacionDet] (
    [CotizacionID] NUMERIC (18)     NOT NULL,
    [Renglon]      NUMERIC (18)     NOT NULL,
    [Equivalencia] INT              NULL,
    [HiloID]       INT              NULL,
    [Aplic]        VARCHAR (50)     NULL,
    [Cod]          VARCHAR (50)     NULL,
    [Metros]       MONEY            NULL,
    [Costo]        MONEY            NULL,
    [Total]        MONEY            NULL,
    [TotalConos]   MONEY            NULL,
    [MtsCono]      INT              NULL,
    [rowguid]      UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_CotizacionDet] PRIMARY KEY CLUSTERED ([CotizacionID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_CotizacionDet].[index_803533946]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_803533946]
    ON [dbo].[T_CotizacionDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Estilos]...';


GO
CREATE TABLE [dbo].[T_Estilos] (
    [EstiloID]    NUMERIC (10)     NOT NULL,
    [Num]         NVARCHAR (30)    NULL,
    [Descripcion] NVARCHAR (60)    NULL,
    [FechaAlta]   DATETIME         NULL,
    [Inactivo]    BIT              NOT NULL,
    [FechaBaja]   DATETIME         NULL,
    [Linea]       VARCHAR (50)     NULL,
    [Division]    VARCHAR (50)     NULL,
    [Cliente]     VARCHAR (50)     NULL,
    [Observacion] TEXT             NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    [num_metadia] INT              NULL,
    CONSTRAINT [aaaaaT_Estilos_PK] PRIMARY KEY NONCLUSTERED ([EstiloID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Estilos].[index_1847677630]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1847677630]
    ON [dbo].[T_Estilos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_EstilosDet]...';


GO
CREATE TABLE [dbo].[T_EstilosDet] (
    [EstiloID]    NUMERIC (10)     NOT NULL,
    [Renglon]     INT              NOT NULL,
    [OperacionID] INT              NOT NULL,
    [Orden]       SMALLINT         NULL,
    [Act]         BIT              NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    [OrdenRpt]    INT              NULL,
    [Lado]        CHAR (25)        NULL,
    [Etapa]       CHAR (25)        NULL,
    CONSTRAINT [aaaaaT_EstilosDet_PK] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_EstilosDet].[C_OperacionesT_EstilosDet]...';


GO
CREATE NONCLUSTERED INDEX [C_OperacionesT_EstilosDet]
    ON [dbo].[T_EstilosDet]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_EstilosDet].[index_1959678029]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1959678029]
    ON [dbo].[T_EstilosDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_EstilosDet].[OperacionID]...';


GO
CREATE NONCLUSTERED INDEX [OperacionID]
    ON [dbo].[T_EstilosDet]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_EstilosDetTeor]...';


GO
CREATE TABLE [dbo].[T_EstilosDetTeor] (
    [EstiloID]    NUMERIC (10)     NOT NULL,
    [Renglon]     INT              NOT NULL,
    [OperacionID] INT              NOT NULL,
    [Orden]       SMALLINT         NULL,
    [Act]         BIT              NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_EstilosDetTeor] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_EstilosDetTeor].[index_810590076]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_810590076]
    ON [dbo].[T_EstilosDetTeor]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_EstilosHilosDet]...';


GO
CREATE TABLE [dbo].[T_EstilosHilosDet] (
    [EstiloID] NUMERIC (10)     NOT NULL,
    [Renglon]  INT              NOT NULL,
    [Orden]    INT              NOT NULL,
    [HiloID]   INT              NOT NULL,
    [Arriba]   BIT              NULL,
    [Act]      BIT              NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_EstilosHilosDet] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [Renglon] ASC, [Orden] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_EstilosHilosDet].[index_498816839]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_498816839]
    ON [dbo].[T_EstilosHilosDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_EstilosHilosDetTeor]...';


GO
CREATE TABLE [dbo].[T_EstilosHilosDetTeor] (
    [EstiloID] NUMERIC (10)     NOT NULL,
    [Renglon]  INT              NOT NULL,
    [Orden]    INT              NOT NULL,
    [HiloID]   INT              NOT NULL,
    [Arriba]   BIT              NULL,
    [Act]      BIT              NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_EstilosHilosDetTeor] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [Renglon] ASC, [Orden] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_EstilosHilosDetTeor].[index_826590133]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_826590133]
    ON [dbo].[T_EstilosHilosDetTeor]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_EstilosMarcas]...';


GO
CREATE TABLE [dbo].[T_EstilosMarcas] (
    [EstiloID] INT              NOT NULL,
    [MarcaID]  VARCHAR (12)     NOT NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_EstilosMarcas] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [MarcaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_EstilosMarcas].[index_1262197284]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1262197284]
    ON [dbo].[T_EstilosMarcas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_EtiqFecPag]...';


GO
CREATE TABLE [dbo].[T_EtiqFecPag] (
    [EtiquetaID] NUMERIC (18)     NOT NULL,
    [FechaPago]  SMALLDATETIME    NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[T_EtiqFecPag].[index_1388584035]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1388584035]
    ON [dbo].[T_EtiqFecPag]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Etiquetas]...';


GO
CREATE TABLE [dbo].[T_Etiquetas] (
    [EtiquetaID]  NUMERIC (18)     NOT NULL,
    [BultoID]     NUMERIC (10)     NOT NULL,
    [OperacionID] INT              NOT NULL,
    [EstiloID]    INT              NULL,
    [Renglon]     INT              NULL,
    [PersonalID]  INT              NULL,
    [Fecha]       SMALLDATETIME    NULL,
    [Hora]        DATETIME         NULL,
    [HojaID]      NUMERIC (18)     NULL,
    [Escaneada]   BIT              NULL,
    [Cancelada]   BIT              NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaT_Etiquetas_PK] PRIMARY KEY NONCLUSTERED ([EtiquetaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Etiquetas].[BultoID]...';


GO
CREATE NONCLUSTERED INDEX [BultoID]
    ON [dbo].[T_Etiquetas]([BultoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Etiquetas].[C_OperacionesT_Etiquetas]...';


GO
CREATE NONCLUSTERED INDEX [C_OperacionesT_Etiquetas]
    ON [dbo].[T_Etiquetas]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Etiquetas].[C_PersonalT_Etiquetas]...';


GO
CREATE NONCLUSTERED INDEX [C_PersonalT_Etiquetas]
    ON [dbo].[T_Etiquetas]([PersonalID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Etiquetas].[HojaID]...';


GO
CREATE NONCLUSTERED INDEX [HojaID]
    ON [dbo].[T_Etiquetas]([HojaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Etiquetas].[index_1170819233]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1170819233]
    ON [dbo].[T_Etiquetas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Etiquetas].[OperacionID]...';


GO
CREATE NONCLUSTERED INDEX [OperacionID]
    ON [dbo].[T_Etiquetas]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Etiquetas].[PersonalID]...';


GO
CREATE NONCLUSTERED INDEX [PersonalID]
    ON [dbo].[T_Etiquetas]([PersonalID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Folios]...';


GO
CREATE TABLE [dbo].[T_Folios] (
    [Folio]   NUMERIC (18)     NULL,
    [Tipo]    CHAR (1)         NOT NULL,
    [rowguid] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Folios] PRIMARY KEY CLUSTERED ([Tipo] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Folios].[index_454292678]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_454292678]
    ON [dbo].[T_Folios]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_HojasControl]...';


GO
CREATE TABLE [dbo].[T_HojasControl] (
    [HojaID]     NUMERIC (18)     NOT NULL,
    [PersonalID] INT              NOT NULL,
    [Fecha]      SMALLDATETIME    NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_HojasControl] PRIMARY KEY CLUSTERED ([HojaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_HojasControl].[index_470292735]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_470292735]
    ON [dbo].[T_HojasControl]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Inventario]...';


GO
CREATE TABLE [dbo].[T_Inventario] (
    [ArticuloID]      NUMERIC (18)     NOT NULL,
    [AlmacenID]       NUMERIC (18)     NOT NULL,
    [Existencia]      NUMERIC (18)     NULL,
    [EntradaUnidad]   NUMERIC (18)     NULL,
    [EntradaValor]    MONEY            NULL,
    [SalidaUnidad]    NUMERIC (18)     NULL,
    [SalidaValor]     MONEY            NULL,
    [ExtDum]          NUMERIC (18)     NULL,
    [CostoPromedio]   MONEY            NULL,
    [CostoReposicion] MONEY            NULL,
    [rowguid]         UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Inventario] PRIMARY KEY CLUSTERED ([ArticuloID] ASC, [AlmacenID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Inventario].[index_1858821684]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1858821684]
    ON [dbo].[T_Inventario]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MantoMaq]...';


GO
CREATE TABLE [dbo].[T_MantoMaq] (
    [MantoId]      NUMERIC (18)     NOT NULL,
    [MaquinariaID] INT              NOT NULL,
    [Fecha]        CHAR (10)        NULL,
    [Motivo]       TEXT             NULL,
    [Total]        MONEY            NULL,
    [Tipo]         SMALLINT         NULL,
    [Cancelado]    BIT              NULL,
    [MotCancelado] VARCHAR (50)     NULL,
    [FechaCancel]  SMALLDATETIME    NULL,
    [MonedaID]     NUMERIC (18)     NULL,
    [TipoCambio]   MONEY            NULL,
    [rowguid]      UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_MantoMaq] PRIMARY KEY CLUSTERED ([MantoId] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_MantoMaq].[index_1200775385]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1200775385]
    ON [dbo].[T_MantoMaq]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MantoMaqDet]...';


GO
CREATE TABLE [dbo].[T_MantoMaqDet] (
    [MantoId]     NUMERIC (18)     NOT NULL,
    [Renglon]     INT              NOT NULL,
    [Cantidad]    REAL             NULL,
    [RefaccionID] NUMERIC (18)     NULL,
    [costo]       MONEY            NULL,
    [CostoPesos]  MONEY            NULL,
    [TipoCambio]  MONEY            NULL,
    [Observacion] TEXT             NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_MantoMaqDet] PRIMARY KEY CLUSTERED ([MantoId] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_MantoMaqDet].[index_976774587]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_976774587]
    ON [dbo].[T_MantoMaqDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MovimientosAlm]...';


GO
CREATE TABLE [dbo].[T_MovimientosAlm] (
    [MovimientoID] NUMERIC (18)     NOT NULL,
    [Tipo]         VARCHAR (1)      NOT NULL,
    [AlmacenID]    NUMERIC (18)     NULL,
    [Fecha]        SMALLDATETIME    NULL,
    [Referencia]   VARCHAR (50)     NULL,
    [TotalU]       NUMERIC (18)     NULL,
    [TotalC]       MONEY            NULL,
    [MonedaID]     NUMERIC (18)     NULL,
    [TotalCDef]    MONEY            NULL,
    [Cancelado]    BIT              NULL,
    [Aplicado]     BIT              NULL,
    [TipoCambio]   MONEY            NULL,
    [rowguid]      UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_MovimientosAlm] PRIMARY KEY CLUSTERED ([MovimientoID] ASC, [Tipo] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_MovimientosAlm].[index_1842821627]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1842821627]
    ON [dbo].[T_MovimientosAlm]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MovimientosAlmacenDet]...';


GO
CREATE TABLE [dbo].[T_MovimientosAlmacenDet] (
    [MovimientoID] NUMERIC (18)     NOT NULL,
    [Tipo]         VARCHAR (1)      NOT NULL,
    [Renglon]      NUMERIC (18)     NOT NULL,
    [ArticuloID]   NUMERIC (18)     NOT NULL,
    [Cantidad]     NUMERIC (18)     NULL,
    [Costo]        MONEY            NULL,
    [Importe]      MONEY            NULL,
    [rowguid]      UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_MovimientosAlmacenDet] PRIMARY KEY CLUSTERED ([MovimientoID] ASC, [Tipo] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_MovimientosAlmacenDet].[index_1874821741]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1874821741]
    ON [dbo].[T_MovimientosAlmacenDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MovimientosMaquinaria]...';


GO
CREATE TABLE [dbo].[T_MovimientosMaquinaria] (
    [MovimientoID]  INT              NOT NULL,
    [MaquinariaID]  INT              NULL,
    [ConceptoID]    INT              NULL,
    [Fecha]         DATETIME         NULL,
    [Origen]        INT              NULL,
    [Destino]       INT              NULL,
    [Entrega]       NVARCHAR (50)    NULL,
    [Recibe]        NVARCHAR (50)    NULL,
    [Autoriza]      NVARCHAR (50)    NULL,
    [Transportista] NVARCHAR (50)    NULL,
    [Observaciones] NVARCHAR (50)    NULL,
    [Cancelado]     BIT              NOT NULL,
    [FechaCancel]   SMALLDATETIME    NULL,
    [Motivo]        NVARCHAR (50)    NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaT_MovimientosMaquinaria_PK] PRIMARY KEY NONCLUSTERED ([MovimientoID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_MovimientosMaquinaria].[C_ConceptosT_MovimientosMaquinaria]...';


GO
CREATE NONCLUSTERED INDEX [C_ConceptosT_MovimientosMaquinaria]
    ON [dbo].[T_MovimientosMaquinaria]([ConceptoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MovimientosMaquinaria].[C_MaquinariaT_MovimientosMaquinaria]...';


GO
CREATE NONCLUSTERED INDEX [C_MaquinariaT_MovimientosMaquinaria]
    ON [dbo].[T_MovimientosMaquinaria]([MaquinariaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MovimientosMaquinaria].[ConceptoID]...';


GO
CREATE NONCLUSTERED INDEX [ConceptoID]
    ON [dbo].[T_MovimientosMaquinaria]([ConceptoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MovimientosMaquinaria].[index_2087678485]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_2087678485]
    ON [dbo].[T_MovimientosMaquinaria]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MovimientosMaquinaria].[MaquinariaID]...';


GO
CREATE NONCLUSTERED INDEX [MaquinariaID]
    ON [dbo].[T_MovimientosMaquinaria]([MaquinariaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_MovimientosMaquinaria].[MovimientoID]...';


GO
CREATE NONCLUSTERED INDEX [MovimientoID]
    ON [dbo].[T_MovimientosMaquinaria]([MovimientoID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Nomina]...';


GO
CREATE TABLE [dbo].[T_Nomina] (
    [NominaID]    NUMERIC (18)     NOT NULL,
    [Semana]      VARCHAR (4)      NULL,
    [FechaInicio] SMALLDATETIME    NULL,
    [FechaFin]    SMALLDATETIME    NULL,
    [Fecha]       SMALLDATETIME    NULL,
    [TotalNomina] MONEY            NULL,
    [Cancelado]   BIT              NULL,
    [Motivo]      VARCHAR (50)     NULL,
    [FechaCancel] SMALLDATETIME    NULL,
    [BalanceoId]  NUMERIC (18)     NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Nomina] PRIMARY KEY CLUSTERED ([NominaID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Nomina].[index_1666821000]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1666821000]
    ON [dbo].[T_Nomina]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_NominaDet]...';


GO
CREATE TABLE [dbo].[T_NominaDet] (
    [NominaID]    NUMERIC (18)     NOT NULL,
    [Renglon]     NUMERIC (18)     NOT NULL,
    [PersonalID]  INT              NOT NULL,
    [ConceptoPID] INT              NOT NULL,
    [Importe]     MONEY            NULL,
    [Cantidad]    MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_NominaDet] PRIMARY KEY CLUSTERED ([NominaID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_NominaDet].[index_418816554]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_418816554]
    ON [dbo].[T_NominaDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_OrdenesProduccion]...';


GO
CREATE TABLE [dbo].[T_OrdenesProduccion] (
    [OrdenID]     INT              NOT NULL,
    [NoOrden]     NVARCHAR (50)    NULL,
    [NoPo]        NVARCHAR (50)    NULL,
    [OV]          NVARCHAR (50)    NULL,
    [FechaAlta]   SMALLDATETIME    NULL,
    [EstiloID]    NUMERIC (10)     NULL,
    [FechaCierre] SMALLDATETIME    NULL,
    [FechaCancel] SMALLDATETIME    NULL,
    [Cancelado]   BIT              NOT NULL,
    [Motivo]      NVARCHAR (50)    NULL,
    [Planta]      VARCHAR (50)     NULL,
    [Tela]        VARCHAR (50)     NULL,
    [FechaCorte]  SMALLDATETIME    NULL,
    [Total]       INT              NULL,
    [rowguid]     UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    [id_periodo]  INT              NULL,
    CONSTRAINT [aaaaaT_OrdenesProduccion_PK] PRIMARY KEY NONCLUSTERED ([OrdenID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_OrdenesProduccion].[index_658817409]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_658817409]
    ON [dbo].[T_OrdenesProduccion]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_OrdenesProduccion].[OrdenID]...';


GO
CREATE NONCLUSTERED INDEX [OrdenID]
    ON [dbo].[T_OrdenesProduccion]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_OrdenesProduccion].[T_EstilosT_OrdenesProduccion]...';


GO
CREATE NONCLUSTERED INDEX [T_EstilosT_OrdenesProduccion]
    ON [dbo].[T_OrdenesProduccion]([EstiloID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_OrdEnPlanta]...';


GO
CREATE TABLE [dbo].[T_OrdEnPlanta] (
    [OrdenID]  INT              NOT NULL,
    [Cantidad] INT              NULL,
    [Fecha]    SMALLDATETIME    NULL,
    [rowguid]  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[T_OrdEnPlanta].[index_879042613]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_879042613]
    ON [dbo].[T_OrdEnPlanta]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_OrdenProduccionDet]...';


GO
CREATE TABLE [dbo].[T_OrdenProduccionDet] (
    [OrdenID]       INT              NOT NULL,
    [Renglon]       INT              NOT NULL,
    [TallaID]       NUMERIC (18)     NULL,
    [NoBultos]      INT              NULL,
    [NPiezasXBulto] INT              NULL,
    [Serie]         VARCHAR (3)      NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaT_OrdenProduccionDet_PK] PRIMARY KEY NONCLUSTERED ([OrdenID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_OrdenProduccionDet].[index_226815870]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_226815870]
    ON [dbo].[T_OrdenProduccionDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_OrdenProduccionDet].[OrdenID]...';


GO
CREATE NONCLUSTERED INDEX [OrdenID]
    ON [dbo].[T_OrdenProduccionDet]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_OrdenProduccionDet].[T_OrdenesProduccionT_OrdenProduccionDet]...';


GO
CREATE NONCLUSTERED INDEX [T_OrdenesProduccionT_OrdenProduccionDet]
    ON [dbo].[T_OrdenProduccionDet]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_OrdOrdenesProduccion]...';


GO
CREATE TABLE [dbo].[T_OrdOrdenesProduccion] (
    [OrdenID]   INT              NOT NULL,
    [Orden]     INT              NULL,
    [Periodo]   VARCHAR (10)     NULL,
    [Auditoria] INT              NULL,
    [rowguid]   UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[T_OrdOrdenesProduccion].[index_764021953]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_764021953]
    ON [dbo].[T_OrdOrdenesProduccion]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Perfil]...';


GO
CREATE TABLE [dbo].[T_Perfil] (
    [PerfilID]   INT              IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [UsuarioID]  INT              NULL,
    [PantallaID] INT              NULL,
    [Alta]       BIT              NULL,
    [Baja]       BIT              NULL,
    [Cambio]     BIT              NULL,
    [Consulta]   BIT              NULL,
    [Depurar]    BIT              NULL,
    [Firma]      BIT              NULL,
    [Imprimir]   BIT              NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaT_Perfil_PK] PRIMARY KEY NONCLUSTERED ([PerfilID] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_Perfil].[C_PantallasT_Perfil]...';


GO
CREATE NONCLUSTERED INDEX [C_PantallasT_Perfil]
    ON [dbo].[T_Perfil]([PantallaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Perfil].[C_UsuariosT_Perfil]...';


GO
CREATE NONCLUSTERED INDEX [C_UsuariosT_Perfil]
    ON [dbo].[T_Perfil]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Perfil].[index_1991678143]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1991678143]
    ON [dbo].[T_Perfil]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Perfil].[PantallaID]...';


GO
CREATE NONCLUSTERED INDEX [PantallaID]
    ON [dbo].[T_Perfil]([PantallaID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Perfil].[PerfilID]...';


GO
CREATE NONCLUSTERED INDEX [PerfilID]
    ON [dbo].[T_Perfil]([PerfilID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_Perfil].[UsuarioID]...';


GO
CREATE NONCLUSTERED INDEX [UsuarioID]
    ON [dbo].[T_Perfil]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_PersonalConceptos]...';


GO
CREATE TABLE [dbo].[T_PersonalConceptos] (
    [PersonalConID] NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [ConceptoPID]   INT              NULL,
    [PersonalID]    INT              NULL,
    [Importe]       MONEY            NULL,
    [Cantidad]      INT              NULL,
    [rowguid]       UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_PersonalConceptos] PRIMARY KEY NONCLUSTERED ([rowguid] ASC) WITH (FILLFACTOR = 90)
);


GO
PRINT N'Creando [dbo].[T_PersonalConceptos].[index_144719568]...';


GO
CREATE UNIQUE CLUSTERED INDEX [index_144719568]
    ON [dbo].[T_PersonalConceptos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_PersonalFaltas]...';


GO
CREATE TABLE [dbo].[T_PersonalFaltas] (
    [PersonalID] INT              NOT NULL,
    [Tipo]       CHAR (1)         NOT NULL,
    [Fecha]      SMALLDATETIME    NOT NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[T_PersonalFaltas].[index_928826471]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_928826471]
    ON [dbo].[T_PersonalFaltas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[T_PersonalFechas]...';


GO
CREATE TABLE [dbo].[T_PersonalFechas] (
    [PersonalID] INT              NOT NULL,
    [Fecha]      SMALLDATETIME    NULL,
    [Tipo]       SMALLINT         NULL,
    [rowguid]    UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[T_PersonalFechas].[index_1150015228]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1150015228]
    ON [dbo].[T_PersonalFechas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[t_RegistroCorte]...';


GO
CREATE TABLE [dbo].[t_RegistroCorte] (
    [id]          INT      NOT NULL,
    [fecha]       DATETIME NULL,
    [BihorarioID] INT      NULL,
    [OrdenID]     INT      NULL,
    [piezas]      INT      NULL
);


GO
PRINT N'Creando [dbo].[Tmp_reporte]...';


GO
CREATE TABLE [dbo].[Tmp_reporte] (
    [TipoID]  NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Campo]   VARCHAR (50)     NULL,
    [rowguid] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
);


GO
PRINT N'Creando [dbo].[Tmp_reporte].[index_1298819689]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1298819689]
    ON [dbo].[Tmp_reporte]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
PRINT N'Creando [dbo].[TmpParamPant]...';


GO
CREATE TABLE [dbo].[TmpParamPant] (
    [Intervalo1] INT           NULL,
    [HoraInicio] SMALLDATETIME NULL,
    [MinutosPer] INT           NULL,
    [Intervalo2] INT           NULL,
    [Intervalo3] INT           NULL,
    [Periodos]   FLOAT (53)    NULL,
    [Duracion1]  INT           NULL,
    [Duracion2]  INT           NULL,
    [Duracion3]  INT           NULL,
    [Meta]       INT           NULL
);


GO
PRINT N'Creando [dbo].[DF__C_Almacen__rowgu__75CD617E]...';


GO
ALTER TABLE [dbo].[C_Almacen]
    ADD CONSTRAINT [DF__C_Almacen__rowgu__75CD617E] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_AreaMod__rowgu__68C508C6]...';


GO
ALTER TABLE [dbo].[C_AreaModulo]
    ADD CONSTRAINT [DF__C_AreaMod__rowgu__68C508C6] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Areas__rowguid__6DA22FD1]...';


GO
ALTER TABLE [dbo].[C_Areas]
    ADD CONSTRAINT [DF__C_Areas__rowguid__6DA22FD1] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Articul__rowgu__108157BA]...';


GO
ALTER TABLE [dbo].[C_Articulos]
    ADD CONSTRAINT [DF__C_Articul__rowgu__108157BA] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Concept__rowgu__62307D25]...';


GO
ALTER TABLE [dbo].[C_Conceptos]
    ADD CONSTRAINT [DF__C_Concept__rowgu__62307D25] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Concept__rowgu__5C77A3CF]...';


GO
ALTER TABLE [dbo].[C_ConceptosP]
    ADD CONSTRAINT [DF__C_Concept__rowgu__5C77A3CF] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Empresa__rowgu__67D0E48D]...';


GO
ALTER TABLE [dbo].[C_EmpresaP]
    ADD CONSTRAINT [DF__C_Empresa__rowgu__67D0E48D] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Empresa__rowgu__56BECA79]...';


GO
ALTER TABLE [dbo].[C_Empresas]
    ADD CONSTRAINT [DF__C_Empresa__rowgu__56BECA79] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_GrosorA__rowgu__3BB699D9]...';


GO
ALTER TABLE [dbo].[C_GrosorAgujas]
    ADD CONSTRAINT [DF__C_GrosorA__rowgu__3BB699D9] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Hilos__Yardas__023D5A04]...';


GO
ALTER TABLE [dbo].[C_Hilos]
    ADD CONSTRAINT [DF__C_Hilos__Yardas__023D5A04] DEFAULT ((0)) FOR [Yardas];


GO
PRINT N'Creando [dbo].[DF__C_Hilos__Costo__03317E3D]...';


GO
ALTER TABLE [dbo].[C_Hilos]
    ADD CONSTRAINT [DF__C_Hilos__Costo__03317E3D] DEFAULT ((0)) FOR [Costo];


GO
PRINT N'Creando [dbo].[DF__C_Hilos__rowguid__5105F123]...';


GO
ALTER TABLE [dbo].[C_Hilos]
    ADD CONSTRAINT [DF__C_Hilos__rowguid__5105F123] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Lineas__rowgui__5378497A]...';


GO
ALTER TABLE [dbo].[C_Lineas]
    ADD CONSTRAINT [DF__C_Lineas__rowgui__5378497A] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF_C_Maquinaria_Rentada]...';


GO
ALTER TABLE [dbo].[C_Maquinaria]
    ADD CONSTRAINT [DF_C_Maquinaria_Rentada] DEFAULT ((0)) FOR [Rentada];


GO
PRINT N'Creando [dbo].[DF__C_Maquina__rowgu__3DBE1285]...';


GO
ALTER TABLE [dbo].[C_Maquinaria]
    ADD CONSTRAINT [DF__C_Maquina__rowgu__3DBE1285] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Marcas__rowgui__66DCC054]...';


GO
ALTER TABLE [dbo].[C_Marcas]
    ADD CONSTRAINT [DF__C_Marcas__rowgui__66DCC054] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_MarcasA__rowgu__31390B66]...';


GO
ALTER TABLE [dbo].[C_MarcasAgujas]
    ADD CONSTRAINT [DF__C_MarcasA__rowgu__31390B66] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_ModeloA__rowgu__2B803210]...';


GO
ALTER TABLE [dbo].[C_ModeloAguja]
    ADD CONSTRAINT [DF__C_ModeloA__rowgu__2B803210] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Modulos__Bono__0BC6C43E]...';


GO
ALTER TABLE [dbo].[C_Modulos]
    ADD CONSTRAINT [DF__C_Modulos__Bono__0BC6C43E] DEFAULT ((0)) FOR [Bono];


GO
PRINT N'Creando [dbo].[DF__C_Modulos__rowgu__4B4D17CD]...';


GO
ALTER TABLE [dbo].[C_Modulos]
    ADD CONSTRAINT [DF__C_Modulos__rowgu__4B4D17CD] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Monedas__rowgu__2102A39D]...';


GO
ALTER TABLE [dbo].[C_Monedas]
    ADD CONSTRAINT [DF__C_Monedas__rowgu__2102A39D] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Operaci__AreaI__108B795B]...';


GO
ALTER TABLE [dbo].[C_Operaciones]
    ADD CONSTRAINT [DF__C_Operaci__AreaI__108B795B] DEFAULT ((0)) FOR [AreaID];


GO
PRINT N'Creando [dbo].[DF__C_Operaci__Consu__117F9D94]...';


GO
ALTER TABLE [dbo].[C_Operaciones]
    ADD CONSTRAINT [DF__C_Operaci__Consu__117F9D94] DEFAULT ((0)) FOR [Consumo];


GO
PRINT N'Creando [dbo].[DF__C_Operaci__Maqui__1273C1CD]...';


GO
ALTER TABLE [dbo].[C_Operaciones]
    ADD CONSTRAINT [DF__C_Operaci__Maqui__1273C1CD] DEFAULT ((0)) FOR [TipoMaquinaID];


GO
PRINT N'Creando [dbo].[DF__C_Operaci__Produ__164452B1]...';


GO
ALTER TABLE [dbo].[C_Operaciones]
    ADD CONSTRAINT [DF__C_Operaci__Produ__164452B1] DEFAULT ((0)) FOR [Produccion];


GO
PRINT N'Creando [dbo].[DF__C_Operaci__Costo__173876EA]...';


GO
ALTER TABLE [dbo].[C_Operaciones]
    ADD CONSTRAINT [DF__C_Operaci__Costo__173876EA] DEFAULT ((0)) FOR [Costoop];


GO
PRINT N'Creando [dbo].[DF_C_Operaciones_Activo]...';


GO
ALTER TABLE [dbo].[C_Operaciones]
    ADD CONSTRAINT [DF_C_Operaciones_Activo] DEFAULT ((1)) FOR [Activo];


GO
PRINT N'Creando [dbo].[DF__C_Operaci__rowgu__3805392F]...';


GO
ALTER TABLE [dbo].[C_Operaciones]
    ADD CONSTRAINT [DF__C_Operaci__rowgu__3805392F] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Operaci__rowgu__0FF747D5]...';


GO
ALTER TABLE [dbo].[C_OperacionHilos]
    ADD CONSTRAINT [DF__C_Operaci__rowgu__0FF747D5] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Pantall__rowgu__45943E77]...';


GO
ALTER TABLE [dbo].[C_Pantallas]
    ADD CONSTRAINT [DF__C_Pantall__rowgu__45943E77] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Persona__Modul__656C112C]...';


GO
ALTER TABLE [dbo].[C_Personal]
    ADD CONSTRAINT [DF__C_Persona__Modul__656C112C] DEFAULT ((0)) FOR [ModuloID];


GO
PRINT N'Creando [dbo].[DF__C_Persona__Sueld__66603565]...';


GO
ALTER TABLE [dbo].[C_Personal]
    ADD CONSTRAINT [DF__C_Persona__Sueld__66603565] DEFAULT ((0)) FOR [SueldoID];


GO
PRINT N'Creando [dbo].[DF__C_Persona__rowgu__0A3E6E7F]...';


GO
ALTER TABLE [dbo].[C_Personal]
    ADD CONSTRAINT [DF__C_Persona__rowgu__0A3E6E7F] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Persona__rowgu__5CED7072]...';


GO
ALTER TABLE [dbo].[C_PersonalFechas]
    ADD CONSTRAINT [DF__C_Persona__rowgu__5CED7072] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Proveed__rowgu__1685152A]...';


GO
ALTER TABLE [dbo].[C_Proveedores]
    ADD CONSTRAINT [DF__C_Proveed__rowgu__1685152A] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Puestos__rowgu__186E28F3]...';


GO
ALTER TABLE [dbo].[C_Puestos]
    ADD CONSTRAINT [DF__C_Puestos__rowgu__186E28F3] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_PuntasA__rowgu__10CC3BD4]...';


GO
ALTER TABLE [dbo].[C_PuntasAgujas]
    ADD CONSTRAINT [DF__C_PuntasA__rowgu__10CC3BD4] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Refacci__rowgu__6C59D134]...';


GO
ALTER TABLE [dbo].[C_Refacciones]
    ADD CONSTRAINT [DF__C_Refacci__rowgu__6C59D134] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Sueldos__Monto__239E4DCF]...';


GO
ALTER TABLE [dbo].[C_Sueldos]
    ADD CONSTRAINT [DF__C_Sueldos__Monto__239E4DCF] DEFAULT ((0)) FOR [Monto];


GO
PRINT N'Creando [dbo].[DF__C_Sueldos__Bono__24927208]...';


GO
ALTER TABLE [dbo].[C_Sueldos]
    ADD CONSTRAINT [DF__C_Sueldos__Bono__24927208] DEFAULT ((0)) FOR [Bono];


GO
PRINT N'Creando [dbo].[DF__C_Sueldos__rowgu__3FDB6521]...';


GO
ALTER TABLE [dbo].[C_Sueldos]
    ADD CONSTRAINT [DF__C_Sueldos__rowgu__3FDB6521] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Tallas__rowgui__3469B275]...';


GO
ALTER TABLE [dbo].[C_Tallas]
    ADD CONSTRAINT [DF__C_Tallas__rowgui__3469B275] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_TiposMa__rowgu__2EB0D91F]...';


GO
ALTER TABLE [dbo].[C_TiposMaquina]
    ADD CONSTRAINT [DF__C_TiposMa__rowgu__2EB0D91F] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_TiposRe__rowgu__7CC54327]...';


GO
ALTER TABLE [dbo].[C_TiposRegAguja]
    ADD CONSTRAINT [DF__C_TiposRe__rowgu__7CC54327] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__C_Usuario__rowgu__28F7FFC9]...';


GO
ALTER TABLE [dbo].[C_Usuarios]
    ADD CONSTRAINT [DF__C_Usuario__rowgu__28F7FFC9] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__Parametro__rowgu__7247B4B4]...';


GO
ALTER TABLE [dbo].[Parametros]
    ADD CONSTRAINT [DF__Parametro__rowgu__7247B4B4] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__rpt_Estat__rowgu__6994D527]...';


GO
ALTER TABLE [dbo].[rpt_Estatus]
    ADD CONSTRAINT [DF__rpt_Estat__rowgu__6994D527] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Agujas__rowgui__49CFAF06]...';


GO
ALTER TABLE [dbo].[T_Agujas]
    ADD CONSTRAINT [DF__T_Agujas__rowgui__49CFAF06] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Balance__rowgu__04859529]...';


GO
ALTER TABLE [dbo].[T_Balanceo]
    ADD CONSTRAINT [DF__T_Balance__rowgu__04859529] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Balance__rowgu__4EE89E87]...';


GO
ALTER TABLE [dbo].[T_BalanceoMaq]
    ADD CONSTRAINT [DF__T_Balance__rowgu__4EE89E87] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF_T_BalanceoOpDet_OperacionID]...';


GO
ALTER TABLE [dbo].[T_BalanceoOpDet]
    ADD CONSTRAINT [DF_T_BalanceoOpDet_OperacionID] DEFAULT ((0)) FOR [OperacionID];


GO
PRINT N'Creando [dbo].[DF__T_Balance__rowgu__60132A89]...';


GO
ALTER TABLE [dbo].[T_BalanceoOpDet]
    ADD CONSTRAINT [DF__T_Balance__rowgu__60132A89] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Balance__rowgu__324C5FD9]...';


GO
ALTER TABLE [dbo].[T_BalanceoOtros]
    ADD CONSTRAINT [DF__T_Balance__rowgu__324C5FD9] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Balance__rowgu__2C938683]...';


GO
ALTER TABLE [dbo].[T_BalanceoStaf]
    ADD CONSTRAINT [DF__T_Balance__rowgu__2C938683] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Bitacor__Usuar__300424B4]...';


GO
ALTER TABLE [dbo].[T_Bitacora]
    ADD CONSTRAINT [DF__T_Bitacor__Usuar__300424B4] DEFAULT ((0)) FOR [UsuarioID];


GO
PRINT N'Creando [dbo].[DF__T_Bitacor__rowgu__7ECCBBD3]...';


GO
ALTER TABLE [dbo].[T_Bitacora]
    ADD CONSTRAINT [DF__T_Bitacor__rowgu__7ECCBBD3] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Bultos__OrdenI__35BCFE0A]...';


GO
ALTER TABLE [dbo].[T_Bultos]
    ADD CONSTRAINT [DF__T_Bultos__OrdenI__35BCFE0A] DEFAULT ((0)) FOR [OrdenID];


GO
PRINT N'Creando [dbo].[DF__T_Bultos__Cantid__36B12243]...';


GO
ALTER TABLE [dbo].[T_Bultos]
    ADD CONSTRAINT [DF__T_Bultos__Cantid__36B12243] DEFAULT ((0)) FOR [Cantidad];


GO
PRINT N'Creando [dbo].[DF__T_Bultos__rowgui__26DAAD2D]...';


GO
ALTER TABLE [dbo].[T_Bultos]
    ADD CONSTRAINT [DF__T_Bultos__rowgui__26DAAD2D] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_CostosM__rowgu__0AC87E64]...';


GO
ALTER TABLE [dbo].[T_CostosMonedas]
    ADD CONSTRAINT [DF__T_CostosM__rowgu__0AC87E64] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Cotizac__rowgu__3B219CFC]...';


GO
ALTER TABLE [dbo].[T_Cotizacion]
    ADD CONSTRAINT [DF__T_Cotizac__rowgu__3B219CFC] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Cotizac__rowgu__691D71D6]...';


GO
ALTER TABLE [dbo].[T_CotizacionDet]
    ADD CONSTRAINT [DF__T_Cotizac__rowgu__691D71D6] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__Cance__3D5E1FD2]...';


GO
ALTER TABLE [dbo].[T_Estilos]
    ADD CONSTRAINT [DF__T_Estilos__Cance__3D5E1FD2] DEFAULT ((0)) FOR [Inactivo];


GO
PRINT N'Creando [dbo].[DF_T_Estilos_Observacion]...';


GO
ALTER TABLE [dbo].[T_Estilos]
    ADD CONSTRAINT [DF_T_Estilos_Observacion] DEFAULT ('') FOR [Observacion];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__rowgu__233F2673]...';


GO
ALTER TABLE [dbo].[T_Estilos]
    ADD CONSTRAINT [DF__T_Estilos__rowgu__233F2673] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__Estil__4222D4EF]...';


GO
ALTER TABLE [dbo].[T_EstilosDet]
    ADD CONSTRAINT [DF__T_Estilos__Estil__4222D4EF] DEFAULT ((0)) FOR [EstiloID];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__Opera__4316F928]...';


GO
ALTER TABLE [dbo].[T_EstilosDet]
    ADD CONSTRAINT [DF__T_Estilos__Opera__4316F928] DEFAULT ((0)) FOR [OperacionID];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__rowgu__7913E27D]...';


GO
ALTER TABLE [dbo].[T_EstilosDet]
    ADD CONSTRAINT [DF__T_Estilos__rowgu__7913E27D] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__rowgu__332D0C27]...';


GO
ALTER TABLE [dbo].[T_EstilosDetTeor]
    ADD CONSTRAINT [DF__T_Estilos__rowgu__332D0C27] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF_T_EstilosHilosDet_EstiloID]...';


GO
ALTER TABLE [dbo].[T_EstilosHilosDet]
    ADD CONSTRAINT [DF_T_EstilosHilosDet_EstiloID] DEFAULT ((0)) FOR [EstiloID];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__rowgu__2121D3D7]...';


GO
ALTER TABLE [dbo].[T_EstilosHilosDet]
    ADD CONSTRAINT [DF__T_Estilos__rowgu__2121D3D7] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__rowgu__3238E7EE]...';


GO
ALTER TABLE [dbo].[T_EstilosHilosDetTeor]
    ADD CONSTRAINT [DF__T_Estilos__rowgu__3238E7EE] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Estilos__rowgu__65E89C1B]...';


GO
ALTER TABLE [dbo].[T_EstilosMarcas]
    ADD CONSTRAINT [DF__T_Estilos__rowgu__65E89C1B] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_EtiqFec__rowgu__54AC64D5]...';


GO
ALTER TABLE [dbo].[T_EtiqFecPag]
    ADD CONSTRAINT [DF__T_EtiqFec__rowgu__54AC64D5] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Etiquet__Bulto__47DBAE45]...';


GO
ALTER TABLE [dbo].[T_Etiquetas]
    ADD CONSTRAINT [DF__T_Etiquet__Bulto__47DBAE45] DEFAULT ((0)) FOR [BultoID];


GO
PRINT N'Creando [dbo].[DF__T_Etiquet__Opera__49C3F6B7]...';


GO
ALTER TABLE [dbo].[T_Etiquetas]
    ADD CONSTRAINT [DF__T_Etiquet__Opera__49C3F6B7] DEFAULT ((0)) FOR [OperacionID];


GO
PRINT N'Creando [dbo].[DF_T_Etiquetas_EstiloID]...';


GO
ALTER TABLE [dbo].[T_Etiquetas]
    ADD CONSTRAINT [DF_T_Etiquetas_EstiloID] DEFAULT ((0)) FOR [EstiloID];


GO
PRINT N'Creando [dbo].[DF__T_Etiquet__Perso__4AB81AF0]...';


GO
ALTER TABLE [dbo].[T_Etiquetas]
    ADD CONSTRAINT [DF__T_Etiquet__Perso__4AB81AF0] DEFAULT ((0)) FOR [PersonalID];


GO
PRINT N'Creando [dbo].[DF__T_Etiquet__rowgu__1D864D1D]...';


GO
ALTER TABLE [dbo].[T_Etiquetas]
    ADD CONSTRAINT [DF__T_Etiquet__rowgu__1D864D1D] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Folios__rowgui__17CD73C7]...';


GO
ALTER TABLE [dbo].[T_Folios]
    ADD CONSTRAINT [DF__T_Folios__rowgui__17CD73C7] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_HojasCo__rowgu__1B68FA81]...';


GO
ALTER TABLE [dbo].[T_HojasControl]
    ADD CONSTRAINT [DF__T_HojasCo__rowgu__1B68FA81] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Inventa__rowgu__163A3110]...';


GO
ALTER TABLE [dbo].[T_Inventario]
    ADD CONSTRAINT [DF__T_Inventa__rowgu__163A3110] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_MantoMa__rowgu__21C1BDAC]...';


GO
ALTER TABLE [dbo].[T_MantoMaq]
    ADD CONSTRAINT [DF__T_MantoMa__rowgu__21C1BDAC] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_MantoMa__rowgu__35C8B659]...';


GO
ALTER TABLE [dbo].[T_MantoMaqDet]
    ADD CONSTRAINT [DF__T_MantoMa__rowgu__35C8B659] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Movimie__rowgu__7B863AD4]...';


GO
ALTER TABLE [dbo].[T_MovimientosAlm]
    ADD CONSTRAINT [DF__T_Movimie__rowgu__7B863AD4] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Movimie__rowgu__1BF30A66]...';


GO
ALTER TABLE [dbo].[T_MovimientosAlmacenDet]
    ADD CONSTRAINT [DF__T_Movimie__rowgu__1BF30A66] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Movimie__Maqui__4F7CD00D]...';


GO
ALTER TABLE [dbo].[T_MovimientosMaquinaria]
    ADD CONSTRAINT [DF__T_Movimie__Maqui__4F7CD00D] DEFAULT ((0)) FOR [MaquinariaID];


GO
PRINT N'Creando [dbo].[DF__T_Movimie__Conce__5070F446]...';


GO
ALTER TABLE [dbo].[T_MovimientosMaquinaria]
    ADD CONSTRAINT [DF__T_Movimie__Conce__5070F446] DEFAULT ((0)) FOR [ConceptoID];


GO
PRINT N'Creando [dbo].[DF__T_Movimie__Cance__5165187F]...';


GO
ALTER TABLE [dbo].[T_MovimientosMaquinaria]
    ADD CONSTRAINT [DF__T_Movimie__Cance__5165187F] DEFAULT ((0)) FOR [Cancelado];


GO
PRINT N'Creando [dbo].[DF__T_Movimie__rowgu__5A5A5133]...';


GO
ALTER TABLE [dbo].[T_MovimientosMaquinaria]
    ADD CONSTRAINT [DF__T_Movimie__rowgu__5A5A5133] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Nomina__rowgui__12149A71]...';


GO
ALTER TABLE [dbo].[T_Nomina]
    ADD CONSTRAINT [DF__T_Nomina__rowgui__12149A71] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_NominaD__rowgu__54A177DD]...';


GO
ALTER TABLE [dbo].[T_NominaDet]
    ADD CONSTRAINT [DF__T_NominaD__rowgu__54A177DD] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Ordenes__Estil__571DF1D5]...';


GO
ALTER TABLE [dbo].[T_OrdenesProduccion]
    ADD CONSTRAINT [DF__T_Ordenes__Estil__571DF1D5] DEFAULT ((0)) FOR [EstiloID];


GO
PRINT N'Creando [dbo].[DF__T_Ordenes__Cance__59063A47]...';


GO
ALTER TABLE [dbo].[T_OrdenesProduccion]
    ADD CONSTRAINT [DF__T_Ordenes__Cance__59063A47] DEFAULT ((0)) FOR [Cancelado];


GO
PRINT N'Creando [dbo].[DF__T_Ordenes__rowgu__735B0927]...';


GO
ALTER TABLE [dbo].[T_OrdenesProduccion]
    ADD CONSTRAINT [DF__T_Ordenes__rowgu__735B0927] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_OrdEnPl__rowgu__3559446E]...';


GO
ALTER TABLE [dbo].[T_OrdEnPlanta]
    ADD CONSTRAINT [DF__T_OrdEnPl__rowgu__3559446E] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_OrdenPr__Orden__5DCAEF64]...';


GO
ALTER TABLE [dbo].[T_OrdenProduccionDet]
    ADD CONSTRAINT [DF__T_OrdenPr__Orden__5DCAEF64] DEFAULT ((0)) FOR [OrdenID];


GO
PRINT N'Creando [dbo].[DF__T_OrdenPr__Rengl__5EBF139D]...';


GO
ALTER TABLE [dbo].[T_OrdenProduccionDet]
    ADD CONSTRAINT [DF__T_OrdenPr__Rengl__5EBF139D] DEFAULT ((0)) FOR [Renglon];


GO
PRINT N'Creando [dbo].[DF__T_OrdenPr__NoBul__5FB337D6]...';


GO
ALTER TABLE [dbo].[T_OrdenProduccionDet]
    ADD CONSTRAINT [DF__T_OrdenPr__NoBul__5FB337D6] DEFAULT ((0)) FOR [NoBultos];


GO
PRINT N'Creando [dbo].[DF__T_OrdenPr__NPiez__60A75C0F]...';


GO
ALTER TABLE [dbo].[T_OrdenProduccionDet]
    ADD CONSTRAINT [DF__T_OrdenPr__NPiez__60A75C0F] DEFAULT ((0)) FOR [NPiezasXBulto];


GO
PRINT N'Creando [dbo].[DF__T_OrdenPr__rowgu__492FC531]...';


GO
ALTER TABLE [dbo].[T_OrdenProduccionDet]
    ADD CONSTRAINT [DF__T_OrdenPr__rowgu__492FC531] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_OrdOrde__rowgu__072F59AF]...';


GO
ALTER TABLE [dbo].[T_OrdOrdenesProduccion]
    ADD CONSTRAINT [DF__T_OrdOrde__rowgu__072F59AF] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Perfil__Usuari__29572725]...';


GO
ALTER TABLE [dbo].[T_Perfil]
    ADD CONSTRAINT [DF__T_Perfil__Usuari__29572725] DEFAULT ((0)) FOR [UsuarioID];


GO
PRINT N'Creando [dbo].[DF__T_Perfil__Pantal__2A4B4B5E]...';


GO
ALTER TABLE [dbo].[T_Perfil]
    ADD CONSTRAINT [DF__T_Perfil__Pantal__2A4B4B5E] DEFAULT ((0)) FOR [PantallaID];


GO
PRINT N'Creando [dbo].[DF__T_Perfil__rowgui__15B0212B]...';


GO
ALTER TABLE [dbo].[T_Perfil]
    ADD CONSTRAINT [DF__T_Perfil__rowgui__15B0212B] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Persona__rowgu__4376EBDB]...';


GO
ALTER TABLE [dbo].[T_PersonalConceptos]
    ADD CONSTRAINT [DF__T_Persona__rowgu__4376EBDB] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Persona__rowgu__7559F6E0]...';


GO
ALTER TABLE [dbo].[T_PersonalFaltas]
    ADD CONSTRAINT [DF__T_Persona__rowgu__7559F6E0] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__T_Persona__rowgu__2B8B1F08]...';


GO
ALTER TABLE [dbo].[T_PersonalFechas]
    ADD CONSTRAINT [DF__T_Persona__rowgu__2B8B1F08] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[DF__Tmp_repor__rowgu__597C06EA]...';


GO
ALTER TABLE [dbo].[Tmp_reporte]
    ADD CONSTRAINT [DF__Tmp_repor__rowgu__597C06EA] DEFAULT (newsequentialid()) FOR [rowguid];


GO
PRINT N'Creando [dbo].[FK_C_Articulos_C_Monedas]...';


GO
ALTER TABLE [dbo].[C_Articulos] WITH NOCHECK
    ADD CONSTRAINT [FK_C_Articulos_C_Monedas] FOREIGN KEY ([MonedaID]) REFERENCES [dbo].[C_Monedas] ([MonedaID]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_Articulos_T_Lineas]...';


GO
ALTER TABLE [dbo].[C_Articulos] WITH NOCHECK
    ADD CONSTRAINT [FK_T_Articulos_T_Lineas] FOREIGN KEY ([LineaID]) REFERENCES [dbo].[C_Lineas] ([LineaID]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_CostosMonedas_C_Almacen]...';


GO
ALTER TABLE [dbo].[T_CostosMonedas] WITH NOCHECK
    ADD CONSTRAINT [FK_T_CostosMonedas_C_Almacen] FOREIGN KEY ([AlmacenID]) REFERENCES [dbo].[C_Almacen] ([AlmacenID]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_CostosMonedas_C_Monedas]...';


GO
ALTER TABLE [dbo].[T_CostosMonedas] WITH NOCHECK
    ADD CONSTRAINT [FK_T_CostosMonedas_C_Monedas] FOREIGN KEY ([MonedaID]) REFERENCES [dbo].[C_Monedas] ([MonedaID]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_EstilosDet_T_Estilos]...';


GO
ALTER TABLE [dbo].[T_EstilosDet] WITH NOCHECK
    ADD CONSTRAINT [FK_T_EstilosDet_T_Estilos] FOREIGN KEY ([EstiloID]) REFERENCES [dbo].[T_Estilos] ([EstiloID]) ON DELETE CASCADE ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_EstilosHilosDet_T_EstilosDet]...';


GO
ALTER TABLE [dbo].[T_EstilosHilosDet] WITH NOCHECK
    ADD CONSTRAINT [FK_T_EstilosHilosDet_T_EstilosDet] FOREIGN KEY ([EstiloID], [Renglon]) REFERENCES [dbo].[T_EstilosDet] ([EstiloID], [Renglon]) ON DELETE CASCADE ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_Inventario_T_Almacen]...';


GO
ALTER TABLE [dbo].[T_Inventario] WITH NOCHECK
    ADD CONSTRAINT [FK_T_Inventario_T_Almacen] FOREIGN KEY ([AlmacenID]) REFERENCES [dbo].[C_Almacen] ([AlmacenID]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_Inventario_T_Articulos]...';


GO
ALTER TABLE [dbo].[T_Inventario] WITH NOCHECK
    ADD CONSTRAINT [FK_T_Inventario_T_Articulos] FOREIGN KEY ([ArticuloID]) REFERENCES [dbo].[C_Articulos] ([ArticuloID]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_MovimientosAlm_T_Almacen]...';


GO
ALTER TABLE [dbo].[T_MovimientosAlm] WITH NOCHECK
    ADD CONSTRAINT [FK_T_MovimientosAlm_T_Almacen] FOREIGN KEY ([AlmacenID]) REFERENCES [dbo].[C_Almacen] ([AlmacenID]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_MovimientosAlmacenDet_T_Articulos]...';


GO
ALTER TABLE [dbo].[T_MovimientosAlmacenDet] WITH NOCHECK
    ADD CONSTRAINT [FK_T_MovimientosAlmacenDet_T_Articulos] FOREIGN KEY ([ArticuloID]) REFERENCES [dbo].[C_Articulos] ([ArticuloID]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[FK_T_MovimientosAlmacenDet_T_MovimientosAlm]...';


GO
ALTER TABLE [dbo].[T_MovimientosAlmacenDet] WITH NOCHECK
    ADD CONSTRAINT [FK_T_MovimientosAlmacenDet_T_MovimientosAlm] FOREIGN KEY ([MovimientoID], [Tipo]) REFERENCES [dbo].[T_MovimientosAlm] ([MovimientoID], [Tipo]) ON UPDATE CASCADE NOT FOR REPLICATION;


GO
PRINT N'Creando [dbo].[T_C_Areas_DTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_C_Areas_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:01 a.m. ******/
CREATE TRIGGER [T_C_Areas_DTrig] ON [dbo].[C_Areas] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'C_Operaciones' */
DELETE C_Operaciones FROM deleted, C_Operaciones WHERE deleted.AreaID = C_Operaciones.AreaID
GO
PRINT N'Creando [dbo].[T_C_Areas_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_C_Areas_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:01 a.m. ******/
CREATE TRIGGER [T_C_Areas_UTrig] ON [dbo].[C_Areas] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'C_Operaciones' */
IF UPDATE(AreaID)
    BEGIN
       UPDATE C_Operaciones
       SET C_Operaciones.AreaID = inserted.AreaID
       FROM C_Operaciones, deleted, inserted
       WHERE deleted.AreaID = C_Operaciones.AreaID
    END
GO
PRINT N'Creando [dbo].[T_C_Conceptos_DTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_C_Conceptos_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:01 a.m. ******/
CREATE TRIGGER [T_C_Conceptos_DTrig] ON [dbo].[C_Conceptos] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_MovimientosMaquinaria' */
DELETE T_MovimientosMaquinaria FROM deleted, T_MovimientosMaquinaria WHERE deleted.ConceptoID = T_MovimientosMaquinaria.ConceptoID
GO
PRINT N'Creando [dbo].[T_C_Conceptos_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_C_Conceptos_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:01 a.m. ******/
CREATE TRIGGER [T_C_Conceptos_UTrig] ON [dbo].[C_Conceptos] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_MovimientosMaquinaria' */
IF UPDATE(ConceptoID)
    BEGIN
       UPDATE T_MovimientosMaquinaria
       SET T_MovimientosMaquinaria.ConceptoID = inserted.ConceptoID
       FROM T_MovimientosMaquinaria, deleted, inserted
       WHERE deleted.ConceptoID = T_MovimientosMaquinaria.ConceptoID
    END
GO
PRINT N'Creando [dbo].[T_C_Modulos_DTrig]...';


GO
CREATE TRIGGER [T_C_Modulos_DTrig] ON [dbo].[C_Modulos] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'C_Personal' */
DELETE C_Personal FROM deleted, C_Personal WHERE deleted.ModuloID = C_Personal.ModuloID
GO
PRINT N'Creando [dbo].[T_C_Modulos_UTrig]...';


GO
CREATE TRIGGER [T_C_Modulos_UTrig] ON [dbo].[C_Modulos] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'C_Personal' */
IF UPDATE(ModuloID)
    BEGIN
       UPDATE C_Personal
       SET C_Personal.ModuloID = inserted.ModuloID
       FROM C_Personal, deleted, inserted
       WHERE deleted.ModuloID = C_Personal.ModuloID
    END
GO
PRINT N'Creando [dbo].[T_C_Pantallas_DTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_C_Pantallas_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_C_Pantallas_DTrig] ON [dbo].[C_Pantallas] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Perfil' */
DELETE T_Perfil FROM deleted, T_Perfil WHERE deleted.PantallaID = T_Perfil.PantallaID
GO
PRINT N'Creando [dbo].[T_C_Pantallas_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_C_Pantallas_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_C_Pantallas_UTrig] ON [dbo].[C_Pantallas] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Perfil' */
IF UPDATE(PantallaID)
    BEGIN
       UPDATE T_Perfil
       SET T_Perfil.PantallaID = inserted.PantallaID
       FROM T_Perfil, deleted, inserted
       WHERE deleted.PantallaID = T_Perfil.PantallaID
    END
GO
PRINT N'Creando [dbo].[T_C_Personal_DTrig]...';


GO
CREATE TRIGGER [T_C_Personal_DTrig] ON [dbo].[C_Personal] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Etiquetas' */
DELETE T_Etiquetas FROM deleted, T_Etiquetas WHERE deleted.PersonalID = T_Etiquetas.PersonalID
GO
PRINT N'Creando [dbo].[T_C_Personal_ITrig]...';


GO
CREATE TRIGGER [T_C_Personal_ITrig] ON [dbo].[C_Personal] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Sueldos' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Sueldos, inserted WHERE (C_Sueldos.SueldoID = inserted.SueldoID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Sueldos''.', 44447, 1)
        ROLLBACK TRANSACTION
    END
GO
PRINT N'Creando [dbo].[T_C_Personal_UTrig]...';


GO
CREATE TRIGGER [T_C_Personal_UTrig] ON [dbo].[C_Personal] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Etiquetas' */
IF UPDATE(PersonalID)
    BEGIN
       UPDATE T_Etiquetas
       SET T_Etiquetas.PersonalID = inserted.PersonalID
       FROM T_Etiquetas, deleted, inserted
       WHERE deleted.PersonalID = T_Etiquetas.PersonalID
    END

/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Sueldos' */
IF UPDATE(SueldoID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Sueldos, inserted WHERE (C_Sueldos.SueldoID = inserted.SueldoID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Sueldos''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END
GO
PRINT N'Creando [dbo].[T_C_Sueldos_DTrig]...';


GO
CREATE TRIGGER [T_C_Sueldos_DTrig] ON [dbo].[C_Sueldos] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'C_Personal' */
DELETE C_Personal FROM deleted, C_Personal WHERE deleted.SueldoID = C_Personal.SueldoID
GO
PRINT N'Creando [dbo].[T_C_Sueldos_UTrig]...';


GO
CREATE TRIGGER [T_C_Sueldos_UTrig] ON [dbo].[C_Sueldos] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'C_Personal' */
IF UPDATE(SueldoID)
    BEGIN
       UPDATE C_Personal
       SET C_Personal.SueldoID = inserted.SueldoID
       FROM C_Personal, deleted, inserted
       WHERE deleted.SueldoID = C_Personal.SueldoID
    END
GO
PRINT N'Creando [dbo].[T_C_Usuarios_DTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_C_Usuarios_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_C_Usuarios_DTrig] ON [dbo].[C_Usuarios] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Bitacora' */
DELETE T_Bitacora FROM deleted, T_Bitacora WHERE deleted.UsuarioID = T_Bitacora.UsuarioID

/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Perfil' */
DELETE T_Perfil FROM deleted, T_Perfil WHERE deleted.UsuarioID = T_Perfil.UsuarioID
GO
PRINT N'Creando [dbo].[T_C_Usuarios_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_C_Usuarios_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_C_Usuarios_UTrig] ON [dbo].[C_Usuarios] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Bitacora' */
IF UPDATE(UsuarioID)
    BEGIN
       UPDATE T_Bitacora
       SET T_Bitacora.UsuarioID = inserted.UsuarioID
       FROM T_Bitacora, deleted, inserted
       WHERE deleted.UsuarioID = T_Bitacora.UsuarioID
    END

/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Perfil' */
IF UPDATE(UsuarioID)
    BEGIN
       UPDATE T_Perfil
       SET T_Perfil.UsuarioID = inserted.UsuarioID
       FROM T_Perfil, deleted, inserted
       WHERE deleted.UsuarioID = T_Perfil.UsuarioID
    END
GO
PRINT N'Creando [dbo].[T_T_Bitacora_ITrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_Bitacora_ITrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Bitacora_ITrig] ON [dbo].[T_Bitacora] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Usuarios' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Usuarios, inserted WHERE (C_Usuarios.UsuarioID = inserted.UsuarioID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Usuarios''.', 44447, 1)
        ROLLBACK TRANSACTION
    END
GO
PRINT N'Creando [dbo].[T_T_Bitacora_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_Bitacora_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Bitacora_UTrig] ON [dbo].[T_Bitacora] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Usuarios' */
IF UPDATE(UsuarioID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Usuarios, inserted WHERE (C_Usuarios.UsuarioID = inserted.UsuarioID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Usuarios''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END
GO
PRINT N'Creando [dbo].[T_T_Estilos_DTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_Estilos_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Estilos_DTrig] ON [dbo].[T_Estilos] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_EstilosDet' */
DELETE T_EstilosDet FROM deleted, T_EstilosDet WHERE deleted.EstiloID = T_EstilosDet.EstiloID

/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_OrdenesProduccion' */
DELETE T_OrdenesProduccion FROM deleted, T_OrdenesProduccion WHERE deleted.EstiloID = T_OrdenesProduccion.EstiloID
GO
PRINT N'Creando [dbo].[T_T_Estilos_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_Estilos_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Estilos_UTrig] ON [dbo].[T_Estilos] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_EstilosDet' */
IF UPDATE(EstiloID)
    BEGIN
       UPDATE T_EstilosDet
       SET T_EstilosDet.EstiloID = inserted.EstiloID
       FROM T_EstilosDet, deleted, inserted
       WHERE deleted.EstiloID = T_EstilosDet.EstiloID
    END

/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_OrdenesProduccion' */
IF UPDATE(EstiloID)
    BEGIN
       UPDATE T_OrdenesProduccion
       SET T_OrdenesProduccion.EstiloID = inserted.EstiloID
       FROM T_OrdenesProduccion, deleted, inserted
       WHERE deleted.EstiloID = T_OrdenesProduccion.EstiloID
    END
GO
PRINT N'Creando [dbo].[T_T_EstilosDet_ITrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_EstilosDet_ITrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_EstilosDet_ITrig] ON [dbo].[T_EstilosDet] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Operaciones' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Operaciones, inserted WHERE (C_Operaciones.OperacionID = inserted.OperacionID))
    BEGIN
        RAISERROR  ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Operaciones''.', 44447, 1)
        ROLLBACK TRANSACTION
    END

/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_Estilos' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM T_Estilos, inserted WHERE (T_Estilos.EstiloID = inserted.EstiloID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_Estilos''.', 44447, 1)
        ROLLBACK TRANSACTION
    END
GO
PRINT N'Creando [dbo].[T_T_EstilosDet_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_EstilosDet_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_EstilosDet_UTrig] ON [dbo].[T_EstilosDet] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Operaciones' */
IF UPDATE(OperacionID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Operaciones, inserted WHERE (C_Operaciones.OperacionID = inserted.OperacionID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Operaciones''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END

/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_Estilos' */
IF UPDATE(EstiloID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM T_Estilos, inserted WHERE (T_Estilos.EstiloID = inserted.EstiloID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_Estilos''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END
GO
PRINT N'Creando [dbo].[T_T_MovimientosMaquinaria_ITrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_MovimientosMaquinaria_ITrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_MovimientosMaquinaria_ITrig] ON [dbo].[T_MovimientosMaquinaria] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Conceptos' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Conceptos, inserted WHERE (C_Conceptos.ConceptoID = inserted.ConceptoID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Conceptos''.', 44447, 1)
        ROLLBACK TRANSACTION
    END

/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Maquinaria' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Maquinaria, inserted WHERE (C_Maquinaria.MaquinariaID = inserted.MaquinariaID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Maquinaria''.', 44447, 1)
        ROLLBACK TRANSACTION
    END
GO
PRINT N'Creando [dbo].[T_T_MovimientosMaquinaria_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_MovimientosMaquinaria_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_MovimientosMaquinaria_UTrig] ON [dbo].[T_MovimientosMaquinaria] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Conceptos' */
IF UPDATE(ConceptoID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Conceptos, inserted WHERE (C_Conceptos.ConceptoID = inserted.ConceptoID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Conceptos''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END

/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Maquinaria' */
IF UPDATE(MaquinariaID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Maquinaria, inserted WHERE (C_Maquinaria.MaquinariaID = inserted.MaquinariaID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Maquinaria''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END
GO
PRINT N'Creando [dbo].[T_T_OrdenesProduccion_DTrig]...';


GO
CREATE TRIGGER [dbo].[T_T_OrdenesProduccion_DTrig] ON [dbo].[T_OrdenesProduccion] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Bultos' */
DELETE T_Bultos FROM deleted, T_Bultos WHERE deleted.OrdenID = T_Bultos.OrdenID

/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_OrdenProduccionDet' */
DELETE T_OrdenProduccionDet FROM deleted, T_OrdenProduccionDet WHERE deleted.OrdenID = T_OrdenProduccionDet.OrdenID
GO
PRINT N'Creando [dbo].[T_T_OrdenesProduccion_ITrig]...';


GO
CREATE TRIGGER [T_T_OrdenesProduccion_ITrig] ON [dbo].[T_OrdenesProduccion] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_Estilos' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM T_Estilos, inserted WHERE (T_Estilos.EstiloID = inserted.EstiloID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_Estilos''.', 44447, 1)
        ROLLBACK TRANSACTION
    END
GO
PRINT N'Creando [dbo].[T_T_OrdenesProduccion_UTrig]...';


GO
CREATE TRIGGER [T_T_OrdenesProduccion_UTrig] ON [dbo].[T_OrdenesProduccion] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_Estilos' */
IF UPDATE(EstiloID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM T_Estilos, inserted WHERE (T_Estilos.EstiloID = inserted.EstiloID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_Estilos''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END

/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Bultos' */
IF UPDATE(OrdenID)
    BEGIN
       UPDATE T_Bultos
       SET T_Bultos.OrdenID = inserted.OrdenID
       FROM T_Bultos, deleted, inserted
       WHERE deleted.OrdenID = T_Bultos.OrdenID
    END

/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_OrdenProduccionDet' */
IF UPDATE(OrdenID)
    BEGIN
       UPDATE T_OrdenProduccionDet
       SET T_OrdenProduccionDet.OrdenID = inserted.OrdenID
       FROM T_OrdenProduccionDet, deleted, inserted
       WHERE deleted.OrdenID = T_OrdenProduccionDet.OrdenID
    END
GO
PRINT N'Creando [dbo].[T_T_OrdenProduccionDet_ITrig]...';


GO
CREATE TRIGGER [T_T_OrdenProduccionDet_ITrig] ON [dbo].[T_OrdenProduccionDet] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_OrdenesProduccion' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM T_OrdenesProduccion, inserted WHERE (T_OrdenesProduccion.OrdenID = inserted.OrdenID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_OrdenesProduccion''.', 44447, 1)
        ROLLBACK TRANSACTION
    END
GO
PRINT N'Creando [dbo].[T_T_OrdenProduccionDet_UTrig]...';


GO
CREATE TRIGGER [T_T_OrdenProduccionDet_UTrig] ON [dbo].[T_OrdenProduccionDet] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_OrdenesProduccion' */
IF UPDATE(OrdenID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM T_OrdenesProduccion, inserted WHERE (T_OrdenesProduccion.OrdenID = inserted.OrdenID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_OrdenesProduccion''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END
GO
PRINT N'Creando [dbo].[T_T_Perfil_ITrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_Perfil_ITrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Perfil_ITrig] ON [dbo].[T_Perfil] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Pantallas' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Pantallas, inserted WHERE (C_Pantallas.PantallaID = inserted.PantallaID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Pantallas''.', 44447, 1)
        ROLLBACK TRANSACTION
    END

/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Usuarios' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Usuarios, inserted WHERE (C_Usuarios.UsuarioID = inserted.UsuarioID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Usuarios''.', 44447, 1)
        ROLLBACK TRANSACTION
    END
GO
PRINT N'Creando [dbo].[T_T_Perfil_UTrig]...';


GO
/****** Objeto:  desencadenador dbo.T_T_Perfil_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Perfil_UTrig] ON [dbo].[T_Perfil] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Pantallas' */
IF UPDATE(PantallaID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Pantallas, inserted WHERE (C_Pantallas.PantallaID = inserted.PantallaID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Pantallas''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END

/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Usuarios' */
IF UPDATE(UsuarioID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Usuarios, inserted WHERE (C_Usuarios.UsuarioID = inserted.UsuarioID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Usuarios''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END
GO
PRINT N'Creando [dbo].[Cs_Etiquetas]...';


GO
CREATE VIEW [dbo].[Cs_Etiquetas]
AS
SELECT     dbo.T_Etiquetas.EtiquetaID, dbo.T_Etiquetas.BultoID, dbo.T_Etiquetas.EstiloID, dbo.T_Etiquetas.OperacionID, dbo.T_Etiquetas.Renglon, 
                      dbo.T_Etiquetas.PersonalID, dbo.T_Etiquetas.Hora, (CASE WHEN FechaPago IS NULL THEN Fecha ELSE FechaPago END) AS Fecha, 
                      dbo.T_Etiquetas.HojaID, dbo.T_Etiquetas.Escaneada, dbo.T_Etiquetas.Cancelada, dbo.T_Etiquetas.rowguid
FROM         dbo.T_Etiquetas LEFT OUTER JOIN
                      dbo.T_EtiqFecPag ON dbo.T_Etiquetas.EtiquetaID = dbo.T_EtiqFecPag.EtiquetaID
GO
PRINT N'Creando [dbo].[Cs_Proceso]...';


GO
CREATE VIEW [dbo].[Cs_Proceso]
AS
SELECT     dbo.T_Bultos.OrdenID, dbo.T_Bultos.BultoID, dbo.T_Bultos.Cantidad, MAX(dbo.T_Etiquetas.Renglon) AS Ren, dbo.T_Etiquetas.EstiloID
FROM         dbo.T_Etiquetas INNER JOIN
                      dbo.T_Bultos ON dbo.T_Etiquetas.BultoID = dbo.T_Bultos.BultoID
WHERE     (dbo.T_Etiquetas.Escaneada = 1)
GROUP BY dbo.T_Bultos.OrdenID, dbo.T_Bultos.BultoID, dbo.T_Bultos.Cantidad, dbo.T_Etiquetas.EstiloID
GO
PRINT N'Creando [dbo].[sp_etiqueta]...';


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_etiqueta]
(
	@NumEtiqueta	CHAR(18),
	@PersonalID		INTEGER,
	@Fecha			SMALLDATETIME,
	@Hora			DATETIME,
	@HojaID			INTEGER
)
AS
BEGIN

DECLARE 
		@Cancelada		BIT,
		@Escaneada		BIT
		

	IF EXISTS(SELECT EtiquetaID FROM T_Etiquetas where EtiquetaID = @NumEtiqueta)
		
		SET @Escaneada = 
		(
			SELECT ISNULL(Escaneada,0) AS Escaneada FROM T_Etiquetas where EtiquetaID = @NumEtiqueta
		)
		
		SET @Cancelada = 
		(
			SELECT ISNULL(Cancelada,0) AS Cancelada FROM T_Etiquetas where EtiquetaID = @NumEtiqueta
		)
		
		IF (ISNULL(@Escaneada,0) = 0 AND ISNULL(@Cancelada,0) = 0)
			BEGIN
				UPDATE T_Etiquetas SET Escaneada = 1, PersonalID = @PersonalID, Fecha = @Fecha, Hora = @Hora, HojaID =  @HojaID WHERE EtiquetaID = @NumEtiqueta
				
				
				SELECT dbo.T_Etiquetas.EtiquetaID AS Etiqueta, dbo.C_Operaciones.Descripción AS Operacion, dbo.C_Tallas.Largo + 'X' + dbo.C_Tallas.Ancho AS Talla,
                     dbo.T_Bultos.NoBulto , dbo.T_Bultos.Cantidad
                FROM dbo.T_Etiquetas 
                INNER JOIN dbo.T_Bultos ON dbo.T_Etiquetas.BultoID = dbo.T_Bultos.BultoID 
                INNER JOIN dbo.C_Tallas ON dbo.T_Bultos.TallaID = dbo.C_Tallas.TallaID 
                INNER JOIN dbo.C_Operaciones ON dbo.T_Etiquetas.OperacionID = dbo.C_Operaciones.OperacionID 
                WHERE (dbo.T_Etiquetas.HojaID = @HojaID) order by dbo.T_Etiquetas.EtiquetaID 
			END
			
		ELSE
			BEGIN 
				RAISERROR('Etiqueta invalida.', 16, 1)
			END

END
GO
PRINT N'Comprobando los datos existentes con las restricciones recién creadas';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[C_Articulos] WITH CHECK CHECK CONSTRAINT [FK_C_Articulos_C_Monedas];

ALTER TABLE [dbo].[C_Articulos] WITH CHECK CHECK CONSTRAINT [FK_T_Articulos_T_Lineas];

ALTER TABLE [dbo].[T_CostosMonedas] WITH CHECK CHECK CONSTRAINT [FK_T_CostosMonedas_C_Almacen];

ALTER TABLE [dbo].[T_CostosMonedas] WITH CHECK CHECK CONSTRAINT [FK_T_CostosMonedas_C_Monedas];

ALTER TABLE [dbo].[T_EstilosDet] WITH CHECK CHECK CONSTRAINT [FK_T_EstilosDet_T_Estilos];

ALTER TABLE [dbo].[T_EstilosHilosDet] WITH CHECK CHECK CONSTRAINT [FK_T_EstilosHilosDet_T_EstilosDet];

ALTER TABLE [dbo].[T_Inventario] WITH CHECK CHECK CONSTRAINT [FK_T_Inventario_T_Almacen];

ALTER TABLE [dbo].[T_Inventario] WITH CHECK CHECK CONSTRAINT [FK_T_Inventario_T_Articulos];

ALTER TABLE [dbo].[T_MovimientosAlm] WITH CHECK CHECK CONSTRAINT [FK_T_MovimientosAlm_T_Almacen];

ALTER TABLE [dbo].[T_MovimientosAlmacenDet] WITH CHECK CHECK CONSTRAINT [FK_T_MovimientosAlmacenDet_T_Articulos];

ALTER TABLE [dbo].[T_MovimientosAlmacenDet] WITH CHECK CHECK CONSTRAINT [FK_T_MovimientosAlmacenDet_T_MovimientosAlm];


GO
PRINT N'Actualización completada.';


GO
