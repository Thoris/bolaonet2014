IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '_CreateTestBaseBolao2010')
BEGIN
	DROP  Procedure  _CreateTestBaseBolao2010
END
GO



CREATE PROCEDURE [dbo].[_CreateTestBaseBolao2010]
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE	@ErrorNumber int,
		@ErrorDescription varchar(4000)			

	DECLARE @UserLogin VARCHAR(100)

	DECLARE @CurrentLogin	varchar(25)
	SET @CurrentLogin = 'Admin'
	
	DECLARE @BolaoId int	
	DECLARE @UserId int
	DECLARE @NomeBolao varchar(50)
	DECLARE @Random int
	
	DECLARE @NomeCampeonato varchar(50)
	SET @NomeCampeonato = 'Copa do Mundo 2010'
	


	SET @BolaoId = 0
	-- LOOP para armazenar os boloes
	WHILE @BolaoId < 10 
	BEGIN
		SET @BolaoId = @bolaoId + 1
	
	
		SET @NomeBolao = 'Copa 2010 Test ' + CONVERT(VARCHAR, @BolaoId)
	
		PRINT 'Criando Bolão:' + @NomeBolao
	
	    
	
		SELECT @Random = ROUND(100 * RAND(), 0)	
		-- CRIANDO O BOLAO
		IF (NOT EXISTS (SELECT * FROM Boloes WHERE Nome = @NomeBolao))
			INSERT INTO Boloes
				(Nome, NomeCampeonato, IsIniciado, TaxaParticipacao, DataInicio, ApostasApenasAntes, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
			 VALUES
				(@NomeBolao, @NomeCampeonato, 0, @Random, '2010-06-10', 1, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
			
	
		-- APLICANDO OS PRÊMIOS
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
			
	
	
	
	
		-- INDICANDO AS APOSTAS EXTRAS DISPONÍVEIS
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
			
		
	
	
	
		SELECT @Random = ROUND(5 * RAND() + 1, 0)	
		-- INDICANDO CRITERIO DE PONTOS PARA O BRASIL
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontosTimes WHERE NomeBolao = @NomeBolao AND NomeTime = 'Brasil'))
			INSERT INTO BOloesCriteriosPontosTimes
				(NomeBolao, NomeTime, Multiplo, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
			 VALUES 
				(@NomeBolao, 'Brasil', @Random, @CurrentLogin, GetDate(), @CurrentLogin, GetDate(), 0)
			
			
			
			
			
			
		SELECT @Random = ROUND(5 * RAND(), 0)	
		-- APLICANDO OS VALORES DOS CRITERIOS
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 1))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (1, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
			
		SELECT @Random = ROUND(5 * RAND(), 0)			
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 2))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (2, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 3))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (3, @NomeBolao, 2, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)			
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 4))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (4, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 5))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (5, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 6))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (6, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 7))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (7, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 8))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (8, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 9))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (9, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 10))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (10, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 11))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (11, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 12))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (12, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 13))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (13, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 14))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (14, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 15))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (15, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 16))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (16, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)

		SELECT @Random = ROUND(5 * RAND(), 0)	
		IF (NOT EXISTS (SELECT * FROM BoloesCriteriosPontos	WHERE NomeBolao = @NomeBolao AND CriterioID = 17))
			INSERT INTO BoloesCriteriosPontos (CriterioID, NomeBolao, Pontos, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy, ActiveFlag)
			 VALUES (17, @NomeBolao, @Random, Getdate(), @CurrentLogin, Getdate(), @CurrentLogin, 0)
			
			



		EXEC	[sp_BoloesMembros_Add]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = NULL,
					@NomeBolao = @NomeBolao,
					@UserName = 'Admin',
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT	
			
	END	
			

	SET @UserId = 0
	-- LOOP para armazenar os usuários
	WHILE @UserId < 20 
	BEGIN
		SET @UserId = @UserId + 1
	

		SET @UserLogin = 'User_' + CONVERT(VARCHAR, @UserId)

		PRINT 'Criando Usuário: ' + @UserLogin

		--Criando o usuário
		EXEC [Framework_CreateUser]
			@CurrentLogin = @CurrentLogin,
			@ApplicationName = NULL,
			@UserName = @UserLogin,
			@FullName = @UserLogin,
			@BirthDate = NULL,
			@Male = NULL,
			@CellPhone = NULL,
			@PhoneNumber = NULL,
			@CompanyPhone = NULL,
			@City = NULL,
			@Country = NULL,
			@State = NULL,
			@Street = NULL,
			@StreetNumber = NULL,
			@CPF = NULL,
			@RG = NULL,
			@MSN = NULL,
			@Skype = NULL,
			@Email = NULL,
			@IDMaritalStatus = NULL,
			@PostalCode = NULL,
			@IsApproved = true,
			@IsLockedOut = false,
			@PasswordQuestion = @UserLogin,
			@PasswordAnswer = @UserLogin,
			@Password = @UserLogin,
			@UniqueEmail = NULL,
			@PasswordFormat = NULL,
			@ActivateKey = NULL,
			@ErrorNumber = @ErrorNumber OUTPUT,
			@ErrorDescription = @ErrorDescription OUTPUT


			-- Adicionando os roles para o usuário
			EXEC	[Framework_AddUserToRole]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = NULL,
					@RoleName = 'Apostador',
					@UserName = @UserLogin,
					@Description = NULL,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT

			EXEC	[Framework_AddUserToRole]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = NULL,
					@RoleName = 'Visitante de Bolão',
					@UserName = @UserLogin,
					@Description = NULL,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT

			EXEC	[Framework_AddUserToRole]
					@CurrentLogin = @CurrentLogin,
					@ApplicationName = NULL,
					@RoleName = 'Visitante de Campeonato',
					@UserName = @UserLogin,
					@Description = NULL,
					@ErrorNumber = @ErrorNumber OUTPUT,
					@ErrorDescription = @ErrorDescription OUTPUT



			SET @BolaoId = 0
			-- LOOP para armazenar os boloes
			WHILE @BolaoId < 20 
			BEGIN
				SET @BolaoId = @bolaoId + 1

				SELECT @Random = ROUND(1 * RAND(), 0)

				IF (@Random = 1) 
				BEGIN

					


					SET @NomeBolao = 'Copa 2010 Test ' + CONVERT(VARCHAR, @BolaoId)
	
					PRINT 'Usuário do bolão: ' + @NomeBolao
	

					EXEC	[sp_BoloesMembros_Add]
								@CurrentLogin = @CurrentLogin,
								@ApplicationName = NULL,
								@NomeBolao = @NomeBolao,
								@UserName = @UserLogin,
								@ErrorNumber = @ErrorNumber OUTPUT,
								@ErrorDescription = @ErrorDescription OUTPUT					




					EXEC	[sp_JogosUsuarios_ApostasAutomatica]
								@CurrentLogin = @CurrentLogin,
								@ApplicationName = NULL,
								@NomeBolao = @NomeBolao,
								@TipoAutomatico = 0,  --TODOS
								@TipoAposta = 0, --TODOS
								@Rodada = NULL,
								@DataInicial = NULL,
								@DataFinal = NULL,
								@NomeTime = NULL,
								@UserName = @UserLogin,
								@GolsTime1 = NULL,
								@GolsTime2 = NULL,
								@RandomInicial = 0,
								@RandomFinal = 5,
								@Randomizado = 1,
								@ErrorNumber = @ErrorNumber OUTPUT,
								@ErrorDescription = @ErrorDescription OUTPUT



				END

			END

							
	END
	
	

END



GO
