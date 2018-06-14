
--|--------------------------------------------------------------------------------
--| [CriteriosFixos] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(1, 'Empate');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(2, 'Vitória');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(3, 'Derrota');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(4, 'Ganhador');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(5, 'Perdedor');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(6, 'Time 1');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(7, 'Time 2');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(8, 'Vitória/Empate/Derrota');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(9, 'Erro');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(10, 'Ganhador Fora');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(11, 'Ganhador Dentro');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(12, 'Perdedor Fora');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(13, 'Perdedor Dentro');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(14, 'Empate Gols');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(15, 'Gols Time 1');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(16, 'Gols Time 2');

	INSERT INTO [CriteriosFixos]
	([CriterioID], [Descricao])
	VALUES
	(17, 'Cheio');

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------
