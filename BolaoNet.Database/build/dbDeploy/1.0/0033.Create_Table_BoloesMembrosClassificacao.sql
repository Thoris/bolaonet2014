
CREATE TABLE [dbo].[BoloesMembrosClassificacao](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[UserName] [varchar](25) NOT NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[Posicao] [int] NULL,
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
	[TotalApostaExtra] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BoloesMembrosClassificacao]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesMembrosClassificacao]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO


ALTER TABLE [dbo].[BoloesMembrosClassificacao]  WITH CHECK ADD FOREIGN KEY([UserName], [NomeBolao])
REFERENCES [dbo].[BoloesMembros] ([UserName], [NomeBolao])
GO
