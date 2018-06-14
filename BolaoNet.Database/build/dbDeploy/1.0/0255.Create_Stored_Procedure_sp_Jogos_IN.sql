IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_IN')
BEGIN
	DROP  Procedure  sp_Jogos_IN
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(50),
	@NomeGrupo							varchar(20),
	@Titulo								varchar(100),
	@NomeTime1							varchar(30),
	@Gols1								smallint,
	@Penaltis1							smallint,
	@DescricaoTime1						varchar(255),	
	@NomeTime2							varchar(30),
	@Gols2								smallint,
	@Penaltis2							smallint,
	@DescricaoTime2						varchar(255),
	@DataJogo							DateTime, 
	@Rodada								int,
	@IsValido							bit, 
	@DataValidacao						datetime, 
	@ValidadoBy							varchar(25),
	@NomeEstadio						varchar(30),
	@JogoLabel							varchar(5),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	
	INSERT INTO Jogos
		(
		NomeCampeonato,
		NomeFase, 
		Titulo, 
		NomeTime1,
		Gols1,
		Penaltis1,
		DescricaoTime1,
		NomeTime2,
		Gols2,
		Penaltis2,
		DescricaoTime2,
		DataJogo,
		Rodada, 
		IsValido,
		DataValidacao,
		ValidadoBy,
		NomeEstadio,
		NomeGrupo,
		JogoLabel,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@NomeCampeonato,
		@NomeFase, 
		@Titulo, 
		@NomeTime1,
		@Gols1,
		@Penaltis1,
		@DescricaoTime1,
		@NomeTime2,
		@Gols2,
		@Penaltis2,
		@DescricaoTime2,
		@DataJogo,
		@Rodada, 
		@IsValido,
		@DataValidacao,
		@ValidadoBy,
		@NomeEstadio,
		@NomeGrupo,
		@JogoLabel,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@IDENTITY	  	
	
	
END



GO
