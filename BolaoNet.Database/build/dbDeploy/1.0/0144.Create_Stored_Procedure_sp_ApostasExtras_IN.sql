IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_ApostasExtras_IN')
BEGIN
	DROP  Procedure  sp_ApostasExtras_IN
END
GO
CREATE PROCEDURE [dbo].[sp_ApostasExtras_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@Posicao							int,
	@Titulo								varchar(50),
	@Descricao							varchar(255),
	@TotalPontos						int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	
	INSERT INTO ApostasExtras
		(
		NomeBolao,
		Posicao,
		Titulo,
		Descricao,
		TotalPontos,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@NomeBolao,
		@Posicao,
		@Titulo,
		@Descricao,
		@TotalPontos,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@RowCount	  	
	
	
END




GO
