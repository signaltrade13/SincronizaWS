CREATE TABLE [dbo].[Tmp_reporte] (
    [TipoID]  NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Campo]   VARCHAR (50)     NULL,
    [rowguid] UNIQUEIDENTIFIER CONSTRAINT [DF__Tmp_repor__rowgu__597C06EA] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1298819689]
    ON [dbo].[Tmp_reporte]([rowguid] ASC) WITH (FILLFACTOR = 90);

