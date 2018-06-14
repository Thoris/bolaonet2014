IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembros_Add')
BEGIN
	DROP  Procedure  sp_BoloesMembros_Add
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembros_Add]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeBolao							varchar(25),
	@UserName							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	IF (EXISTS (SELECT * 
				  FROM BoloesMembros 
				 WHERE NomeBolao = @NomeBolao 
				   AND Username = @UserName)
		)
	BEGIN
		RETURN 1
	END
	
	
	
	INSERT INTO BoloesMembros
		(
			NomeBolao,
			Username,
			CreatedBy,
			CreatedDate,
			ModifiedBy,
			ModifiedDate
		)
		VALUES
		(
			@NomeBolao,
			@UserName, 
			@CurrentLogin,
			Getdate(),
			@CurrentLogin,
			GetDate()
		)
	
	
		
	RETURN @@RowCount	  	
	
	
END



GO
