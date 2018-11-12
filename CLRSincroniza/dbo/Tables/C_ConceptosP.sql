CREATE TABLE [dbo].[C_ConceptosP] (
    [ConceptoPID] INT              NOT NULL,
    [Descripción] VARCHAR (50)     NULL,
    [Tipo]        BIT              NULL,
    [Monto]       MONEY            NULL,
    [Formula]     VARCHAR (50)     NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Concept__rowgu__5C77A3CF] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_C_ConceptosP] PRIMARY KEY CLUSTERED ([ConceptoPID] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [IX_C_ConceptosP] UNIQUE NONCLUSTERED ([Descripción] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_80719340]
    ON [dbo].[C_ConceptosP]([rowguid] ASC) WITH (FILLFACTOR = 90);

