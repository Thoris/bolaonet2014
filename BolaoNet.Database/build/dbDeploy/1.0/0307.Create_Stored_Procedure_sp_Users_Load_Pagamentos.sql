IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sp_Users_Load_Pagamentos')
BEGIN
	DROP  Procedure  sp_Users_Load_Pagamentos
END
GO
CREATE PROCEDURE [dbo].[sp_Users_Load_Pagamentos]
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



	--SELECT  NomeBolao, 
	--		UserName, 
	--		Sum(Valor) as 'Valor',
	--		(SELECT TaxaParticipacao FROM Boloes WHERE Nome = Pagamentos.NomeBolao) as 'Taxa',
	--		(SELECT DataInicio FROM Boloes WHERE Nome = Pagamentos.NomeBolao) as 'DataInicio'
	--  FROM Pagamentos
	-- WHERE UserName = @UserName
	-- GROUP BY UserName, NomeBolao
 



	SELECT Boloes.Nome as 'NomeBolao', 
		   BoloesMembros.UserName as 'Username', 
		   Boloes.DataInicio as 'DataInicio', 
		   Boloes.TaxaParticipacao as 'TaxaParticipacao',
			ISNULL((SELECT Sum(Valor) FROM Pagamentos WHERE Pagamentos.UserName = BoloesMembros.UserName and Pagamentos.NomeBolao = Boloes.Nome),0) as 'Valor'
	  FROM BoloesMembros 
	 INNER JOIN Boloes
		ON BoloesMembros.NomeBolao		= Boloes.Nome
	 WHERE UserName = @UserName
		 
	  
	 

	RETURN @@RowCount

END



GO
