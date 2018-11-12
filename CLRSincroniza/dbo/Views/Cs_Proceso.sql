CREATE VIEW [dbo].[Cs_Proceso]
AS
SELECT     dbo.T_Bultos.OrdenID, dbo.T_Bultos.BultoID, dbo.T_Bultos.Cantidad, MAX(dbo.T_Etiquetas.Renglon) AS Ren, dbo.T_Etiquetas.EstiloID
FROM         dbo.T_Etiquetas INNER JOIN
                      dbo.T_Bultos ON dbo.T_Etiquetas.BultoID = dbo.T_Bultos.BultoID
WHERE     (dbo.T_Etiquetas.Escaneada = 1)
GROUP BY dbo.T_Bultos.OrdenID, dbo.T_Bultos.BultoID, dbo.T_Bultos.Cantidad, dbo.T_Etiquetas.EstiloID







