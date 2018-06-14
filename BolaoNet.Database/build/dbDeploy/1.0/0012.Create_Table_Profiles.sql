

CREATE TABLE [dbo].[Profiles](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[IsAnonymous] [bit] NULL,
	[LastActivityDate] [datetime] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[PropertyValuesBinary] [image] NULL,
	[PropertyValuesString] [ntext] NULL,
	[PropertyNames] [ntext] NULL,
	[UserName] [varchar](25) NULL,
 CONSTRAINT [PK_Profiles2] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
