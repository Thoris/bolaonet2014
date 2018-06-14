IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '_CampeonatoDataCopadoMundo2002')
BEGIN
	DROP  Procedure  _CampeonatoDataCopadoMundo2002
END
GO

CREATE PROCEDURE [dbo].[_CampeonatoDataCopadoMundo2002]
AS
BEGIN
	DECLARE @NomeCampeonato VARCHAR(100)
	SET @NomeCampeonato = 'Copa do Mundo 2002'
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
			CONVERT(DATETIME, '2002-05-31'),
			@Usuario,
			GetDate(),
			@Usuario,
			GetDate(),
			0
		)


	DECLARE @FaseClassificatoria varchar(100)
	SET @FaseClassificatoria = 'Classificatória'

	

	-- Inserindo os jogos
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'França', NULL, NULL,  NULL, 'Senegal', NULL, NULL,  NULL, '2002-05-31', 1,0, '', '1', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Uruguai', NULL, NULL,  NULL, 'Dinamarca', NULL, NULL,  NULL, '2002-06-01', 1,0, '', '3', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'França', NULL, NULL,  NULL, 'Uruguai', NULL, NULL,  NULL, '2002-06-06', 2,0, '', '18', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Dinamarca', NULL, NULL,  NULL, 'Senegal', NULL, NULL,  NULL, '2002-06-06', 2,0, '', '20', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Dinamarca', NULL, NULL,  NULL, 'França', NULL, NULL,  NULL, '2002-06-11', 3,0, '', '33', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'A', NULL, 'Senegal', NULL, NULL,  NULL, 'Uruguai', NULL, NULL,  NULL, '2002-06-11', 3,0, '', '34', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Paraguai', NULL, NULL,  NULL, 'África do Sul', NULL, NULL,  NULL, '2002-06-02', 1,0, '', '6', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Espanha', NULL, NULL,  NULL, 'Eslovênia', NULL, NULL,  NULL, '2002-06-02', 1,0, '', '8', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Espanha', NULL, NULL,  NULL, 'Paraguai', NULL, NULL,  NULL, '2002-06-07', 2,0, '', '22', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'África do Sul', NULL, NULL,  NULL, 'Eslovênia', NULL, NULL,  NULL, '2002-06-08', 2,0, '', '24', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'África do Sul', NULL, NULL,  NULL, 'Espanha', NULL, NULL,  NULL, '2002-06-12', 3,0, '', '39', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'B', NULL, 'Eslovênia', NULL, NULL,  NULL, 'Paraguai', NULL, NULL,  NULL, '2002-06-12', 3,0, '', '40', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Brasil', NULL, NULL,  NULL, 'Turquia', NULL, NULL,  NULL, '2002-06-03', 1,0, '', '10', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'China', NULL, NULL,  NULL, 'Costa Rica', NULL, NULL,  NULL, '2002-06-04', 1,0, '', '12', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Brasil', NULL, NULL,  NULL, 'China', NULL, NULL,  NULL, '2002-06-08', 2,0, '', '26', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Costa Rica', NULL, NULL,  NULL, 'Turquia', NULL, NULL,  NULL, '2002-06-09', 2,0, '', '28', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Costa Rica', NULL, NULL,  NULL, 'Brasil', NULL, NULL,  NULL, '2002-06-13', 3,0, '', '41', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'C', NULL, 'Turquia', NULL, NULL,  NULL, 'China', NULL, NULL,  NULL, '2002-06-13', 3,0, '', '42', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Coreia do Sul', NULL, NULL,  NULL, 'Polônia', NULL, NULL,  NULL, '2002-06-04', 1,0, '', '14', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Estados Unidos', NULL, NULL,  NULL, 'Portugal', NULL, NULL,  NULL, '2002-06-05', 1,0, '', '16', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Coreia do Sul', NULL, NULL,  NULL, 'Estados Unidos', NULL, NULL,  NULL, '2002-06-10', 2,0, '', '30', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Portugal', NULL, NULL,  NULL, 'Polônia', NULL, NULL,  NULL, '2002-06-10', 2,0, '', '32', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Portugal', NULL, NULL,  NULL, 'Coreia do Sul', NULL, NULL,  NULL, '2002-06-14', 3,0, '', '47', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'D', NULL, 'Polônia', NULL, NULL,  NULL, 'Estados Unidos', NULL, NULL,  NULL, '2002-06-14', 3,0, '', '48', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'República da Irlanda', NULL, NULL,  NULL, 'Camarões', NULL, NULL,  NULL, '2002-06-01', 1,0, '', '2', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Alemanha', NULL, NULL,  NULL, 'Arábia Saudita', NULL, NULL,  NULL, '2002-06-01', 1,0, '', '4', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Alemanha', NULL, NULL,  NULL, 'República da Irlanda', NULL, NULL,  NULL, '2002-06-05', 2,0, '', '17', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Camarões', NULL, NULL,  NULL, 'Arábia Saudita', NULL, NULL,  NULL, '2002-06-06', 2,0, '', '19', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Camarões', NULL, NULL,  NULL, 'Alemanha', NULL, NULL,  NULL, '2002-06-11', 3,0, '', '35', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'E', NULL, 'Arábia Saudita', NULL, NULL,  NULL, 'República da Irlanda', NULL, NULL,  NULL, '2002-06-11', 3,0, '', '36', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Inglaterra', NULL, NULL,  NULL, 'Suécia', NULL, NULL,  NULL, '2002-06-02', 1,0, '', '5', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Argentina', NULL, NULL,  NULL, 'Nigéria', NULL, NULL,  NULL, '2002-06-02', 1,0, '', '7', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Suécia', NULL, NULL,  NULL, 'Nigéria', NULL, NULL,  NULL, '2002-06-07', 2,0, '', '21', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Argentina', NULL, NULL,  NULL, 'Inglaterra', NULL, NULL,  NULL, '2002-06-07', 2,0, '', '23', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Suécia', NULL, NULL,  NULL, 'Argentina', NULL, NULL,  NULL, '2002-06-12', 3,0, '', '37', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'F', NULL, 'Nigéria', NULL, NULL,  NULL, 'Inglaterra', NULL, NULL,  NULL, '2002-06-12', 3,0, '',  '38', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Croácia', NULL, NULL,  NULL, 'México', NULL, NULL,  NULL, '2002-06-03', 1,0, '', '9', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Itália', NULL, NULL,  NULL, 'Equador', NULL, NULL,  NULL, '2002-06-03', 1,0, '', '11', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Itália', NULL, NULL,  NULL, 'Croácia', NULL, NULL,  NULL, '2002-06-08', 2,0, '', '25', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'México', NULL, NULL,  NULL, 'Equador', NULL, NULL,  NULL, '2002-06-09', 2,0, '', '27', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'México', NULL, NULL,  NULL, 'Itália', NULL, NULL,  NULL, '2002-06-13', 3,0, '', '43', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'G', NULL, 'Equador', NULL, NULL,  NULL, 'Croácia', NULL, NULL,  NULL, '2002-06-13', 3,0, '', '44', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Japão', NULL, NULL,  NULL, 'Bélgica', NULL, NULL,  NULL, '2002-06-04', 1,0, '', '13', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Rússia', NULL, NULL,  NULL, 'Tunísia', NULL, NULL,  NULL, '2002-06-05', 1,0, '', '15', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Japão', NULL, NULL,  NULL, 'Rússia', NULL, NULL,  NULL, '2002-06-09', 2,0, '','29', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Tunísia', NULL, NULL,  NULL, 'Bélgica', NULL, NULL,  NULL, '2002-06-10', 2,0, '', '31', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Tunísia', NULL, NULL,  NULL, 'Japão', NULL, NULL,  NULL, '2002-06-14', 3,0, '', '45', NULL, NULL
	EXEC sp_Jogos_InsertAllData @Usuario, NULL, @NomeCampeonato, 0, @FaseClassificatoria, 'H', NULL, 'Bélgica', NULL, NULL,  NULL, 'Rússia', NULL, NULL,  NULL, '2002-06-14', 3,0, '', '46', NULL, NULL
	 
 
	 
	 
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
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2002-06-15', 4, ' ', '1E', '2B', 
		 NULL, 'E', 1, NULL, NULL, 'B', 2, NULL, NULL, 49, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2002-06-15', 4, ' ', '1A', '2F', 
		 NULL, 'A', 1, NULL, NULL, 'F', 2, NULL, NULL, 50, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2002-06-16', 4, ' ', '1F', '2A', 
		 NULL, 'F', 1, NULL, NULL, 'A', 2, NULL, NULL, 51, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 



	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2002-06-16', 4, ' ', '1B', '2E', 
		 NULL, 'B', 1, NULL, NULL, 'E', 2, NULL, NULL, 52, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2002-06-17', 4, ' ', '1G', '2D', 
		 NULL, 'G', 1, NULL, NULL, 'D', 2, NULL, NULL, 53, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2002-06-17', 4, ' ', '1C', '2H', 
		 NULL, 'C', 1, NULL, NULL, 'H', 2, NULL, NULL, 54, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2002-06-18', 4, ' ', '1F', '2C', 
		 NULL, 'F', 1, NULL, NULL, 'C', 2, NULL, NULL, 55, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Oitavas de Final', '', NULL, NULL, '2002-06-18', 4, ' ', '1D', '2G', 
		 NULL, 'D', 1, NULL, NULL, 'G', 2, NULL, NULL, 56, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		 


	-- QUARTAS DE FINAL

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Quartas de Final' AND @NomeCampeonato = NomeCampeonato))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	(@NomeCampeonato, 'Quartas de Final', NULL, @Usuario, GetDate(), @Usuario, GetDate(), 0) 
	
	
	
	DECLARE @PendTime1 int
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '50'
	   
	
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
		(@NomeCampeonato, 'Quartas de Final', '', NULL, NULL, '2002-06-21', 5, ' ', 'Vencedor jogo 50', 'Vencedor jogo 54', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 57, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
	
	
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '49'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '53'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Quartas de Final', '', NULL, NULL, '2002-06-21', 5, ' ', 'Vencedor jogo 49', 'Vencedor jogo 53', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 58, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '52'
	   
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
		(@NomeCampeonato, 'Quartas de Final', '', NULL, NULL, '2002-06-22', 5, ' ', 'Vencedor jogo 52', 'Vencedor jogo 56', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 59, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
		
		
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '51'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '55'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Quartas de Final', '', NULL, NULL, '2002-06-22', 5, ' ', 'Vencedor jogo 51', 'Vencedor jogo 55', 
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
	   AND JogoLabel = '59'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		(@NomeCampeonato, 'Semi Finais', '', NULL, NULL, '2002-06-25', 6, ' ', 'Vencedor jogo 58', 'Vencedor jogo 59', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 61, @Usuario, GetDate(), @Usuario, GetDate(), 0, 0)
				



	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato =@NomeCampeonato 
	   AND JogoLabel = '57'
	   
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
		(@NomeCampeonato, 'Semi Finais', '', NULL, NULL, '2002-06-26', 6, ' ', 'Vencedor jogo 57', 'Vencedor jogo 60', 
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
		(@NomeCampeonato, 'Final', '', NULL, NULL, '2002-06-29', 7, ' ', 'Perdedor jogo 61', 'Perdedor jogo 62', 
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
		(@NomeCampeonato, 'Final', '', NULL, NULL, '2002-06-30', 7, ' ', 'Vencedor jogo 61', 'Vencedor jogo 62', 
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
