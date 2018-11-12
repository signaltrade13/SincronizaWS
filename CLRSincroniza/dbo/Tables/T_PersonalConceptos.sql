CREATE TABLE [dbo].[T_PersonalConceptos] (
    [PersonalConID] NUMERIC (18)     IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [ConceptoPID]   INT              NULL,
    [PersonalID]    INT              NULL,
    [Importe]       MONEY            NULL,
    [Cantidad]      INT              NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__T_Persona__rowgu__4376EBDB] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_PersonalConceptos] PRIMARY KEY NONCLUSTERED ([rowguid] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE CLUSTERED INDEX [index_144719568]
    ON [dbo].[T_PersonalConceptos]([rowguid] ASC) WITH (FILLFACTOR = 90);

