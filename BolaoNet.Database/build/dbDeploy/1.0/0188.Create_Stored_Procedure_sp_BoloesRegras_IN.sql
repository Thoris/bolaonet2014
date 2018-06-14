IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesRegras_IN')
BEGIN
	DROP  Procedure  sp_BoloesRegras_IN
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesRegras_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	--@MessageID							bigint,
	@Description						varchar(255),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	
	INSERT INTO BoloesRegras 
		(
		NomeBolao,
		Description,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@NomeBolao,
		@Description,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@Identity	  	
	
	
END




GO
