IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_Next_Jogo')
BEGIN
	DROP  Procedure  sp_Jogos_Next_Jogo
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_Next_Jogo]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @NextDate DATETIME
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	


	SELECT @NextDate = min(datajogo)
	  FROM Jogos 
	 WHERE DataJogo > GETDATE()
	   and (@NomeCampeonato IS NULL OR @NomeCampeonato = '' OR @NomeCampeonato = NomeCampeonato)

	IF (@NextDate IS NULL)
	BEGIN
		RETURN -1
	END

	IF (@NextDate < GETDATE())
	BEGIN
		RETURN -2
	END
	
	SELECT DATEDIFF(day, GetDate(), @NextDate) as total


	RETURN 1

END



GO
