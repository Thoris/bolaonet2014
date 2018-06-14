IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '_Insert_Copa_do_Mundo_2006')
BEGIN
	DROP  Procedure  _Insert_Copa_do_Mundo_2006
END
GO

CREATE PROCEDURE [dbo].[_Insert_Copa_do_Mundo_2006]
AS
BEGIN

	DECLARE @Usuario VARCHAR(100)
	SET @Usuario = 'Admin'
	DECLARE @NomeCampeonato VARCHAR(100)
	SET @NomeCampeonato = 'Copa do Mundo 2006'

	DECLARE @NomeFase VARCHAR(100)
	DECLARE @NomeGrupo VARCHAR(100)
	DECLARE @Rodada int
	SET @NomeFase = 'Classificatória'
	SET @NomeGrupo = NULL
	SET @Rodada = NULL


	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 4, NULL, NULL, 2, NULL, @Rodada, '1'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 2, NULL, @Rodada, '2'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '17'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 0, NULL, @Rodada, '18'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 3, NULL, @Rodada, '33'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 2, NULL, @Rodada, '34'
	
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '3'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 0, NULL, @Rodada, '4'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 0, NULL, @Rodada, '19'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '20'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 2, NULL, @Rodada, '35'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 0, NULL, @Rodada, '36'
 	
    EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '5'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 1, NULL, @Rodada, '6'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 6, NULL, NULL, 0, NULL, @Rodada, '21'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '22'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 0, NULL, @Rodada, '37'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 2, NULL, @Rodada, '38'
	
    EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 1, NULL, @Rodada, '7'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 1, NULL, @Rodada, '8'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 0, NULL, @Rodada, '23'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 0, NULL, @Rodada, '24'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '39'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 1, NULL, @Rodada, '40'
	
    EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 0, NULL, @Rodada, '9'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 3, NULL, @Rodada, '10'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 1, NULL, @Rodada, '25'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 2, NULL, @Rodada, '26'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 2, NULL, @Rodada, '41'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '42'
	
    EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '11'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 1, NULL, @Rodada, '12'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 0, NULL, @Rodada, '27'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 0, NULL, @Rodada, '28'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 4, NULL, @Rodada, '43'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 2, NULL, @Rodada, '44'
	
    EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 0, NULL, @Rodada, '13'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '14'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 1, NULL, @Rodada, '29'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 2, NULL, @Rodada, '30'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 2, NULL, @Rodada, '45'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 0, NULL, @Rodada, '46'
	
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 4, NULL, NULL, 0, NULL, @Rodada, '15'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 2, NULL, @Rodada, '16'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 1, NULL, @Rodada, '31'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 4, NULL, @Rodada, '32'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 1, NULL, @Rodada, '47'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '48'
	

	-- Oitavas de final
	
	SET @NomeFase = 'Oitavas de Final'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 0, NULL, @Rodada, '49'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '50'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '51'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '52'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '53'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0,    0, NULL, 0,    3, @Rodada, '54'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 0, NULL, @Rodada, '55'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 3, NULL, @Rodada, '56'
	 
	-- Quartas de Final
	
	SET @NomeFase = 'Quartas de Final'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1,    4, NULL, 1,    2, @Rodada, '57'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 0, NULL, @Rodada, '58'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0,    1, NULL, 0,    3, @Rodada, '59'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 1, NULL, @Rodada, '60'
	 
	-- Semi Final
	
	SET @NomeFase = 'Semi Finais'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 2, NULL, @Rodada, '61'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 1, NULL, @Rodada, '62'
	
	--Final
	
	SET @NomeFase = 'Final'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 1, NULL, @Rodada, '63'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1,    5, NULL, 1,    3, @Rodada, '64'
	
		
END