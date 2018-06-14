IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Estadios_IN')
BEGIN
	DROP  Procedure  sp_Estadios_IN
END
GO
CREATE PROCEDURE [dbo].[sp_Estadios_IN]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@Nome								varchar(30),
	@NomeTime							varchar(30),
	@Pais								varchar(20),
	@Estado								varchar(20),
	@Cidade								varchar(20),
	@Descricao							varchar(255),
	@Foto								image,
	@Capacidade							int,
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	
	INSERT INTO Estadios 
		(
		Nome,
		NomeTime,
		Pais,
		Estado,
		Cidade,
		Descricao,
		Foto,
		Capacidade,
		CreatedBy,
		CreatedDate,
		ModifiedBy,
		ModifiedDate,
		ActiveFlag 
		)
		VALUES 
		(
		@Nome,
		@NomeTime,
		@Pais,
		@Estado,
		@Cidade,
		@Descricao,
		@Foto,
		@Capacidade,
		@CurrentLogin,
		GetDate(),
		@CurrentLogin,
		GetDate(),
		0
		) 
		
	RETURN @@RowCount	  	
	
	
END



GO
