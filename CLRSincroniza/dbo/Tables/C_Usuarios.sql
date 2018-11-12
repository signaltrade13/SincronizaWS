CREATE TABLE [dbo].[C_Usuarios] (
    [UsuarioID]  INT              NOT NULL,
    [Usuario]    NVARCHAR (50)    NULL,
    [Contraseña] NVARCHAR (50)    NULL,
    [Nombre]     NVARCHAR (50)    NULL,
    [Activo]     BIT              NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__C_Usuario__rowgu__28F7FFC9] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Usuarios_PK] PRIMARY KEY NONCLUSTERED ([UsuarioID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [Clave]
    ON [dbo].[C_Usuarios]([Usuario] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1831677573]
    ON [dbo].[C_Usuarios]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [UsuarioID]
    ON [dbo].[C_Usuarios]([UsuarioID] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_C_Usuarios_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_C_Usuarios_DTrig] ON [dbo].[C_Usuarios] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Bitacora' */
DELETE T_Bitacora FROM deleted, T_Bitacora WHERE deleted.UsuarioID = T_Bitacora.UsuarioID

/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Perfil' */
DELETE T_Perfil FROM deleted, T_Perfil WHERE deleted.UsuarioID = T_Perfil.UsuarioID







GO
/****** Objeto:  desencadenador dbo.T_C_Usuarios_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_C_Usuarios_UTrig] ON [dbo].[C_Usuarios] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Bitacora' */
IF UPDATE(UsuarioID)
    BEGIN
       UPDATE T_Bitacora
       SET T_Bitacora.UsuarioID = inserted.UsuarioID
       FROM T_Bitacora, deleted, inserted
       WHERE deleted.UsuarioID = T_Bitacora.UsuarioID
    END

/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Perfil' */
IF UPDATE(UsuarioID)
    BEGIN
       UPDATE T_Perfil
       SET T_Perfil.UsuarioID = inserted.UsuarioID
       FROM T_Perfil, deleted, inserted
       WHERE deleted.UsuarioID = T_Perfil.UsuarioID
    END






