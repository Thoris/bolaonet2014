IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesCriteriosPontos_UP')
BEGIN
	DROP  Procedure  sp_BoloesCriteriosPontos_UP
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesCriteriosPontos_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@CriterioID							int,
	@NomeBolao							varchar(30),
	@Descricao							varchar(255),
	@Pontos								int,
	--@NomeTime							varchar(30),
	--@MultiploTime						int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE BoloesCriteriosPontos SET		
		Pontos				= @Pontos,
		Descricao			= @Descricao,
		--NomeTime			= @NomeTime,
		--MultiploTime		= @MultiploTime,
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
			NomeBolao			= @NomeBolao
		AND CriterioID			= @CriterioID
		
			  	
	RETURN @@RowCount	
	
END



GO
