CREATE TABLE [dbo].[T_EstilosDet] (
    [EstiloID]    NUMERIC (10)     CONSTRAINT [DF__T_Estilos__Estil__4222D4EF] DEFAULT ((0)) NOT NULL,
    [Renglon]     INT              NOT NULL,
    [OperacionID] INT              CONSTRAINT [DF__T_Estilos__Opera__4316F928] DEFAULT ((0)) NOT NULL,
    [Orden]       SMALLINT         NULL,
    [Act]         BIT              NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Estilos__rowgu__7913E27D] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [OrdenRpt]    INT              NULL,
    [Lado]        CHAR (25)        NULL,
    [Etapa]       CHAR (25)        NULL,
    CONSTRAINT [aaaaaT_EstilosDet_PK] PRIMARY KEY CLUSTERED ([EstiloID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_T_EstilosDet_T_Estilos] FOREIGN KEY ([EstiloID]) REFERENCES [dbo].[T_Estilos] ([EstiloID]) ON DELETE CASCADE ON UPDATE CASCADE NOT FOR REPLICATION
);


GO
CREATE NONCLUSTERED INDEX [C_OperacionesT_EstilosDet]
    ON [dbo].[T_EstilosDet]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1959678029]
    ON [dbo].[T_EstilosDet]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [OperacionID]
    ON [dbo].[T_EstilosDet]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_T_EstilosDet_ITrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_EstilosDet_ITrig] ON [dbo].[T_EstilosDet] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Operaciones' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Operaciones, inserted WHERE (C_Operaciones.OperacionID = inserted.OperacionID))
    BEGIN
        RAISERROR  ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Operaciones''.', 44447, 1)
        ROLLBACK TRANSACTION
    END

/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'T_Estilos' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM T_Estilos, inserted WHERE (T_Estilos.EstiloID = inserted.EstiloID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''T_Estilos''.', 44447, 1)
        ROLLBACK TRANSACTION
    END






GO
/****** Objeto:  desencadenador dbo.T_T_EstilosDet_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_EstilosDet_UTrig] ON [dbo].[T_EstilosDet] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Operaciones' */
IF UPDATE(OperacionID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Operaciones, inserted WHERE (C_Operaciones.OperacionID = inserted.OperacionID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Operaciones''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END

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





