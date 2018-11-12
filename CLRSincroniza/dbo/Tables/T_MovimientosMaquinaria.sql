CREATE TABLE [dbo].[T_MovimientosMaquinaria] (
    [MovimientoID]  INT              NOT NULL,
    [MaquinariaID]  INT              CONSTRAINT [DF__T_Movimie__Maqui__4F7CD00D] DEFAULT ((0)) NULL,
    [ConceptoID]    INT              CONSTRAINT [DF__T_Movimie__Conce__5070F446] DEFAULT ((0)) NULL,
    [Fecha]         DATETIME         NULL,
    [Origen]        INT              NULL,
    [Destino]       INT              NULL,
    [Entrega]       NVARCHAR (50)    NULL,
    [Recibe]        NVARCHAR (50)    NULL,
    [Autoriza]      NVARCHAR (50)    NULL,
    [Transportista] NVARCHAR (50)    NULL,
    [Observaciones] NVARCHAR (50)    NULL,
    [Cancelado]     BIT              CONSTRAINT [DF__T_Movimie__Cance__5165187F] DEFAULT ((0)) NOT NULL,
    [FechaCancel]   SMALLDATETIME    NULL,
    [Motivo]        NVARCHAR (50)    NULL,
    [rowguid]       UNIQUEIDENTIFIER CONSTRAINT [DF__T_Movimie__rowgu__5A5A5133] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaT_MovimientosMaquinaria_PK] PRIMARY KEY NONCLUSTERED ([MovimientoID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [C_ConceptosT_MovimientosMaquinaria]
    ON [dbo].[T_MovimientosMaquinaria]([ConceptoID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [C_MaquinariaT_MovimientosMaquinaria]
    ON [dbo].[T_MovimientosMaquinaria]([MaquinariaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [ConceptoID]
    ON [dbo].[T_MovimientosMaquinaria]([ConceptoID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_2087678485]
    ON [dbo].[T_MovimientosMaquinaria]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [MaquinariaID]
    ON [dbo].[T_MovimientosMaquinaria]([MaquinariaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [MovimientoID]
    ON [dbo].[T_MovimientosMaquinaria]([MovimientoID] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_T_MovimientosMaquinaria_ITrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_MovimientosMaquinaria_ITrig] ON [dbo].[T_MovimientosMaquinaria] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Conceptos' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Conceptos, inserted WHERE (C_Conceptos.ConceptoID = inserted.ConceptoID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Conceptos''.', 44447, 1)
        ROLLBACK TRANSACTION
    END

/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Maquinaria' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Maquinaria, inserted WHERE (C_Maquinaria.MaquinariaID = inserted.MaquinariaID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Maquinaria''.', 44447, 1)
        ROLLBACK TRANSACTION
    END






GO
/****** Objeto:  desencadenador dbo.T_T_MovimientosMaquinaria_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_MovimientosMaquinaria_UTrig] ON [dbo].[T_MovimientosMaquinaria] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Conceptos' */
IF UPDATE(ConceptoID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Conceptos, inserted WHERE (C_Conceptos.ConceptoID = inserted.ConceptoID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Conceptos''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END

/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Maquinaria' */
IF UPDATE(MaquinariaID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Maquinaria, inserted WHERE (C_Maquinaria.MaquinariaID = inserted.MaquinariaID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Maquinaria''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END





