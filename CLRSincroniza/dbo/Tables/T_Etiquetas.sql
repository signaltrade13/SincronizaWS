CREATE TABLE [dbo].[T_Etiquetas] (
    [EtiquetaID]  NUMERIC (18)     NOT NULL,
    [BultoID]     NUMERIC (10)     CONSTRAINT [DF__T_Etiquet__Bulto__47DBAE45] DEFAULT ((0)) NOT NULL,
    [OperacionID] INT              CONSTRAINT [DF__T_Etiquet__Opera__49C3F6B7] DEFAULT ((0)) NOT NULL,
    [EstiloID]    INT              CONSTRAINT [DF_T_Etiquetas_EstiloID] DEFAULT ((0)) NULL,
    [Renglon]     INT              NULL,
    [PersonalID]  INT              CONSTRAINT [DF__T_Etiquet__Perso__4AB81AF0] DEFAULT ((0)) NULL,
    [Fecha]       SMALLDATETIME    NULL,
    [Hora]        DATETIME         NULL,
    [HojaID]      NUMERIC (18)     NULL,
    [Escaneada]   BIT              NULL,
    [Cancelada]   BIT              NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Etiquet__rowgu__1D864D1D] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [aaaaaT_Etiquetas_PK] PRIMARY KEY NONCLUSTERED ([EtiquetaID] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE NONCLUSTERED INDEX [BultoID]
    ON [dbo].[T_Etiquetas]([BultoID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [C_OperacionesT_Etiquetas]
    ON [dbo].[T_Etiquetas]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [C_PersonalT_Etiquetas]
    ON [dbo].[T_Etiquetas]([PersonalID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [HojaID]
    ON [dbo].[T_Etiquetas]([HojaID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_1170819233]
    ON [dbo].[T_Etiquetas]([rowguid] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [OperacionID]
    ON [dbo].[T_Etiquetas]([OperacionID] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [PersonalID]
    ON [dbo].[T_Etiquetas]([PersonalID] ASC) WITH (FILLFACTOR = 90);

