
CREATE TABLE [dbo].[ApostasExtrasUsuarios](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[DataAposta] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Pontos] [int] NULL,
	[IsApostaValida] [bit] NULL,
	[ActiveFlag] [bit] NULL,
	[Posicao] [int] NOT NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[UserName] [varchar](25) NOT NULL,
	[NomeTime] [varchar](30) NULL,
	[Automatico] bit,
PRIMARY KEY CLUSTERED 
(
	[Posicao] ASC,
	[NomeBolao] ASC,
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ApostasExtrasUsuarios]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[ApostasExtrasUsuarios]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[ApostasExtrasUsuarios]  WITH CHECK ADD FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO

ALTER TABLE [dbo].[ApostasExtrasUsuarios]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[ApostasExtrasUsuarios]  WITH CHECK ADD FOREIGN KEY([Posicao], [NomeBolao])
REFERENCES [dbo].[ApostasExtras] ([Posicao], [NomeBolao])
GO
