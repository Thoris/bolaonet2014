

CREATE TABLE [dbo].[UsersInRoles](
	[RoleName] [varchar](255) NOT NULL,
	[CreatedBy] [varchar](25) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ModifiedDate] [datetime] NULL,
	[ActiveFlag] [bit] NULL,
	[UserName] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleName] ASC,
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD FOREIGN KEY([RoleName])
REFERENCES [dbo].[Roles] ([RoleName])
GO

ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[Users] ([UserName])
GO

ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD FOREIGN KEY([UserName])
REFERENCES [dbo].[Users] ([UserName])
GO