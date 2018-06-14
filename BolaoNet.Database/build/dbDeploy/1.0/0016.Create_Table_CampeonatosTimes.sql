

CREATE TABLE [dbo].[CampeonatosTimes](
	[NomeCampeonato] [varchar](50) NOT NULL,
	[NomeTime] [varchar](30) NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[NomeTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CampeonatosTimes]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosTimes]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosTimes]  WITH CHECK ADD FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO

ALTER TABLE [dbo].[CampeonatosTimes]  WITH CHECK ADD FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO
