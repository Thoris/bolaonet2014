IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Mensagens_UP')
BEGIN
	DROP  Procedure  sp_Mensagens_UP
END
GO
CREATE PROCEDURE [dbo].[sp_Mensagens_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@FromUser							varchar(25),
	@MessageID							bigint,
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

	
	UPDATE Mensagens SET	
		CreationDate		= @Creationdate,
		Private				= @Private,
		ToUser				= @ToUser,	
		Title				= @Title,
		Message				= @Message,
		TotalRead			= @TotalRead,
		AnsweredMessageID	= @AnsweredMessageID,
		ModifiedBy			= @CurrentLogin,
		ModifiedDate		= GetDate(),
		ActiveFlag			= 0
	 WHERE 
			NomeBolao		= @NomeBolao
	   AND	FromUser		= @FromUser
	   AND	MessageID		= @MessageID
		
			  	
	RETURN @@RowCount	
	
END




GO
