
--|--------------------------------------------------------------------------------
--| [Roles] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Administrador', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Apostador', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Convidado', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Avisos', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Bolão', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Campeonatos', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Critérios', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Dados Básicos', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Enquetes', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Mensagens', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Pagamentos', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Pontuação', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Publicidade', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Gerenciador de Resultados', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Visitante de Bolão', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

	INSERT INTO [Roles]
	([RoleName], [Description], [CreatedDate], [ModifiedDate], [ActiveFlag], [CreatedBy], [ModifiedBy])
	VALUES
	('Visitante de Campeonato', NULL, '04/07/2010 21:55:56', '04/07/2010 21:55:56', 0, 'Admin', 'Admin');

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------
