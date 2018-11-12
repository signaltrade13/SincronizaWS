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
    [rowguid]        UNIQUEIDENTIFIER CONSTRAINT [DF__C_Empresa__rowgu__56BECA79] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_Empresas] PRIMARY KEY CLUSTERED ([EmpresaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1719677174]
    ON [dbo].[C_Empresas]([rowguid] ASC) WITH (FILLFACTOR = 90);

