
CREATE TABLE [dbo].[lg_log_records](
	[class_name] [varchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[method_name] [varchar](50) NULL,
	[source] [varchar](50) NULL,
	[application] [int] NULL,
	[description] [varchar](255) NULL,
	[content] [text] NULL,
	[reference_id] [varchar](50) NULL,
	[computer_name] [varchar](50) NULL,
	[userlogon] [varchar](50) NULL,
	[log_guid] [uniqueidentifier] NULL,
	[time_stamp] [datetime] NULL,
	[logging_context_guid] [varchar](50) NULL,
	[content_type] [int] NULL,
	[log_level] [int] NULL,
 CONSTRAINT [PK_lg_log_records] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
