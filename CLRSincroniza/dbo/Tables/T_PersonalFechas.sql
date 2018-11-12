CREATE TABLE [dbo].[T_PersonalFechas] (
    [PersonalID] INT              NOT NULL,
    [Fecha]      SMALLDATETIME    NULL,
    [Tipo]       SMALLINT         NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__T_Persona__rowgu__2B8B1F08] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1150015228]
    ON [dbo].[T_PersonalFechas]([rowguid] ASC) WITH (FILLFACTOR = 90);

