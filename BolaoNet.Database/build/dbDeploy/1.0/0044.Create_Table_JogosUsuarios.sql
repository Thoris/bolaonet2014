

CREATE TABLE [dbo].[JogosUsuarios](
	[IdJogo] [int] NOT NULL,
	[NomeCampeonato] [varchar](50) NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[DataAposta] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[Automatico] [smallint] NULL,
	[ModifiedDate] [datetime] NULL,
	[ApostaTime1] [smallint] NULL,
	[ActiveFlag] [bit] NULL,
	[ApostaTime2] [smallint] NULL,
	[UserName] [varchar](25) NOT NULL,
	[IsDerrota] [bit] NULL,
	[Pontos] [int] NULL,
	[Valido] [bit] NULL,
	[IsEmpate] [bit] NULL,
	[IsVitoria] [bit] NULL,
	[IsGolsGanhador] [bit] NULL,
	[IsGolsPerdedor] [bit] NULL,
	[IsResultTime1] [bit] NULL,
	[IsResultTime2] [bit] NULL,
	[IsVDE] [bit] NULL,
	[IsErro] [bit] NULL,
	[IsGolsGanhadorFora] [bit] NULL,
	[IsGolsGanhadorDentro] [bit] NULL,
	[IsGolsPerdedorFora] [bit] NULL,
	[IsGolsPerdedorDentro] [bit] NULL,
	[IsGolsEmpate] [bit] NULL,
	[IsMultiploTime] [bit] NULL,
	[IsGolsTime1] [bit] NULL,
	[MultiploTime] [int] NULL,
	[IsGolsTime2] [bit] NULL,
	[IsPlacarCheio] [bit] NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[NomeTimeResult1] [varchar](30) NULL,
	[NomeTimeResult2] [varchar](30) NULL,
	[Ganhador] [int] NULL,
	[DataFacebook] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdJogo] ASC,
	[NomeCampeonato] ASC,
	[UserName] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[JogosUsuarios]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[JogosUsuarios]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[JogosUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeTimeResult2])
REFERENCES [dbo].[Times] ([Nome])
GO

ALTER TABLE [dbo].[JogosUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeTimeResult1])
REFERENCES [dbo].[Times] ([Nome])
GO

ALTER TABLE [dbo].[JogosUsuarios]  WITH CHECK ADD FOREIGN KEY([UserName], [NomeBolao])
REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
GO

ALTER TABLE [dbo].[JogosUsuarios]  WITH CHECK ADD FOREIGN KEY([IdJogo], [NomeCampeonato])
REFERENCES [dbo].[Jogos] ([IdJogo], [NomeCampeonato])
GO

