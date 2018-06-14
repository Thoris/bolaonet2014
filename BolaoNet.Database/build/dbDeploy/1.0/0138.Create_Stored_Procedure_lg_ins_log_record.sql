IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'lg_ins_log_record')
BEGIN
	DROP  Procedure  lg_ins_log_record
END
GO
CREATE PROCEDURE [dbo].[lg_ins_log_record]
(
	@class_name						varchar(50),
	@method_name					varchar(50),
	@source							varchar(50),
	@application_id					int,
	@description					varchar(255), 
	@reference_id					varchar(50), 
	@computer_name					varchar(50), 
	@userlogon						varchar(50), 
	@log_guid						varchar(50), 
	@time_stamp						datetime, 
	@log_level						int, 
	@content_type					int,
	@content						text,
	@logging_context_guid			varchar(50)
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM lg_log_records WHERE log_guid = @log_guid)
	BEGIN
		INSERT INTO lg_log_records
		(
			class_name, 
			method_name, 
			source, 
			application, 
			description, 
			reference_id, 
			computer_name, 
			userlogon,
			log_guid, 
			time_stamp, 
			log_level, 
			content_type,
			content,
			logging_context_guid
		)
		VALUES
		(
			@class_name,
			@method_name,
			@source,
			@application_id,
			@description,
			@reference_id,
			@computer_name,
			@userlogon,
			@log_guid,
			@time_stamp,
			@log_level,
			@content_type,
			@content,
			@logging_context_guid
		)

	END

END



GO
