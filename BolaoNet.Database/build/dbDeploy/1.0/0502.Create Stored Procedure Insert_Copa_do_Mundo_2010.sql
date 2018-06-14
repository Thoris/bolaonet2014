IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = '_Insert_Copa_do_Mundo_2010')
BEGIN
	DROP  Procedure  _Insert_Copa_do_Mundo_2010
END
GO

CREATE PROCEDURE [dbo].[_Insert_Copa_do_Mundo_2010]
AS
BEGIN

	DECLARE @Usuario VARCHAR(100)
	SET @Usuario = 'Admin'
	DECLARE @NomeCampeonato VARCHAR(100)
	SET @NomeCampeonato = 'Copa do Mundo 2010'

	DECLARE @NomeFase VARCHAR(100)
	DECLARE @NomeGrupo VARCHAR(100)
	DECLARE @Rodada int
	SET @NomeFase = 'Classificatória'
	SET @NomeGrupo = NULL
	SET @Rodada = NULL


	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'África do Sul', 1, NULL, 'México', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Uruguai', 0, NULL, 'França', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'África do Sul', 0, NULL, 'Uruguai', 3, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'França', 0, NULL, 'México', 2, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'México', 0, NULL, 'Uruguai', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'França', 1, NULL, 'África do Sul', 2, NULL, @Rodada, NULL
	
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Coreia do Sul', 2, NULL, 'Grécia', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Argentina', 1, NULL, 'Nigéria', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Argentina', 4, NULL, 'Coreia do Sul', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Grécia', 2, NULL, 'Nigéria', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Nigéria', 2, NULL, 'Coreia do Sul', 2, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Grécia', 0, NULL, 'Argentina', 2, NULL, @Rodada, NULL
		
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Inglaterra', 1, NULL, 'Estados Unidos', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Argélia', 0, NULL, 'Eslovênia', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Eslovênia', 2, NULL, 'Estados Unidos', 2, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Inglaterra', 0, NULL, 'Argélia', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Eslovênia', 0, NULL, 'Inglaterra', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Estados Unidos', 1, NULL, 'Argélia', 0, NULL, @Rodada, NULL
	
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Sérvia', 0, NULL, 'Gana', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Alemanha', 4, NULL, 'Austrália', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Alemanha', 0, NULL, 'Sérvia', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Gana', 1, NULL, 'Austrália', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Gana', 0, NULL, 'Alemanha', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Austrália', 2, NULL, 'Sérvia', 1, NULL, @Rodada, NULL
	
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Holanda', 2, NULL, 'Dinamarca', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Japão', 1, NULL, 'Camarões', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Holanda', 1, NULL, 'Japão', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Camarões', 1, NULL, 'Dinamarca', 2, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Dinamarca', 1, NULL, 'Japão', 3, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Camarões', 1, NULL, 'Holanda', 2, NULL, @Rodada, NULL
	
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Itália', 1, NULL, 'Paraguai', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Nova Zelândia', 1, NULL, 'Eslováquia', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Eslováquia', 0, NULL, 'Paraguai', 2, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Itália', 1, NULL, 'Nova Zelândia', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Eslováquia', 3, NULL, 'Itália', 2, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Paraguai', 0, NULL, 'Nova Zelândia', 0, NULL, @Rodada, NULL
	
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Costa do Marfim', 0, NULL, 'Portugal', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Brasil', 2, NULL, 'Coreia do Norte', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Brasil', 3, NULL, 'Costa do Marfim', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Portugal', 7, NULL, 'Coreia do Norte', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Portugal', 0, NULL, 'Brasil', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Coreia do Norte', 0, NULL, 'Costa do Marfim', 3, NULL, @Rodada, NULL
	
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Honduras', 0, NULL, 'Chile', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Espanha', 0, NULL, 'Suíça', 1, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Chile', 1, NULL, 'Suíça', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Espanha', 2, NULL, 'Honduras', 0, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Chile', 1, NULL, 'Espanha', 2, NULL, @Rodada, NULL
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, 'Suíça', 0, NULL, 'Honduras', 0, NULL, @Rodada, NULL

	-- Oitavas de final
	
	SET @NomeFase = 'Oitavas de Final'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '49'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 2, NULL, @Rodada, '50'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 4, NULL, NULL, 1, NULL, @Rodada, '51'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 1, NULL, @Rodada, '52'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '53'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 3, NULL, NULL, 0, NULL, @Rodada, '54'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, 5,    NULL, 0, 3,    @Rodada, '55'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, NULL, NULL, 0, NULL, @Rodada, '56'
	 
	-- Quartas de Final
	
	SET @NomeFase = 'Quartas de Final'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 1, NULL, @Rodada, '57'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 1, 4,    NULL, 2, 1,    @Rodada, '58'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 4, NULL, @Rodada, '59'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 1, NULL, @Rodada, '60'
	 
	-- Semi Final
	
	SET @NomeFase = 'Semi Finais'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 3, NULL, @Rodada, '61'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 1, NULL, @Rodada, '62'
	
	--Final
	
	SET @NomeFase = 'Final'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 2, NULL, NULL, 3, NULL, @Rodada, '63'
	EXEC [_Insert_Jogo_Result]	@Usuario, NULL, @NomeCampeonato, @NomeFase, @NomeGrupo, NULL, 0, NULL, NULL, 1, NULL, @Rodada, '64'
	
		
END