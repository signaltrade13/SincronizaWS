CREATE TABLE [dbo].[T_HojasControl] (
    [HojaID]     NUMERIC (18)     NOT NULL,
    [PersonalID] INT              NOT NULL,
    [Fecha]      SMALLDATETIME    NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__T_HojasCo__rowgu__1B68FA81] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_HojasControl] PRIMARY KEY CLUSTERED ([HojaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_470292735]
    ON [dbo].[T_HojasControl]([rowguid] ASC) WITH (FILLFACTOR = 90);

