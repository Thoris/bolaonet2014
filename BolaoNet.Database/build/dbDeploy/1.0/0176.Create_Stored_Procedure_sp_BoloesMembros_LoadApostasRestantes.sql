IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembros_LoadApostasRestantes')
BEGIN
	DROP  Procedure  sp_BoloesMembros_LoadApostasRestantes
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembros_LoadApostasRestantes]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	DECLARE @Nomecampeonato			varchar(50)
	DECLARE @TotalJogos				int
	DECLARE @TaxaParticipacao		decimal

	
	
	--Buscando o nome do campeonato
	SELECT	@Nomecampeonato		= Nomecampeonato,
			@TaxaParticipacao	= ISNULL(TaxaParticipacao, 0)
	  FROM Boloes
	 WHERE Nome = @NomeBolao
	
	-- Buscando a quantidade de jogos do campeonato
	SELECT @TotalJogos = ISNULL(Count(*),0) 
	  FROM Jogos
	 WHERE NomeCampeonato = @NomeCampeonato
	
	
	PRINT 'Taxa: ' + CONVERT(VARCHAR, @TaxaParticipacao)
	
	SELECT BoloesMembros.*, Users.FullName, Users.Email,
		(
			SELECT @TotalJogos - ISNULL(COUNT(*),0) 
			  FROM JogosUsuarios
			 WHERE JogosUsuarios.NomeBolao		= @NomeBolao
			   AND JogosUsuarios.Nomecampeonato	= @NomeCampeonato
			   AND JogosUsuarios.UserName		= Users.UserName
		) as 'Restantes',
		
		ISNULL(
			(
			SELECT @TaxaParticipacao - ISNULL(SUM(Pagamentos.Valor), 0)
			  FROM Pagamentos
			 WHERE Pagamentos.NomeBolao			= @NomeBolao
			   AND Pagamentos.UserName			= Users.UserName
			 GROUP BY Pagamentos.NomeBolao, Pagamentos.UserName
			)
		, @TaxaParticipacao) as 'Pago'
		
		
	  FROM BoloesMembros
	 INNER JOIN Users
	    ON BoloesMembros.UserName		= Users.UserName
	 WHERE BoloesMembros.NomeBolao		= @NomeBolao
	 ORDER BY BoloesMembros.UserName
		
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
