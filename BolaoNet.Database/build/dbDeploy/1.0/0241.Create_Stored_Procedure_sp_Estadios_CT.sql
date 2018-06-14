IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Estadios_CT')
BEGIN
	DROP  Procedure  sp_Estadios_CT
END
GO
CREATE PROCEDURE [dbo].[sp_Estadios_CT]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,	
	@Where								nvarchar(1000),
	@TotalRows							int OUTPUT,	
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT	
)
AS
BEGIN


	EXEC sp_Select_Count
		@CurrentLogin,
		@ApplicationName, 
		'Estadios', 
		@Where, 
		@TotalRows OUTPUT,
		@ErrorNumber OUTPUT, @ErrorDescription OUTPUT


END



GO
