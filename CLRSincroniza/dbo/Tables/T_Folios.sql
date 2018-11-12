CREATE TABLE [dbo].[T_Folios] (
    [Folio]   NUMERIC (18)     NULL,
    [Tipo]    CHAR (1)         NOT NULL,
    [rowguid] UNIQUEIDENTIFIER CONSTRAINT [DF__T_Folios__rowgui__17CD73C7] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Folios] PRIMARY KEY CLUSTERED ([Tipo] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_454292678]
    ON [dbo].[T_Folios]([rowguid] ASC) WITH (FILLFACTOR = 90);

