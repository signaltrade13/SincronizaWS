CREATE TABLE [dbo].[T_PersonalFaltas] (
    [PersonalID] INT              NOT NULL,
    [Tipo]       CHAR (1)         NOT NULL,
    [Fecha]      SMALLDATETIME    NOT NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__T_Persona__rowgu__7559F6E0] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_928826471]
    ON [dbo].[T_PersonalFaltas]([rowguid] ASC) WITH (FILLFACTOR = 90);

