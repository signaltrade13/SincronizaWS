CREATE TABLE [dbo].[C_EmpresaP] (
    [EmpresaID] INT              NOT NULL,
    [Dias]      INT              NULL,
    [PorMax]    INT              NULL,
    [rowguid]   UNIQUEIDENTIFIER CONSTRAINT [DF__C_Empresa__rowgu__67D0E48D] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1693743074]
    ON [dbo].[C_EmpresaP]([rowguid] ASC) WITH (FILLFACTOR = 90);

