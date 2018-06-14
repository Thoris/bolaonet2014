IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_Load_Acertos_Dificeis')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_Load_Acertos_Dificeis
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_Load_Acertos_Dificeis]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@TotalAcertos						int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	


	DECLARE @JOGOS AS TABLE
	(
		IdJogo			int, 
		NomeBolao		varchar(30),
		NomeCampeonato	varchar(50)
	)

	INSERT @JOGOS
	SELECT IdJogo, NomeBolao, NomeCampeonato
	  FROM JogosUsuarios
	 WHERE NomeBolao = @NomeBolao
	   AND IsPlacarCheio = 1
	 GROUP BY IdJogo, NomeBolao, NomeCampeonato
	HAVING COUNT(*) <= @TotalAcertos


	SELECT jog.*, usu.UserName, usu.DataAposta, usu.Automatico, usu.NomeBolao, usu.Pontos
	  FROM @JOGOS aux
	 INNER JOIN JogosUsuarios usu
		ON usu.NomeBolao		= aux.NomeBolao
	   AND usu.NomeCampeonato	= aux.NomeCampeonato
	   AND usu.IdJogo			= aux.IdJogo
	   AND usu.IsPlacarCheio	= 1
	 INNER JOIN Jogos jog
		ON usu.NomeCampeonato	= jog.NomeCampeonato
	   AND usu.IdJogo			= jog.IdJogo
	 ORDER BY jog.Rodada, jog.IdJogo


	 

	RETURN @@RowCount

END



GO
