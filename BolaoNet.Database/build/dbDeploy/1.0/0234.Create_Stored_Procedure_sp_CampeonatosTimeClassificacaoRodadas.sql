IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_CampeonatosTimeClassificacaoRodadas')
BEGIN
	DROP  Procedure  sp_CampeonatosTimeClassificacaoRodadas
END
GO
CREATE PROCEDURE [dbo].[sp_CampeonatosTimeClassificacaoRodadas]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(30),
	@NomeGrupo							varchar(20) = NULL,
	@NomeTime							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN


	DECLARE @MaxRodada			int
	DECLARE @Rodada				int
	
	
	DECLARE @Classificacao TABLE
		(
			Rodada			int,
			Posicao			int
		)
		
	
	
	SET @Rodada = 3


	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL


	SELECT @MaxRodada = Max(Rodada)
	  FROM CampeonatosClassificacao l
	 WHERE l.NomeCampeonato		= @NomeCampeonato
	   AND l.NomeGrupo			= @NomeGrupo
	   AND l.NomeFase			= @NomeFase		   

	DECLARE @Counter int
	DECLARE @CurrentPosition int
	
	SET @Counter = 1
	WHILE (@Counter <= @MaxRodada)
	BEGIN
	

		SELECT @CurrentPosition = Posicao 
		  FROM CampeonatosClassificacao l
		 WHERE l.NomeCampeonato		= @NomeCampeonato
		   AND l.NomeGrupo			= @NomeGrupo
		   AND l.NomeFase			= @NomeFase
		   AND l.NomeTime			= @NomeTime
		   AND l.Rodada				= @Counter					   


		INSERT INTO @Classificacao (Rodada,Posicao) VALUES (@Counter, @CurrentPosition)

	
		SET @Counter = @Counter + 1
	END

	SELECT * FROM @Classificacao ORDER BY Rodada

	RETURN @@RowCount	  	
	
	
END



GO
