CREATE TABLE [dbo].[C_Bihorarios] (
    [BihorarioID]    INT        NOT NULL,
    [HoraInicio]     DATETIME   NULL,
    [HoraFin]        DATETIME   NULL,
    [CantHrsLab]     FLOAT (53) NULL,
    [HoraIniReal]    DATETIME   NULL,
    [HoraFinReal]    DATETIME   NULL,
    [HoraIniRealAnt] DATETIME   NULL,
    [HoraFinRealAnt] DATETIME   NULL,
    CONSTRAINT [PK_C_Bihorarios] PRIMARY KEY CLUSTERED ([BihorarioID] ASC)
);

