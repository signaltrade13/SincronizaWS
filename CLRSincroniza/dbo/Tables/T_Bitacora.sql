CREATE TABLE [dbo].[T_Bitacora] (
    [BitacoraID]  NUMERIC (10)     NOT NULL,
    [UsuarioID]   INT              CONSTRAINT [DF__T_Bitacor__Usuar__300424B4] DEFAULT ((0)) NULL,
    [Fecha]       DATETIME         NULL,
    [Hora]        DATETIME         NULL,
    [Descripción] VARCHAR (100)    NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Bitacor__rowgu__7ECCBBD3] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [C_UsuariosT_Bitacora]
    ON [dbo].[T_Bitacora]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1506820430]
    ON [dbo].[T_Bitacora]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [UsuarioID]
    ON [dbo].[T_Bitacora]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_T_Bitacora_ITrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Bitacora_ITrig] ON [dbo].[T_Bitacora] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Usuarios' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Usuarios, inserted WHERE (C_Usuarios.UsuarioID = inserted.UsuarioID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Usuarios''.', 44447, 1)
        ROLLBACK TRANSACTION
    END







GO
/****** Objeto:  desencadenador dbo.T_T_Bitacora_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Bitacora_UTrig] ON [dbo].[T_Bitacora] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Usuarios' */
IF UPDATE(UsuarioID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Usuarios, inserted WHERE (C_Usuarios.UsuarioID = inserted.UsuarioID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Usuarios''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END






