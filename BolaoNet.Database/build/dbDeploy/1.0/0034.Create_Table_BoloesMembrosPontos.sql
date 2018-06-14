
CREATE TABLE [dbo].[BoloesMembrosPontos](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[Posicao] [int] NULL,
	[Rodada] [int] NOT NULL,
	[LastPosicao] [int] NULL,
	[TotalPontos] [int] NULL,
	[TotalEmpate] [int] NULL,
	[TotalVitoria] [int] NULL,
	[TotalGolsGanhador] [int] NULL,
	[TotalGolsPerdedor] [int] NULL,
	[TotalResultTime1] [int] NULL,
	[TotalResultTime2] [int] NULL,
	[TotalVDE] [int] NULL,
	[TotalErro] [int] NULL,
	[TotalGolsGanhadorFora] [int] NULL,
	[TotalGolsGanhadorDentro] [int] NULL,
	[TotalPerdedorFora] [int] NULL,
	[TotalPerdedorDentro] [int] NULL,
	[TotalGolsEmpate] [int] NULL,
	[TotalGolsTime1] [int] NULL,
	[TotalGolsTime2] [int] NULL,
	[TotalPlacarCheio] [int] NULL,
	[UserName] [varchar](25) NOT NULL,
	[IsMultiploTime] [bit] NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[MultiploTime] [int] NULL,
	[NomeCampeonato] [varchar](50) NOT NULL,
	[NomeFase] [varchar](30) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[NomeBolao] ASC,
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[Rodada] ASC,
	[NomeGrupo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[BoloesMembrosPontos]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO


ALTER TABLE [dbo].[BoloesMembrosPontos]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO


ALTER TABLE [dbo].[BoloesMembrosPontos]  WITH CHECK ADD FOREIGN KEY([NomeGrupo], [NomeCampeonato])
REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
GO

ALTER TABLE [dbo].[BoloesMembrosPontos]  WITH CHECK ADD FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO

ALTER TABLE [dbo].[BoloesMembrosPontos]  WITH CHECK ADD FOREIGN KEY([UserName], [NomeBolao])
REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
GO

