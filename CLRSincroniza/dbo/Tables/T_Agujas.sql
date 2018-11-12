CREATE TABLE [dbo].[T_Agujas] (
    [Folio]         NUMERIC (18)     NOT NULL,
    [MaquinariaID]  INT              NOT NULL,
    [MarcaID]       NUMERIC (18)     NULL,
    [ModeloID]      NUMERIC (18)     NULL,
    [GrosorID]      NUMERIC (18)     NULL,
    [PuntaID]       NUMERIC (18)     NULL,
    [Motivo]        TEXT             NULL,
    [Fecha]         SMALLDATETIME    NULL,
    [Observaciones] TEXT             NULL,
    [Tipo]          SMALLINT         NULL,
    [cancelado]     BIT              NULL,
    [FechaCancel]   SMALLDATETIME    NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__T_Agujas__rowgui__49CFAF06] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_Agujas] PRIMARY KEY CLUSTERED ([Folio] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1600776810]
    ON [dbo].[T_Agujas]([rowguid] ASC) WITH (FILLFACTOR = 90);

