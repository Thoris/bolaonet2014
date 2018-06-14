
CREATE TABLE [dbo].[BoloesPontuacao](
	[CreatedBy] [varchar](25) NULL,
	[Pontos] [int] NOT NULL,
	[ModifiedBy] [varchar](25) NULL,
	[Titulo] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[ForeColor] [varchar](20) NULL,
	[ModifiedDate] [datetime] NULL,
	[BackColor] [varchar](20) NULL,
	[ActiveFlag] [bit] NULL,
	[NomeBolao] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[Pontos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BoloesPontuacao]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesPontuacao]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[BoloesPontuacao]  WITH CHECK ADD FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO

