﻿-- BEGINNING TRANSACTION STRUCTURE
PRINT 'Beginning transaction STRUCTURE'
BEGIN TRANSACTION _STRUCTURE_
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChangeLog]') AND type in (N'U'))
BEGIN
	CREATE TABLE ChangeLog 
	(
		change_number INTEGER NOT NULL,
		delta_set VARCHAR(10) NOT NULL,
		start_dt DATETIME NOT NULL,
		complete_dt DATETIME NULL,
		applied_by VARCHAR(100) NOT NULL,
		description VARCHAR(500) NOT NULL
	)
	IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
	
	ALTER TABLE ChangeLog ADD CONSTRAINT Pk_ChangeLog PRIMARY KEY (change_number, delta_set)
	IF @@ERROR<>0 OR @@TRANCOUNT=0 BEGIN IF @@TRANCOUNT>0 ROLLBACK SET NOEXEC ON END
END

-- COMMITTING TRANSACTION STRUCTURE
PRINT 'Committing transaction STRUCTURE'
IF @@TRANCOUNT>0
	COMMIT TRANSACTION _STRUCTURE_
GO

SET NOEXEC OFF
GO
