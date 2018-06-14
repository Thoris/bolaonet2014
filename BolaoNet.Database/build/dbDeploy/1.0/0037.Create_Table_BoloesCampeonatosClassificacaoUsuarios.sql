
CREATE TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios](
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[NomeCampeonato] [varchar](50) NOT NULL,
	[NomeFase] [varchar](30) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeTime] [varchar](30) NOT NULL,
	[UserName] [varchar](25) NOT NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[Posicao] [int] NULL,
	[TotalVitorias] [int] NULL,
	[TotalDerrotas] [int] NULL,
	[TotalEmpates] [int] NULL,
	[TotalGolsContra] [int] NULL,
	[TotalGolsPro] [int] NULL,
	[TotalPontos] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeGrupo] ASC,
	[NomeTime] ASC,
	[UserName] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO

ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO

ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO

ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeGrupo], [NomeCampeonato])
REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
GO

ALTER TABLE [dbo].[BoloesCampeonatosClassificacaoUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO


