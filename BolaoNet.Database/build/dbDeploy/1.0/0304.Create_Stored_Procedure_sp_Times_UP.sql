IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Times_UP')
BEGIN
	DROP  Procedure  sp_Times_UP
END
GO
CREATE PROCEDURE [dbo].[sp_Times_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Nome								varchar(30),
	@IsClube							bit,
	@Escudo								image,
	@DataFundacao						datetime,
	@Site								varchar(100),
	@Pais								varchar(20),
	@Estado								varchar(20),
	@Cidade								varchar(20),
	@Descricao							varchar(255),
	@NomeMascote						varchar(20),
	@Mascote							image,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE Times SET		
		Escudo				= @Escudo,
		DataFundacao		= @DataFundacao,
		Site				= @Site,
		Pais				= @Pais,
		Estado				= @Estado,
		Cidade				= @Cidade,
		Descricao			= @Descricao,
		NomeMascote			= @NomeMascote,
		Mascote				= @Mascote,
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
		Nome				= @Nome
		
			  	
	RETURN @@RowCount	
	
END



GO
