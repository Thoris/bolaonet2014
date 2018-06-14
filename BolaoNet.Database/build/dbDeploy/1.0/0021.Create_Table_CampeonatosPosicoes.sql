
CREATE TABLE [dbo].[CampeonatosPosicoes](
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[Posicao] [int] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Titulo] [varchar](50) NULL,
	[ActiveFlag] [bit] NULL,
	[NomeCampeonato] [varchar](50) NOT NULL,
	[BackColor] [varchar](20) NULL,
	[NomeFase] [varchar](30) NOT NULL,
	[ForeColor] [varchar](20) NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeGrupo] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CampeonatosPosicoes]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosPosicoes]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosPosicoes]  WITH CHECK ADD FOREIGN KEY([NomeGrupo], [NomeCampeonato])
REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
GO

ALTER TABLE [dbo].[CampeonatosPosicoes]  WITH CHECK ADD FOREIGN KEY([NomeCampeonato], [NomeFase])
REFERENCES [dbo].[CampeonatosFases] ([NomeCampeonato], [Nome])
GO

