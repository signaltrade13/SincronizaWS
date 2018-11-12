CREATE TABLE [dbo].[T_NominaDet] (
    [NominaID]    NUMERIC (18)     NOT NULL,
    [Renglon]     NUMERIC (18)     NOT NULL,
    [PersonalID]  INT              NOT NULL,
    [ConceptoPID] INT              NOT NULL,
    [Importe]     MONEY            NULL,
    [Cantidad]    MONEY            NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_NominaD__rowgu__54A177DD] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_NominaDet] PRIMARY KEY CLUSTERED ([NominaID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_418816554]
    ON [dbo].[T_NominaDet]([rowguid] ASC) WITH (FILLFACTOR = 90);

