
CREATE TABLE [dbo].[ApostasExtras](
	[Posicao] [int] NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[Titulo] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[Descricao] [varchar](255) NULL,
	[ModifiedBy] [varchar](25) NULL,
	[TotalPontos] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsValido] [bit] NULL,
	[ActiveFlag] [bit] NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[DataValidacao] [datetime] NULL,
	[ValidadoBy] [varchar](25) NULL,
	[NomeTimeValidado] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Posicao] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ApostasExtras]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[ApostasExtras]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[ApostasExtras]  WITH CHECK ADD FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO

ALTER TABLE [dbo].[ApostasExtras]  WITH CHECK ADD FOREIGN KEY([NomeTimeValidado])
REFERENCES [dbo].[Times] ([Nome])
GO

ALTER TABLE [dbo].[ApostasExtras]  WITH CHECK ADD FOREIGN KEY([ValidadoBy])
REFERENCES [dbo].[Users] ([UserName])
GO
