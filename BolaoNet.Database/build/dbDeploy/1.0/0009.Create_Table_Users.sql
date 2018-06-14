
CREATE TABLE [dbo].[Users](
	[UserName] [varchar](25) NOT NULL,
	[FullName] [varchar](150) NULL,
	[BirthDate] [datetime] NULL,
	[Male] [bit] NULL,
	[CellPhone] [varchar](20) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[CompanyPhone] [varchar](20) NULL,
	[City] [varchar](50) NULL,
	[Country] [varchar](25) NULL,
	[State] [varchar](30) NULL,
	[Street] [varchar](50) NULL,
	[StreetNumber] [int] NULL,
	[CPF] [varchar](20) NULL,
	[RG] [varchar](20) NULL,
	[MSN] [varchar](100) NULL,
	[Skype] [varchar](100) NULL,
	[Email] [varchar](200) NULL,
	[IsApproved] [bit] NULL,
	[IsLockedOut] [bit] NULL,
	[LastActivityDate] [datetime] NULL,
	[LastLockoutDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[LastPasswordChangedDate] [datetime] NULL,
	[PasswordQuestion] [varchar](200) NULL,
	[FailedPasswordAttemptCount] [smallint] NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NULL,
	[FailedPasswordAnswerAttemptCount] [smallint] NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NULL,
	[PasswordFormat] [smallint] NULL,
	[PasswordAnswer] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ReceiveEmails] [bit] NULL,
	[ActivateKey] [varchar](100) NULL,
	[Comments] [varchar](4000) NULL,
	[CreatedBy] [varchar](25) NULL,
	[RequestedBy] [varchar](25) NULL,
	[RequestedDate] [datetime] NULL,
	[ModifiedBy] [varchar](25) NULL,
	[ActiveFlag] [bit] NULL,
	[ApprovedBy] [varchar](25) NULL,
	[ApprovedDate] [datetime] NULL,
	[PostalCode] [varchar](20) NULL,
	[IdMaritalStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([IdMaritalStatus])
REFERENCES [dbo].[UserMaritalStatus] ([IdMaritalStatus])
GO
