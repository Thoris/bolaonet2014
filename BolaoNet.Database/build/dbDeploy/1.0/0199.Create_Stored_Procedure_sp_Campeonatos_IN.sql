IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Campeonatos_IN')
BEGIN
	DROP  Procedure  sp_Campeonatos_IN
END
GO
CREATE PROCEDURE [dbo].[sp_Campeonatos_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Nome								varchar(50),
	@IsClube							bit,
	@Descricao							varchar(255),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	
	INSERT INTO Campeonatos 
		(
		Nome,
		IsClube,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@Nome,
		@IsClube,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@RowCount	  	
	
	
END



GO
