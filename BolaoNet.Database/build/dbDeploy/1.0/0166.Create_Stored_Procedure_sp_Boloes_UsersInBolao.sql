IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_UsersInBolao')
BEGIN
	DROP  Procedure  sp_Boloes_UsersInBolao
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_UsersInBolao]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@UserName							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	SELECT *
	  FROM BoloesMembros
	 WHERE NomeBolao	= @NomeBolao
	   AND UserName		= @UserName
	
		
	RETURN @@RowCount	  	
	
	
END




GO
