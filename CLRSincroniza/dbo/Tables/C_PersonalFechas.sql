CREATE TABLE [dbo].[C_PersonalFechas] (
    [PersonalID] INT              NOT NULL,
    [Tipo]       SMALLINT         NULL,
    [Fecha]      SMALLDATETIME    NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__C_Persona__rowgu__5CED7072] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1166015285]
    ON [dbo].[C_PersonalFechas]([rowguid] ASC) WITH (FILLFACTOR = 90);

