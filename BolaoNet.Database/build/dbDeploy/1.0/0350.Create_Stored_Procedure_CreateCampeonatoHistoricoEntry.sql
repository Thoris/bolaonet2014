IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CreateCampeonatoHistoricoEntry')
BEGIN
	DROP  Procedure  CreateCampeonatoHistoricoEntry
END
GO
CREATE PROCEDURE [dbo].[CreateCampeonatoHistoricoEntry]
(
	@CurrentLogin			varchar(25),
	@Nome					varchar(50),
	@Ano					int,
	@NomeTimeCampeao		varchar(30),
	@NomeTimeVice			varchar(30),
	@NomeTimeTerceiro		varchar(30),
	@FinalTime1				smallint,
	@FinalTime2				smallint,
	@FinalPenaltis1			smallint,
	@FinalPenaltis2			smallint,
	@Sede					varchar(25)	    
    
)
AS
BEGIN

	SET NOCOUNT ON;
	
	
	
	
	IF (NOT EXISTS (SELECT * FROM CampeonatosHistorico WHERE Ano = @Ano AND Nome = @Nome))
		INSERT INTO CampeonatosHistorico 
			(Nome, Ano, Sede, NomeTimeCampeao, NomeTimeVice, NomeTimeTerceiro, FinalTime1, FinalTime2, FinalPenaltis1, FinalPenaltis2, 
			 CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
		VALUES 
			(@Nome, @Ano, @Sede, @NomeTimeCampeao, @NomeTimeVice, @NomeTimeTerceiro, @FinalTime1, @FinalTime2, @FinalPenaltis1, @FinalPenaltis2,
		     @CurrentLogin, GetDate(), @CurrentLogin, Getdate(), 0)
		 
	return @@RowCount


END



GO
