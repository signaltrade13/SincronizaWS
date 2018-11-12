CREATE VIEW [dbo].[Cs_Etiquetas]
AS
SELECT     dbo.T_Etiquetas.EtiquetaID, dbo.T_Etiquetas.BultoID, dbo.T_Etiquetas.EstiloID, dbo.T_Etiquetas.OperacionID, dbo.T_Etiquetas.Renglon, 
                      dbo.T_Etiquetas.PersonalID, dbo.T_Etiquetas.Hora, (CASE WHEN FechaPago IS NULL THEN Fecha ELSE FechaPago END) AS Fecha, 
                      dbo.T_Etiquetas.HojaID, dbo.T_Etiquetas.Escaneada, dbo.T_Etiquetas.Cancelada, dbo.T_Etiquetas.rowguid
FROM         dbo.T_Etiquetas LEFT OUTER JOIN
                      dbo.T_EtiqFecPag ON dbo.T_Etiquetas.EtiquetaID = dbo.T_EtiqFecPag.EtiquetaID





