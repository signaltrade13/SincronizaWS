CREATE TABLE [dbo].[T_Bultos] (
    [BultoID]  NUMERIC (10)     NOT NULL,
    [NoBulto]  NUMERIC (18)     NULL,
    [Serie]    VARCHAR (5)      NULL,
    [OrdenID]  INT              CONSTRAINT [DF__T_Bultos__OrdenI__35BCFE0A] DEFAULT ((0)) NOT NULL,
    [Cantidad] INT              CONSTRAINT [DF__T_Bultos__Cantid__36B12243] DEFAULT ((0)) NULL,
    [FechaEnt] DATETIME         NULL,
    [TallaID]  NUMERIC (18)     NULL,
    [rowguid]  UNIQUEIDENTIFIER CONSTRAINT [DF__T_Bultos__rowgui__26DAAD2D] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Bultos] PRIMARY KEY CLUSTERED ([BultoID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [BultoID]
    ON [dbo].[T_Bultos]([BultoID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_562817067]
    ON [dbo].[T_Bultos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [OrdenID]
    ON [dbo].[T_Bultos]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [T_OrdenesProduccionT_Bultos]
    ON [dbo].[T_Bultos]([OrdenID] ASC) WITH (FILLFACTOR = 90);

