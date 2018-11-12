CREATE TABLE [dbo].[C_Puestos] (
    [PuestoID] NUMERIC (18)     NOT NULL,
    [Puesto]   VARCHAR (50)     NULL,
    [rowguid]  UNIQUEIDENTIFIER CONSTRAINT [DF__C_Puestos__rowgu__186E28F3] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_912826414]
    ON [dbo].[C_Puestos]([rowguid] ASC) WITH (FILLFACTOR = 90);

