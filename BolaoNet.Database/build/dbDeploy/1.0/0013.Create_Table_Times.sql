

CREATE TABLE [dbo].[Times](
	[Nome] [varchar](30) NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ActiveFlag] [bit] NULL,
	[IsClube] [bit] NULL,
	[Escudo] [image] NULL,
	[DataFundacao] [datetime] NULL,
	[Site] [varchar](100) NULL,
	[Pais] [varchar](20) NULL,
	[Estado] [varchar](20) NULL,
	[Cidade] [varchar](20) NULL,
	[Descricao] [varchar](255) NULL,
	[NomeMascote] [varchar](20) NULL,
	[Mascote] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Times]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Times]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO
