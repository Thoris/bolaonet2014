
--|--------------------------------------------------------------------------------
--| [Users] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION

	INSERT INTO [Users]
	([UserName], [FullName], [BirthDate], [Male], [CellPhone], [PhoneNumber], [CompanyPhone], [City], [Country], [State], [Street], [StreetNumber], [CPF], [RG], [MSN], [Skype], [Email], [IsApproved], [IsLockedOut], [LastActivityDate], [LastLockoutDate], [LastLoginDate], [LastPasswordChangedDate], [PasswordQuestion], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [PasswordFormat], [PasswordAnswer], [Password], [CreatedDate], [ModifiedDate], [ReceiveEmails], [ActivateKey], [Comments], [CreatedBy], [RequestedBy], [RequestedDate], [ModifiedBy], [ActiveFlag], [ApprovedBy], [ApprovedDate], [PostalCode], [IdMaritalStatus])
	VALUES
	('Admin', 'Administrador Login', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 0, '04/12/2010 13:37:39', NULL, NULL, NULL, 'Question', NULL, NULL, NULL, NULL, 0, 'Answer', 'Admin', '04/07/2010 21:31:19', '04/07/2010 21:31:19', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL);

	INSERT INTO [Users]
	([UserName], [FullName], [BirthDate], [Male], [CellPhone], [PhoneNumber], [CompanyPhone], [City], [Country], [State], [Street], [StreetNumber], [CPF], [RG], [MSN], [Skype], [Email], [IsApproved], [IsLockedOut], [LastActivityDate], [LastLockoutDate], [LastLoginDate], [LastPasswordChangedDate], [PasswordQuestion], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [PasswordFormat], [PasswordAnswer], [Password], [CreatedDate], [ModifiedDate], [ReceiveEmails], [ActivateKey], [Comments], [CreatedBy], [RequestedBy], [RequestedDate], [ModifiedBy], [ActiveFlag], [ApprovedBy], [ApprovedDate], [PostalCode], [IdMaritalStatus])
	VALUES
	('Thoris', 'Thoris Angelo Pivetta', '07/21/1981 00:00:00', 1, '', '', '', '', '', '', '', 0, '21754009808', '', '', '', 'thorisangelo@hotmail.com', 1, 0, '11/03/2012 19:25:31', NULL, '11/03/2012 19:24:18', '04/09/2010 21:02:46', '', 0, NULL, 0, NULL, 0, 'resposta', 'thoris', '04/09/2010 18:55:36', '04/09/2010 18:55:36', 0, 'HgxaDAaCqAaFrcoRHSiTtBSSRa5oHlBZSJvAFFOJCigYVcuwew', '', '', '', '04/09/2010 18:55:36', '', NULL, 'thoris', '04/09/2010 18:57:41', '', 0);

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------
