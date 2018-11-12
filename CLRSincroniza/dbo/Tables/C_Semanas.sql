CREATE TABLE [dbo].[C_Semanas] (
    [SemanaID]    INT      NOT NULL,
    [FechaInicio] DATETIME NULL,
    [FechaFinal]  DATETIME NULL,
    CONSTRAINT [PK_C_Semanas] PRIMARY KEY CLUSTERED ([SemanaID] ASC)
);

