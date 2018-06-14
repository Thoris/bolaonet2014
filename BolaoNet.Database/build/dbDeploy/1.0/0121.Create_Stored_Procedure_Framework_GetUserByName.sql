IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Framework_GetUserByName')
BEGIN
	DROP  Procedure  Framework_GetUserByName
END
GO
CREATE PROCEDURE [dbo].[Framework_GetUserByName]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256),
	@UserName							varchar(25),
	@UserIsOnline						bit = 0,
    @UpdateLastActivity					bit = 0,    
    @ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	-- Se deve atualizar o usuário
    IF (@UpdateLastActivity = 1)
    BEGIN
    
		-- Se não encontrou o usuário
		IF (NOT EXISTS(SELECT TOP 1 * 
						 FROM Users 
						WHERE LOWER(UserName)		= LOWER(@UserName)))
			RETURN -1
    
		-- Atualizando o registro do usuário
        UPDATE   Users
        SET      LastActivityDate	= GETDATE()
        WHERE    LOWER(UserName)				= LOWER(@UserName)


		-- Buscando os dados do usuário
		SELECT * 
		  FROM Users
		 WHERE LOWER(UserName)	= LOWER(@UserName)

    END
    -- Se não precisa atualizar os dados do usuário
    ELSE
    BEGIN

		-- Buscando os dados do usuário
		SELECT TOP 1 * 
		  FROM Users
		 WHERE LOWER(UserName)			= LOWER(@UserName)

		

        IF (@@ROWCOUNT = 0) -- Username not found
            RETURN -1
    END

    RETURN 0
END




GO
