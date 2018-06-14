
--|--------------------------------------------------------------------------------
--| [lg_log_level_types] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION

	INSERT INTO [lg_log_level_types]
	([ID], [Description])
	VALUES
	(1, 'Debug');

	INSERT INTO [lg_log_level_types]
	([ID], [Description])
	VALUES
	(2, 'Information');

	INSERT INTO [lg_log_level_types]
	([ID], [Description])
	VALUES
	(3, 'Warning');

	INSERT INTO [lg_log_level_types]
	([ID], [Description])
	VALUES
	(4, 'Error');

	INSERT INTO [lg_log_level_types]
	([ID], [Description])
	VALUES
	(5, 'Trace');

	INSERT INTO [lg_log_level_types]
	([ID], [Description])
	VALUES
	(6, 'SucessAudit');

	INSERT INTO [lg_log_level_types]
	([ID], [Description])
	VALUES
	(7, 'FailureAudit');

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------
