IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtrasUsuarios_IN')
BEGIN
	DROP  Procedure  sp_ApostasExtrasUsuarios_IN
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtrasUsuarios_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Username							varchar(25),
	@NomeBolao							varchar(30),	
	@Posicao							int,
	@NomeTime							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	-- Se encontrou um registro com esta chave
	IF (NOT EXISTS(SELECT * 
				 FROM ApostasExtrasUsuarios
				 WHERE 	Posicao			= @Posicao
				   AND	NomeBolao		= @NomeBolao
				   AND	UserName		= @UserName))
	BEGIN
	
		INSERT INTO ApostasExtrasUsuarios
			(
			Posicao,
			NomeBolao,
			UserName,
			DataAposta,
			Pontos,
			NomeTime,
			IsApostaValida,			
			Automatico,
			CreatedBy,
			CreatedDate,
			ModifiedBy,
			ModifiedDate,
			ActiveFlag
			)
			VALUES
			(
			@Posicao,
			@NomeBolao,
			@UserName,
			GetDate(),
			0,
			@NomeTime,
			0,
			0,
			@CurrentLogin,
			GetDate(),
			@CurrentLogin,
			GetDate(),
			0
			)
	
	END
	-- Se não existe nenhum registro com esta chave
	ELSE
	BEGIN
	
		UPDATE ApostasExtrasUsuarios
		   SET	DataAposta		= GetDate(),
				Pontos			= 0,
				NomeTime		= @NomeTime,
				IsApostaValida	= 0,
				ModifiedBy		= @CurrentLogin,
				ModifiedDate	= GetDate(),
				Automatico      = 0		
		 WHERE 	Posicao			= @Posicao
		   AND	NomeBolao		= @NomeBolao
		   AND	UserName		= @UserName
				
	END
	
	
	

		
	RETURN @@RowCount  	
	
	
END



GO
