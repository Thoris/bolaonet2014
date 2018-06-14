IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesRequests_ChangeStatus')
BEGIN
	DROP  Procedure  sp_BoloesRequests_ChangeStatus
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesRequests_ChangeStatus]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@RequestID							int,
	@NomeBolao							varchar(30),
	@AnsweredBy							varchar(25),
	@StatusRequestID					int,
	@Descricao							varchar(255),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	

    UPDATE	BoloesRequests
	   SET	AnsweredBy			= @AnsweredBy,
			AnsweredDate		= GetDate(),
			StatusRequestID		= @StatusRequestID,
			Descricao			= @Descricao,
			ModifiedBy			= @CurrentLogin,
			ModifiedDate		= GetDate()
	 WHERE  RequestID			= @RequestID
	   AND	NomeBolao			= @NomeBolao
	
	
	RETURN @@RowCount
	
END




GO
