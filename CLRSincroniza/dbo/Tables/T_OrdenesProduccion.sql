CREATE TABLE [dbo].[T_OrdenesProduccion] (
    [OrdenID]     INT              NOT NULL,
    [NoOrden]     NVARCHAR (50)    NULL,
    [NoPo]        NVARCHAR (50)    NULL,
    [OV]          NVARCHAR (50)    NULL,
    [FechaAlta]   SMALLDATETIME    NULL,
    [EstiloID]    NUMERIC (10)     CONSTRAINT [DF__T_Ordenes__Estil__571DF1D5] DEFAULT ((0)) NULL,
    [FechaCierre] SMALLDATETIME    NULL,
    [FechaCancel] SMALLDATETIME    NULL,
    [Cancelado]   BIT              CONSTRAINT [DF__T_Ordenes__Cance__59063A47] DEFAULT ((0)) NOT NULL,
    [Motivo]      NVARCHAR (50)    NULL,
    [Planta]      VARCHAR (50)     NULL,
    [Tela]        VARCHAR (50)     NULL,
    [FechaCorte]  SMALLDATETIME    NULL,
    [Total]       INT              NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Ordenes__rowgu__735B0927] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [id_periodo]  INT              NULL,
    CONSTRAINT [aaaaaT_OrdenesProduccion_PK] PRIMARY KEY NONCLUSTERED ([OrdenID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_658817409]
    ON [dbo].[T_OrdenesProduccion]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [OrdenID]
    ON [dbo].[T_OrdenesProduccion]([OrdenID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [T_EstilosT_OrdenesProduccion]
    ON [dbo].[T_OrdenesProduccion]([EstiloID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE TRIGGER [dbo].[T_T_OrdenesProduccion_DTrig] ON [dbo].[T_OrdenesProduccion] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Bultos' */
DELETE T_Bultos FROM deleted, T_Bultos WHERE deleted.OrdenID = T_Bultos.OrdenID

/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_OrdenProduccionDet' */
DELETE T_OrdenProduccionDet FROM deleted, T_OrdenProduccionDet WHERE deleted.OrdenID = T_OrdenProduccionDet.OrdenID








GO
CREATE TRIGGER [T_T_OrdenesProduccion_ITrig] ON [dbo].[T_OrdenesProduccion] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_Estilos' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM T_Estilos, inserted WHERE (T_Estilos.EstiloID = inserted.EstiloID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_Estilos''.', 44447, 1)
        ROLLBACK TRANSACTION
    END








GO
CREATE TRIGGER [T_T_OrdenesProduccion_UTrig] ON [dbo].[T_OrdenesProduccion] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_Estilos' */
IF UPDATE(EstiloID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM T_Estilos, inserted WHERE (T_Estilos.EstiloID = inserted.EstiloID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_Estilos''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END

/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Bultos' */
IF UPDATE(OrdenID)
    BEGIN
       UPDATE T_Bultos
       SET T_Bultos.OrdenID = inserted.OrdenID
       FROM T_Bultos, deleted, inserted
       WHERE deleted.OrdenID = T_Bultos.OrdenID
    END

/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_OrdenProduccionDet' */
IF UPDATE(OrdenID)
    BEGIN
       UPDATE T_OrdenProduccionDet
       SET T_OrdenProduccionDet.OrdenID = inserted.OrdenID
       FROM T_OrdenProduccionDet, deleted, inserted
       WHERE deleted.OrdenID = T_OrdenProduccionDet.OrdenID
    END







