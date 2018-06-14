IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CreateCampeonatoCopadasConfederacoes2013')
BEGIN
	DROP  Procedure  CreateCampeonatoCopadasConfederacoes2013
END
GO




GO
CREATE PROCEDURE [dbo].[CreateCampeonatoCopadasConfederacoes2013]
AS
BEGIN

	DECLARE @NomeCopa varchar(100)
	DECLARE @FaseClassificatoria varchar(100)
	DECLARE @PendTime1 int
	DECLARE @PendTime2 int
	
		
	SET @NomeCopa = 'Confederações 2013'
	SET @FaseClassificatoria = 'Classificatória'

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF (NOT EXISTS (SELECT * FROM Campeonatos WHERE Nome = @NomeCopa))
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
			@NomeCopa,
			0,
			0,
			CONVERT(DATETIME, '2013-06-10'),
			'Admin',
			GetDate(),
			'Admin',
			GetDate(),
			0
		)
	-- Inserindo os jogos
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'A', NULL, 'Brasil', NULL, NULL,  NULL, 'Japão', NULL, NULL,  NULL, '2013-06-15 16:00:00.000', 1,0, 'Brasília', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'A', NULL, 'México', NULL, NULL,  NULL, 'Itália', NULL, NULL,  NULL, '2013-06-16 16:00:00.000', 1,0, 'Maracanã', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'A', NULL, 'Brasil', NULL, NULL,  NULL, 'México', NULL, NULL,  NULL, '2013-06-19 16:00:00.000', 2,0, 'Fortaleza', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'A', NULL, 'Itália', NULL, NULL,  NULL, 'Japão', NULL, NULL,  NULL, '2013-06-19 19:00:00.000', 2,0, 'Recife', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'A', NULL, 'Japão', NULL, NULL,  NULL, 'México', NULL, NULL,  NULL, '2013-06-22 16:00:00.000', 3,0, 'Mineirão', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'A', NULL, 'Brasil', NULL, NULL,  NULL, 'Itália', NULL, NULL,  NULL, '2013-06-22 16:00:00.000', 3,0, 'Salvador', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'B', NULL, 'Espanha', NULL, NULL,  NULL, 'Uruguai', NULL, NULL,  NULL, '2013-06-16 19:00:00.000', 1,0, 'Recife', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'B', NULL, 'Taiti', NULL, NULL,  NULL, 'Nigéria', NULL, NULL,  NULL, '2013-06-17 16:00:00.000', 1,0, 'Mineirão', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'B', NULL, 'Espanha', NULL, NULL,  NULL, 'Taiti', NULL, NULL,  NULL, '2013-06-20 16:00:00.000', 2,0, 'Maracanã', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'B', NULL, 'Uruguai', NULL, NULL,  NULL, 'Nigéria', NULL, NULL,  NULL, '2013-06-20 19:00:00.000', 2,0, 'Salvador', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'B', NULL, 'Espanha', NULL, NULL,  NULL, 'Nigéria', NULL, NULL,  NULL, '2013-06-23 16:00:00.000', 3,0, 'Fortaleza', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, @NomeCopa, 0, @FaseClassificatoria, 'B', NULL, 'Uruguai', NULL, NULL,  NULL, 'Taiti', NULL, NULL,  NULL, '2013-06-23 16:00:00.000', 3,0, 'Recife', NULL, NULL

	IF (NOT EXISTS (SELECT * FROM CampeonatosGrupos WHERE Nome = ' '))
		INSERT INTO CampeonatosGrupos (NomeCampeonato, Nome, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		VALUES (@NomeCopa, ' ', 'Admin', GetDate(), 'Admin', GetDate(), 0)



	-- SEMI FINAL
	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Semi Final'))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCopa, 'Semi Final', NULL, 'Admin', GetDate(), 'Admin', GetDate(), 0) 
	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCopa, 'Semi Final', 'Mineirão', NULL, NULL, '2013-06-26 16:00:00', 4, ' ', '1A', '2B', 
		 NULL, 'A', 1, NULL, NULL, 'B', 2, NULL, NULL, 13, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCopa, 'Semi Final', 'Fortaleza', NULL, NULL, '2013-06-27 16:00:00', 4, ' ', '1B', '2A', 
		 NULL, 'B', 1, NULL, NULL, 'A', 2, NULL, NULL, 14, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
	

	-- Final
	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Final'))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCopa, 'Final', NULL, 'Admin', GetDate(), 'Admin', GetDate(), 0) 
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato = @NomeCopa 
	   AND JogoLabel = '13'
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato = @NomeCopa 
	   AND JogoLabel = '14'
	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCopa, 'Final', 'Salvador', NULL, NULL, '2013-06-30 15:30:00', 5, ' ', 'Perdedor jogo 13', 'Perdedor jogo 14', 
		 NULL, NULL, NULL, @PendTime1, 0, NULL, NULL, @PendTime2, 0, 15, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCopa 
	   AND JogoLabel = '13'
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCopa 
	   AND JogoLabel = '14'
	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCopa, 'Final', 'Maracanã', NULL, NULL, '2013-06-30 16:00:00', 5, ' ', 'Vencedor jogo 13', 'Vencedor jogo 14', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 16, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
	
	
	
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'A' AND Posicao = 1 AND NomeCampeonato = @NomeCopa AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('A', 1, @NomeCopa, @FaseClassificatoria, 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'A' AND Posicao = 2 AND NomeCampeonato = @NomeCopa AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('A', 2, @NomeCopa, @FaseClassificatoria, 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'B' AND Posicao = 1 AND NomeCampeonato = @NomeCopa AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('B', 1, @NomeCopa, @FaseClassificatoria, 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'B' AND Posicao = 2 AND NomeCampeonato = @NomeCopa AND NomeFase = @FaseClassificatoria))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('B', 2, @NomeCopa, @FaseClassificatoria, 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
END

GO