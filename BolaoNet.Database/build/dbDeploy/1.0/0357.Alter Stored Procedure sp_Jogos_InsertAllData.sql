IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_InsertAllData')
BEGIN
	DROP  Procedure  sp_Jogos_InsertAllData
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_InsertAllData]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@IsClube							bit,
	@NomeFase							varchar(50),
	@NomeGrupo							varchar(20),
	@Titulo								varchar(100),
	@NomeTime1							varchar(30),
	@Gols1								smallint = null,
	@Penaltis1							smallint = null,
	@DescricaoTime1						varchar(255),	
	@NomeTime2							varchar(30),
	@Gols2								smallint = null,
	@Penaltis2							smallint = null,
	@DescricaoTime2						varchar(255),
	@DataJogo							DateTime, 
	@Rodada								int,
	@IsValido							bit = false, 
	@NomeEstadio						varchar(30),
	@JogoLabel							varchar(5) = null,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DECLARE @IsCampeonatoIniciado  bit
	
	-- Verificando o time que joga em casa
	IF (NOT EXISTS (SELECT * FROM Times Where Nome = @NomeTime1))
	BEGIN
	
		INSERT INTO Times
			(
				Nome,
				IsClube,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				@NomeTime1,
				@IsClube,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END	-- Time em casa
	
	
	
		-- Verificando o time que joga fora de casa
	IF (NOT EXISTS (SELECT * FROM Times Where Nome = @NomeTime2))
	BEGIN
	
		INSERT INTO Times
			(
				Nome,
				IsClube,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				@NomeTime2,
				@IsClube,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END	-- Time fora
	
	
	-- Verificando o estadio
	IF (@NomeEstadio IS NOT NULL AND NOT EXISTS(SELECT * FROM Estadios WHERE Nome = @NomeEstadio))
	BEGIN
		INSERT INTO Estadios
			(
				Nome,
				NomeTime,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				@NomeEstadio,
				@NomeTime1,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)		
	
	END -- estádios
	
	
	
	
	-- Se não existir o campeonato, insere-se
	IF (NOT EXISTS (SELECT * FROM Campeonatos WHERE Nome = @NomeCampeonato))
	BEGIN
		INSERT INTO Campeonatos
			(
				Nome,
				IsClube,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				@NomeCampeonato,
				@IsClube,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END -- inserção de campeonato
	
	
	
	IF (NOT EXISTS (SELECT * FROM CampeonatosTimes Where NomeCampeonato = @NomeCampeonato AND NomeTime = @NomeTime1))
	BEGIN
		INSERT INTO CampeonatosTimes
			(
				NomeCampeonato,
				NomeTime,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				Activeflag
			)
			VALUES
			(
				@NomeCampeonato,
				@NomeTime1,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END
	

	IF (NOT EXISTS (SELECT * FROM CampeonatosTimes Where NomeCampeonato = @NomeCampeonato AND NomeTime = @NomeTime2))
	BEGIN
		INSERT INTO CampeonatosTimes
			(
				NomeCampeonato,
				NomeTime,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				Activeflag
			)
			VALUES
			(
				@NomeCampeonato,
				@NomeTime2,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END	
	
	
	
	
	-- Se não existir o grupo
	IF (@NomeGrupo IS NOT NULL AND NOT EXISTS (SELECT * FROM CampeonatosGrupos WHERE NomeCampeonato = @NomeCampeonato AND Nome = @NomeGrupo))
	BEGIN
		INSERT INTO CampeonatosGrupos
			(
				Nome,
				NomeCampeonato,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				@NomeGrupo,
				@NomeCampeonato,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END -- inserção de grupos dos campeonatos	
	
	
	
	
	-- Se não existir a fase
	IF (@NomeFase IS NOT NULL AND NOT EXISTS (SELECT * FROM CampeonatosFases WHERE NomeCampeonato = @NomeCampeonato AND Nome = @NomeFase))
	BEGIN
		INSERT INTO CampeonatosFases
			(
				Nome,
				NomeCampeonato,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				@NomeFase,
				@NomeCampeonato,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END -- inserção de fases dos campeonatos
	
	
	

	-- Se o time 1 não está no grupo
	IF (@NomeGrupo IS NOT NULL AND NOT EXISTS (SELECT * FROM CampeonatosGruposTimes WHERE NomeCampeonato = @NomeCampeonato AND NomeGrupo = @NomeGrupo AND NomeTime = @NomeTime1))
	BEGIN
		INSERT INTO CampeonatosGruposTimes
			(
				NomeGrupo,
				NomeCampeonato,
				NomeTime,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				@NomeGrupo,
				@NomeCampeonato,
				@NomeTime1,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END -- inserção de time 1
	



	-- Se o time 2 não está no grupo
	IF (@NomeGrupo IS NOT NULL AND NOT EXISTS (SELECT * FROM CampeonatosGruposTimes WHERE NomeCampeonato = @NomeCampeonato AND NomeGrupo = @NomeGrupo AND NomeTime = @NomeTime2))
	BEGIN
		INSERT INTO CampeonatosGruposTimes
			(
				NomeGrupo,
				NomeCampeonato,
				NomeTime,
				CreatedBy,
				CreatedDate,
				ModifiedBy,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				@NomeGrupo,
				@NomeCampeonato,
				@NomeTime2,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				0
			)	
	END -- inserção de time 2

	
	
	
	
	
	
	
	INSERT INTO Jogos
		(
		NomeCampeonato,
		NomeFase, 
		NomeGrupo,
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
		@NomeGrupo,
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
		NULL,
		NULL,
		@NomeEstadio,
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
