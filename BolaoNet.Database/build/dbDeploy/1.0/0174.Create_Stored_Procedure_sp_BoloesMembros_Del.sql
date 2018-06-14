IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembros_Del')
BEGIN
	DROP  Procedure  sp_BoloesMembros_Del
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembros_Del]
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
	
	BEGIN TRANSACTION
	
	
	
	DELETE FROM ApostasExtrasUsuarios
	 WHERE NomeBolao			= @NomeBolao
	   AND UserName				= @UserName
		
	IF (@@ERROR > 0)
	BEGIN	
		ROLLBACK TRANSACTION
		RETURN 0;	
	END		
	
	
	
	DELETE FROM BoloesPontosRodadasUsuarios
	 WHERE NomeBolao			= @NomeBolao
	   AND UserName				= @UserName
		
	IF (@@ERROR > 0)
	BEGIN	
		ROLLBACK TRANSACTION
		RETURN 0;	
	END	
	
	
	DELETE FROM BoloesMembrosPontos
	 WHERE NomeBolao			= @NomeBolao
	   AND UserName				= @UserName
		
	IF (@@ERROR > 0)
	BEGIN	
		ROLLBACK TRANSACTION
		RETURN 0;	
	END	
	
	
	
	
	DELETE FROM BoloesMembrosClassificacao
	 WHERE NomeBolao			= @NomeBolao
	   AND UserName				= @UserName
		
	IF (@@ERROR > 0)
	BEGIN	
		ROLLBACK TRANSACTION
		RETURN 0;	
	END
	
	
	
	
	
	DELETE FROM JogosUsuarios
	 WHERE NomeBolao			= @NomeBolao
	   AND UserName				= @UserName
		
	IF (@@ERROR > 0)
	BEGIN	
		ROLLBACK TRANSACTION
		RETURN 0;	
	END
	
	
	
	
	
	
	
	
	
	DELETE FROM BoloesMembros
	 WHERE NomeBolao			= @NomeBolao
	   AND UserName				= @UserName
		
	IF (@@ERROR > 0)
	BEGIN	
		ROLLBACK TRANSACTION
		RETURN 0;	
	END
	
	
	
	
	
	COMMIT TRANSACTION
	
		
	RETURN 1	  	
	
	
END



GO
