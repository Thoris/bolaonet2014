IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesCriteriosPontosTimes_UP')
BEGIN
	DROP  Procedure  sp_BoloesCriteriosPontosTimes_UP
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesCriteriosPontosTimes_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeTime							varchar(30),
	@NomeBolao							varchar(30),
	@Multiplo							int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE BoloesCriteriosPontosTimes SET		
		Multiplo			= @Multiplo,
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
			NomeBolao			= @NomeBolao
		AND NomeTime			= @NomeTime
		
			  	
	RETURN @@RowCount	
	
END



GO
