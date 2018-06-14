IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtrasUsuarios_PG')
BEGIN
	DROP  Procedure  sp_ApostasExtrasUsuarios_PG
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtrasUsuarios_PG]
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
		SET @Order = 'ApostasExtras.NomeBolao, ApostasExtras.Posicao'

	DECLARE @FieldsLoad			nvarchar(3000)
	
	SET @FieldsLoad = @Fields
	
	IF (@FieldsLoad IS NULL OR LEN(@FieldsLoad) = 0)
	BEGIN
	
		SET @FieldsLoad = 'ApostasExtrasUsuarios.*, ApostasExtras.Posicao as PosicaoItem,
			ApostasExtras.NomeBolao as NomeBolaoItem, ApostasExtras.Titulo,
			ApostasExtras.Descricao, ApostasExtras.TotalPontos, ApostasExtras.IsValido,
			ApostasExtras.DataValidacao, ApostasExtras.ValidadoBy, ApostasExtras.NomeTimeValidado'
	
	END


	EXEC sp_Select_PG
		@CurrentLogin, 
		@ApplicationName,
		@FieldsLoad, 
		'ApostasExtras 
		 INNER JOIN ApostasExtrasUsuarios 
		    ON ApostasExtras.Posicao	= ApostasExtrasUsuarios.Posicao
		   AND ApostasExtras.NomeBolao	= ApostasExtrasUsuarios.NomeBolao', 
		@Where, 
		@Order, 
		@PageNumber, @PageSize,
		@ErrorNumber, @ErrorDescription


END



GO
