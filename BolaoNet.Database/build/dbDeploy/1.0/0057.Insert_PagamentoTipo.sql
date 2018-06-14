
--|--------------------------------------------------------------------------------
--| [PagamentoTipo] - Backs up all the data from a table into a SQL script.
--|--------------------------------------------------------------------------------
BEGIN TRANSACTION

	INSERT INTO [PagamentoTipo]
	([TipoPagamento], [Descricao])
	VALUES
	('1', 'Dinheiro');

	INSERT INTO [PagamentoTipo]
	([TipoPagamento], [Descricao])
	VALUES
	('2', 'Cheque');

	INSERT INTO [PagamentoTipo]
	([TipoPagamento], [Descricao])
	VALUES
	('3', 'Depósito');

IF @@ERROR <> 0 ROLLBACK TRANSACTION;
ELSE COMMIT TRANSACTION;
GO
--|--------------------------------------------------------------------------------
