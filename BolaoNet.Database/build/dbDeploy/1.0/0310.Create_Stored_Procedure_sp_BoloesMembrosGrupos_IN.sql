IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_BoloesMembrosGrupos_IN')
BEGIN
	DROP  Procedure  sp_BoloesMembrosGrupos_IN
END
GO
CREATE PROCEDURE [dbo].[sp_BoloesMembrosGrupos_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25),
	@UserNameSelecionado				varchar(25),
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	
	INSERT INTO BoloesMembrosGrupo
		(
		UserName,
		UserNameSelecionado,
		NomeBolao,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@UserName,
		@UserNameSelecionado,
		@NomeBolao,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@RowCount	  	
	
	
END



GO
