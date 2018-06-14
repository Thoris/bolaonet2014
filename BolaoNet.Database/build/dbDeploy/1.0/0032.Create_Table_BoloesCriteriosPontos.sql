
CREATE TABLE [dbo].[BoloesCriteriosPontos](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[Pontos] [int] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[Descricao] [varchar](255) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[CriterioID] [int] NOT NULL,
	[NomeBolao] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CriterioID] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BoloesCriteriosPontos]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesCriteriosPontos]  WITH CHECK ADD FOREIGN KEY([CriterioID])
REFERENCES [dbo].[CriteriosFixos] ([CriterioID])
GO

ALTER TABLE [dbo].[BoloesCriteriosPontos]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesCriteriosPontos]  WITH CHECK ADD FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
