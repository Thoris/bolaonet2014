IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembros_Load')
BEGIN
	DROP  Procedure  sp_BoloesMembros_Load
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembros_Load]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	SELECT BoloesMembros.*, Users.FullName, Users.Email 
	  FROM BoloesMembros
	 INNER JOIN Users
	    ON BoloesMembros.UserName		= Users.UserName
	 WHERE NomeBolao		= @NomeBolao
		
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
