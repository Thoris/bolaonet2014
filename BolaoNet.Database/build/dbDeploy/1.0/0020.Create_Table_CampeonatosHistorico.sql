
CREATE TABLE [dbo].[CampeonatosHistorico](
	[Ano] [int] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Sede] [varchar](25) NULL,
	[NomeTimeCampeao] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[NomeTimeVice] [varchar](25) NULL,
	[ActiveFlag] [bit] NULL,
	[NomeTimeTerceiro] [varchar](25) NULL,
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
	[FinalTime1] [smallint] NULL,
	[FinalPenaltis1] [smallint] NULL,
	[FinalTime2] [smallint] NULL,
	[Nome] [varchar](50) NOT NULL,
	[FinalPenaltis2] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Nome] ASC,
	[Ano] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CampeonatosHistorico]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosHistorico]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[CampeonatosHistorico]  WITH CHECK ADD FOREIGN KEY([Nome])
REFERENCES [dbo].[Campeonatos] ([Nome])
GO

