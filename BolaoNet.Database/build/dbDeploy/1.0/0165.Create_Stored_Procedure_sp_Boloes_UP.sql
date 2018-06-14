IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_UP')
BEGIN
	DROP  Procedure  sp_Boloes_UP
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Nome								varchar(30),
	@NomeCampeonato						varchar(50),
	@Descricao							varchar(255),
	@TaxaParticipacao					money,
	@Foto								Image, 
	@Publico							bit,
	@ForumAtivado						bit,
	@PermitirMsgAnonimos				bit,
	@DataInicio							DateTime,
	@Pais								varchar(20),
	@Estado								varchar(20),
	@Cidade								varchar(20),
	@ApostasApenasAntes					bit,
	@HorasLimiteAposta					int,
	@IsIniciado							bit,
	@IniciadoBy							varchar(25),
	@DataIniciado						DateTime,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL


	DECLARE @LastInicio  datetime	
	SELECT @LastInicio = DataIniciado FROM Boloes WHERE Nome = @Nome


	IF (@IsIniciado = 1 AND @LastInicio IS NULL)
		SET @LastInicio = GetDate()


	
	UPDATE Boloes SET		
		NomeCampeonato		= @NomeCampeonato,
		Descricao			= @Descricao,
		TaxaParticipacao	= @TaxaParticipacao,
		Foto				= @Foto,
		Publico				= @Publico,
		ForumAtivado		= @ForumAtivado,
		PermitirMsgAnonimos	= @PermitirMsgAnonimos,
		DataInicio			= @DataInicio,
		Pais				= @Pais,
		Estado				= @Estado,
		Cidade				= @Cidade,
		ApostasApenasAntes	= @ApostasApenasAntes,
		HorasLimiteAposta	= @HorasLimiteAposta,
		IsIniciado			= @IsIniciado,
		IniciadoBy			= @IniciadoBy,
		DataIniciado		= @LastInicio,				
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
		Nome				= @Nome
		
			  	
	RETURN @@RowCount	
	
END



GO
