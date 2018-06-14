IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '_CampeonatoDataCopadoMundo2006')
BEGIN
	DROP  Procedure  _CampeonatoDataCopadoMundo2006
END
GO

CREATE PROCEDURE [dbo].[_CampeonatoDataCopadoMundo2006]
AS
BEGIN
	DECLARE @NomeCampeonato VARCHAR(100)
	SET @NomeCampeonato = 'Copa do Mundo 2006'
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
			CONVERT(DATETIME, '2006-06-09'),
			@Usuario,
			GetDate(),
			@Usuario,
			GetDate(),
			0
		)


	DECLARE @FaseClassificatoria varchar(100)
	SET @FaseClassificatoria = 'Classificatória'

	

	-- Inserindo os jogos
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Alemanha', NULL, NULL,  NULL, 'Costa Rica', NULL, NULL,  NULL, '2006-06-09', 1,0, '', '1', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Polônia', NULL, NULL,  NULL, 'Equador', NULL, NULL,  NULL, '2006-06-09', 1,0, '', '2', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Alemanha', NULL, NULL,  NULL, 'Polônia', NULL, NULL,  NULL, '2006-06-14', 2,0, '', '17', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Equador', NULL, NULL,  NULL, 'Costa Rica', NULL, NULL,  NULL, '2006-06-15', 2,0, '', '18', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Equador', NULL, NULL,  NULL, 'Alemanha', NULL, NULL,  NULL, '2006-06-20', 3,0, '', '33', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Costa Rica', NULL, NULL,  NULL, 'Polônia', NULL, NULL,  NULL, '2006-06-20', 3,0, '', '34', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Inglaterra', NULL, NULL,  NULL, 'Paraguai', NULL, NULL,  NULL, '2006-06-10', 1,0, '', '3', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Trinidad e Tobago', NULL, NULL,  NULL, 'Suécia', NULL, NULL,  NULL, '2006-06-10', 1,0, '', '4', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Inglaterra', NULL, NULL,  NULL, 'Trinidad e Tobago', NULL, NULL,  NULL, '2006-06-15', 2,0, '', '19', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Suécia', NULL, NULL,  NULL, 'Paraguai', NULL, NULL,  NULL, '2006-06-15', 2,0, '', '20', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Suécia', NULL, NULL,  NULL, 'Inglaterra', NULL, NULL,  NULL, '2006-06-20', 3,0, '', '35', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Paraguai', NULL, NULL,  NULL, 'Trinidad e Tobago', NULL, NULL,  NULL, '2006-06-20', 3,0, '', '36', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Argentina', NULL, NULL,  NULL, 'Costa do Marfim', NULL, NULL,  NULL, '2006-06-10', 1,0, '', '5', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Sérvia e Montenegro', NULL, NULL,  NULL, 'Holanda', NULL, NULL,  NULL, '2006-06-11', 1,0, '', '6', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Argentina', NULL, NULL,  NULL, 'Sérvia e Montenegro', NULL, NULL,  NULL, '2006-06-16', 2,0, '', '21', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Holanda', NULL, NULL,  NULL, 'Costa do Marfim', NULL, NULL,  NULL, '2006-06-16', 2,0, '', '22', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Holanda', NULL, NULL,  NULL, 'Argentina', NULL, NULL,  NULL, '2006-06-21', 3,0, '', '37', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Costa do Marfim', NULL, NULL,  NULL, 'Sérvia e Montenegro', NULL, NULL,  NULL, '2006-06-21', 3,0, '', '38', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'México', NULL, NULL,  NULL, 'Irã', NULL, NULL,  NULL, '2006-06-11', 1,0, '', '7', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Angola', NULL, NULL,  NULL, 'Portugal', NULL, NULL,  NULL, '2006-06-11', 1,0, '', '8', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'México', NULL, NULL,  NULL, 'Angola', NULL, NULL,  NULL, '2006-06-16', 2,0, '', '23', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Portugal', NULL, NULL,  NULL, 'Irã', NULL, NULL,  NULL, '2006-06-17', 2,0, '', '24', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Portugal', NULL, NULL,  NULL, 'México', NULL, NULL,  NULL, '2006-06-21', 3,0, '', '39', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Irã', NULL, NULL,  NULL, 'Angola', NULL, NULL,  NULL, '2006-06-21', 3,0, '', '40', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Itália', NULL, NULL,  NULL, 'Gana', NULL, NULL,  NULL, '2006-06-12', 1,0, '', '9', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Estados Unidos', NULL, NULL,  NULL, 'República Tcheca', NULL, NULL,  NULL, '2006-06-12', 1,0, '', '10', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Itália', NULL, NULL,  NULL, 'Estados Unidos', NULL, NULL,  NULL, '2006-06-17', 2,0, '', '25', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'República Tcheca', NULL, NULL,  NULL, 'Gana', NULL, NULL,  NULL, '2006-06-17', 2,0, '', '26', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'República Tcheca', NULL, NULL,  NULL, 'Itália', NULL, NULL,  NULL, '2006-06-22', 3,0, '', '41', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Gana', NULL, NULL,  NULL, 'Estados Unidos', NULL, NULL,  NULL, '2006-06-22', 3,0, '', '42', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Brasil', NULL, NULL,  NULL, 'Croácia', NULL, NULL,  NULL, '2006-06-13', 1,0, '', '11', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Austrália', NULL, NULL,  NULL, 'Japão', NULL, NULL,  NULL, '2006-06-12', 1,0, '', '12', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Brasil', NULL, NULL,  NULL, 'Austrália', NULL, NULL,  NULL, '2006-06-18', 2,0, '', '27', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Japão', NULL, NULL,  NULL, 'Croácia', NULL, NULL,  NULL, '2006-06-18', 2,0, '', '28', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Japão', NULL, NULL,  NULL, 'Brasil', NULL, NULL,  NULL, '2006-06-22', 3,0, '', '43', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Croácia', NULL, NULL,  NULL, 'Austrália', NULL, NULL,  NULL, '2006-06-22', 3,0, '',  '44', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'França', NULL, NULL,  NULL, 'Suíça', NULL, NULL,  NULL, '2006-06-13', 1,0, '', '13', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Coreia do Sul', NULL, NULL,  NULL, 'Togo', NULL, NULL,  NULL, '2006-06-13', 1,0, '', '14', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'França', NULL, NULL,  NULL, 'Coreia do Sul', NULL, NULL,  NULL, '2006-06-18', 2,0, '', '29', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Togo', NULL, NULL,  NULL, 'Suíça', NULL, NULL,  NULL, '2006-06-19', 2,0, '', '30', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Togo', NULL, NULL,  NULL, 'França', NULL, NULL,  NULL, '2006-06-23', 3,0, '', '45', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Suíça', NULL, NULL,  NULL, 'Coreia do Sul', NULL, NULL,  NULL, '2006-06-23', 3,0, '', '46', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Espanha', NULL, NULL,  NULL, 'Ucrânia', NULL, NULL,  NULL, '2006-06-14', 1,0, '', '15', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Tunísia', NULL, NULL,  NULL, 'Arábia Saudita', NULL, NULL,  NULL, '2006-06-14', 1,0, '', '16', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Espanha', NULL, NULL,  NULL, 'Tunísia', NULL, NULL,  NULL, '2006-06-19', 2,0, '','31', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Arábia Saudita', NULL, NULL,  NULL, 'Ucrânia', NULL, NULL,  NULL, '2006-06-19', 2,0, '', '32', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Arábia Saudita', NULL, NULL,  NULL, 'Espanha', NULL, NULL,  NULL, '2006-06-23', 3,0, '', '47', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Ucrânia', NULL, NULL,  NULL, 'Tunísia', NULL, NULL,  NULL, '2006-06-23', 3,0, '', '48', NULL, NULL
	 
 
	 
	 
	IF (NOT EXISTS (SELECT * FROM CampeonatosGrupos WHERE Nome = ' ' AND @NomeCampeonato = NomeCampeonato))
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
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2006-06-24', 4, ' ', '1A', '2B', 
		 NULL, 'A', 1, NULL, NULL, 'B', 2, NULL, NULL, 49, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2006-06-24', 4, ' ', '1C', '2D', 
		 NULL, 'C', 1, NULL, NULL, 'D', 2, NULL, NULL, 50, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2006-06-25', 4, ' ', '1D', '2C', 
		 NULL, 'D', 1, NULL, NULL, 'C', 2, NULL, NULL, 51, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 



	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2006-06-25', 4, ' ', '1B', '2A', 
		 NULL, 'B', 1, NULL, NULL, 'A', 2, NULL, NULL, 52, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2006-06-26', 4, ' ', '1E', '2F', 
		 NULL, 'E', 1, NULL, NULL, 'F', 2, NULL, NULL, 53, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2006-06-26', 4, ' ', '1G', '2H', 
		 NULL, 'G', 1, NULL, NULL, 'H', 2, NULL, NULL, 54, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2006-06-27', 4, ' ', '1F', '2E', 
		 NULL, 'F', 1, NULL, NULL, 'E', 2, NULL, NULL, 55, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2006-06-27', 4, ' ', '1H', '2G', 
		 NULL, 'H', 1, NULL, NULL, 'G', 2, NULL, NULL, 56, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	-- QUARTAS DE FINAL

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Quartas de Final' AND @NomeCampeonato = NomeCampeonato))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCampeonato, 'Quartas de Final', NULL, @Usuario, GetDate(), @Usuario, GetDate(), 0) 
	
	
	
	DECLARE @PendTime1 int
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '53'
	   
	
	DECLARE @PendTime2 int
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
		(@NomeCampeonato, 'Quartas de Final', '', NULL, NULL, '2006-06-30', 5, ' ', 'Vencedor jogo 53', 'Vencedor jogo 54', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 57, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
	
	
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '49'
	   
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
		(@NomeCampeonato, 'Quartas de Final', '', NULL, NULL, '2006-06-30', 5, ' ', 'Vencedor jogo 49', 'Vencedor jogo 50', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 58, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '52'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '51'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Quartas de Final', '', NULL, NULL, '2006-07-01', 5, ' ', 'Vencedor jogo 52', 'Vencedor jogo 51', 
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
		(@NomeCampeonato, 'Quartas de Final', '', NULL, NULL, '2006-07-01', 5, ' ', 'Vencedor jogo 55', 'Vencedor jogo 56', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 60, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		
				
	

	-- Semi Finais

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Semi finais' AND @NomeCampeonato = NomeCampeonato))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCampeonato, 'Semi finais', NULL, @Usuario, GetDate(), @Usuario, GetDate(), 0) 
		

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '58'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '57'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Semi Finais', '', NULL, NULL, '2006-07-04', 6, ' ', 'Vencedor jogo 58', 'Vencedor jogo 57', 
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
		(@NomeCampeonato, 'Semi Finais', '', NULL, NULL, '2006-07-05', 6, ' ', 'Vencedor jogo 59', 'Vencedor jogo 60', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 62, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
				


	-- Final

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Final' AND @NomeCampeonato = NomeCampeonato))
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
		(@NomeCampeonato, 'Final', '', NULL, NULL, '2006-07-08', 7, ' ', 'Perdedor jogo 61', 'Perdedor jogo 62', 
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
		(@NomeCampeonato, 'Final', '', NULL, NULL, '2006-07-09', 7, ' ', 'Vencedor jogo 61', 'Vencedor jogo 62', 
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




END



GO
