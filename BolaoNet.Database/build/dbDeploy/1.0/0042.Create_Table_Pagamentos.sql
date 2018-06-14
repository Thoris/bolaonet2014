

CREATE TABLE [dbo].[Pagamentos](
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[DataPagamento] [datetime] NOT NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[Descricao] [varchar](255) NULL,
	[ActiveFlag] [bit] NULL,
	[NomeBolao] [varchar](30) NOT NULL,
	[UserName] [varchar](25) NOT NULL,
	[Valor] [decimal](5, 2) NULL,
	[TipoPagamento] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[NomeBolao] ASC,
	[UserName] ASC,
	[DataPagamento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Pagamentos]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Pagamentos]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[Pagamentos]  WITH CHECK ADD FOREIGN KEY([NomeBolao])
REFERENCES [dbo].[Boloes] ([Nome])
GO

ALTER TABLE [dbo].[Pagamentos]  WITH CHECK ADD FOREIGN KEY([TipoPagamento])
REFERENCES [dbo].[PagamentoTipo] ([TipoPagamento])
GO

ALTER TABLE [dbo].[Pagamentos]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[Users] ([UserName])
GO
