IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Estadios_UP')
BEGIN
	DROP  Procedure  sp_Estadios_UP
END
GO
CREATE PROCEDURE [dbo].[sp_Estadios_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Nome								varchar(30),
	@NomeTime							varchar(30),
	@Pais								varchar(20),
	@Estado								varchar(20),
	@Cidade								varchar(20),
	@Descricao							varchar(255),
	@Foto								image,
	@Capacidade							int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE Estadios SET		
		NomeTime			= @NomeTime,
		Pais				= @Pais,
		Estado				= @Estado,
		Cidade				= @Cidade,
		Descricao			= @Descricao,
		Foto				= @Foto,
		Capacidade			= @Capacidade,
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
		Nome				= @Nome
		
			  	
	RETURN @@RowCount	
	
END



GO
