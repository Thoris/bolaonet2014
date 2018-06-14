IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_CreateRole')
BEGIN
	DROP  Procedure  Framework_CreateRole
END
GO
CREATE PROCEDURE [dbo].[Framework_CreateRole]
(
	@CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@RoleName							varchar(255),	
	@Description						varchar(255),	    
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
	
)
AS
BEGIN
 
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
 
 
	IF (EXISTS(SELECT * FROM Roles WHERE RoleName = @RoleName))
	BEGIN
	
		SET @ErrorNumber = 1
		SET @ErrorDescription = 'The Role is already exists'
		
		RETURN 1
	
	END
	
	
	INSERT INTO Roles 
		(
		RoleName,
		Description, 
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag
		)
		VALUES
		(
		@RoleName,
		@Description,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		)
		 
	IF (@@ERROR > 0)
	BEGIN
		SET @ErrorNumber = @@Error
		SET @ErrorDescription = 'Error raised when saving the role.'
		
		RETURN -1
	END
	
	RETURN 0
 
 
    
END




GO
