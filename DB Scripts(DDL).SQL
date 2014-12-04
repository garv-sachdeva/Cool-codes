SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeCode] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[DateOfJoining] [datetime] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IssueHistories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IssueHistories](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[IssueId] [int] NOT NULL,
	[Comment] [varchar](2000) NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[AssignedTo] [int] NOT NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK_IssueHistories] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Logins]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Logins](
	[LoginName] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Role] [char](1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Logins] PRIMARY KEY CLUSTERED 
(
	[LoginName] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Issues]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Issues](
	[IssueId] [int] NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[DatePosted] [datetime] NOT NULL,
	[PostedBy] [int] NOT NULL,
	[AssignedTo] [int] NOT NULL,
	[Status] [smallint] NOT NULL,
	[Priority] [smallint] NOT NULL,
 CONSTRAINT [PK_Issues] PRIMARY KEY CLUSTERED 
(
	[IssueId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Issues', N'COLUMN',N'IssueId'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID of the Issue' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Issues', @level2type=N'COLUMN',@level2name=N'IssueId'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Issues', N'COLUMN',N'Title'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title of the Issue' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Issues', @level2type=N'COLUMN',@level2name=N'Title'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notices]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Notices](
	[NoticeId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[PostedBy] [int] NOT NULL,
 CONSTRAINT [PK_Notices] PRIMARY KEY CLUSTERED 
(
	[NoticeId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllNotices]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetAllNotices]
AS
BEGIN
	SELECT
		N.NoticeId, N.Title, 
		N.Description, N.StartDate, N.ExpirationDate,
		E.EmployeeId, E.FirstName, E.LastName
	FROM
		Notices N
	INNER JOIN
		Employees E
	ON
		E.EmployeeId = N.PostedBy
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmployee]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetEmployee]
	(		@employeeId int	)
AS
BEGIN
	SELECT
		E.EmployeeCode, E.FirstName, 
		E.LastName, E.DOB, E.Email, 
		E.DepartmentId, D.DepartmentName, E.DateOfJoining
	FROM
		Employees E
	INNER JOIN
		Departments D
	ON
		E.DepartmentId = D.DepartmentId
	WHERE
		E.EmployeeId = @employeeId
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetNotice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetNotice]
	(		@noticeId int	)
AS
BEGIN
	SELECT
		N.NoticeId, N.Title, 
		N.Description, N.StartDate, N.ExpirationDate,
		E.EmployeeId, E.FirstName, E.LastName
	FROM
		Notices N
	INNER JOIN
		Employees E
	ON
		E.EmployeeId = N.PostedBy
	WHERE
		N.NoticeId = @noticeId
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Login]	(		@loginName varchar(20),		@password varchar(20)	)ASBEGIN
		SELECT		LoginName, Role, EmployeeId	FROM		Logins
	WHERE		LoginName = @loginName AND Password = @password;
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddNotice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AddNotice]
	(		@title varchar(200),
		@description varchar(2000),
		@startDate datetime,
		@expirationDate datetime,		@postedBy int	)
AS
BEGIN
	INSERT INTO Notices
	(
		Title, Description, StartDate, 
		ExpirationDate, PostedBy
	)
	VALUES
	(
		@title, @description, @startDate, 
		@expirationDate, @postedBy
	)

	SELECT @@Identity
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateNotice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateNotice]
	(		@noticeId int,
		@title varchar(200),
		@description varchar(2000),
		@startDate datetime,
		@expirationDate datetime	)
AS
BEGIN
	UPDATE 
		Notices 
	SET
		Title = @title, 
		Description = @description, 
		StartDate = @startDate, 
		ExpirationDate = @expirationDate
	WHERE
		NoticeId = @noticeId
END


' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Notices_Employees]') AND parent_object_id = OBJECT_ID(N'[dbo].[Notices]'))
ALTER TABLE [dbo].[Notices]  WITH CHECK ADD  CONSTRAINT [FK_Notices_Employees] FOREIGN KEY([PostedBy])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Notices] CHECK CONSTRAINT [FK_Notices_Employees]
