CREATE TABLE [dbo].[T_BalanceoOpDet] (
    [BalanceoID]  NUMERIC (18)     NOT NULL,
    [OperacionID] INT              CONSTRAINT [DF_T_BalanceoOpDet_OperacionID] DEFAULT ((0)) NOT NULL,
    [Renglon]     INT              NOT NULL,
    [std]         REAL             NULL,
    [stda]        REAL             NULL,
    [prodh]       REAL             NULL,
    [prodt]       REAL             NULL,
    [tiempon]     REAL             NULL,
    [operariost]  REAL             NULL,
    [operariorr]  INT              NULL,
    [mintd]       REAL             NULL,
    [desocu]      REAL             NULL,
    [maquinas]    INT              NULL,
    [Manuales]    INT              NULL,
    [asistente]   INT              NULL,
    [bultero]     INT              NULL,
    [sup]         INT              NULL,
    [rowguid]     UNIQUEIDENTIFIER CONSTRAINT [DF__T_Balance__rowgu__60132A89] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [PK_T_BalanceoOpDet] PRIMARY KEY CLUSTERED ([BalanceoID] ASC, [OperacionID] ASC, [Renglon] ASC) WITH (FILLFACTOR = 90)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_390292450]
    ON [dbo].[T_BalanceoOpDet]([rowguid] ASC) WITH (FILLFACTOR = 90);

