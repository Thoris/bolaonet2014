IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtras_UP')
BEGIN
	DROP  Procedure  sp_ApostasExtras_UP
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtras_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@Posicao							int,
	@Titulo								varchar(50),
	@Descricao							varchar(255),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE ApostasExtras SET	
		Titulo				= @Titulo,
		Descricao			= @Descricao,		
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	Posicao			= @Posicao
		
			  	
	RETURN @@RowCount	
	
END




GO
