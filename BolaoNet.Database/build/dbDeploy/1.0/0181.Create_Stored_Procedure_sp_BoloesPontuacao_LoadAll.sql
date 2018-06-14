IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesPontuacao_LoadAll')
BEGIN
	DROP  Procedure  sp_BoloesPontuacao_LoadAll
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesPontuacao_LoadAll]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @Execute		varchar(5000);

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	SELECT * 
	  FROM BoloesPontuacao
	 WHERE NomeBolao			= @NomeBolao
     ORDER BY Pontos   


	RETURN @@RowCount

END





GO
