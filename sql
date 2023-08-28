USE [SC.VersionManagement]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[Id] [uniqueidentifier] NOT NULL,
	[TenantId] [bigint] NOT NULL,
	[WorkGroupId] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedDateUnixTime] [int] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedByName] [nvarchar](128) NULL,
	[LastEditedDate] [datetime] NULL,
	[LastEditedDateUnixTime] [int] NULL,
	[LastEditedBy] [bigint] NULL,
	[LastEditedByName] [nvarchar](128) NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeleteDateUnixTime] [int] NULL,
	[DeleteByName] [nvarchar](128) NULL,
 CONSTRAINT [PK_Application ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [int] NOT NULL,
	[ErrorTime] [datetime] NULL,
	[UserName] [nvarchar](200) NULL,
	[HostName] [nvarchar](200) NULL,
	[ErrorNumber] [int] NULL,
	[ErrorCode] [int] NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorProcedure] [nvarchar](126) NULL,
	[ErrorLine] [int] NULL,
	[ErrorMessage] [nvarchar](4000) NULL,
	[ServiceID] [int] NULL,
	[AccountID] [bigint] NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VersionDetail]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VersionDetail](
	[Id] [uniqueidentifier] NOT NULL,
	[TenantId] [bigint] NOT NULL,
	[WorkGroupId] [bigint] NOT NULL,
	[VersionLockDateId] [uniqueidentifier] NULL,
	[VersionId] [uniqueidentifier] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedDateUnixTime] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedByName] [nvarchar](128) NULL,
	[LastEditedDate] [datetime] NULL,
	[LastEditedDateUnixTime] [int] NULL,
	[LastEditedBy] [bigint] NULL,
	[LastEditedByName] [nvarchar](128) NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeleteDateUnixTime] [int] NULL,
	[DeleteByName] [nvarchar](128) NULL,
 CONSTRAINT [PK_VersionDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VersionEvironment]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VersionEvironment](
	[Id] [uniqueidentifier] NOT NULL,
	[IdApplication] [uniqueidentifier] NOT NULL,
	[TenantId] [bigint] NOT NULL,
	[WorkGroupId] [bigint] NOT NULL,
	[UrlFile] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Environment] [int] NULL,
	[Version] [decimal](18, 1) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedDateUnixTime] [int] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedByName] [nvarchar](128) NULL,
	[LastEditedDate] [datetime] NULL,
	[LastEditedDateUnixTime] [int] NULL,
	[LastEditedBy] [bigint] NULL,
	[LastEditedByName] [nvarchar](128) NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeleteDateUnixTime] [int] NULL,
	[DeleteByName] [nvarchar](128) NULL,
 CONSTRAINT [PK_VersionEvironment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VersionLockDate]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VersionLockDate](
	[Id] [uniqueidentifier] NOT NULL,
	[TenantId] [bigint] NOT NULL,
	[WorkGroupId] [bigint] NOT NULL,
	[IsPublic] [bit] NULL,
	[Active] [bit] NULL,
	[Environment] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedDateUnixTime] [int] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedByName] [nvarchar](128) NULL,
	[LastEditedDate] [datetime] NULL,
	[LastEditedDateUnixTime] [int] NULL,
	[LastEditedBy] [bigint] NULL,
	[LastEditedByName] [nvarchar](128) NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeleteDateUnixTime] [int] NULL,
	[DeleteByName] [nvarchar](128) NULL,
 CONSTRAINT [PK_LookVersion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application] ADD  CONSTRAINT [DF_Application _IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[VersionDetail] ADD  CONSTRAINT [DF_VersionDetail_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[VersionEvironment] ADD  CONSTRAINT [DF_VersionEvironment_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[VersionEvironment] ADD  CONSTRAINT [DF_VersionEvironment_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[VersionLockDate] ADD  CONSTRAINT [DF_LookVersion_IsPublic]  DEFAULT ((0)) FOR [IsPublic]
GO
ALTER TABLE [dbo].[VersionLockDate] ADD  CONSTRAINT [DF_LockVersion_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[VersionLockDate] ADD  CONSTRAINT [DF_VersionLockDate_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  StoredProcedure [dbo].[SP_Application_FeGetByPage]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		linhvd
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROC [dbo].[SP_Application_FeGetByPage]
	@TenantId				BIGINT					= NULL,
	@WorkGroupId			BIGINT					= NULL,
	@Keyword				NVARCHAR(512)			= NULL,
	@PageNumber				INT						= 1,
	@PageSize				INT						= 10,
	@Orderby				BIT						= 1,
    @FieldName				nvarchar(64)			= 'CreatedDate'
AS
BEGIN
		SET @Keyword				= [dbo].[ValidateString](@Keyword)
		--- Validate tránh sql injection ---
		SET @FieldName				= [dbo].[ValidateString](@FieldName)
		
		--- Validate tránh sql injection ---

		--- Kiểm tra cột muốn sort có nằm trong table muốn lấy ra không ---
		IF NOT EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS  WHERE  TABLE_NAME = 'Application'AND COLUMN_NAME = @FieldName)
		BEGIN
			SET @FieldName = 'CreatedDate'
		END
		--- Kiểm tra cột muốn sort có nằm trong table muốn lấy ra không ---

		--- Order by ---
		DECLARE @OrderbyQr nvarchar(4) = null
		IF @Orderby = 1
		BEGIN
			SET @OrderbyQr = 'desc'
		END
		ELSE
		BEGIN
			SET @OrderbyQr = 'asc'
		END
		--- Order by ---

		--- Sort FieldName ---
		DECLARE @SortFieldNameQuery nvarchar(512) = CONCAT(' ORDER BY ' , @FieldName , ' ' , @OrderbyQr)
		--- Sort FieldName ---

		--- Paging ---
		DECLARE @PagingQuery nvarchar(512) = null
		IF @PageNumber is not null AND @PageSize is not null
		BEGIN
			SET @PagingQuery =   CONCAT(' OFFSET ',@PageSize ,'  * (' , @PageNumber ,'  - 1) ROWS FETCH NEXT ' , @PageSize , '  ROWS ONLY ')
		END
		--- Paging ---

		-- full text search Key LEFT JOIN --> INER JOIN --- 
		DECLARE @KeyQr nvarchar(512) = null
		IF @Keyword IS NOT NULL AND @Keyword != ''
		BEGIN
			SET @KeyQr = 'FROM [dbo].[Application] WHERE [Application].[Name] LIKE N''%' + CAST(@Keyword as nvarchar) + '%'''
		END
		ELSE
		BEGIN
			SET @KeyQr = ' FROM [dbo].[Application]'
		END
		--- WHERE Like Key ---

		--- Excute Query ---
		DECLARE @sql NVARCHAR(MAX); 
		SET @sql =  'SELECT [Id]
			  ,[TenantId]
			  ,[WorkGroupId]
			  ,[Name]
			  ,[Description]
			  ,[CreatedDate]
			  ,[CreatedDateUnixTime]
			  ,[CreatedBy]
			  ,[CreatedByName]
			  ,[LastEditedDate]
			  ,[LastEditedDateUnixTime]
			  ,[LastEditedBy]
			  ,[LastEditedByName]
			  ,[DeletedBy]
			  ,[DeletedDate]
			  ,[IsDeleted]
			  ,[DeleteDateUnixTime]
			  ,[DeleteByName]'

		SET @sql = @sql +  @KeyQr

		--- Thêm xử lý phần lấy Paging ---
		IF @PagingQuery IS NOT NULL
		BEGIN
			SET @sql = ' WITH Main_CTE AS( ' + @sql + ')
				  , Count_CTE AS (
					SELECT COUNT(*) AS [Total]
					FROM Main_CTE
				  )
				  SELECT *
				  FROM Main_CTE, Count_CTE' + @SortFieldNameQuery + @PagingQuery
		END
		ELSE
		BEGIN
			SET @sql = ' WITH Main_CTE AS( ' + @sql + ')
				  , Count_CTE AS (
					SELECT COUNT(*) AS [Total]
					FROM Main_CTE
				  )
				  SELECT *
				  FROM Main_CTE, Count_CTE' + @SortFieldNameQuery 
		END
		--- Thêm xử lý phần lấy Paging ---
		EXEC (@sql) 
		--- Excute Query ---
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Application_GetDetailById]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[SP_Application_GetDetailById]
	@Id					UNIQUEIDENTIFIER		,
	@TenantId				BIGINT				= NULL,
	@WorkGroupId			BIGINT				= NULL
AS
BEGIN
	IF(EXISTS(SELECT [Id] FROM [dbo].[Application] WHERE [Id] = @Id))
			BEGIN
				SELECT [Id]
					  ,[TenantId]
					  ,[WorkGroupId]
					  ,[Name]
					  ,[Description]
					  ,[CreatedDate]
					  ,[CreatedDateUnixTime]
					  ,[CreatedBy]
					  ,[CreatedByName]
					  ,[LastEditedDate]
					  ,[LastEditedDateUnixTime]
					  ,[LastEditedBy]
					  ,[LastEditedByName]
					  ,[DeletedBy]
					  ,[DeletedDate]
					  ,[IsDeleted]
					  ,[DeleteDateUnixTime]
					  ,[DeleteByName]
				  FROM [dbo].[Application ]
				  Where [Id] = @Id
				RETURN
			 END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Application_Insert]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[SP_Application_Insert]
	@Id											UNIQUEIDENTIFIER		  ,
	@Name										NVARCHAR(100)		= null,
	@Description								NVARCHAR(250)		= null,
	@CreatedBy									BIGINT				= null,
	@CreatedByName								NVARCHAR(128)		= NULL,
	@TenantId									BIGINT				= NULL,
	@WorkGroupId								BIGINT				= NULL,
	@ResponseStatus								BIGINT				= -99 OUTPUT
AS
BEGIN
	SET @ResponseStatus															= -99	--- SystemError ---
	DECLARE @CreatedDate												DATETIME	= GETUTCDATE()
	DECLARE @CreatedDateUnixTime						INT			= [dbo].[FN_UNIX_TIMESTAMP](GETUTCDATE())
	DECLARE @ERROR_EXISTED										INT				= -100
	DECLARE @ERROR_NOT_EXISTED									INT				= -101
	DECLARE @ERROR_NOT_NULL_NAME								INT				= -102

	IF(@Name = NULL OR @Name = '')
			BEGIN
				SET @ResponseStatus = @ERROR_NOT_NULL_NAME
				RETURN
			END
	IF(NOT EXISTS(SELECT [Id] FROM [dbo].[Application] WHERE [Name] = @Name))
			BEGIN
				INSERT INTO [dbo].[Application ]
					   ([Id]
					   ,[TenantId]
					   ,[WorkGroupId]
					   ,[Name]
					   ,[Description]
					   ,[CreatedDate]
					   ,[CreatedDateUnixTime]
					   ,[CreatedBy]
					   ,[CreatedByName]
					   ,[IsDeleted])
				  VALUES
					  (@Id
					  ,@TenantId
					  ,@WorkGroupId
					  ,@Name
					  ,@Description
					  ,@CreatedDate
					  ,@CreatedDateUnixTime
					  ,@CreatedBy
					  ,@CreatedByName
					  ,0)
				SET @ResponseStatus = 1
				RETURN
			 END
	 ELSE
			 BEGIN
				SET @ResponseStatus = @ERROR_EXISTED
				RETURN
			 END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Application_Update]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[SP_Application_Update]
	@Id											UNIQUEIDENTIFIER,
	@Name										NVARCHAR(100)		= null,
	@Description								NVARCHAR(250)		= null,
	@ModifiedBy									BIGINT,
	@TenantId				BIGINT				= NULL,
	@WorkGroupId			BIGINT				= NULL,
	@ResponseStatus								BIGINT				= -99 OUTPUT
AS
BEGIN
	SET @ResponseStatus															= -99	--- SystemError ---
	DECLARE @ModifiedDate										DATETIME		= GETUTCDATE()
	DECLARE @ERROR_EXISTED										INT				= -100
	DECLARE @ERROR_NOT_EXISTED									INT				= -101
	DECLARE @ERROR_NOT_NULL_NAME								INT				= -102

	IF(@Name = NULL OR @Name = '')
			BEGIN
				SET @ResponseStatus = @ERROR_NOT_NULL_NAME
				RETURN
			END
	IF(EXISTS(SELECT [Id] FROM [dbo].[Application] WHERE [Name] = @Name AND [Description] = @Description))
			BEGIN
				SET @ResponseStatus = @ERROR_EXISTED
				RETURN
			END
	IF(EXISTS(SELECT [Id] FROM [dbo].[Application] WHERE [Id] = @Id))
			BEGIN
				UPDATE [dbo].[Application ]
					   SET [Name] = @Name
						  ,[Description] = @Description
						  ,[LastEditedBy] = @ModifiedBy
						  ,[LastEditedDate] = @ModifiedDate
					 WHERE [Id] = @Id 
				SET @ResponseStatus = 1
				RETURN
			 END
	 ELSE
			 BEGIN
				SET @ResponseStatus = @ERROR_NOT_EXISTED
				RETURN
			 END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LogError]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[SP_LogError]
    @_ErrorCode [int] = 0 OUTPUT
--WITH ENCRYPTION
AS
BEGIN
  SET NOCOUNT ON;
  SET @_ErrorCode = 0;
  BEGIN TRY
     IF ERROR_NUMBER() IS NULL   RETURN;
     IF XACT_STATE() = -1
     BEGIN
        PRINT 'Cannot log error since the current transaction is in an uncommittable state. '
        + 'Rollback the transaction before executing SP_LogError in order to successfully log error information.';
        RETURN;
     END
     SELECT @_ErrorCode =
     CASE
        WHEN ERROR_NUMBER() = 2601 THEN -2 -- Cannot UPDATE,INSERT duplicate key row unique
        WHEN ERROR_NUMBER() = 515     THEN -3 -- value NULL into column  does not allow nulls.
        WHEN ERROR_NUMBER()
           IN (245,235,8114,293)     THEN -4 -- Error converting data type varchar to (INT,BIGINT,Numeric,Money,SmallMoney).
        WHEN ERROR_NUMBER() = 241     THEN -5 -- Conversion failed when converting datetime from character string.
        WHEN ERROR_NUMBER() = 547     THEN -6 -- The UPDATE,INSERT statement conflicted with the FOREIGN KEY constraint
        WHEN ERROR_NUMBER() = 544    THEN -7 -- Cannot INSERT explicit value for identity column in table  when IDENTITY_INSERT is set to OFF.
        WHEN ERROR_NUMBER() = 248    THEN -8 -- The conversion value overflowed an int column. Maximum VALUE exceeded.
        WHEN ERROR_NUMBER() = 1205    THEN -9 -- Transaction was deadlocked on lock resources with another process and has been chosen as the deadlock victim.
        ELSE 0
           --ELSE ERROR_NUMBER()
     END  -- END CASE
     INSERT [dbo].[ErrorLog]
        (
        [UserName],
        [HostName],
        [ErrorNumber],
        [ErrorCode],
        [ErrorSeverity],
        [ErrorState],
        [ErrorProcedure],
        [ErrorLine],
        [ErrorMessage])
     VALUES
        (
        CONVERT(sysname, CURRENT_USER),
         HOST_NAME(),
        ERROR_NUMBER(),
        @_ErrorCode,
        ERROR_SEVERITY(),
        ERROR_STATE(),
        ERROR_PROCEDURE(),
        ERROR_LINE(),
        ERROR_MESSAGE()
        );
  END TRY
  BEGIN CATCH
     PRINT 'An error occurred in stored procedure SP_LogError: ';
     RETURN -1;
  END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_VersionDetail_Insert]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_VersionDetail_Insert]
	-- Add the parameters for the stored procedure here
		@Id							uniqueidentifier	= NULL
        ,@TenantId					bigint				= NULL
        ,@WorkgroupId				bigint				= NULL
        ,@VersionLockDateId			uniqueidentifier	= NULL
        ,@VersionId					uniqueidentifier	= NULL
        ,@CreatedBy					bigint				= NULL
        ,@CreatedByName				nvarchar(128)		= NULL
		,@ResponseStatus			INT					= 0			OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET @ResponseStatus												= -99	--- SystemError ---
	DECLARE @CreatedDate								DATETIME	= GETUTCDATE()
	DECLARE @CreatedDateUnixTime						INT			= [dbo].[FN_UNIX_TIMESTAMP](GETUTCDATE())
	DECLARE @ERROR_VERSIONDETAIL_EXISTED				INT			= -122

	BEGIN TRY
		IF(NOT EXISTS(SELECT [Id] FROM [dbo].[VersionLockDate] WHERE [Id] = @Id AND [IsDeleted] <> 1))
		BEGIN
		
			INSERT INTO [dbo].[VersionDetail]
           ([Id]
           ,[TenantId]
           ,[WorkgroupId]
           ,[VersionLockDateId]
           ,[VersionId]
           ,[CreatedDate]
           ,[CreatedDateUnixTime]
           ,[CreatedBy]
           ,[CreatedByName])
     VALUES
           (@Id
           ,@TenantId
           ,@WorkgroupId
           ,@VersionLockDateId
           ,@VersionId
           ,@CreatedDate
           ,@CreatedDateUnixTime
           ,@CreatedBy
           ,@CreatedByName)
		SET @ResponseStatus = 1
		RETURN
	  END
	  ELSE
	  BEGIN
		SET @ResponseStatus = @ERROR_VERSIONDETAIL_EXISTED
		RETURN
	  END
	END TRY
	BEGIN CATCH
		EXEC [dbo].[SP_LogError]
		SET @ResponseStatus	= -99;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionEnvironment_FeGetByPage]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		linhvd
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROC [dbo].[SP_VersionEnvironment_FeGetByPage]
	@TenantId				BIGINT					= NULL,
	@WorkGroupId			BIGINT					= NULL,
	@Keyword				NVARCHAR(512)			= NULL,
	@PageNumber				INT						= 1,
	@PageSize				INT						= 10,
	@Orderby				BIT						= 1,
    @FieldName				nvarchar(64)			= 'CreatedDate',
	@IdApplication			nvarchar(36)			= null,
	@Active					nvarchar(1)			= null,
	@Environment			nvarchar(1)			= null
AS
BEGIN
		SET @Keyword				= [dbo].[ValidateString](@Keyword)
		--- Validate tránh sql injection ---
		SET @FieldName				= [dbo].[ValidateString](@FieldName)
		DECLARE @EmptyGuid uniqueidentifier = '00000000-0000-0000-0000-000000000000'
		--- Validate tránh sql injection ---

		--- Kiểm tra cột muốn sort có nằm trong table muốn lấy ra không ---
		IF NOT EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS  WHERE  TABLE_NAME = 'Application'AND COLUMN_NAME = @FieldName)
		BEGIN
			SET @FieldName = 'CreatedDate'
		END
		--- Kiểm tra cột muốn sort có nằm trong table muốn lấy ra không ---

		--- Order by ---
		DECLARE @OrderbyQr nvarchar(4) = null
		IF @Orderby = 1
		BEGIN
			SET @OrderbyQr = 'desc'
		END
		ELSE
		BEGIN
			SET @OrderbyQr = 'asc'
		END
		--- Order by ---

		--- Sort FieldName ---
		DECLARE @SortFieldNameQuery nvarchar(512) = CONCAT(' ORDER BY ' , @FieldName , ' ' , @OrderbyQr)
		--- Sort FieldName ---

		--- Paging ---
		DECLARE @PagingQuery nvarchar(512) = null
		IF @PageNumber is not null AND @PageSize is not null
		BEGIN
			SET @PagingQuery =   CONCAT(' OFFSET ',@PageSize ,'  * (' , @PageNumber ,'  - 1) ROWS FETCH NEXT ' , @PageSize , '  ROWS ONLY ')
		END
		--- Paging ---

		--- Active ---
		DECLARE @ActiveQuery nvarchar(512) = null 
		IF @Active is not null AND @Active != ''
		BEGIN
			SET @ActiveQuery = 'AND [VersionEvironment].[Active] = ''' + CAST(@Active as nvarchar) + ''''
		END
		--- Active ---

		--- Environment ---
		DECLARE @EnvironmentQuery nvarchar(512) = null
		IF @Environment is not null AND @Environment != ''
		BEGIN
			SET @EnvironmentQuery = 'AND [VersionEvironment].[Environment] = ''' + CAST(@Environment as nvarchar) + ''''
		END
		--- Environment ---


		--- IdApplication ---
		DECLARE @IdApplicationQuery nvarchar(512) = null
		IF @IdApplication <> @EmptyGuid
		BEGIN
			SET @IdApplicationQuery = 'AND [VersionEvironment].[IdApplication] = ''' + CAST(@IdApplication as nvarchar(36)) + ''''
		END
		--- IdApplication ---

		-- full text search Key LEFT JOIN --> INNER JOIN ---
			DECLARE @KeyQr nvarchar(512) = null
			IF @Keyword IS NOT NULL AND @Keyword != ''
			BEGIN
				SET @KeyQr = 'WHERE [VersionEvironment].[Description] LIKE N''%' + CAST(@Keyword as nvarchar) + '%'''
			END
			ELSE
			BEGIN
				SET @KeyQr = 'WHERE [VersionEvironment].[IsDeleted] = 0'
			END
			--- WHERE Like Key ---

			--- Execute Query ---
			DECLARE @sql NVARCHAR(MAX); 
			SET @sql =      'SELECT [Id]
							,[IdApplication]
							,[TenantId]
							,[WorkGroupId]
							,[UrlFile]
							,[Description]
							,[Environment]
							,[Version]
							,[Active]
							,[CreatedDate]
							,[CreatedDateUnixTime]
							,[CreatedBy]
							,[CreatedByName]
							,[LastEditedDate]
							,[LastEditedDateUnixTime]
							,[LastEditedBy]
							,[LastEditedByName]
							,[DeletedBy]
							,[DeletedDate]
							,[IsDeleted]
							,[DeleteDateUnixTime]
							,[DeleteByName]
							FROM [dbo].[VersionEvironment] ' + @KeyQr

		--- where ActiveQuery ---
		IF @ActiveQuery IS NOT NULL
		BEGIN
			SET @sql = @sql +  @ActiveQuery
		END

		--- where ActiveQuery ---

		--- where IdApplicationQuery ---
		IF @IdApplicationQuery IS NOT NULL
		BEGIN
			SET @sql = @sql +  @IdApplicationQuery
		END

		--- where IdApplicationQuery ---

		--- where EnvironmentQuery---
		IF @EnvironmentQuery IS NOT NULL
		BEGIN
			SET @sql = @sql +  @EnvironmentQuery
		END

		--- where EnvironmentQuery ---

		--- Thêm xử lý phần lấy Paging ---
		IF @PagingQuery IS NOT NULL
		BEGIN
			SET @sql = ' WITH Main_CTE AS( ' + @sql + ')
				  , Count_CTE AS (
					SELECT COUNT(*) AS [Total]
					FROM Main_CTE
				  )
				  SELECT *
				  FROM Main_CTE, Count_CTE' + @SortFieldNameQuery + @PagingQuery
		END
		ELSE
		BEGIN
			SET @sql = ' WITH Main_CTE AS( ' + @sql + ')
				  , Count_CTE AS (
					SELECT COUNT(*) AS [Total]
					FROM Main_CTE
				  )
				  SELECT *
				  FROM Main_CTE, Count_CTE' + @SortFieldNameQuery 
		END
		--- Thêm xử lý phần lấy Paging ---
		EXEC (@sql) 
		--- Excute Query ---
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionEnvironment_GetByVersionLockDateId]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[SP_VersionEnvironment_GetByVersionLockDateId]
    @VersionLockDateId								uniqueidentifier	= NULL
	,@ResponseStatus								BIGINT				= -99 OUTPUT
AS
BEGIN
	SELECT [VersionEvironment].[Id]
      ,[Application].[Name]
      ,[VersionEvironment].[UrlFile]
      ,[VersionEvironment].[Description]
      ,[VersionEvironment].[Environment]
      ,[VersionEvironment].[Version]
      ,[VersionEvironment].[Active]
      ,[VersionEvironment].[CreatedDate]
      ,[VersionEvironment].[CreatedDateUnixTime]
      ,[VersionEvironment].[CreatedBy]
      ,[VersionEvironment].[CreatedByName]
      ,[VersionEvironment].[LastEditedDate]
      ,[VersionEvironment].[LastEditedDateUnixTime]
      ,[VersionEvironment].[LastEditedBy]
      ,[VersionEvironment].[LastEditedByName]
      ,[VersionEvironment].[DeletedBy]
      ,[VersionEvironment].[DeletedDate]
      ,[VersionEvironment].[IsDeleted]
      ,[VersionEvironment].[DeleteDateUnixTime]
      ,[VersionEvironment].[DeleteByName]
	  FROM [dbo].[VersionEvironment]
	  INNER JOIN [dbo].[Application] ON [VersionEvironment].[IdApplication] = [Application].[Id]
	  Where [VersionEvironment].[IsDeleted] <> 1
		AND [VersionEvironment].[Id] IN (Select [VersionId]  from [dbo].[VersionDetail] where [VersionLockDateId] = @VersionLockDateId)
	SET @ResponseStatus = 1
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionEnvironment_GetMaxVersion]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[SP_VersionEnvironment_GetMaxVersion]
	@IdApplication								UNIQUEIDENTIFIER,
	@Environment								INT
AS
BEGIN
	SELECT MAX([Version])
	FROM [dbo].[VersionEvironment]
	WHERE [IdApplication] = @IdApplication AND [Environment] = @Environment
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionEnvironment_Insert]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[SP_VersionEnvironment_Insert]
	@Id											UNIQUEIDENTIFIER,
	@IdApplication								UNIQUEIDENTIFIER,
	@UrlFile									NVARCHAR(MAX)		= NULL,
	@Description								NVARCHAR(250)		= NULL,
	@Environment									INT				= NULL,
	@TenantId									BIGINT				= NULL,
	@WorkGroupId								BIGINT				= NULL,
	@CreatedBy									BIGINT				= NULL,
	@ResponseStatus								BIGINT				= -99 OUTPUT
AS
BEGIN
	SET @ResponseStatus												= -99	--- SystemError ---
	DECLARE @CreatedDate								DATETIME		= GETUTCDATE()
	DECLARE @Version									DECIMAL(18,1)			= 1.0
	DECLARE @Max_Version								DECIMAL(18,1)			= 0
	DECLARE @ERROR_EXISTED								INT				= -100
	DECLARE @ERROR_NOT_Environment						INT				= -101
	DECLARE @ERROR_NOT_URLFILE							INT				= -102
	DECLARE @ERROR_APPLICATION_NOT_EXISTED				INT				= -123
	
	--Kiểm tra Environment và UrlFile có bị null không
	IF(@Environment = NULL OR @Environment = '')
			BEGIN
				SET @ResponseStatus = @ERROR_NOT_Environment
				RETURN
			END
	IF(@UrlFile = NULL OR @UrlFile = '')
			BEGIN
				SET @ResponseStatus = @ERROR_NOT_URLFILE
				RETURN
			END

	IF(NOT EXISTS(SELECT [Id] FROM [dbo].[Application] WHERE [Id] = @IdApplication))
			BEGIN
				SET @ResponseStatus = @ERROR_APPLICATION_NOT_EXISTED
				RETURN
			END

	--Kiểm tra Environment và UrlFile có bị null không

	--Tự động ver 
	SET @Max_Version = (SELECT MAX(Version) FROM [dbo].[VersionEvironment] WHERE [IdApplication] = @IdApplication AND [Environment] = @Environment)
		IF(@Max_Version >= 1.0)
			BEGIN
				SET @Version = @Max_Version + 0.1
			END
	--Tự động ver

	IF(NOT EXISTS(SELECT [Id] FROM [dbo].[VersionEvironment] WHERE [Id] = @Id))
	  BEGIN
				INSERT INTO [dbo].[VersionEvironment]
						   ([Id]
						   ,[IdApplication]
						   ,[UrlFile]
						   ,[Description]
						   ,[Environment]
						   ,[Version]
						   ,[WorkGroupId]
						   ,[TenantId]
						   ,[Active]
						   ,[CreatedBy]
						   ,[CreatedDate]
						   ,[IsDeleted])
						  VALUES
							  (@Id
							  ,@IdApplication
							  ,@UrlFile
							  ,@Description
							  ,@Environment
							  ,@Version
							  ,@WorkGroupId
							  ,@TenantId
							  ,0
							  ,@CreatedBy
							  ,@CreatedDate
							  ,0)
						--Kiểm tra Active rồi cập nhật
						--IF(@Active = 1)
						--	BEGIN
						--			UPDATE [dbo].[VersionEvironment]
						--			   SET [Active] = 0
						--			 WHERE [Id] <> @Id AND [IdApplication] = @IdApplication AND [Environment] = @Environment
						--	END
						--Kiểm tra Active rồi cập nhật
						SET @ResponseStatus = 1
						RETURN
			
	  END
	  ELSE
	  BEGIN
		SET @ResponseStatus = @ERROR_EXISTED
		RETURN
	  END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionEnvironment_UpdateActive]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_VersionEnvironment_UpdateActive]
	@TenantId				BIGINT				= NULL,
	@WorkGroupId			BIGINT				= NULL,
	@Id						UNIQUEIDENTIFIER	= NULL,
	@LastEditedBy			BIGINT				= NULL,
	@ResponseStatus			BIGINT				= -99 OUTPUT
AS
BEGIN
	SET @ResponseStatus											= -99	--- SystemError ---
	DECLARE @LastEditedDate									DATETIME	= GETUTCDATE()
	DECLARE @LastEditedDateUnixTime							INT			= [dbo].[FN_UNIX_TIMESTAMP](GETUTCDATE())
	DECLARE @ERROR_VersionEvironment_NOT_EXISTED			INT			= -101
	DECLARE @ActiveOld										BIT				= 0
	DECLARE @IdApplication									UNIQUEIDENTIFIER				= null
	DECLARE @Environment										INT				= null
	BEGIN TRY
		IF EXISTS(SELECT [Id] FROM [dbo].[VersionEvironment] WHERE [Id] = @Id)
			BEGIN
				SELECT @ActiveOld = [Active] FROM [dbo].[VersionEvironment] WHERE [Id] = @Id 

				SET @IdApplication = (SELECT [IdApplication] FROM [dbo].[VersionEvironment] WHERE [Id] = @Id)
				SET @Environment = (SELECT [Environment] FROM [dbo].[VersionEvironment] WHERE [Id] = @Id)

							UPDATE [dbo].[VersionEvironment] 
							SET
							[Active] =	CASE
								WHEN  @ActiveOld = 0 THEN ISNULL(1, [Active])
								ELSE ISNULL(0, [Active])
								END ,
							[LastEditedBy]		=	ISNULL(@LastEditedBy,[LastEditedBy]),
							[LastEditedDate]	=	ISNULL(@LastEditedDate,[LastEditedDate])
							WHERE [Id] = @Id

							--Kiểm tra Active rồi cập nhật
							IF(EXISTS(SELECT 1 FROM [dbo].[VersionEvironment] WHERE [Id] = @Id AND [Active] = 1))
								BEGIN
										UPDATE [dbo].[VersionEvironment]
										   SET [Active] = 0
										 WHERE [Id] <> @Id 
										 AND [IdApplication] = @IdApplication 
										 AND [Environment] = @Environment
							END
							--Kiểm tra Active rồi cập nhật
					
				SET	@ResponseStatus = 1
			END
		ELSE
		  BEGIN
			SET @ResponseStatus = @ERROR_VersionEvironment_NOT_EXISTED
			RETURN
		  END
	END TRY
	BEGIN CATCH
		EXEC [dbo].[SP_LogError]
		SET @ResponseStatus	= -99;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionLockDate_FeGetByPage]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		linhvd
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROC [dbo].[SP_VersionLockDate_FeGetByPage]
	@IsPublic				BIT						= NULL,
	@DateMax				BIT						= NULL,
	@Environment			INT						= NULL,
	@Active					BIT						= NULL,
	@DateTo					DATETIME				= NULL,
	@DateFrom				DATETIME				= NULL,
	@ListId					NVARCHAR(MAX)			= NULL,
	@TenantId				BIGINT					= NULL,
	@WorkGroupId			BIGINT					= NULL,
	@Keyword				NVARCHAR(512)			= NULL,
	@PageNumber				INT						= 1,
	@PageSize				INT						= 10,
	@Orderby				BIT						= 1,
    @FieldName				nvarchar(64)			= 'CreatedDate'
AS
BEGIN
		SET @Keyword				= [dbo].[ValidateString](@Keyword)
		
		SET @ListId					= [dbo].[ValidateString](@ListId)
		--- Validate tránh sql injection ---
		SET @FieldName				= [dbo].[ValidateString](@FieldName)
		
		--- Validate tránh sql injection ---

		--- Kiểm tra cột muốn sort có nằm trong table muốn lấy ra không ---
		IF NOT EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS  WHERE  TABLE_NAME = 'VersionLockDate'AND COLUMN_NAME = @FieldName)
		BEGIN
			SET @FieldName = 'CreatedDate'
		END
		--- Kiểm tra cột muốn sort có nằm trong table muốn lấy ra không ---

		--- Order by ---
		DECLARE @OrderbyQr nvarchar(4) = null
		IF @Orderby = 1
		BEGIN
			SET @OrderbyQr = 'desc'
		END
		ELSE
		BEGIN
			SET @OrderbyQr = 'asc'
		END
		--- Order by ---

		--- Sort FieldName ---
		DECLARE @SortFieldNameQuery nvarchar(512) = CONCAT(' ORDER BY ' , @FieldName , ' ' , @OrderbyQr)
		--- Sort FieldName ---

		--- Paging ---
		DECLARE @PagingQuery nvarchar(512) = null
		IF @PageNumber is not null AND @PageSize is not null
		BEGIN
			SET @PagingQuery =   CONCAT(' OFFSET ',@PageSize ,'  * (' , @PageNumber ,'  - 1) ROWS FETCH NEXT ' , @PageSize , '  ROWS ONLY ')
		END
		--- Paging ---

		--- Where By IsPublic ---
		DECLARE @IsPublicQr nvarchar(128) = null
		IF @IsPublic IS NOT NULL AND @IsPublic != ''
		BEGIN
			SET @IsPublicQr = CONCAT(' AND [VersionLockDate].[IsPublic] = ''', @IsPublic , '''')
		END
		--- Where By IsPublic ---

		--- Where By Environment ---
		DECLARE @EnviromentQr nvarchar(128) = null
		IF @Environment IS NOT NULL AND @Environment != '0'
		BEGIN
			SET @EnviromentQr = CONCAT(' AND [VersionLockDate].[Environment] = ''', @Environment , '''')
		END
		--- Where By Environment ---

		--- Where By Active ---
		DECLARE @ActiveQr nvarchar(128) = null
		IF @Active IS NOT NULL AND @Active != ''
		BEGIN
			SET @ActiveQr = CONCAT(' AND [VersionLockDate].[Active] = ''', @Active , '''')
		END
		--- Where By Active ---
		
		

		--- Where By DateTo And DateFrom ---
		DECLARE @WhereDateQr nvarchar(4000) = null
		IF @DateFrom IS NOT NULL AND @DateTo IS NOT NULL 
		BEGIN
			SET @WhereDateQr = CONCAT(' AND CAST([VersionLockDate].[CreatedDate] AS DATE) between CAST(N''' , @DateFrom , ''' AS DATE) AND CAST(N''' , @DateTo , ''' AS DATE)')
		END
		--- Where By Active ---

		--- Where By ListId ---
		DECLARE @WhereInIdQr NVARCHAR(max) = null
		IF @ListId IS NOT NULL
		BEGIN
			SET @WhereInIdQr = CONCAT(' AND [VersionLockDateCategory].[Id] IN (', @ListId,')')
		END
		--- Where By ListId ---
		
		
		--- Where By TenantId ---
		DECLARE @WhereTenantIdQr NVARCHAR(max) = null
		IF @TenantId != 0
		BEGIN
			SET @WhereTenantIdQr = CONCAT(' AND [VersionLockDate].[TenantId] = (', @TenantId,')')
		END
		--- Where By TenantId ---

		-- full text search Key LEFT JOIN --> INER JOIN --- 
		DECLARE @KeyQr nvarchar(512) = null
		IF @Keyword IS NOT NULL AND @Keyword != ''
		BEGIN
			SET @KeyQr = 'FROM [dbo].[VersionLockDate]
							WHERE [VersionLockDate].[IsDeleted] <> 1 
							AND [VersionLockDate].[WorkGroupId] = '+ CAST(@WorkGroupId as nvarchar) +''
		END
		ELSE
		BEGIN
			SET @KeyQr = ' FROM [dbo].[VersionLockDate]
							 WHERE [VersionLockDate].[IsDeleted] <> 1 
							 AND [VersionLockDate].[WorkGroupId] = '+ CAST(@WorkGroupId as nvarchar) +''
		END
		--- WHERE Like Key ---

		--- Excute Query ---
		DECLARE @sql NVARCHAR(MAX); 
		SET @sql =  'SELECT DISTINCT 
							[Id]
							,[TenantId]
							,[WorkGroupId]
							,[IsPublic]
							,[Active]
							,[Environment]
							,[CreatedDate]
							,[CreatedDateUnixTime]
							,[CreatedBy]
							,[CreatedByName]
							,[LastEditedDate]
							,[LastEditedDateUnixTime]
							,[LastEditedBy]
							,[LastEditedByName]
							,[DeletedBy]
							,[DeletedDate]
							,[IsDeleted]
							,[DeleteDateUnixTime]
							,[DeleteByName]'

		SET @sql = @sql +  @KeyQr		
		--- Thêm các điều kiện where ---

		--- where IsPublic ---
		IF @IsPublicQr IS NOT NULL
		BEGIN
			SET @sql = @sql +  @IsPublicQr
		END
	
	
		IF @WhereTenantIdQr IS NOT NULL
		BEGIN
			SET @sql = @sql +  @WhereTenantIdQr
		END
		--- where Environment ---
		IF @EnviromentQr IS NOT NULL
		BEGIN
			SET @sql = @sql +  @EnviromentQr
		END

		--- where Active ---
		IF @ActiveQr IS NOT NULL
		BEGIN
			SET @sql = @sql +  @ActiveQr
		END

		--- where Date ---
		IF @WhereDateQr IS NOT NULL
		BEGIN
			SET @sql = @sql +  @WhereDateQr
		END

		--- where Id ---
		IF @WhereInIdQr IS NOT NULL
		BEGIN
			SET @sql = @sql +  @WhereInIdQr
		END

		--- Where By DateMax ---
		DECLARE @DateMaxQr nvarchar(128) = null
		IF @DateMax IS NOT NULL AND @DateMax != ''
		BEGIN
			if @DateMax = 1
				Begin
				--CREATE TABLE #temp_VersionLockDate
				--	(
				--		[Id] uniqueidentifier NOT NULL,
				--		[TenantId] bigint NOT NULL,
				--		[WorkGroupId] bigint NOT NULL,
				--		[IsPublic] bit NULL,
				--		[Active] bit NULL,
				--		[Environment] int NULL,
				--		[CreatedDate] datetime NOT NULL,
				--		[CreatedDateUnixTime] int NOT NULL,
				--		[CreatedBy] bigint NOT NULL,
				--		[CreatedByName] nvarchar(128) NULL,
				--		[LastEditedDate] datetime NULL,
				--		[LastEditedDateUnixTime] int NULL,
				--		[LastEditedBy] bigint NULL,
				--		[LastEditedByName] nvarchar(128) NULL,
				--		[DeletedBy] bigint NULL,
				--		[DeletedDate] datetime NULL,
				--		[IsDeleted] bit NULL,
				--		[DeleteDateUnixTime] int NULL,
				--		[DeleteByName] nvarchar(128) NULL
				--	)	
				SELECT * INTO #temp_VersionLockDate FROM VersionLockDate WHERE 1=2;
					insert into #temp_VersionLockDate
					exec (@sql)
					DECLARE @DateMaxTemp int =  (SELECT MAX([CreatedDateUnixTime]) from #temp_VersionLockDate)
					SET @DateMaxQr = ' AND [VersionLockDate].[CreatedDateUnixTime] = ''' + CAST(@DateMaxTemp as nvarchar(max)) + ''''
				end
		END
		--- Where By DateMax ---

		--- where DateMax ---
		IF @DateMaxQr IS NOT NULL
		BEGIN
			SET @sql = @sql +  @DateMaxQr
		END

		--- Thêm các điều kiện where ---

		--- Thêm xử lý phần lấy Paging ---
		IF @PagingQuery IS NOT NULL
		BEGIN
			SET @sql = ' WITH Main_CTE AS( ' + @sql + ')
				  , Count_CTE AS (
					SELECT COUNT(*) AS [TotalRows]
					FROM Main_CTE
				  )
				  SELECT *
				  FROM Main_CTE, Count_CTE' + @SortFieldNameQuery + @PagingQuery
		END
		ELSE
		BEGIN
			SET @sql = ' WITH Main_CTE AS( ' + @sql + ')
				  , Count_CTE AS (
					SELECT COUNT(*) AS [TotalRows]
					FROM Main_CTE
				  )
				  SELECT *
				  FROM Main_CTE, Count_CTE' + @SortFieldNameQuery 
		END
		--- Thêm xử lý phần lấy Paging ---
		EXEC (@sql) 
		--- Excute Query ---
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionLockDate_GetDetail]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		linhvd
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROC [dbo].[SP_VersionLockDate_GetDetail]
	@TenantId				BIGINT					= NULL,
	@WorkGroupId			bigint					= NULL,
	@Environment				INT						= NULL
AS
BEGIN
			SELECT  
			[Id]
			,[TenantId]
			,[WorkGroupId]
			,[IsPublic]
			,[Active]
			,[Environment]
			,[CreatedDate]
			,[CreatedDateUnixTime]
			,[CreatedBy]
			,[CreatedByName]
			,[LastEditedDate]
			,[LastEditedDateUnixTime]
			,[LastEditedBy]
			,[LastEditedByName]
			,[DeletedBy]
			,[DeletedDate]
			,[IsDeleted]
			,[DeleteDateUnixTime]
			,[DeleteByName]
			FROM [dbo].[VersionLockDate]
			WHERE [VersionLockDate].[IsDeleted] <> 1 
			AND [VersionLockDate].[TenantId] = @TenantId
			AND [VersionLockDate].[WorkGroupId] = @WorkGroupId
			AND [VersionLockDate].[IsPublic] = 1	
			AND [VersionLockDate].[Environment] = @Environment
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionLockDate_GetDetailById]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		linhvd
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROC [dbo].[SP_VersionLockDate_GetDetailById]
	@Id				UNIQUEIDENTIFIER				= NULL
AS
BEGIN
			SELECT  
			[Id]
			,[TenantId]
			,[WorkGroupId]
			,[IsPublic]
			,[Active]
			,[Environment]
			,[CreatedDate]
			,[CreatedDateUnixTime]
			,[CreatedBy]
			,[CreatedByName]
			,[LastEditedDate]
			,[LastEditedDateUnixTime]
			,[LastEditedBy]
			,[LastEditedByName]
			,[DeletedBy]
			,[DeletedDate]
			,[IsDeleted]
			,[DeleteDateUnixTime]
			,[DeleteByName]
			FROM [dbo].[VersionLockDate]
			WHERE [VersionLockDate].[IsDeleted] <> 1 
			AND [Id] = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionLockDate_Insert]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_VersionLockDate_Insert]
	-- Add the parameters for the stored procedure here
		@Id						UNIQUEIDENTIFIER	= NULL,
		@TenantId				BIGINT				= 0,
		@ListApplicationId		NVARCHAR(MAX)		= NULL,
		@WorkGroupId			BIGINT				= 0,
		@Environment			INT					= NULL,
		@CreatedBy				BIGINT				= 0,
		@CreatedByName			NVARCHAR(128)		= NULL,
		@ResponseStatus			INT					= 0			OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET @ResponseStatus												= -99	--- SystemError ---
	DECLARE @CreatedDate								DATETIME	= GETUTCDATE()
	DECLARE @CreatedDateUnixTime						INT			= [dbo].[FN_UNIX_TIMESTAMP](GETUTCDATE())
	DECLARE @ERROR_VERSIONLOCKDATE_EXISTED				INT			= -120

	BEGIN TRY
		IF(NOT EXISTS(SELECT [Id] FROM [dbo].[VersionLockDate] WHERE [Id] = @Id AND [IsDeleted] <> 1))
		BEGIN
		
			INSERT INTO [dbo].[VersionLockDate]
				   ([Id]
				   ,[TenantId]
				   ,[WorkGroupId]
				   ,[Environment]
				   ,[CreatedDate]
				   ,[CreatedDateUnixTime]
				   ,[CreatedBy]
				   ,[CreatedByName])
			VALUES
				   (@Id
				   ,@TenantId
				   ,@WorkGroupId
				   ,@Environment 
				   ,@CreatedDate
				   ,@CreatedDateUnixTime
				   ,@CreatedBy
				   ,@CreatedByName)
				 
				 IF OBJECT_ID('tempdb..#my_temp_Version') IS NOT NULL
					DROP TABLE #my_temp_Version
					SELECT * INTO #my_temp_Version
						FROM [dbo].[VersionEvironment]
						WHERE [Environment] = @Environment
							AND [Active] = 1
							AND [IsDeleted] <> 1
			

					IF @ListApplicationId IS NOT NULL
					BEGIN
						DECLARE @sql NVARCHAR(MAX); 
					SET @sql = 'DELETE From #my_temp_Version
						WHERE 1 = 1'
					SET @sql = @sql + CONCAT(' AND [IdApplication] NOT IN  (',@ListApplicationId ,')')
					EXEC (@sql)
					END
			DECLARE @Count int

			Set  @Count =  (Select COUNT([Id]) FROM #my_temp_Version)

			IF @Count > 0
			BEGIN
						DECLARE @VersionDetailTenantId				BIGINT				= @TenantId
						DECLARE @VersionDetailWorkgroupId			BIGINT				= @WorkGroupId
						DECLARE @VersionDetailVersionLockDateId		UNIQUEIDENTIFIER	= @Id
						DECLARE @VersionDetailCreatedBy				BIGINT				= @CreatedBy
						DECLARE @VersionDetailCreatedByName			NVARCHAR(128)		= @CreatedByName
					WHILE @Count > 0
					BEGIN
						DECLARE @VersionDetailVersionId				UNIQUEIDENTIFIER	= NULL
						DECLARE @VersionDetailId					UNIQUEIDENTIFIER	= NEWID()
						SET @VersionDetailVersionId = (SELECT TOP 1 [Id] FROM #my_temp_Version)
						
						EXEC [dbo].[SP_VersionDetail_Insert]
								@Id = @VersionDetailId
								,@TenantId = @VersionDetailTenantId
								,@WorkgroupId  = @VersionDetailWorkgroupId
								,@VersionLockDateId = @VersionDetailVersionLockDateId
								,@VersionId = @VersionDetailVersionId
								,@CreatedBy = @VersionDetailCreatedBy
								,@CreatedByName = @VersionDetailCreatedByName
								,@ResponseStatus = @ResponseStatus  OUTPUT
						
						DELETE FROM #my_temp_Version WHERE [Id] = @VersionDetailVersionId
						SET @Count = @Count - 1
					END
			END

			SET @ResponseStatus = 1
		RETURN
	  END
	  ELSE
	  BEGIN
		SET @ResponseStatus = @ERROR_VERSIONLOCKDATE_EXISTED
		RETURN
	  END
	END TRY
	BEGIN CATCH
		SET @ResponseStatus	= -99;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionLockDate_UpdateActive]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_VersionLockDate_UpdateActive]
	@TenantId				BIGINT				= NULL,
	@WorkGroupId			BIGINT				= NULL,
	@Id						UNIQUEIDENTIFIER	= NULL,
	@LastEditedBy			BIGINT				= NULL,
	@LastEditedByName		NVARCHAR(128)		= NULL,	
	@ResponseStatus			BIGINT				= -99 OUTPUT
AS
BEGIN
	SET @ResponseStatus											= -99	--- SystemError ---
	DECLARE @LastEditedDate							DATETIME	= GETUTCDATE()
	DECLARE @LastEditedDateUnixTime					INT			= [dbo].[FN_UNIX_TIMESTAMP](GETUTCDATE())
	DECLARE @ERROR_VERSIONLOCKDATE_NOT_EXISTED		INT			= -121
	DECLARE @ActiveOld								BIT				= null
	BEGIN TRY
		IF EXISTS(SELECT [Id] FROM [dbo].[VersionLockDate] WHERE [Id] = @Id AND [VersionLockDate].[TenantId] = @TenantId
			AND [VersionLockDate].[WorkGroupId] = @WorkGroupId)
			BEGIN
				SELECT @ActiveOld = [Active] FROM [dbo].[VersionLockDate] WHERE [Id] = @Id  AND [VersionLockDate].[TenantId] = @TenantId
				AND [VersionLockDate].[WorkGroupId] = @WorkGroupId

				IF @ActiveOld is not null
				BEGIN

					UPDATE [dbo].[VersionLockDate] SET
					[Active] =	CASE
						WHEN  @ActiveOld = 0 THEN ISNULL(1, [Active])
						ELSE ISNULL(0, [Active])
						END ,
					[LastEditedBy]		=	ISNULL(@LastEditedBy,[LastEditedBy]),
					[LastEditedByName]	=	ISNULL(@LastEditedByName,[LastEditedByName]),
					[LastEditedDate]	=	ISNULL(@LastEditedDate,[LastEditedDate]),
					[LastEditedDateUnixTime]	=	ISNULL(@LastEditedDateUnixTime,[LastEditedDateUnixTime])
					WHERE [Id] = @Id AND [VersionLockDate].[TenantId] = @TenantId
					AND [VersionLockDate].[WorkGroupId] = @WorkGroupId
					
				END
				SET	@ResponseStatus = 1
			END
		ELSE
		  BEGIN
			SET @ResponseStatus = @ERROR_VERSIONLOCKDATE_NOT_EXISTED
			RETURN
		  END
	END TRY
	BEGIN CATCH
	
		SET @ResponseStatus	= -99;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_VersionLockDate_UpdatePublic]    Script Date: 8/28/2023 2:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_VersionLockDate_UpdatePublic]
	@Id						UNIQUEIDENTIFIER	= NULL,
	@LastEditedBy			BIGINT				= NULL,
	@LastEditedByName		NVARCHAR(128)		= NULL,	
	@ResponseStatus			BIGINT				= -99 OUTPUT
AS
BEGIN
	SET @ResponseStatus											= -99	--- SystemError ---
	DECLARE @LastEditedDate							DATETIME	= GETUTCDATE()
	DECLARE @LastEditedDateUnixTime					INT			= [dbo].[FN_UNIX_TIMESTAMP](GETUTCDATE())
	DECLARE @ERROR_VERSIONLOCKDATE_NOT_EXISTED		INT			= -121
	BEGIN TRY
		IF EXISTS(SELECT [Id] FROM [dbo].[VersionLockDate] WHERE [Id] = @Id)
			BEGIN
				UPDATE [dbo].[VersionLockDate]
				SET [IsPublic] = CASE
					WHEN [VersionLockDate].[Id] = @Id THEN ISNULL(1, [IsPublic])
					ELSE ISNULL(0, [IsPublic])
					END
				,[LastEditedBy] = ISNULL(@LastEditedBy, [LastEditedBy])
				,[LastEditedByName]	=	ISNULL(@LastEditedByName,[LastEditedByName])
				,[LastEditedDate] = ISNULL(@LastEditedDate, [LastEditedDate])
				,[LastEditedDateUnixTime] = ISNULL(@LastEditedDateUnixTime, [LastEditedDateUnixTime])
				WHERE [VersionLockDate].[IsDeleted] <> 1 
					AND [VersionLockDate].[TenantId] = (SELECT [TenantId] FROM [dbo].[VersionLockDate] WHERE [Id] = @Id)
					AND [VersionLockDate].[WorkGroupId] = (SELECT [WorkGroupId] FROM [dbo].[VersionLockDate] WHERE [Id] = @Id)
					AND [VersionLockDate].[Environment] = (SELECT [Environment] FROM [VersionLockDate] where [Id] = @Id);
			
			SET	@ResponseStatus = 1
			END
		ELSE
		  BEGIN
			SET @ResponseStatus = @ERROR_VERSIONLOCKDATE_NOT_EXISTED
			RETURN
		  END
	END TRY
	BEGIN CATCH
		
		SET @ResponseStatus	= -99;
	END CATCH
END
GO
