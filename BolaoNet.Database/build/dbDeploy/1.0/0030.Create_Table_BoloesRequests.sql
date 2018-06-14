

CREATE TABLE [dbo].[BoloesRequests](
	[CreatedBy] [varchar](25) NULL,
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[RequestedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[AnsweredDate] [datetime] NULL,
	[RequestedBy] [varchar](25) NULL,
	[Owner] [varchar](25) NULL,
	[StatusRequestID] [int] NULL,
	[AnsweredBy] [varchar](25) NULL,
	[Descricao] [varchar](255) NULL,
 CONSTRAINT [PK_BoloesRequests] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC,
	[NomeBolao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
