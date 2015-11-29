CREATE Procedure [dbo].[usp_LoginHandle]
	@Action nchar(3),
	@LoginId int = 0,
	@LoginName nvarchar(50) = NULL,
	@LoginPassword nvarchar(50) = NULL,
	@DateStart smalldatetime = NULL,
	@DateStop smalldatetime = NULL,
	@Enabled bit = 0,
	@Security_Add bit = 0,
	@Security_Change bit = 0,
	@Security_Delete bit = 0,
	@Finance_Add bit = 0,
	@Finance_Change bit = 0,
	@Finance_Delete bit = 0,
	@Settings_Add bit = 0,
	@Settings_Change bit = 0,
	@Settings_Delete bit = 0,
	@Groups_Delete bit = 0,
	@Clients_Delete bit = 0
AS

-- ****************************************************************************
-- Author	Bart Thieme
-- Purpose		
-- ****************************************************************************
-- Version	Date		Author	Description
-- *******	**********	******	***********************************************
-- 1.0		2010-01-01	BT		Initial Version
-- 2.0		2013-09-22	BT		Replaced Delete with inactivate
--								Replaced IF/OR with ISNULL
-- ****************************************************************************

IF @Action = 'Get'
	BEGIN
		--IF ISNULL(@LoginId,0) = 0 AND isnull(@LoginName,'') = ''
		--	BEGIN
		SELECT [PK_LoginID]
			,[LoginName]
			,[LoginPassword]
			,[DateStart]
			,[DateStop]
			,[Enabled]
			,[Security_Add]
			,[Security_Change]
			,[Security_Delete]
			,[Finance_Add]
			,[Finance_Change]
			,[Finance_Delete]
			,[Settings_Add]
			,[Settings_Change]
			,[Settings_Delete]
			,[Groups_Delete]
			,[Clients_Delete]
		FROM [dbo].[tbl_Logins]
		WHERE [Active] = 1
			AND ISNULL(@LoginId,0) IN ([PK_LoginID],0)
			AND ISNULL(@LoginName,'') IN ([LoginName],'')
		--	END
		--IF isnull(@LoginId,0) = 0 AND len(@LoginName) > 0
		--	BEGIN
		--		SELECT [PK_LoginID]
		--			  ,[LoginName]
		--			  ,[LoginPassword]
		--			  ,[DateStart]
		--			  ,[DateStop]
		--			  ,[Enabled]
		--			  ,[Security_Add]
		--			  ,[Security_Change]
		--			  ,[Security_Delete]
		--			  ,[Finance_Add]
		--			  ,[Finance_Change]
		--			  ,[Finance_Delete]
		--			  ,[Settings_Add]
		--			  ,[Settings_Change]
		--			  ,[Settings_Delete]
		--			  ,[Groups_Delete]
		--			  ,[Clients_Delete]
		--		  FROM [dbo].[tbl_Logins]
		--		WHERE [LoginName] = @LoginName
		--		  AND [Active] = 1
		--	END
		--IF @LoginId > 0
		--	BEGIN
		--		SELECT [PK_LoginID]
		--			  ,[LoginName]
		--			  ,[LoginPassword]
		--			  ,[DateStart]
		--			  ,[DateStop]
		--			  ,[Enabled]
		--			  ,[Security_Add]
		--			  ,[Security_Change]
		--			  ,[Security_Delete]
		--			  ,[Finance_Add]
		--			  ,[Finance_Change]
		--			  ,[Finance_Delete]
		--			  ,[Settings_Add]
		--			  ,[Settings_Change]
		--			  ,[Settings_Delete]
		--			  ,[Groups_Delete]
		--			  ,[Clients_Delete]
		--		  FROM [dbo].[tbl_Logins]
		--		WHERE [PK_LoginID] = @LoginId
		--		  AND [Active] = 1
		--	END
	END

IF @Action = 'Upd'
	BEGIN
		UPDATE [dbo].[tbl_Logins] SET [LoginName] = @LoginName
			,[LoginPassword] = isnull(@LoginPassword,[LoginPassword])
			,[DateStart] = @DateStart
			,[DateStop] = @DateStop
			,[Enabled] = @Enabled
			,[Security_Add] = @Security_Add
			,[Security_Change] = @Security_Change
			,[Security_Delete] = @Security_Delete
			,[Finance_Add] = @Finance_Add
			,[Finance_Change] = @Finance_Change
			,[Finance_Delete] = @Finance_Delete
			,[Settings_Add] = @Settings_Add
			,[Settings_Change] = @Settings_Change
			,[Settings_Delete] = @Settings_Delete
			,[Groups_Delete] = @Groups_Delete
			,[Clients_Delete] = @Clients_Delete
		WHERE [PK_LoginID] = @LoginId

		--		DECLARE @SQL AS nvarchar(2000)
		--		SET @SQL = 'UPDATE [dbo].[tbl_Logins] SET [LoginName] = ''' + @LoginName + ''''
		--		IF @LoginPassword IS NOT NULL SET @SQL = @SQL + ' ,[LoginPassword] = ''' + @LoginPassword + ''''
		--		SET @SQL = @SQL + ' ,[DateStart] = ''' + CONVERT(Char(8),@DateStart,112) + ''''
		--		IF @DateStop IS NOT NULL 
		--			SET @SQL = @SQL + ' ,[DateStop] = ''' + CONVERT(char(8),@DateStop,112) + ''''
		--		ELSE
		--			SET @SQL = @SQL + ' ,[DateStop] = NULL '
		--		SET @SQL = @SQL + ' ,[Enabled] = ' + CAST(@Enabled AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Security_Add] = ' + CAST(@Security_Add AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Security_Change] = ' + CAST(@Security_Change AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Security_Delete] = ' + CAST(@Security_Delete AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Finance_Add] = ' + CAST(@Finance_Add AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Finance_Change] = ' + CAST(@Finance_Change AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Finance_Delete] = ' + CAST(@Finance_Delete AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Settings_Add] = ' + CAST(@Settings_Add AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Settings_Change] = ' + CAST(@Settings_Change AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Settings_Delete] = ' + CAST(@Settings_Delete AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Groups_Delete] = ' + CAST(@Groups_Delete AS nchar(1))
		--		SET @SQL = @SQL + ' ,[Clients_Delete] = ' + CAST(@Clients_Delete AS nchar(1))
		--		SET @SQL = @SQL + ' WHERE [PK_LoginID] = ' + CAST(@LoginId AS nvarchar(10))

		--		EXEC sp_executesql @SQL
	END

IF @Action = 'Ins'
	BEGIN
		INSERT INTO [dbo].[tbl_Logins]
				([LoginName]
				,[LoginPassword]
			    ,[DateStart]
			    ,[DateStop]
			    ,[Enabled]
				,[Security_Add]
				,[Security_Change]
				,[Security_Delete]
				,[Finance_Add]
				,[Finance_Change]
				,[Finance_Delete]
				,[Settings_Add]
				,[Settings_Change]
				,[Settings_Delete]
				,[Groups_Delete]
				,[Clients_Delete])
			 VALUES
				(@LoginName
				,@LoginPassword
				,@DateStart
				,@DateStop
				,@Enabled
				,@Security_Add
				,@Security_Change
				,@Security_Delete
				,@Finance_Add
				,@Finance_Change
				,@Finance_Delete
				,@Settings_Add
				,@Settings_Change
				,@Settings_Delete
				,@Groups_Delete
				,@Clients_Delete)
	END

IF @Action = 'Del'
	BEGIN
		IF ISNULL(@LoginId,0) <> 0
			BEGIN
				UPDATE [dbo].[tbl_Logins] 
				SET [Active] = 0
				WHERE [PK_LoginID] = @LoginId
			END
	END
;
