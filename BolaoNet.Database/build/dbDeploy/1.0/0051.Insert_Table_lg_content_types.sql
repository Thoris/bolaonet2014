
--|--------------------------------------------------------------------------------
--| [lg_content_types] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION

	INSERT INTO [lg_content_types]
	([Id], [Description])
	VALUES
	(1, 'TextPlain');

	INSERT INTO [lg_content_types]
	([Id], [Description])
	VALUES
	(2, 'XML');

	INSERT INTO [lg_content_types]
	([Id], [Description])
	VALUES
	(3, 'Exception');

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------
