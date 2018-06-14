IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesPremios_LoadAll')
BEGIN
	DROP  Procedure  sp_BoloesPremios_LoadAll
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesPremios_LoadAll]
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
	  FROM BoloesPremios
	 WHERE NomeBolao			= @NomeBolao
     ORDER BY Posicao   


	RETURN @@RowCount

END




GO
