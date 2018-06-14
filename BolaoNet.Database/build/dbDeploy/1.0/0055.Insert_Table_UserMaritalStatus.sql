
--|--------------------------------------------------------------------------------
--| [UserMaritalStatus] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION

	INSERT INTO [UserMaritalStatus]
	([IdMaritalStatus], [Description])
	VALUES
	(0, 'Não definido');

	INSERT INTO [UserMaritalStatus]
	([IdMaritalStatus], [Description])
	VALUES
	(1, 'Casado');

	INSERT INTO [UserMaritalStatus]
	([IdMaritalStatus], [Description])
	VALUES
	(2, 'Solteiro');

	INSERT INTO [UserMaritalStatus]
	([IdMaritalStatus], [Description])
	VALUES
	(3, 'Em um relacionamento');

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------
