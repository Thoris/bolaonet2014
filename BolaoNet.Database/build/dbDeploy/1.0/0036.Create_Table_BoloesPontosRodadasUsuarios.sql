
CREATE TABLE [dbo].[BoloesPontosRodadasUsuarios](
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Rodada] [int] NOT NULL,
	[ActiveFlag] [bit] NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeCampeonato] [varchar](50) NOT NULL,
	[TotalPontos] [int] NULL,
	[NomeFase] [varchar](30) NOT NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[Posicao] [int] NOT NULL,
	[UserName] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeGrupo] ASC,
	[NomeCampeonato] ASC,
	[NomeFase] ASC,
	[NomeBolao] ASC,
	[Rodada] ASC,
	[Posicao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]  WITH CHECK ADD FOREIGN KEY([UserName], [NomeBolao])
REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
GO

ALTER TABLE [dbo].[BoloesPontosRodadasUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeGrupo], [NomeCampeonato], [NomeFase], [NomeBolao], [Posicao])
REFERENCES [dbo].[BoloesPontosRodadas] ([NomeGrupo], [NomeCampeonato], [NomeFase], [NomeBolao], [Posicao])
GO

