IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CreateBolaoCopaDasConfederacoes2013')
BEGIN
	DROP  Procedure  CreateBolaoCopaDasConfederacoes2013
END
GO




CREATE PROCEDURE [dbo].[CreateBolaoCopaDasConfederacoes2013]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @NomeBolao varchar(50)
	SET @NomeBolao = 'Confederações 2013'
	DECLARE @NomeCampeonato varchar(50)
	SET @NomeCampeonato = 'Confederações 2013'
	DECLARE @CurrentLogin	varchar(25)
	SET @CurrentLogin = 'Admin'
	IF (NOT EXISTS (SELECT * FROM Boloes WHERE Nome = @NomeBolao))
		INSERT INTO Boloes
			(Nome, NomeCampeonato, IsIniciado, TaxaParticipacao, DataInicio, ApostasApenasAntes, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(@NomeBolao, @NomeCampeonato, 0, 10.000, '2013-06-10', 1, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
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
	iF (NOT EXISTS (SELECT * FROM ApostasExtras WHERE NomeBolao = @NomeBolao AND Posicao = 1))
		INSERT INTO ApostasExtras
			(Posicao, NomeBolao, Titulo, TotalPontos, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(1, @NomeBolao, 'Campeão', 50, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
	iF (NOT EXISTS (SELECT * FROM ApostasExtras WHERE NomeBolao = @NomeBolao AND Posicao = 2))
		INSERT INTO ApostasExtras
			(Posicao, NomeBolao, Titulo, TotalPontos, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(2, @NomeBolao, 'Vice-Campeão', 30, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
	iF (NOT EXISTS (SELECT * FROM ApostasExtras WHERE NomeBolao = @NomeBolao AND Posicao = 3))
		INSERT INTO ApostasExtras
			(Posicao, NomeBolao, Titulo, TotalPontos, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(3, @NomeBolao, 'Terceiro Lugar', 20, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
	iF (NOT EXISTS (SELECT * FROM ApostasExtras WHERE NomeBolao = @NomeBolao AND Posicao = 4))
		INSERT INTO ApostasExtras
			(Posicao, NomeBolao, Titulo, TotalPontos, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES
			(4, @NomeBolao, 'Quarto Lugar', 20, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontosTimes WHERE NomeBolao = @NomeBolao AND NomeTime = 'Brasil'))
		INSERT INTO BOloesCriteriosPontosTimes
			(NomeBolao, NomeTime, Multiplo, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		 VALUES 
			(@NomeBolao, 'Brasil', 2, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 1))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (1, @NomeBolao, 1, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 2))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (2, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 3))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (3, @NomeBolao, 2, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
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
		 VALUES (8, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
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
		 VALUES (14, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 15))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (15, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 16))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (16, @NomeBolao, 0, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
	IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 17))
		INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
		 VALUES (17, @NomeBolao, 5, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)


	IF (NOT EXISTS (SELECT * FROM BoloesMembros WHERE NomeBolao = @NomeBolao AND UserName = 'thoris'))
		INSERT INTO [BoloesMembros] ([CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag],[UserName],[NomeBolao])
        VALUES (@CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0, 'thoris', @NomeBolao) 

END
GO