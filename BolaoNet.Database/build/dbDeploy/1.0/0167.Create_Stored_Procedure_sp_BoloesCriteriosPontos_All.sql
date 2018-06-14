IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesCriteriosPontos_All')
BEGIN
	DROP  Procedure  sp_BoloesCriteriosPontos_All
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesCriteriosPontos_All]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@Condition							varchar(4000),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @Execute		varchar(5000)

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	
	SET @Execute = 
		'SELECT * 
		   FROM BoloesCriteriosPontos
		  WHERE NomeBolao = ''' + @NomeBolao + '''
		  ORDER BY CriterioID'
		
		--SET @Execute = @Execute + ' WHERE ' + @Condition

	--SET @Execute = @Execute + ' ORDER BY BoloesRequests.RequestedDate'

	
	EXEC (@Execute)


	RETURN 0

END




GO
