IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Times_IN')
BEGIN
	DROP  Procedure  sp_Times_IN
END
GO
CREATE PROCEDURE [dbo].[sp_Times_IN]
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
	
	
	
	INSERT INTO Times 
		(
		Nome,
		Escudo,
		DataFundacao, 
		Site,
		Pais,
		Estado,
		Cidade,
		Descricao,
		NomeMascote,
		Mascote,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@Nome,
		@Escudo,
		@DataFundacao, 
		@Site,
		@Pais,
		@Estado,
		@Cidade,
		@Descricao,
		@NomeMascote,
		@Mascote,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@RowCount	  	
	
	
END



GO
