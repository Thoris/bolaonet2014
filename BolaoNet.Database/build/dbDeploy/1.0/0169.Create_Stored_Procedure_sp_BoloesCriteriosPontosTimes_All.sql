IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesCriteriosPontosTimes_All')
BEGIN
	DROP  Procedure  sp_BoloesCriteriosPontosTimes_All
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesCriteriosPontosTimes_All]
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
		   FROM BoloesCriteriosPontosTimes
		  WHERE NomeBolao = ''' + @NomeBolao + '''
		  ORDER BY NomeTime'
		
		--SET @Execute = @Execute + ' WHERE ' + @Condition

	--SET @Execute = @Execute + ' ORDER BY BoloesRequests.RequestedDate'

	
	EXEC (@Execute)


	RETURN 0

END




GO
