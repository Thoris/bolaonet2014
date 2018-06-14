

CREATE TABLE [dbo].[Mensagens](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](25) NULL,
	[Private] [bit] NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[TotalRead] [int] NULL,
	[Title] [varchar](100) NULL,
	[AnsweredMessageID] [int] NULL,
	[ToUser] [varchar](25) NULL,
	[Message] [varchar](4000) NULL,
	[FromUser] [varchar](25) NOT NULL,
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Mensagens] PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[FromUser] ASC,
	[MessageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
