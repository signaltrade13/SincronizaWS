CREATE TABLE [dbo].[C_Pantallas] (
    [PantallaID]  INT              IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [Descripción] NVARCHAR (50)    NULL,
    [Indice]      INT              NULL,
    [Menu]        CHAR (1)         NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__C_Pantall__rowgu__45943E77] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Pantallas_PK] PRIMARY KEY NONCLUSTERED ([PantallaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1767677345]
    ON [dbo].[C_Pantallas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [ModuloID]
    ON [dbo].[C_Pantallas]([PantallaID] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_C_Pantallas_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_C_Pantallas_DTrig] ON [dbo].[C_Pantallas] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_Perfil' */
DELETE T_Perfil FROM deleted, T_Perfil WHERE deleted.PantallaID = T_Perfil.PantallaID








GO
/****** Objeto:  desencadenador dbo.T_C_Pantallas_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_C_Pantallas_UTrig] ON [dbo].[C_Pantallas] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_Perfil' */
IF UPDATE(PantallaID)
    BEGIN
       UPDATE T_Perfil
       SET T_Perfil.PantallaID = inserted.PantallaID
       FROM T_Perfil, deleted, inserted
       WHERE deleted.PantallaID = T_Perfil.PantallaID
    END







