IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '_CampeonatoDataCopadoMundo2014')
BEGIN
	DROP  Procedure  _CampeonatoDataCopadoMundo2014
END
GO

CREATE PROCEDURE [dbo].[_CampeonatoDataCopadoMundo2014]
AS
BEGIN
	DECLARE @NomeCampeonato VARCHAR(100)
	SET @NomeCampeonato = 'Copa do Mundo 2014'
	DECLARE @Usuario VARCHAR(100)
	SET @Usuario = 'Admin'

	SET NOCOUNT ON;

	IF (NOT EXISTS (SELECT * FROM Campeonatos WHERE Nome = @NomeCampeonato))
	-- Inserindo os dados principais
	INSERT INTO Campeonatos
		(
			Nome,
			IsClube,
			IsIniciado,
			DataInicio,
			CreatedBy,
			CreatedDate,
			ModifiedBy,
			ModifiedDate,
			ActiveFlag
		)
	 VALUES
		(
			@NomeCampeonato,
			0,
			0,
			CONVERT(DATETIME, '2014-06-11'),
			@Usuario,
			GetDate(),
			@Usuario,
			GetDate(),
			0
		)


	DECLARE @FaseClassificatoria varchar(100)
	SET @FaseClassificatoria = 'Classificatória'


	-- Inserindo os jogos
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Brasil', NULL, NULL,  NULL, 'Croácia', NULL, NULL,  NULL, '2014-06-12 17:00:00', 1,0, 'São Paulo', NULL, NULL, '1'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'México', NULL, NULL,  NULL, 'Camarões', NULL, NULL,  NULL, '2014-06-13 13:00:00', 1,0, 'Natal', NULL, NULL, '2'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Brasil', NULL, NULL,  NULL, 'México', NULL, NULL,  NULL, '2014-06-17 16:00:00', 2,0, 'Fortaleza', NULL, NULL, '17'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Camarões', NULL, NULL,  NULL, 'Croácia', NULL, NULL,  NULL, '2014-06-18 19:00:00', 2,0, 'Manaus', NULL, NULL, '18'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Camarões', NULL, NULL,  NULL, 'Brasil', NULL, NULL,  NULL, '2014-06-23 17:00:00', 3,0, 'Brasília', NULL, NULL, '33'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Croácia', NULL, NULL,  NULL, 'México', NULL, NULL,  NULL, '2014-06-23 17:00:00', 3,0, 'Recife', NULL, NULL, '34'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Espanha', NULL, NULL,  NULL, 'Holanda', NULL, NULL,  NULL, '2014-06-13 16:00:00', 1,0, 'Cuiabá', NULL, NULL, '3'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Chile', NULL, NULL,  NULL, 'Austrália', NULL, NULL,  NULL, '2014-06-13 18:00:00', 1,0, 'Rio de Janeiro', NULL, NULL, '4'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Espanha', NULL, NULL,  NULL, 'Chile', NULL, NULL,  NULL, '2014-06-18 16:00:00', 2,0, 'Rio de Janeiro', NULL, NULL, '19'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Austrália', NULL, NULL,  NULL, 'Holanda', NULL, NULL,  NULL, '2014-06-18 13:00:00', 2,0, 'Porto Alegre', NULL, NULL, '20'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Austrália', NULL, NULL,  NULL, 'Espanha', NULL, NULL,  NULL, '2014-06-23 13:00:00', 3,0, 'Curitiba', NULL, NULL, '35'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Holanda', NULL, NULL,  NULL, 'Chile', NULL, NULL,  NULL, '2014-06-23 13:00:00', 3,0, 'São Paulo', NULL, NULL, '36'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Colômbia', NULL, NULL,  NULL, 'Grécia', NULL, NULL,  NULL, '2014-06-14 13:00:00', 1,0, 'Belo Horizonte', NULL, NULL, '5'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Costa do Marfim', NULL, NULL,  NULL, 'Japão', NULL, NULL,  NULL, '2014-06-14 22:00:00', 1,0, 'Recife', NULL, NULL, '6'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Colômbia', NULL, NULL,  NULL, 'Costa do Marfim', NULL, NULL,  NULL, '2014-06-19 13:00:00', 2,0, 'Brasília', NULL, NULL, '21'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Japão', NULL, NULL,  NULL, 'Grécia', NULL, NULL,  NULL, '2014-06-19 19:00:00', 2,0, 'Natal', NULL, NULL, '22'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Japão', NULL, NULL,  NULL, 'Colômbia', NULL, NULL,  NULL, '2014-06-24 16:00:00', 3,0, 'Cuiabá', NULL, NULL, '37'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Grécia', NULL, NULL,  NULL, 'Costa do Marfim', NULL, NULL,  NULL, '2014-06-24 17:00:00', 3,0, 'Fortaleza', NULL, NULL, '38'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Uruguai', NULL, NULL,  NULL, 'Costa Rica', NULL, NULL,  NULL, '2014-06-14 16:00:00', 1,0, 'Fortaleza', NULL, NULL, '7'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Inglaterra', NULL, NULL,  NULL, 'Itália', NULL, NULL,  NULL, '2014-06-14 19:00:00', 1,0, 'Manaus', NULL, NULL, '8'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Uruguai', NULL, NULL,  NULL, 'Inglaterra', NULL, NULL,  NULL, '2014-06-19 16:00:00', 2,0, 'São Paulo', NULL, NULL, '23'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Itália', NULL, NULL,  NULL, 'Costa Rica', NULL, NULL,  NULL, '2014-06-20 13:00:00', 2,0, 'Recife', NULL, NULL, '24'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Itália', NULL, NULL,  NULL, 'Uruguai', NULL, NULL,  NULL, '2014-06-24 13:00:00', 3,0, 'Natal', NULL, NULL, '39'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Costa Rica', NULL, NULL,  NULL, 'Inglaterra', NULL, NULL,  NULL, '2014-06-24 13:00:00', 3,0, 'Belo Horizonte', NULL, NULL, '40'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Suíça', NULL, NULL,  NULL, 'Equador', NULL, NULL,  NULL, '2014-06-15 13:00:00', 1,0, 'Brasília', NULL, NULL, '9'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'França', NULL, NULL,  NULL, 'Honduras', NULL, NULL,  NULL, '2014-06-15 16:00:00', 1,0, 'Porto Alegre', NULL, NULL, '10'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Suíça', NULL, NULL,  NULL, 'França', NULL, NULL,  NULL, '2014-06-20 16:00:00', 2,0, 'Salvador', NULL, NULL, '25'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Honduras', NULL, NULL,  NULL, 'Equador', NULL, NULL,  NULL, '2014-06-20 19:00:00', 2,0, 'Curitiba', NULL, NULL, '26'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Honduras', NULL, NULL,  NULL, 'Suíça', NULL, NULL,  NULL, '2014-06-25 16:00:00', 3,0, 'Manaus', NULL, NULL, '41'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Equador', NULL, NULL,  NULL, 'França', NULL, NULL,  NULL, '2014-06-25 17:00:00', 3,0, 'Rio de Janeiro', NULL, NULL, '42'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Argentina', NULL, NULL,  NULL, 'Bósnia e Herzegovina', NULL, NULL,  NULL, '2014-06-15 19:00:00', 1,0, 'Rio de Janeiro', NULL, NULL, '11'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Irã', NULL, NULL,  NULL, 'Nigéria', NULL, NULL,  NULL, '2014-06-16 16:00:00', 1,0, 'Curitiba', NULL, NULL, '12'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Argentina', NULL, NULL,  NULL, 'Irã', NULL, NULL,  NULL, '2014-06-21 13:00:00', 2,0, 'Belo Horizonte', NULL, NULL, '27'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Nigéria', NULL, NULL,  NULL, 'Bósnia e Herzegovina', NULL, NULL,  NULL, '2014-06-21 18:00:00', 2,0, 'Cuiabá', NULL, NULL, '28'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Nigéria', NULL, NULL,  NULL, 'Argentina', NULL, NULL,  NULL, '2014-06-25 13:00:00', 3,0, 'Porto Alegre', NULL, NULL, '43'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Bósnia e Herzegovina', NULL, NULL,  NULL, 'Irã', NULL, NULL,  NULL, '2014-06-25 13:00:00', 3,0, 'Salvador', NULL, NULL, '44'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Alemanha', NULL, NULL,  NULL, 'Portugal', NULL, NULL,  NULL, '2014-06-16 13:00:00', 1,0, 'Salvador', NULL, NULL, '13'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Gana', NULL, NULL,  NULL, 'Estados Unidos', NULL, NULL,  NULL, '2014-06-16 19:00:00', 1,0, 'Natal', NULL, NULL, '14'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Alemanha', NULL, NULL,  NULL, 'Gana', NULL, NULL,  NULL, '2014-06-21 16:00:00', 2,0, 'Fortaleza', NULL, NULL, '29'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Estados Unidos', NULL, NULL,  NULL, 'Portugal', NULL, NULL,  NULL, '2014-06-22 19:00:00', 2,0, 'Manaus', NULL, NULL, '30'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Estados Unidos', NULL, NULL,  NULL, 'Alemanha', NULL, NULL,  NULL, '2014-06-26 13:00:00', 3,0, 'Recife', NULL, NULL, '45'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Portugal', NULL, NULL,  NULL, 'Gana', NULL, NULL,  NULL, '2014-06-26 13:00:00', 3,0, 'Brasília', NULL, NULL, '46'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Bélgica', NULL, NULL,  NULL, 'Argélia', NULL, NULL,  NULL, '2014-06-17 13:00:00', 1,0, 'Belo Horizonte', NULL, NULL, '15'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Rússia', NULL, NULL,  NULL, 'Coreia do Sul', NULL, NULL,  NULL, '2014-06-17 18:00:00', 1,0, 'Cuiabá', NULL, NULL, '16'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Bélgica', NULL, NULL,  NULL, 'Rússia', NULL, NULL,  NULL, '2014-06-22 13:00:00', 2,0, 'Rio de Janeiro', NULL, NULL, '31'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Coreia do Sul', NULL, NULL,  NULL, 'Argélia', NULL, NULL,  NULL, '2014-06-22 16:00:00', 2,0, 'Porto Alegre', NULL, NULL, '32'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Coreia do Sul', NULL, NULL,  NULL, 'Bélgica', NULL, NULL,  NULL, '2014-06-26 17:00:00', 3,0, 'São Paulo', NULL, NULL, '47'
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Argélia', NULL, NULL,  NULL, 'Rússia', NULL, NULL,  NULL, '2014-06-26 17:30:00', 3,0, 'Curitiba', NULL, NULL, '48'
	 
	 
	 
	IF (NOT EXISTS (SELECT * FROM CampeonatosGrupos WHERE Nome = ' '  AND @NomeCampeonato = NomeCampeonato))
		INSERT INTO CampeonatosGrupos (NomeCampeonato, Nome, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		VALUES (@NomeCampeonato, ' ', @Usuario, GetDate(), @Usuario, GetDate(), 0)


	-- OITAVAS DE FINAL
	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Oitavas de Final'  AND @NomeCampeonato = NomeCampeonato))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCampeonato, 'Oitavas de Final', NULL, @Usuario, GetDate(), @Usuario, GetDate(), 0) 

	
	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', 'Belo Horizonte', NULL, NULL, '2014-06-28 13:00:00', 4, ' ', '1A', '2B', 
		 NULL, 'A', 1, NULL, NULL, 'B', 2, NULL, NULL, 49, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', 'Rio de Janeiro', NULL, NULL, '2014-06-28 17:00:00', 4, ' ', '1C', '2D', 
		 NULL, 'C', 1, NULL, NULL, 'D', 2, NULL, NULL, 50, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', 'Fortaleza', NULL, NULL, '2014-06-29 13:00:00', 4, ' ', '1B', '2A', 
		 NULL, 'B', 1, NULL, NULL, 'A', 2, NULL, NULL, 51, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 



	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', 'Recife', NULL, NULL, '2014-06-29 17:00:00', 4, ' ', '1D', '2C', 
		 NULL, 'D', 1, NULL, NULL, 'C', 2, NULL, NULL, 52, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', 'Brasília', NULL, NULL, '2014-06-30 13:00:00', 4, ' ', '1E', '2F', 
		 NULL, 'E', 1, NULL, NULL, 'F', 2, NULL, NULL, 53, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', 'Porto Alegre', NULL, NULL, '2014-06-30 17:00:00', 4, ' ', '1G', '2H', 
		 NULL, 'G', 1, NULL, NULL, 'H', 2, NULL, NULL, 54, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', 'São Paulo', NULL, NULL, '2014-07-01 13:00:00', 4, ' ', '1F', '2E', 
		 NULL, 'F', 1, NULL, NULL, 'E', 2, NULL, NULL, 55, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', 'Salvador', NULL, NULL, '2014-07-01 17:00:00', 4, ' ', '1H', '2G', 
		 NULL, 'H', 1, NULL, NULL, 'G', 2, NULL, NULL, 56, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	-- QUARTAS DE FINAL

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Quartas de Final'  AND @NomeCampeonato = NomeCampeonato))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCampeonato, 'Quartas de Final', NULL, @Usuario, GetDate(), @Usuario, GetDate(), 0) 
	
	
	
	DECLARE @PendTime1 int
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '49'
	   
	
	DECLARE @PendTime2 int
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '50'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Quartas de Final', 'Fortaleza', NULL, NULL, '2014-07-04 17:00:00', 5, ' ', 'Vencedor jogo 49', 'Vencedor jogo 50', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 57, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
	
	
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '53'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '54'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Quartas de Final', 'Rio de Janeiro', NULL, NULL, '2014-07-04 13:00:00', 5, ' ', 'Vencedor jogo 53', 'Vencedor jogo 54', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 58, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '51'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '52'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Quartas de Final', 'Salvador', NULL, NULL, '2014-07-05 17:00:00', 5, ' ', 'Vencedor jogo 51', 'Vencedor jogo 52', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 59, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		
		
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '55'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '56'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Quartas de Final', 'Brasília', NULL, NULL, '2014-07-05 13:00:00', 5, ' ', 'Vencedor jogo 55', 'Vencedor jogo 56', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 60, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		
				
	

	-- Semi Finais

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Semi finais'  AND @NomeCampeonato = NomeCampeonato))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCampeonato, 'Semi finais', NULL, @Usuario, GetDate(), @Usuario, GetDate(), 0) 
		

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '57'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '58'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Semi Finais', 'Belo Horizonte', NULL, NULL, '2014-07-08 17:00:00', 6, ' ', 'Vencedor jogo 57', 'Vencedor jogo 58', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 61, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
				



	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '59'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '60'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Semi Finais', 'São Paulo', NULL, NULL, '2014-07-09 17:00:00', 6, ' ', 'Vencedor jogo 59', 'Vencedor jogo 60', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 62, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
				


	-- Final

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Final'  AND @NomeCampeonato = NomeCampeonato))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCampeonato, 'Final', NULL, @Usuario, GetDate(), @Usuario, GetDate(), 0) 
			

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '61'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '62'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Final', 'Brasília', NULL, NULL, '2014-07-12 17:00:00', 7, ' ', 'Perdedor jogo 61', 'Perdedor jogo 62', 
		 NULL, NULL, NULL, @PendTime1, 0, NULL, NULL, @PendTime2, 0, 63, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
				

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '61'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '62'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Final', 'Rio de Janeiro', NULL, NULL, '2014-07-13 16:00:00', 7, ' ', 'Vencedor jogo 61', 'Vencedor jogo 62', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 64, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
				







	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'A' AND Posicao = 1 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('A', 1, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'A' AND Posicao = 2 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('A', 2, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'B' AND Posicao = 1 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('B', 1, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'B' AND Posicao = 2 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('B', 2, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'C' AND Posicao = 1 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('C', 1, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'C' AND Posicao = 2 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('C', 2, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'D' AND Posicao = 1 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('D', 1, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'D' AND Posicao = 2 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('D', 2, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'E' AND Posicao = 1 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('E', 1, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'E' AND Posicao = 2 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('E', 2, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'F' AND Posicao = 1 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('F', 1, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'F' AND Posicao = 2 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('F', 2, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)


	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'G' AND Posicao = 1 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('G', 1, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'G' AND Posicao = 2 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('G', 2, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'H' AND Posicao = 1 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('H', 1, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'H' AND Posicao = 2 AND NomeCampeonato = @NomeCampeonato AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('H', 2, @NomeCampeonato, @FaseClassificatoria, 'Classificado', 'Green', 'White', @Usuario, GetDate(), @Usuario, GetDate(), 0)






	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1930, 'Uruguai', 'Argentina', NULL, 4, 2, NULL, NULL, 'Uruguai' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1934, 'Itália', 'Tchecoslováquia', NULL, 2, 1, NULL, NULL, 'Itália' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1938, 'Itália', 'Hungria', NULL, 4, 2, NULL, NULL, 'França' 
	--EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1942, 'Uruguai', 'Argentina', NULL, 4, 2, NULL, NULL, 'Uruguai' 
	--EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1946, 'Uruguai', 'Argentina', NULL, 4, 2, NULL, NULL, 'Uruguai' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1950, 'Uruguai', 'Brasil', NULL, 2, 1, NULL, NULL, 'Brasil' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1954, 'Alemanha Ocidental', 'Hungria', NULL, 3, 2, NULL, NULL, 'Suíça' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1958, 'Brasil', 'Suécia', NULL, 5, 2, NULL, NULL, 'Suécia' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1962, 'Brasil', 'Tchecoslováquia', NULL, 3, 1, NULL, NULL, 'Chile' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1966, 'Inglaterra', 'Alemanha Ocidental', NULL, 4, 2, NULL, NULL, 'Inglaterra' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1970, 'Brasil', 'Itália', NULL, 4, 1, NULL, NULL, 'México' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1974, 'Alemanha Ocidental', 'Holanda', NULL, 2, 1, NULL, NULL, 'Alemanha Ocidental' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1978, 'Argentina', 'Holanda', NULL, 3, 1, NULL, NULL, 'Argentina' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1982, 'Itália', 'Alemanha Ocidental', NULL, 3, 1, NULL, NULL, 'Espanha' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1986, 'Argentina', 'Alemanha Ocidental', NULL, 3, 2, NULL, NULL, 'México' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1990, 'Alemanha Ocidental', 'Argentina', NULL, 1, 0, NULL, NULL, 'Itália' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1994, 'Brasil', 'Itália', NULL, 0, 0, 3, 2, 'Estados Unidos' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 1998, 'França', 'Brasil', NULL, 3, 0, NULL, NULL, 'França' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 2002, 'Brasil', 'Alemanha', NULL, 2, 0, NULL, NULL, 'Coréia do Sul e Japão' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 2006, 'Itália', 'França', NULL, 1, 1, 5, 3, 'Alemanha' 
	EXEC CreateCampeonatoHistoricoEntry  @Usuario, @NomeCampeonato, 2010, 'Espanha', 'Holanda', NULL, 1, 0, NULL, NULL, 'Alemanha' 
	



END



GO
