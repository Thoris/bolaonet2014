IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_JogosUsuarios_PG')
BEGIN
	DROP  Procedure  sp_JogosUsuarios_PG
END
GO
CREATE PROCEDURE [dbo].[sp_JogosUsuarios_PG]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Fields								nvarchar(1000),
	@Where								nvarchar(1000),
	@Order								nvarchar(1000),
	@PageNumber							int,
	@PageSize							int,	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	IF (@Order IS NULL OR LEN(LTRIM(RTRIM(@Order))) = 0)
		SET @Order = 'Jogos.IdJogo'

	DECLARE @FieldsLoad			nvarchar(3000)
	
	SET @FieldsLoad = @Fields
	
	IF (@FieldsLoad IS NULL OR LEN(@FieldsLoad) = 0)
	BEGIN
	
		SET @FieldsLoad = 'JogosUsuarios.*, Jogos.NomeFase, Jogos.NomeGrupo, Jogos.Titulo, 
			Jogos.NomeTime1, Jogos.Gols1, Jogos.Penaltis1, Jogos.DescricaoTime1, 
			Jogos.NomeTime2, Jogos.Gols2, Jogos.Penaltis2, Jogos.DescricaoTime2, 
			Jogos.DataJogo, Jogos.Rodada, Jogos.IsValido, Jogos.DataValidacao, 
			Jogos.ValidadoBy, Jogos.NomeEstadio, 
			Jogos.IDJogo as IDJogoItem, Jogos.NomeCampeonato as NomeCampeonatoItem'
	
		--SET @FieldsLoad = 'JogosUsuarios.UserName, JogosUsuarios.NomeBolao 
		--  JogosUsuarios.DataAposta, JogosUsuarios.Automatico, JogosUsuarios.ApostaTime1,
		--  JogosUsuarios.ApostaTime2, JogosUsuarios.Pontos, JogosUsuarios.Valido, 
		--  JogosUsuarios.IsEmpate, JogosUsuarios.IsVitoria, JogosUsuarios.IsDerrota,
		--  JogosUsuarios.IsGOlsGanhador, JogosUsuarios.IsGolsPerderdor, 
		--  JogosUsuarios.IsResultTime1, JogosUsuarios.IsResultTime2, JogosUsuarios.IsVDE
		--  JogosUsuarios.IsErro, JogosUsuarios.IsGolsGanhadorFora, 
		--  JogosUsuarios.IsGolsGanhadorDentro, JogosUsuarios.IsGolsPerdedorDentro, 
		--  JogosUsuarios.IsGolsPerdedorFora, JogosUsuarios.IsGolsEmpate, 
		--  JogosUsuarios.IsGolsTime1, JogosUsuarios.IsGolsTime2, JogosUsuarios.IsPlacarCheio,
		--  JogosUsuarios.CreatedBy, JogosUsuarios.ModifiedBy, JogosUsuarios.CreatedDate,
		--  JogosUsuarios.ModifiedDate, Jogos.IDJogo, Jogos.NomeCampeonato,
		--  Jogos.NomeFase, Jogos.NomeGrupo, Jogos.Titulo, Jogos.NomeTime1, Jogos.Gols1,
		--  Jogos.Penaltis1, Jogos.DescricaoTime1, Jogos.NomeTime2, Jogos.Gols2,
		--  Jogos.Penaltis2, Jogos.DescricaoTime2, Jogos.DataJogo, Jogos.'
	
	END


	EXEC sp_Select_PG
		@CurrentLogin, 
		@ApplicationName,
		@FieldsLoad, 
		'Jogos 
		 INNER JOIN JogosUsuarios 
		    ON Jogos.NomeCampeonato = JogosUsuarios.NomeCampeonato 
		   AND Jogos.IDJogo			= JogosUsuarios.IDJogo', 
		@Where, 
		@Order, 
		@PageNumber, @PageSize,
		@ErrorNumber, @ErrorDescription


END



GO
