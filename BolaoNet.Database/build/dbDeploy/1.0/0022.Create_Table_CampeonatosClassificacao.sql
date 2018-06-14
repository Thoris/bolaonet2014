
CREATE TABLE [dbo].[CampeonatosClassificacao](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[TotalVitorias] [int] NULL,
	[Rodada] [int] NOT NULL,
	[Posicao] [int] NULL,
	[ActiveFlag] [bit] NULL,
	[TotalDerrotas] [int] NULL,
	[NomeCampeonato] [varchar](50) NOT NULL,
	[LastPosicao] [int] NULL,
	[TotalEmpates] [int] NULL,
	[NomeFase] [varchar](30) NOT NULL,
	[NomeTime] [varchar](30) NOT NULL,
	[TotalGolsContra] [int] NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[TotalGolsPro] [int] NULL,
	[TotalPontos] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeTime] ASC,
	[NomeGrupo] ASC,
	[Rodada] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CampeonatosClassificacao]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosClassificacao]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosClassificacao]  WITH CHECK ADD FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO

ALTER TABLE [dbo].[CampeonatosClassificacao]  WITH CHECK ADD FOREIGN KEY([NomeTime], [NomeGrupo], [NomeCampeonato])
REFERENCES [dbo].[CampeonatosGruposTimes] ([NomeTime], [NomeGrupo], [NomeCampeonato])
GO

