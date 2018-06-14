IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '_CreateBolaoCopaDoMundo2014')
BEGIN
	DROP  Procedure  _CreateBolaoCopaDoMundo2014
END
GO



CREATE PROCEDURE [dbo].[_CreateBolaoCopaDoMundo2014]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	
	DECLARE @NomeBolao varchar(50)
	SET @NomeBolao = 'Copa do Mundo 2014'
	
	DECLARE @NomeCampeonato varchar(50)
	SET @NomeCampeonato = 'Copa do Mundo 2014'
	
	DECLARE @CurrentLogin	varchar(25)
	SET @CurrentLogin = 'Admin'
	
	
	
	IF (NOT EXISTS (SELECT * FROM Boloes WHERE Nome = @NomeBolao))
		INSERT INTO Boloes
			(Nome, NomeCampeonato, IsIniciado, TaxaParticipacao, DataInicio, ApostasApenasAntes, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(@NomeBolao, @NomeCampeonato, 0, 20.000, '2010-06-11', 1, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
			
	
	
	IF (NOT EXISTS (SELECT * FROM BoloesPremios WHERE NomeBolao = @NomeBolao AND Posicao = 1))
		INSERT INTO BoloesPremios
			(Posicao, NomeBolao, Titulo, BackColor, FOreColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(1, @NomeBolao, 'Campeão', 'Green', 'White', @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
			
			
	IF (NOT EXISTS (SELECT * FROM BoloesPremios WHERE NomeBolao = @NomeBolao AND Posicao = 2))
		INSERT INTO BoloesPremios
			(Posicao, NomeBolao, Titulo, BackColor, FOreColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(2, @NomeBolao, 'Vice-Campeão', 'Yellow', 'White', @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
			

	IF (NOT EXISTS (SELECT * FROM BoloesPremios WHERE NomeBolao = @NomeBolao AND Posicao = 3))
		INSERT INTO BoloesPremios
			(Posicao, NomeBolao, Titulo, BackColor, FOreColor, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(3, @NomeBolao, 'Terceiro', 'Blue', 'Black', @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
	
	
	
	iF (NOT EXISTS (SELECT * FROM ApostasExtras WHERE NomeBolao = @NomeBolao AND Posicao = 1))
		INSERT INTO ApostasExtras
			(Posicao, NomeBolao, Titulo, TotalPontos, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(1, @NomeBolao, 'Campeão', 15, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
	

	iF (NOT EXISTS (SELECT * FROM ApostasExtras WHERE NomeBolao = @NomeBolao AND Posicao = 2))
		INSERT INTO ApostasExtras
			(Posicao, NomeBolao, Titulo, TotalPontos, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(2, @NomeBolao, 'Vice-Campeão', 15, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
		

	iF (NOT EXISTS (SELECT * FROM ApostasExtras WHERE NomeBolao = @NomeBolao AND Posicao = 3))
		INSERT INTO ApostasExtras
			(Posicao, NomeBolao, Titulo, TotalPontos, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(3, @NomeBolao, 'Terceiro Lugar', 15, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
			
	iF (NOT EXISTS (SELECT * FROM ApostasExtras WHERE NomeBolao = @NomeBolao AND Posicao = 4))
		INSERT INTO ApostasExtras
			(Posicao, NomeBolao, Titulo, TotalPontos, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(4, @NomeBolao, 'Quarto Lugar', 15, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
			
		
	
	
	
	
	
	
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontosTimes WHERE NomeBolao = @NomeBolao AND NomeTime = 'Brasil'))
		INSERT INTO BOloesCriteriosPontosTimes
			(NomeBolao, NomeTime, Multiplo, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES 
			(@NomeBolao, 'Brasil', 2, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
			
			
			
			
			
			
			
			
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 1))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (1, @NomeBolao, 2, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
			
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 2))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (2, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 3))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (3, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 4))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (4, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 5))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (5, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 6))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (6, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 7))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (7, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 8))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (8, @NomeBolao, 3, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 9))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (9, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 10))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (10, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 11))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (11, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 12))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (12, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 13))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (13, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 14))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (14, @NomeBolao, -2, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 15))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (15, @NomeBolao, 1, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 16))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (16, @NomeBolao, 1, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 17))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (17, @NomeBolao, 5, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
			


	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 1 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 1, 
			'Premiação para o primeiro lugar: 70% do dinheiro arrecadado')			
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 2 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 2, 
			'Premiação para o segundo lugar: 20% do dinheiro arrecadado')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 3 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 3, 
			'Premiação para o terceiro lugar: 10% do dinheiro arrecadado')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 4 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 4, 
			'havendo dois primeiros lugares, 45% para cada e o próximo leva 10%; havendo empate no segundo lugar, divide-se entre eles os 30% (se dois empatarem 15% para cada)')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 5 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 5, 
			'Se caso a aposta não foi realizado, será considerado o placar de 0x0')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 6 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 6, 
			'A taxa de participação do bolão será de 20 reais')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 7 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 7, 
			'Pontuação:')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 8 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 8, 
			'10 PONTOS - Acertar o resultado em cheio: Ex.: Aposta 2 x 1; Resultado 2 x 1;')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 9 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 9, 
			'5  PONTOS - Acertar o empate errando o número de gols: Ex.: Aposta 1 x 1; Resultado 2 x 2;')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 10 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 10, 
			'4  PONTOS - Acertar vencedor e acertar apenas um dos placares: Ex.: Aposta 2 x 1; Resultado 3 x 1;')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 11 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 11, 
			'3  PONTOS - Acertar apenas o vencedor e errar os placares: Ex.: Aposta 2 x 1; Resultado 1 x 0;')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 12 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 12, 
			'1  PONTO  - Errar o resultado jogo e acertar apenas um dos placares: Ex.: Aposta 2 x 1; Resultado 0 x 1 ou 1 x 1;')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 13 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 13, 
			'0  PONTO  - Para as outras situações.')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 14 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 14, 
			'Com relação ao resultado dos 4 primeiros: Valerá apenas 15 pontos cada acerto.')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 15 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 15, 
			'Obs.: Na medida que vc vai apostando o software vai fazendo uma previsão de quem serão os classificados.')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 16 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 16, 
			'Porém, ainda que na sua aposta esteja aparecendo Brasil 2 x 1 Chile, o no jogo real seja Portugal x Chile, vale o resultado.')
	IF (NOT EXISTS(SELECT * FROM BoloesRegras WHERE RegraID = 17 AND NomeBolao = @NomeBolao))
		INSERT INTO BoloesRegras (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, NomeBolao, RegraID, Description) 
		VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, @NomeBolao, 17, 
			'Ou seja, vc estará apostando no primeiro classificado do grupo A x Segundo classificado do grupo B, independente do time que classificar.')










	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 0	,'Erro', 'White','Red','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 1	,'Gols', 'Black','Cyan','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 2	,'Gols - Brasil','Black','Cyan','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 3	,'Vencedor', 'Black','Gray','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 4	,'Vencedor + Gols','Black','Blue','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 5	,'Empate','Black','Yellow','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 6	,'Vencedor - Brasil','Black','Gray','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 8	,'Venc+Gols+Br','Black','Blue','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 10	,'Cheio','White','Green','Copa do Mundo 2014')
	INSERT INTO BoloesPontuacao (CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag, Pontos, Titulo, ForeColor, BackColor, NomeBolao)
	VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 20	,'Cheio - Brasil','White','Green','Copa do Mundo 2014')







END



GO
