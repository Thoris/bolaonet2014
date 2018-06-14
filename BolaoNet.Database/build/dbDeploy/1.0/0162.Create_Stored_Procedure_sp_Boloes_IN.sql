IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_IN')
BEGIN
	DROP  Procedure  sp_Boloes_IN
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_IN]
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
	
	
	
	INSERT INTO Boloes 
		(
		Nome,
		NomeCampeonato,
		Descricao,
		TaxaParticipacao,
		Foto,
		Publico,
		ForumAtivado,
		PermitirMsgAnonimos,
		DataInicio,
		Pais,
		Estado,
		Cidade,
		ApostasApenasAntes,
		HorasLimiteAposta,
		IsIniciado,
		IniciadoBy,
		DataIniciado,		
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@Nome,
		@NomeCampeonato,
		@Descricao,
		@TaxaParticipacao,
		@Foto,
		@Publico,
		@ForumAtivado,
		@PermitirMsgAnonimos,
		@DataInicio,
		@Pais,
		@Estado,
		@Cidade,
		@ApostasApenasAntes,
		@HorasLimiteAposta,
		@IsIniciado,
		@IniciadoBy,
		@DataIniciado,		
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@RowCount	  	
	
	
END



GO
