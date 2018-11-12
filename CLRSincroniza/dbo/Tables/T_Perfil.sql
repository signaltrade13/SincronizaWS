CREATE TABLE [dbo].[T_Perfil] (
    [PerfilID]   INT              IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [UsuarioID]  INT              CONSTRAINT [DF__T_Perfil__Usuari__29572725] DEFAULT ((0)) NULL,
    [PantallaID] INT              CONSTRAINT [DF__T_Perfil__Pantal__2A4B4B5E] DEFAULT ((0)) NULL,
    [Alta]       BIT              NULL,
    [Baja]       BIT              NULL,
    [Cambio]     BIT              NULL,
    [Consulta]   BIT              NULL,
    [Depurar]    BIT              NULL,
    [Firma]      BIT              NULL,
    [Imprimir]   BIT              NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__T_Perfil__rowgui__15B0212B] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaT_Perfil_PK] PRIMARY KEY NONCLUSTERED ([PerfilID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [C_PantallasT_Perfil]
    ON [dbo].[T_Perfil]([PantallaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [C_UsuariosT_Perfil]
    ON [dbo].[T_Perfil]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1991678143]
    ON [dbo].[T_Perfil]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [PantallaID]
    ON [dbo].[T_Perfil]([PantallaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [PerfilID]
    ON [dbo].[T_Perfil]([PerfilID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [UsuarioID]
    ON [dbo].[T_Perfil]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_T_Perfil_ITrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Perfil_ITrig] ON [dbo].[T_Perfil] FOR INSERT AS
SET NOCOUNT ON
/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Pantallas' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Pantallas, inserted WHERE (C_Pantallas.PantallaID = inserted.PantallaID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Pantallas''.', 44447, 1)
        ROLLBACK TRANSACTION
    END

/* * IMPEDIR INSERCIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Usuarios' */
IF (SELECT COUNT(*) FROM inserted) !=
   (SELECT COUNT(*) FROM C_Usuarios, inserted WHERE (C_Usuarios.UsuarioID = inserted.UsuarioID))
    BEGIN
        RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Usuarios''.', 44447, 1)
        ROLLBACK TRANSACTION
    END








GO
/****** Objeto:  desencadenador dbo.T_T_Perfil_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Perfil_UTrig] ON [dbo].[T_Perfil] FOR UPDATE AS
SET NOCOUNT ON
/* * IMPEDIR ACTUALIZACIONES SI NO HAY NINGUNA CLAVE COINCIDENTE EN 'C_Pantallas' */
IF UPDATE(PantallaID)
    BEGIN
        IF (SELECT COUNT(*) FROM inserted) !=
           (SELECT COUNT(*) FROM C_Pantallas, inserted WHERE (C_Pantallas.PantallaID = inserted.PantallaID))
            BEGIN
                RAISERROR ('No puede agregarse ni modificarse el registro. Las reglas de integridad referencial requieren un registro relacionado en la tabla ''C_Pantallas''.', 44446, 1)
                ROLLBACK TRANSACTION
            END
    END

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







