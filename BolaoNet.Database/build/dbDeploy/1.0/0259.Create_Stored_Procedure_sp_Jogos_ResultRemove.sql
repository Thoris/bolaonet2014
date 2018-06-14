IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_ResultRemove')
BEGIN
	DROP  Procedure  sp_Jogos_ResultRemove
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_ResultRemove]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@NomeCampeonato						varchar(50),	
	@IDJogo								bigint,
	@ValidadoBy							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE Jogos SET		
		Gols1						= NULL,
		Penaltis1					= NULL,
		Gols2						= NULL,
		Penaltis2					= NULL,
		IsValido					= 0,
		DataValidacao				= GetDate(),
		ValidadoBy					= @ValidadoBy		
	 WHERE 
			NomeCampeonato			= @NomeCampeonato
	   AND	IDJogo					= @IDJogo
	
		
			  	
	RETURN @@RowCount
	
END



GO
