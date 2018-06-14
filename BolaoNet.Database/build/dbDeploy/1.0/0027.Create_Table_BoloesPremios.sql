
CREATE TABLE [dbo].[BoloesPremios](
	[CreatedDate] [datetime] NULL,
	[Posicao] [int] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[Titulo] [varchar](50) NULL,
	[ActiveFlag] [bit] NULL,
	[BackColor] [varchar](20) NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[ForeColor] [varchar](20) NULL,
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Posicao] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BoloesPremios]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO


ALTER TABLE [dbo].[BoloesPremios]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO


ALTER TABLE [dbo].[BoloesPremios]  WITH CHECK ADD FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO
