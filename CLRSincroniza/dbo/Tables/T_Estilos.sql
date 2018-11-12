CREATE TABLE [dbo].[T_Estilos] (
    [EstiloID]    NUMERIC (10)     NOT NULL,
    [Num]         NVARCHAR (30)    NULL,
    [Descripcion] NVARCHAR (60)    NULL,
    [FechaAlta]   DATETIME         NULL,
    [Inactivo]    BIT              CONSTRAINT [DF__T_Estilos__Cance__3D5E1FD2] DEFAULT ((0)) NOT NULL,
    [FechaBaja]   DATETIME         NULL,
    [Linea]       VARCHAR (50)     NULL,
    [Division]    VARCHAR (50)     NULL,
    [Cliente]     VARCHAR (50)     NULL,
    [Observacion] TEXT             CONSTRAINT [DF_T_Estilos_Observacion] DEFAULT ('') NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Estilos__rowgu__233F2673] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [num_metadia] INT              NULL,
    CONSTRAINT [aaaaaT_Estilos_PK] PRIMARY KEY NONCLUSTERED ([EstiloID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1847677630]
    ON [dbo].[T_Estilos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_T_Estilos_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Estilos_DTrig] ON [dbo].[T_Estilos] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_EstilosDet' */
DELETE T_EstilosDet FROM deleted, T_EstilosDet WHERE deleted.EstiloID = T_EstilosDet.EstiloID

/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_OrdenesProduccion' */
DELETE T_OrdenesProduccion FROM deleted, T_OrdenesProduccion WHERE deleted.EstiloID = T_OrdenesProduccion.EstiloID







GO
/****** Objeto:  desencadenador dbo.T_T_Estilos_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:02 a.m. ******/
CREATE TRIGGER [T_T_Estilos_UTrig] ON [dbo].[T_Estilos] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_EstilosDet' */
IF UPDATE(EstiloID)
    BEGIN
       UPDATE T_EstilosDet
       SET T_EstilosDet.EstiloID = inserted.EstiloID
       FROM T_EstilosDet, deleted, inserted
       WHERE deleted.EstiloID = T_EstilosDet.EstiloID
    END

/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_OrdenesProduccion' */
IF UPDATE(EstiloID)
    BEGIN
       UPDATE T_OrdenesProduccion
       SET T_OrdenesProduccion.EstiloID = inserted.EstiloID
       FROM T_OrdenesProduccion, deleted, inserted
       WHERE deleted.EstiloID = T_OrdenesProduccion.EstiloID
    END






