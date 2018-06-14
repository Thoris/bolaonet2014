IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Pagamentos_CBO')
BEGIN
	DROP  Procedure  sp_Pagamentos_CBO
END
GO
CREATE PROCEDURE [dbo].[sp_Pagamentos_CBO]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	DECLARE @Execute		varchar(5000);

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	
	SET @Execute = 
		'SELECT * ' + CHAR(13) + 
		'  FROM Pagamentos ' + CHAR(13)
		
	--IF (@Condition IS NOT NULL AND LEN (@Condition) > 0) 
	--	SET @Execute = @Execute + ' WHERE ' + @Condition
	
	EXEC (@Execute)


	RETURN 0

END




GO
