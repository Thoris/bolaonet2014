
CREATE TABLE [dbo].[CampeonatosGruposTimes](
	[NomeTime] [varchar](30) NOT NULL,
	[NomeGrupo] [varchar](20) NOT NULL,
	[NomeCampeonato] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeTime] ASC,
	[NomeGrupo] ASC,
	[NomeCampeonato] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CampeonatosGruposTimes]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosGruposTimes]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosGruposTimes]  WITH CHECK ADD FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO

ALTER TABLE [dbo].[CampeonatosGruposTimes]  WITH CHECK ADD FOREIGN KEY([NomeGrupo], [NomeCampeonato])
REFERENCES [dbo].[CampeonatosGrupos] ([Nome], [NomeCampeonato])
GO

