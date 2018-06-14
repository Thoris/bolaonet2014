IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_Aguardar')
BEGIN
	DROP  Procedure  sp_Boloes_Aguardar
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_Aguardar]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	UPDATE Boloes
	   SET	ModifiedBy		= @CurrentLogin,
			ModifiedDate	= GetDate(),
			IsIniciado		= 0
	 WHERE Nome				= @NomeBolao
			

		
	RETURN @@RowCount	  	
	
	
END



GO
