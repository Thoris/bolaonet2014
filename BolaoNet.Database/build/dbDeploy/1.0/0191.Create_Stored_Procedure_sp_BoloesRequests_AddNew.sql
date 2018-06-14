IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesRequests_AddNew')
BEGIN
	DROP  Procedure  sp_BoloesRequests_AddNew
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesRequests_AddNew]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@Owner								varchar(25) = null,
	@StatusRequestID					int,
	@RequestedBy						varchar(25),	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	

	
	
	
	IF (@Owner IS NULL OR LEN(@Owner) = 0)
	BEGIN
		-- BUscando o owner do bolão
		SELECT @Owner = CreatedBy 
		  FROM Boloes
		 WHERE Nome = @NomeBolao     
    END
     

	INSERT INTO BoloesRequests
		(
			NomeBolao,
			RequestedBy,
			RequestedDate,
			Owner,
			StatusRequestID,
			AnsweredBy, 
			AnsweredDate,
			CreatedBy,	
			CreatedDate,
			ModifiedBy,
			ModifiedDate,
			ActiveFlag			
		)
		VALUES
		(
			@NomeBolao,
			@RequestedBy,
			GetDate(),
			@Owner,
			@StatusRequestID,
			NULL,
			NULL,
			@CurrentLogin,
			GetDate(),
			@CurrentLogin,
			GetDate(),
			0
		)
	
	RETURN @@IDENTITY
	  	
	
	
END




GO
