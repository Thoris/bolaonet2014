IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembrosGrupos_Classificacao')
BEGIN
	DROP  Procedure  sp_BoloesMembrosGrupos_Classificacao
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembrosGrupos_Classificacao]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25),
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	

	SELECT BoloesMembrosGrupo.UserNameSelecionado as UserName, BoloesMembrosClassificacao.*, Users.FullName
	  FROM BoloesMembrosGrupo
	 INNER JOIN Users
		ON Users.UserName	= BoloesMembrosGrupo.UserNameSelecionado
	  LEFT JOIN BoloesMembrosClassificacao
		ON BoloesMembrosGrupo.UserNameSelecionado	= BoloesMembrosClassificacao.UserName
	   AND BoloesMembrosGrupo.NomeBolao	= BoloesMembrosClassificacao.NomeBolao
	 WHERE BoloesMembrosGrupo.NomeBolao	= @NomeBolao
	   AND BoloesMembrosGrupo.UserName	= @UserName
	 ORDER BY BoloesMembrosClassificacao.Posicao, 
			  BoloesMembrosClassificacao.LastPosicao,
			  BOloesMembrosClassificacao.TotalPontos

	

	
	RETURN @@RowCount	  	
	
	
END



GO
