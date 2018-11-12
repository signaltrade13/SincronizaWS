-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_etiqueta]
(
	@NumEtiqueta	CHAR(18),
	@PersonalID		INTEGER,
	@Fecha			SMALLDATETIME,
	@Hora			DATETIME,
	@HojaID			INTEGER
)
AS
BEGIN

DECLARE 
		@Cancelada		BIT,
		@Escaneada		BIT
		

	IF EXISTS(SELECT EtiquetaID FROM T_Etiquetas where EtiquetaID = @NumEtiqueta)
		
		SET @Escaneada = 
		(
			SELECT ISNULL(Escaneada,0) AS Escaneada FROM T_Etiquetas where EtiquetaID = @NumEtiqueta
		)
		
		SET @Cancelada = 
		(
			SELECT ISNULL(Cancelada,0) AS Cancelada FROM T_Etiquetas where EtiquetaID = @NumEtiqueta
		)
		
		IF (ISNULL(@Escaneada,0) = 0 AND ISNULL(@Cancelada,0) = 0)
			BEGIN
				UPDATE T_Etiquetas SET Escaneada = 1, PersonalID = @PersonalID, Fecha = @Fecha, Hora = @Hora, HojaID =  @HojaID WHERE EtiquetaID = @NumEtiqueta
				
				
				SELECT dbo.T_Etiquetas.EtiquetaID AS Etiqueta, dbo.C_Operaciones.Descripción AS Operacion, dbo.C_Tallas.Largo + 'X' + dbo.C_Tallas.Ancho AS Talla,
                     dbo.T_Bultos.NoBulto , dbo.T_Bultos.Cantidad
                FROM dbo.T_Etiquetas 
                INNER JOIN dbo.T_Bultos ON dbo.T_Etiquetas.BultoID = dbo.T_Bultos.BultoID 
                INNER JOIN dbo.C_Tallas ON dbo.T_Bultos.TallaID = dbo.C_Tallas.TallaID 
                INNER JOIN dbo.C_Operaciones ON dbo.T_Etiquetas.OperacionID = dbo.C_Operaciones.OperacionID 
                WHERE (dbo.T_Etiquetas.HojaID = @HojaID) order by dbo.T_Etiquetas.EtiquetaID 
			END
			
		ELSE
			BEGIN 
				RAISERROR('Etiqueta invalida.', 16, 1)
			END

END
	



