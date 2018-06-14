IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembrosGrupos_DE')
BEGIN
	DROP  Procedure  sp_BoloesMembrosGrupos_DE
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembrosGrupos_DE]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25),
	@UserNameSelecionado				varchar(25),
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	DELETE 
	  FROM BoloesMembrosGrupo
	 WHERE NomeBolao			= @NomeBolao
	   AND UserName				= @UserName
	   AND UserNameSelecionado  = @UserNameSelecionado

		
	RETURN @@RowCount	  	
	
	
END



GO
