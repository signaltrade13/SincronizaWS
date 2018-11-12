CREATE TABLE [dbo].[T_OrdenProduccionDet] (
    [OrdenID]       INT              CONSTRAINT [DF__T_OrdenPr__Orden__5DCAEF64] DEFAULT ((0)) NOT NULL,
    [Renglon]       INT              CONSTRAINT [DF__T_OrdenPr__Rengl__5EBF139D] DEFAULT ((0)) NOT NULL,
    [TallaID]       NUMERIC (18)     NULL,
    [NoBultos]      INT              CONSTRAINT [DF__T_OrdenPr__NoBul__5FB337D6] DEFAULT ((0)) NULL,
    [NPiezasXBulto] INT              CONSTRAINT [DF__T_OrdenPr__NPiez__60A75C0F] DEFAULT ((0)) NULL,
    [Serie]         VARCHAR (3)      NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__T_OrdenPr__rowgu__492FC531] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaT_OrdenProduccionDet_PK] PRIMARY KEY NONCLUSTERED ([OrdenID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_226815870]
    ON [dbo].[T_OrdenProduccionDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [OrdenID]
    ON [dbo].[T_OrdenProduccionDet]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [T_OrdenesProduccionT_OrdenProduccionDet]
    ON [dbo].[T_OrdenProduccionDet]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE TRIGGER [T_T_OrdenProduccionDet_ITrig] ON [dbo].[T_OrdenProduccionDet] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_OrdenesProduccion' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM T_OrdenesProduccion, inserted WHERE (T_OrdenesProduccion.OrdenID = inserted.OrdenID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_OrdenesProduccion''.', 44447, 1)
        ROLLBACK TRANSACTION
    END








GO
CREATE TRIGGER [T_T_OrdenProduccionDet_UTrig] ON [dbo].[T_OrdenProduccionDet] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_OrdenesProduccion' */
IF UPDATE(OrdenID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM T_OrdenesProduccion, inserted WHERE (T_OrdenesProduccion.OrdenID = inserted.OrdenID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_OrdenesProduccion''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END







