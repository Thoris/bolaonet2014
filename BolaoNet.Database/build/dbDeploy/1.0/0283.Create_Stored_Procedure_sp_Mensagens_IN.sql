IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Mensagens_IN')
BEGIN
	DROP  Procedure  sp_Mensagens_IN
END
GO
CREATE PROCEDURE [dbo].[sp_Mensagens_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@FromUser							varchar(25),
	--@MessageID							bigint,
	@CreationDate						datetime,
	@Private							bit,
	@ToUser								varchar(25),
	@Title								varchar(100),
	@Message							varchar(4000),
	@TotalRead							int,
	@AnsweredMessageID					bigint,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	
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
		@CreationDate,
		@Private,
		@ToUser,
		@Title,
		@Message,
		@TotalRead,
		@AnsweredMessageID,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@Identity	  	
	
	
END




GO
