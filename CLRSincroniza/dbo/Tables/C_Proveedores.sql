CREATE TABLE [dbo].[C_Proveedores] (
    [ProveedorID] NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Descripción] VARCHAR (100)    NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Proveed__rowgu__1685152A] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_Proveedores] PRIMARY KEY CLUSTERED ([ProveedorID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_157295670]
    ON [dbo].[C_Proveedores]([rowguid] ASC) WITH (FILLFACTOR = 90);

