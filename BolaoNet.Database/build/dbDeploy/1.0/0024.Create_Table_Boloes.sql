CREATE TABLE [dbo].[Boloes](
	[Nome] [varchar](30) NOT NULL,
	[Descricao] [varchar](255) NULL,
	[TaxaParticipacao] [money] NULL,
	[CreatedDate] [datetime] NULL,
	[Foto] [varbinary](1) NULL,
	[ModifiedDate] [datetime] NULL,
	[Publico] [bit] NULL,
	[ActiveFlag] [bit] NULL,
	[ForumAtivado] [bit] NULL,
	[CreatedBy] [varchar](25) NULL,
	[PermitirMsgAnonimos] [bit] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[DataInicio] [datetime] NULL,
	[Estado] [varchar](20) NULL,
	[Cidade] [varchar](100) NULL,
	[ApostasApenasAntes] [bit] NULL,
	[HorasLimiteAposta] [int] NULL,
	[Pais] [varchar](20) NULL,
	[IsIniciado] [bit] NULL,
	[DataIniciado] [datetime] NULL,
	[IniciadoBy] [varchar](25) NULL,
	[NomeCampeonato] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Boloes]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Boloes]  WITH CHECK ADD FOREIGN KEY([IniciadoBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Boloes]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Boloes]  WITH CHECK ADD FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO


