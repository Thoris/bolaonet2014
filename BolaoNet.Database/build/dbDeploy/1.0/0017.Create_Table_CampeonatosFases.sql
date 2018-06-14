
CREATE TABLE [dbo].[CampeonatosFases](
	[NomeCampeonato] [varchar](50) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Descricao] [varchar](255) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeCampeonato] ASC,
	[Nome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CampeonatosFases]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosFases]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosFases]  WITH CHECK ADD FOREIGN KEY([NomeCampeonato])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO
