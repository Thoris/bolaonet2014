IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Users_Load_Boloes')
BEGIN
	DROP  Procedure  sp_Users_Load_Boloes
END
GO
CREATE PROCEDURE [dbo].[sp_Users_Load_Boloes]
(
    @CurrentLogin						varchar(25),
	@ApplicationName					nvarchar(256) = null,
	@UserName							varchar(25),
	@ErrorNumber						int OUTPUT,
    @ErrorDescription					varchar(4000) OUTPUT
)
AS
BEGIN

	
	SET @ErrorNumber = 0
	SET @ErrorDescription = NULL	

	SELECT b.Nome as 'NomeBolao', b.NomeCampeonato,
			(SELECT Count(*) FROM BoloesMembros c WHERE c.NomeBolao = a.NomeBolao) as 'Membros', 
			(
			  SELECT Posicao 
				FROM BoloesMembrosClassificacao d 
			   WHERE d.NomeBolao		= a.NomeBolao
			     AND d.UserName			= @UserName
			) as 'Position',
			
			(SELECT Count(*)
			  FROM Jogos j
			 WHERE j.NomeCampeonato = b.NomeCampeonato
			   AND NOT EXISTS (SELECT * 
								 FROM JogosUsuarios u
								WHERE u.Nomecampeonato		= j.NomeCampeonato
								  AND u.IDJogo				= j.IDJogo
								  AND u.NomeBolao			= b.Nome
								  AND u.UserName			= @UserName
								  AND u.ApostaTime1			IS NOT NULL
								  AND u.ApostaTime2			IS NOT NULL
							  )			
			
			) as 'ApostasRestantes'
			
	  FROM BoloesMembros a
	 INNER JOIN Boloes b
	    ON a.NomeBolao = b.Nome
	 WHERE a.UserName = @UserName
	 
	  
	 

	RETURN @@RowCount

END



GO
