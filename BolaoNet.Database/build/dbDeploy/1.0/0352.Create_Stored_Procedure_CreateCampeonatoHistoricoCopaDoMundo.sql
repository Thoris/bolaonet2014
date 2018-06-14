IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CreateCampeonatoHistoricoCopaDoMundo')
BEGIN
	DROP  Procedure  CreateCampeonatoHistoricoCopaDoMundo
END
GO


CREATE PROCEDURE [dbo].[CreateCampeonatoHistoricoCopaDoMundo]
AS
BEGIN

	SET NOCOUNT ON;
	
	DECLARE @CurrentLogin			varchar(25)
	SET @CurrentLogin	= 'Admin'
	
	DECLARE @NomeCampeonato			varchar(30)
	SET @NomeCampeonato = 'Copa do Mundo 2010'
	

	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1930, 'Uruguai', 'Argentina', NULL, 4, 2, NULL, NULL, 'Uruguai' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1934, 'Itália', 'Tchecoslováquia', NULL, 2, 1, NULL, NULL, 'Itália' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1938, 'Itália', 'Hungria', NULL, 4, 2, NULL, NULL, 'França' 
	--EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1942, 'Uruguai', 'Argentina', NULL, 4, 2, NULL, NULL, 'Uruguai' 
	--EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1946, 'Uruguai', 'Argentina', NULL, 4, 2, NULL, NULL, 'Uruguai' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1950, 'Uruguai', 'Brasil', NULL, 2, 1, NULL, NULL, 'Brasil' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1954, 'Alemanha Ocidental', 'Hungria', NULL, 3, 2, NULL, NULL, 'Suíça' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1958, 'Brasil', 'Suécia', NULL, 5, 2, NULL, NULL, 'Suécia' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1962, 'Brasil', 'Tchecoslováquia', NULL, 3, 1, NULL, NULL, 'Chile' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1966, 'Inglaterra', 'Alemanha Ocidental', NULL, 4, 2, NULL, NULL, 'Inglaterra' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1970, 'Brasil', 'Itália', NULL, 4, 1, NULL, NULL, 'México' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1974, 'Alemanha Ocidental', 'Holanda', NULL, 2, 1, NULL, NULL, 'Alemanha Ocidental' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1978, 'Argentina', 'Holanda', NULL, 3, 1, NULL, NULL, 'Argentina' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1982, 'Itália', 'Alemanha Ocidental', NULL, 3, 1, NULL, NULL, 'Espanha' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1986, 'Argentina', 'Alemanha Ocidental', NULL, 3, 2, NULL, NULL, 'México' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1990, 'Alemanha Ocidental', 'Argentina', NULL, 1, 0, NULL, NULL, 'Itália' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1994, 'Brasil', 'Itália', NULL, 0, 0, 3, 2, 'Estados Unidos' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 1998, 'França', 'Brasil', NULL, 3, 0, NULL, NULL, 'França' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 2002, 'Brasil', 'Alemanha', NULL, 2, 0, NULL, NULL, 'Coréia do Sul e Japão' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 2006, 'Itália', 'França', NULL, 1, 1, 5, 3, 'Alemanha' 
	EXEC CreateCampeonatoHistoricoEntry  @CurrentLogin, @NomeCampeonato, 2010, 'Espanha', 'Holanda', NULL, 1, 0, NULL, NULL, 'Alemanha' 
	

END



GO
