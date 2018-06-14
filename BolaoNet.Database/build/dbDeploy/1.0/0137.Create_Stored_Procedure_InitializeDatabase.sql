IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InitializeDatabase')
BEGIN
	DROP  Procedure  InitializeDatabase
END
GO
CREATE PROCEDURE [dbo].[InitializeDatabase]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF (NOT EXISTS (SELECT * FROM Users WHERE UserName = 'Admin'))
		-- Inserindo o usuário padrão de sistema
		INSERT INTO Users 
			(
				UserName,
				Password,
				PasswordFormat,
				PasswordQuestion,
				PasswordAnswer,
				FullName,
				IsLockedOut,
				IsApproved,
				CreatedDate,
				ModifiedDate,
				ActiveFlag
			)
			VALUES
			(
				'Admin',
				'Admin',
				0,
				'Question',
				'Answer',
				'Administrador Login',
				0,
				1,
				GetDate(),
				GetDate(),
				0
			)


	-- Inserindo os content types dos logs
	INSERT INTO [lg_content_types] ([Id], [Description]) VALUES (1, 'TextPlain')
	INSERT INTO [lg_content_types] ([Id], [Description]) VALUES (2, 'XML')
	INSERT INTO [lg_content_types] ([Id], [Description]) VALUES (3, 'Exception')


	-- Inserindo os níveis de log
	INSERT INTO [lg_log_level_types] ([Id], [Description]) VALUES (1, 'Debug')
	INSERT INTO [lg_log_level_types] ([Id], [Description]) VALUES (2, 'Information')
	INSERT INTO [lg_log_level_types] ([Id], [Description]) VALUES (3, 'Warning')
	INSERT INTO [lg_log_level_types] ([Id], [Description]) VALUES (4, 'Error')
	INSERT INTO [lg_log_level_types] ([Id], [Description]) VALUES (5, 'Trace')
	INSERT INTO [lg_log_level_types] ([Id], [Description]) VALUES (6, 'SucessAudit')
	INSERT INTO [lg_log_level_types] ([Id], [Description]) VALUES (7, 'FailureAudit')
	
	
	-- Inserindo o tipo de relacionamento do usuário
	INSERT INTO [UserMaritalStatus] ([IdMaritalStatus],[Description]) VALUES (0, 'Não definido')
	INSERT INTO [UserMaritalStatus] ([IdMaritalStatus],[Description]) VALUES (1, 'Casado')
	INSERT INTO [UserMaritalStatus] ([IdMaritalStatus],[Description]) VALUES (2, 'Solteiro')
	INSERT INTO [UserMaritalStatus] ([IdMaritalStatus],[Description]) VALUES (3, 'Em um relacionamento')

	
	-- Inserindo os status de requsição
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (1, 'Participar')
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (2, 'Retirar')
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (3, 'Aprovado')
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (4, 'Rejeitado')
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (5, 'Removido')
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (6, 'Mantido')
	INSERT INTO [BoloesRequestsStatus] ([StatusRequestID],[Descricao]) VALUES (7, 'Convidado')
		

	-- Inserindo os critérios fixos
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (1, 'Empate')	
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (2, 'Vitória')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (3, 'Derrota')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (4, 'Ganhador')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (5, 'Perdedor')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (6, 'Time 1')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (7, 'Time 2')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (8, 'Vitória/Empate/Derrota')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (9, 'Erro')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (10, 'Ganhador Fora')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (11, 'Ganhador Dentro')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (12, 'Perdedor Fora')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (13, 'Perdedor Dentro')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (14, 'Empate Gols')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (15, 'Gols Time 1')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (16, 'Gols Time 2')
	INSERT INTO [CriteriosFixos] ([CriterioID], [Descricao]) VALUES (17, 'Cheio')

	-- Inserindo os tipos de pagamentos
	INSERT INTO [PagamentoTipo]  ([TipoPagamento],[Descricao]) VALUES (1, 'Dinheiro')
	INSERT INTO [PagamentoTipo]  ([TipoPagamento],[Descricao]) VALUES (2, 'Cheque')
	INSERT INTO [PagamentoTipo]  ([TipoPagamento],[Descricao]) VALUES (3, 'Depósito')


	-- Inserindo os roles
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Administrador', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Apostador', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Convidado', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Avisos', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Bolão', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Campeonatos', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Critérios', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Dados Básicos', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Enquetes', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Mensagens', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Pagamentos', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Pontuação', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Publicidade', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Gerenciador de Resultados', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Visitante de Bolão', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	INSERT INTO [Roles]  ([RoleName],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate],[ActiveFlag]) VALUES ('Visitante de Campeonato', 'Admin', GetDate(), 'Admin', GetDate(), 0)
	
	
	INSERT INTO [UsersInRoles] (RoleName, UserName, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag)
	  VALUES ('Administrador', 'Admin', 'Admin', GetDate(), 'Admin', GetDate(), 0)


END



GO
