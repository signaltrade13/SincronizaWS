CREATE TABLE [dbo].[C_Conceptos] (
    [ConceptoID] INT              NOT NULL,
    [Tipo]       NVARCHAR (1)     NULL,
    [Concepto]   NVARCHAR (50)    NULL,
    [rowguid]    UNIQUEIDENTIFIER CONSTRAINT [DF__C_Concept__rowgu__62307D25] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaC_Conceptos_PK] PRIMARY KEY NONCLUSTERED ([ConceptoID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [ConceptoID]
    ON [dbo].[C_Conceptos]([ConceptoID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1687677060]
    ON [dbo].[C_Conceptos]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
/****** Objeto:  desencadenador dbo.T_C_Conceptos_DTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:01 a.m. ******/
CREATE TRIGGER [T_C_Conceptos_DTrig] ON [dbo].[C_Conceptos] FOR DELETE AS
SET NOCOUNT ON
/* * EXTENDER ELIMINACIONES EN CASCADA A 'T_MovimientosMaquinaria' */
DELETE T_MovimientosMaquinaria FROM deleted, T_MovimientosMaquinaria WHERE deleted.ConceptoID = T_MovimientosMaquinaria.ConceptoID







GO
/****** Objeto:  desencadenador dbo.T_C_Conceptos_UTrig  fecha de la secuencia de comandos: 20/05/2005 01:07:01 a.m. ******/
CREATE TRIGGER [T_C_Conceptos_UTrig] ON [dbo].[C_Conceptos] FOR UPDATE AS
SET NOCOUNT ON
/* * EXTENDER ACTUALIZACIONES EN CASCADA A 'T_MovimientosMaquinaria' */
IF UPDATE(ConceptoID)
    BEGIN
       UPDATE T_MovimientosMaquinaria
       SET T_MovimientosMaquinaria.ConceptoID = inserted.ConceptoID
       FROM T_MovimientosMaquinaria, deleted, inserted
       WHERE deleted.ConceptoID = T_MovimientosMaquinaria.ConceptoID
    END






