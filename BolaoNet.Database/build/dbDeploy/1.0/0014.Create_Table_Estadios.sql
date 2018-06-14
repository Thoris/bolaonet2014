/****** Object:  Table [dbo].[Estadios]    Script Date: 10/31/2012 09:32:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Estadios](
	[Nome] [varchar](30) NOT NULL,
	[Pais] [varchar](20) NULL,
	[Estado] [varchar](20) NULL,
	[Cidade] [varchar](100) NULL,
	[Foto] [image] NULL,
	[Capacidade] [int] NULL,
	[Descricao] [varchar](255) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[CreatedBy] [varchar](25) NULL,
	[ModifiedBy] [varchar](25) NULL,
	[NomeTime] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Estadios]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Estadios]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Estadios]  WITH CHECK ADD FOREIGN KEY([NomeTime])
REFERENCES [dbo].[Times] ([Nome])
GO
