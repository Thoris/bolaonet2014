IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Jogos_UP')
BEGIN
	DROP  Procedure  sp_Jogos_UP
END
GO
CREATE PROCEDURE [dbo].[sp_Jogos_UP]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@IdJogo								bigint,
	@NomeCampeonato						varchar(50),
	@NomeFase							varchar(50),
	@NomeGrupo							varchar(20),
	@Titulo								varchar(100),
	@NomeTime1							varchar(30),
	@Gols1								smallint,
	@Penaltis1							smallint,
	@DescricaoTime1						varchar(255),	
	@NomeTime2							varchar(30),
	@Gols2								smallint,
	@Penaltis2							smallint,
	@DescricaoTime2						varchar(255),
	@DataJogo							DateTime, 
	@Rodada								int,
	@IsValido							bit, 
	@DataValidacao						datetime, 
	@ValidadoBy							varchar(25),
	@NomeEstadio						varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL

	
	UPDATE Jogos SET		
		NomeFase					= @NomeFase,
		NomeGrupo					= @NomeGrupo,
		Titulo						= @Titulo,
		NomeTime1					= @NomeTime1,
		Gols1						= @Gols1,
		Penaltis1					= @Penaltis1,
		DescricaoTime1				= @DescricaoTime1,
		NomeTime2					= @NomeTime2,
		Gols2						= @Gols2,
		Penaltis2					= @Penaltis2,
		DescricaoTime2				= @DescricaoTime2,
		DataJogo					= @DataJogo,
		Rodada						= @Rodada,
		IsValido					= @IsValido,
		DataValidacao				= @DataValidacao,
		ValidadoBy					= @ValidadoBy,
		NomeEstadio					= @NomeEstadio,
		ModifiedBy					= @CurrentLogin,
		ModifiedDate				= GetDate(),
		ActiveFlag					= 0
	 WHERE 
			NomeCampeonato			= @NomeCampeonato
	   AND	IDJogo					= @IDJogo
		
			  	
	RETURN @@RowCount	
	
END



GO
