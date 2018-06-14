IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CreateCampeonatoCopadoMundo2010')
BEGIN
	DROP  Procedure  CreateCampeonatoCopadoMundo2010
END
GO

CREATE PROCEDURE [dbo].[CreateCampeonatoCopadoMundo2010]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



	IF (NOT EXISTS (SELECT * FROM Campeonatos WHERE Nome = 'Copa do Mundo 2010'))
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
			'Copa do Mundo 2010',
			0,
			0,
			CONVERT(DATETIME, '2010-06-10'),
			'Admin',
			GetDate(),
			'Admin',
			GetDate(),
			0
		)



	-- Inserindo os jogos
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'A', NULL, 'África do Sul', NULL, NULL,  NULL, 'México', NULL, NULL,  NULL, '2010-06-11 11:00:00.000', 1,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'A', NULL, 'Uruguai', NULL, NULL,  NULL, 'França', NULL, NULL,  NULL, '2010-06-11 15:30:00.000', 1,0, 'Cidade do Cabo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'A', NULL, 'África do Sul', NULL, NULL,  NULL, 'Uruguai', NULL, NULL,  NULL, '2010-06-16 15:30:00.000', 2,0, 'Pretória', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'A', NULL, 'França', NULL, NULL,  NULL, 'México', NULL, NULL,  NULL, '2010-06-17 15:30:00.000', 2,0, 'Polokwane', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'A', NULL, 'México', NULL, NULL,  NULL, 'Uruguai', NULL, NULL,  NULL, '2010-06-22 11:00:00.000', 3,0, 'Rustenburg', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'A', NULL, 'França', NULL, NULL,  NULL, 'África do Sul', NULL, NULL,  NULL, '2010-06-22 11:00:00.000', 3,0, 'Bloemfontein', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'B', NULL, 'Coreia do Sul', NULL, NULL,  NULL, 'Grécia', NULL, NULL,  NULL, '2010-06-12 08:30:00.000', 1,0, 'Port Elizabeth', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'B', NULL, 'Argentina', NULL, NULL,  NULL, 'Nigéria', NULL, NULL,  NULL, '2010-06-12 11:00:00.000', 1,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'B', NULL, 'Argentina', NULL, NULL,  NULL, 'Coreia do Sul', NULL, NULL,  NULL, '2010-06-17 08:30:00.000', 2,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'B', NULL, 'Grécia', NULL, NULL,  NULL, 'Nigéria', NULL, NULL,  NULL, '2010-06-17 11:00:00.000', 2,0, 'Bloemfontein', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'B', NULL, 'Nigéria', NULL, NULL,  NULL, 'Coreia do Sul', NULL, NULL,  NULL, '2010-06-22 15:30:00.000', 3,0, 'Durban', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'B', NULL, 'Grécia', NULL, NULL,  NULL, 'Argentina', NULL, NULL,  NULL, '2010-06-22 15:30:00.000', 3,0, 'Polokwane', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'C', NULL, 'Inglaterra', NULL, NULL,  NULL, 'Estados Unidos', NULL, NULL,  NULL, '2010-06-12 15:30:00.000', 1,0, 'Rustenburg', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'C', NULL, 'Argélia', NULL, NULL,  NULL, 'Eslovênia', NULL, NULL,  NULL, '2010-06-13 08:30:00.000', 1,0, 'Polokwane', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'C', NULL, 'Eslovênia', NULL, NULL,  NULL, 'Estados Unidos', NULL, NULL,  NULL, '2010-06-18 11:00:00.000', 2,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'C', NULL, 'Inglaterra', NULL, NULL,  NULL, 'Argélia', NULL, NULL,  NULL, '2010-06-18 15:30:00.000', 2,0, 'Cidade do Cabo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'C', NULL, 'Eslovênia', NULL, NULL,  NULL, 'Inglaterra', NULL, NULL,  NULL, '2010-06-23 11:00:00.000', 3,0, 'Port Elizabeth', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'C', NULL, 'Estados Unidos', NULL, NULL,  NULL, 'Argélia', NULL, NULL,  NULL, '2010-06-23 11:00:00.000', 3,0, 'Pretória', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'D', NULL, 'Sérvia', NULL, NULL,  NULL, 'Gana', NULL, NULL,  NULL, '2010-06-13 11:00:00.000', 1,0, 'Pretória', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'D', NULL, 'Alemanha', NULL, NULL,  NULL, 'Austrália', NULL, NULL,  NULL, '2010-06-13 15:30:00.000', 1,0, 'Durban', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'D', NULL, 'Alemanha', NULL, NULL,  NULL, 'Sérvia', NULL, NULL,  NULL, '2010-06-18 08:30:00.000', 2,0, 'Port Elizabeth', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'D', NULL, 'Gana', NULL, NULL,  NULL, 'Austrália', NULL, NULL,  NULL, '2010-06-19 11:00:00.000', 2,0, 'Rustenburg', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'D', NULL, 'Gana', NULL, NULL,  NULL, 'Alemanha', NULL, NULL,  NULL, '2010-06-23 15:30:00.000', 3,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'D', NULL, 'Austrália', NULL, NULL,  NULL, 'Sérvia', NULL, NULL,  NULL, '2010-06-23 15:30:00.000', 3,0, 'Nelspruit', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'E', NULL, 'Holanda', NULL, NULL,  NULL, 'Dinamarca', NULL, NULL,  NULL, '2010-06-14 08:30:00.000', 1,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'E', NULL, 'Japão', NULL, NULL,  NULL, 'Camarões', NULL, NULL,  NULL, '2010-06-14 11:00:00.000', 1,0, 'Bloemfontein', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'E', NULL, 'Holanda', NULL, NULL,  NULL, 'Japão', NULL, NULL,  NULL, '2010-06-19 08:30:00.000', 2,0, 'Durbain', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'E', NULL, 'Camarões', NULL, NULL,  NULL, 'Dinamarca', NULL, NULL,  NULL, '2010-06-19 15:30:00.000', 2,0, 'Pretória', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'E', NULL, 'Dinamarca', NULL, NULL,  NULL, 'Japão', NULL, NULL,  NULL, '2010-06-24 15:30:00.000', 3,0, 'Rustenburg', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'E', NULL, 'Camarões', NULL, NULL,  NULL, 'Holanda', NULL, NULL,  NULL, '2010-06-24 15:30:00.000', 3,0, 'Cidade do Cabo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'F', NULL, 'Itália', NULL, NULL,  NULL, 'Paraguai', NULL, NULL,  NULL, '2010-06-14 15:30:00.000', 1,0, 'Cidade do Cabo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'F', NULL, 'Nova Zelândia', NULL, NULL,  NULL, 'Eslováquia', NULL, NULL,  NULL, '2010-06-15 08:30:00.000', 1,0, 'Rustenburg', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'F', NULL, 'Eslováquia', NULL, NULL,  NULL, 'Paraguai', NULL, NULL,  NULL, '2010-06-20 08:30:00.000', 2,0, 'Bloemfontein', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'F', NULL, 'Itália', NULL, NULL,  NULL, 'Nova Zelândia', NULL, NULL,  NULL, '2010-06-20 11:00:00.000', 2,0, 'Nelspruit', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'F', NULL, 'Eslováquia', NULL, NULL,  NULL, 'Itália', NULL, NULL,  NULL, '2010-06-24 11:00:00.000', 3,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'F', NULL, 'Paraguai', NULL, NULL,  NULL, 'Nova Zelândia', NULL, NULL,  NULL, '2010-06-24 11:00:00.000', 3,0, 'Polokwane', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'G', NULL, 'Costa do Marfim', NULL, NULL,  NULL, 'Portugal', NULL, NULL,  NULL, '2010-06-15 11:00:00.000', 1,0, 'Port Elizabeth', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'G', NULL, 'Brasil', NULL, NULL,  NULL, 'Coreia do Norte', NULL, NULL,  NULL, '2010-06-15 15:30:00.000', 1,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'G', NULL, 'Brasil', NULL, NULL,  NULL, 'Costa do Marfim', NULL, NULL,  NULL, '2010-06-20 15:30:00.000', 2,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'G', NULL, 'Portugal', NULL, NULL,  NULL, 'Coreia do Norte', NULL, NULL,  NULL, '2010-06-21 08:30:00.000', 2,0, 'Cidade do Cabo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'G', NULL, 'Portugal', NULL, NULL,  NULL, 'Brasil', NULL, NULL,  NULL, '2010-06-25 11:00:00.000', 3,0, 'Durban', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'G', NULL, 'Coreia do Norte', NULL, NULL,  NULL, 'Costa do Marfim', NULL, NULL,  NULL, '2010-06-25 11:00:00.000', 3,0, 'Nelspruit', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'H', NULL, 'Honduras', NULL, NULL,  NULL, 'Chile', NULL, NULL,  NULL, '2010-06-16 08:30:00.000', 1,0, 'Nelspruit', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'H', NULL, 'Espanha', NULL, NULL,  NULL, 'Suíça', NULL, NULL,  NULL, '2010-06-16 11:00:00.000', 1,0, 'Durban', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'H', NULL, 'Chile', NULL, NULL,  NULL, 'Suíça', NULL, NULL,  NULL, '2010-06-21 11:00:00.000', 2,0, 'Port Elizabeth', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'H', NULL, 'Espanha', NULL, NULL,  NULL, 'Honduras', NULL, NULL,  NULL, '2010-06-21 15:30:00.000', 2,0, 'Johanesburgo', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'H', NULL, 'Chile', NULL, NULL,  NULL, 'Espanha', NULL, NULL,  NULL, '2010-06-25 15:30:00.000', 3,0, 'Pretória', NULL, NULL
	EXEC sp_Jogos_InsertAllData 'Admin', NULL, 'Copa do Mundo 2010', 0, 'Classificatória', 'H', NULL, 'Suíça', NULL, NULL,  NULL, 'Honduras', NULL, NULL,  NULL, '2010-06-25 15:30:00.000', 3,0, 'Bloemfontein', NULL, NULL
	 
	 
	 
	IF (NOT EXISTS (SELECT * FROM CampeonatosGrupos WHERE Nome = ' '))
		INSERT INTO CampeonatosGrupos (NomeCampeonato, Nome, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		VALUES ('Copa do Mundo 2010', ' ', 'Admin', GetDate(), 'Admin', GetDate(), 0)


	-- OITAVAS DE FINAL
	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Oitavas de Final'))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	('Copa do Mundo 2010', 'Oitavas de Final', NULL, 'Admin', GetDate(), 'Admin', GetDate(), 0) 

	
	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Oitavas de Final', 'Port Elizabeth', NULL, NULL, '2010-06-26 11:00:00', 4, ' ', '1A', '2B', 
		 NULL, 'A', 1, NULL, NULL, 'B', 2, NULL, NULL, 49, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		 
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Oitavas de Final', 'Rustenburg', NULL, NULL, '2010-06-26 15:30:00', 4, ' ', '1C', '2D', 
		 NULL, 'C', 1, NULL, NULL, 'D', 2, NULL, NULL, 50, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		 
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Oitavas de Final', 'Bloemfontein', NULL, NULL, '2010-06-27 11:00:00', 4, ' ', '1D', '2C', 
		 NULL, 'D', 1, NULL, NULL, 'C', 2, NULL, NULL, 51, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		 



	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Oitavas de Final', 'Johanesburgo', NULL, NULL, '2010-06-27 15:30:00', 4, ' ', '1B', '2A', 
		 NULL, 'B', 1, NULL, NULL, 'A', 2, NULL, NULL, 52, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Oitavas de Final', 'Durban', NULL, NULL, '2010-06-28 11:00:00', 4, ' ', '1E', '2F', 
		 NULL, 'E', 1, NULL, NULL, 'F', 2, NULL, NULL, 53, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		 


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Oitavas de Final', 'Johanesburgo', NULL, NULL, '2010-06-28 15:30:00', 4, ' ', '1G', '2H', 
		 NULL, 'G', 1, NULL, NULL, 'H', 2, NULL, NULL, 54, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		 

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Oitavas de Final', 'Pretória', NULL, NULL, '2010-06-29 11:00:00', 4, ' ', '1F', '2E', 
		 NULL, 'F', 1, NULL, NULL, 'E', 2, NULL, NULL, 55, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		 

	IF (NOT EXISTS(SELECT * FROM Estadios WHERE Nome = 'Cape Town'))
		INSERT INTO Estadios   (Nome, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag) 
		 VALUES   ('Cape Town', 'Admin', Getdate(), 'Admin', Getdate(), 0)


	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Oitavas de Final', 'Cape Town', NULL, NULL, '2010-06-29 15:30:00', 4, ' ', '1H', '2G', 
		 NULL, 'H', 1, NULL, NULL, 'G', 2, NULL, NULL, 56, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		 


	-- QUARTAS DE FINAL

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Quartas de Final'))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	('Copa do Mundo 2010', 'Quartas de Final', NULL, 'Admin', GetDate(), 'Admin', GetDate(), 0) 
	
	
	
	DECLARE @PendTime1 int
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '53'
	   
	
	DECLARE @PendTime2 int
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '54'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Quartas de Final', 'Port Elizabeth', NULL, NULL, '2010-07-02 11:00:00', 5, ' ', 'Vencedor jogo 53', 'Vencedor jogo 54', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 57, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
	
	
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '49'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '50'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Quartas de Final', 'Johanesburgo', NULL, NULL, '2010-07-02 15:30:00', 5, ' ', 'Vencedor jogo 49', 'Vencedor jogo 50', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 58, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '52'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '51'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Quartas de Final', 'Cape Town', NULL, NULL, '2010-07-03 11:00:00', 5, ' ', 'Vencedor jogo 52', 'Vencedor jogo 51', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 59, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		
		
	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '55'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '56'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Quartas de Final', 'Johanesburgo', NULL, NULL, '2010-07-03 15:30:00', 5, ' ', 'Vencedor jogo 55', 'Vencedor jogo 56', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 60, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
		
				
	

	-- Semi Finais

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Semi finais'))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	('Copa do Mundo 2010', 'Semi finais', NULL, 'Admin', GetDate(), 'Admin', GetDate(), 0) 
		

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '58'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '57'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Semi Finais', 'Cape Town', NULL, NULL, '2010-07-06 15:30:00', 6, ' ', 'Vencedor jogo 58', 'Vencedor jogo 57', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 61, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
				



	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '59'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '60'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Semi Finais', 'Durban', NULL, NULL, '2010-07-07 15:30:00', 6, ' ', 'Vencedor jogo 59', 'Vencedor jogo 60', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 62, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
				


	-- Final

	IF (NOT EXISTS (SELECT * FROM CampeonatosFases WHERE Nome = 'Final'))
		INSERT INTO CampeonatosFases (Nomecampeonato, Nome, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES	('Copa do Mundo 2010', 'Final', NULL, 'Admin', GetDate(), 'Admin', GetDate(), 0) 
			

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '61'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '62'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Final', 'Port Elizabeth', NULL, NULL, '2010-07-10 15:30:00', 7, ' ', 'Perdedor jogo 61', 'Perdedor jogo 62', 
		 NULL, NULL, NULL, @PendTime1, 0, NULL, NULL, @PendTime2, 0, 63, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
				

	SELECT @PendTime1 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '61'
	   
	SELECT @PendTime2 = IDJogo 
	  FROM Jogos 
	 WHERE NomeCampeonato ='Copa do Mundo 2010' 
	   AND JogoLabel = '62'
	   

	INSERT INTO Jogos 
		(NomeCampeonato, NomeFase, NomeEstadio, NomeTime1, NomeTime2, DataJogo, Rodada, NomeGrupo, DescricaoTime1, DescricaoTime2,
		 Titulo, PendenteTime1NomeGrupo, PendenteTime1PosGrupo, PendenteTime1JogoID, PendenteTime1Ganhador, 
		 PendenteTime2NomeGrupo, PendenteTime2PosGrupo, PendenteTime2JogoID,PendenteTime2Ganhador, JogoLabel,
		 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, IsValido) 
	 VALUES
		('Copa do Mundo 2010', 'Final', 'Johanesburgo', NULL, NULL, '2010-07-11 15:30:00', 7, ' ', 'Vencedor jogo 61', 'Vencedor jogo 62', 
		 NULL, NULL, NULL, @PendTime1, 1, NULL, NULL, @PendTime2, 1, 64, 'Admin', GetDate(), 'Admin', GetDate(), 0, 0)
				







	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'A' AND Posicao = 1 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('A', 1, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'A' AND Posicao = 2 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('A', 2, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'B' AND Posicao = 1 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('B', 1, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'B' AND Posicao = 2 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('B', 2, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'C' AND Posicao = 1 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('C', 1, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'C' AND Posicao = 2 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('C', 2, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'D' AND Posicao = 1 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('D', 1, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'D' AND Posicao = 2 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('D', 2, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'E' AND Posicao = 1 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('E', 1, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'E' AND Posicao = 2 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('E', 2, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'F' AND Posicao = 1 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('F', 1, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'F' AND Posicao = 2 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('F', 2, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)


	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'G' AND Posicao = 1 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('G', 1, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'G' AND Posicao = 2 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('G', 2, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)

	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'H' AND Posicao = 1 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('H', 1, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)
		 
	IF (NOT EXISTS(SELECT * FROM CampeonatosPosicoes WHERE NomeGrupo = 'H' AND Posicao = 2 AND NomeCampeonato = 'Copa do Mundo 2010' AND NomeFase = 'Classificatória'))
		INSERT INTO CampeonatosPosicoes (NomeGrupo, Posicao, NomeCampeonato, NomeFase, Titulo, BackColor, ForeColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES ('H', 2, 'Copa do Mundo 2010', 'Classificatória', 'Classificado', 'Green', 'White', 'Admin', GetDate(), 'Admin', GetDate(), 0)




END



GO
