
CREATE TABLE [dbo].[Campeonatos](
	[ModifiedBy] [varchar](25) NULL,
	[Nome] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[IsClube] [bit] NULL,
	[FaseAtual] [varchar](30) NULL,
	[CreatedBy] [varchar](25) NULL,
	[RodadaAtual] [int] NULL,
	[IsIniciado] [bit] NULL,
	[ModifiedDate] [datetime] NULL,
	[DataInicio] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Campeonatos]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Campeonatos]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO
