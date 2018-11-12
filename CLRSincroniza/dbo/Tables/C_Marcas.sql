﻿CREATE TABLE [dbo].[C_Marcas] (
    [MARCAID] VARCHAR (12)     NOT NULL,
    [MARCA]   VARCHAR (50)     NULL,
    [rowguid] UNIQUEIDENTIFIER CONSTRAINT [DF__C_Marcas__rowgui__66DCC054] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED ([MARCAID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1230197170]
    ON [dbo].[C_Marcas]([rowguid] ASC) WITH (FILLFACTOR = 90);
