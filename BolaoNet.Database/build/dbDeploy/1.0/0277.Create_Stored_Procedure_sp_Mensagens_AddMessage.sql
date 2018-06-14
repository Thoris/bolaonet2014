IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Mensagens_AddMessage')
BEGIN
	DROP  Procedure  sp_Mensagens_AddMessage
END
GO
CREATE PROCEDURE [dbo].[sp_Mensagens_AddMessage]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@FromUser							varchar(25),
	@Private							bit,
	@ToUser								varchar(25) = null,
	@Title								varchar(100),
	@Message							varchar(4000),
	@AnsweredMessageID					bigint,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	IF (@ToUser IS NULL OR LEN(@ToUser) = 0)
	BEGIN
	


		INSERT INTO Mensagens
			(
			NomeBolao,
			FromUser,
			CreationDate,
			Private,
			ToUser,
			Title,
			Message,
			TotalRead,
			AnsweredMessageID,
			CreatedBy,
			CreatedDate,
			ModifiedBy,
			ModifiedDate,
			ActiveFlag 
			)
			
			SELECT NomeBolao,
				@FromUser,
				GetDate(),
				@Private,
				UserName,
				@Title,
				@Message,
				0,
				@AnsweredMessageID,
				@CurrentLogin,
				GetDate(),
				@CurrentLogin,
				GetDate(),
				1
			  FROM BoloesMembros
             WHERE NomeBolao = @NomeBolao
               AND UserName <> @FromUser
	
	
	
	
	
	
	END
	ELSE
	BEGIN
		
		INSERT INTO Mensagens 
			(
			NomeBolao,
			FromUser,
			CreationDate,
			Private,
			ToUser,
			Title,
			Message,
			TotalRead,
			AnsweredMessageID,
			CreatedBy,
			CreatedDate,
			ModifiedBy,
			ModifiedDate,
			ActiveFlag 
			)
			VALUES 
			(
			@NomeBolao,
			@FromUser,
			GetDate(),
			@Private,
			@ToUser,
			@Title,
			@Message,
			0,
			@AnsweredMessageID,
			@CurrentLogin,
			GetDate(),
			@CurrentLogin,
			GetDate(),
			0
			) 	
		
	END
	
	
	
	
	
	
		
	RETURN @@Identity	  	
	
	
END




GO
