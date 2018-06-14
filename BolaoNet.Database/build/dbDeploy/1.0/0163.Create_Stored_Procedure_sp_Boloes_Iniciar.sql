IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Boloes_Iniciar')
BEGIN
	DROP  Procedure  sp_Boloes_Iniciar
END
GO
CREATE PROCEDURE [dbo].[sp_Boloes_Iniciar]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@IniciadoBy							varchar(25),
	@NomeBolao							varchar(30),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL
	
	
	UPDATE Boloes
	   SET	IniciadoBy		= @IniciadoBy,
			IsIniciado		= 1,
			DataIniciado	= GetDate(),
			ModifiedBy		= @CurrentLogin,
			ModifiedDate	= Getdate()
	 WHERE Nome				= @NomeBolao
			
			
			
			
	DECLARE @UserName		varchar(25)
			
	DECLARE curMembros CURSOR FOR
	SELECT	UserName
	  FROM BoloesMembros
	 WHERE NomeBolao		= @NomeBolao
		
	OPEN curmembros
			
	FETCH NEXT FROM curMembros INTO @UserName

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
			
			
				
					
		INSERT INTO JogosUsuarios
			(IdJogo, NomeCampeonato, UserName, NomeBolao, DataAposta, Automatico, 
			 ApostaTime1, ApostaTime2, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
		SELECT Jogos.IDJogo, Jogos.NomeCampeonato, @UserName, @NomeBolao, GetDAte(), 1,
			 0, 0, @CurrentLogin, GetDate(), @CurrentLogin, GetDate() 
		  FROM Jogos
		 WHERE NOT EXISTS 
			(
				SELECT * 
				  FROM JogosUsuarios
				 WHERE UserName					= @UserName
				   AND NomeBolao				= @NomeBolao
				   AND Jogos.IDJogo				= JogosUsuarios.IDJogo 
				   AND Jogos.NomeCampeonato		= JogosUsuarios.NomeCampeonato
			
			)			
					
		FETCH NEXT FROM curMembros INTO @UserName
				
	END				
			
			
			
			
			
			

		
	RETURN @@RowCount	  	
	
	
END



GO
