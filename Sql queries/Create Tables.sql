USE [master]
GO

USE [TBTD]
GO
/****** Object:  Table [dbo].[AccountPlans]    Script Date: 13.09.2018 8:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountPlans](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[vchName] [nvarchar](1000) NOT NULL,
	[vchDescription] [nvarchar](1000) NOT NULL,
	[isChargeable] [bit] NOT NULL,
	[dcmAmount] [decimal](10, 2) NOT NULL,
	[intCurrency] [int] NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_ACCOUNTPLANS] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 13.09.2018 8:59:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachments](
	[bintId] [bigint] IDENTITY(1,1) NOT NULL,
	[intFileType] [int] NOT NULL,
	[vchName] [nvarchar](200) NOT NULL,
	[vchUrl] [nvarchar](200) NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
	[bintTaskId] [bigint] NOT NULL,
 CONSTRAINT [PK_ATTACHMENTS] PRIMARY KEY CLUSTERED 
(
	[bintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[AttachmentTypes]    Script Date: 13.09.2018 8:59:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentTypes](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[vchName] [nvarchar](1) NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_ATTACHMENTTYPES] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 13.09.2018 8:59:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Currencies](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[vchName] [varchar](3) NOT NULL,
	[intCode] [int] NOT NULL,
 CONSTRAINT [PK_CURRENCIES] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[intCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[vchName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 13.09.2018 8:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[bintId] [bigint] IDENTITY(1,1) NOT NULL,
	[bintUserId] [bigint] NOT NULL,
	[intGroupType] [int] NOT NULL,
	[vchName] [nvarchar](500) NOT NULL,
	[vchDescription] [nvarchar](max) NOT NULL,
	[intOrder] [int] NOT NULL,
	[dtCreation] [datetime] NOT NULL,
	[bitIsActive] [bit] NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_GROUPS] PRIMARY KEY CLUSTERED 
(
	[bintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GroupTypes]    Script Date: 13.09.2018 8:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupTypes](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[vchName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_GROUPTYPES] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[SharedGroups]    Script Date: 13.09.2018 8:59:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedGroups](
	[bintId] [bigint] IDENTITY(1,1) NOT NULL,
	[bintGroupId] [bigint] NOT NULL,
	[bintRecipientUserId] [bigint] NOT NULL,
	[intShareType] [int] NOT NULL,
	[bitIsActive] [bit] NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_SHAREDGROUPS] PRIMARY KEY CLUSTERED 
(
	[bintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[SharedTasks]    Script Date: 13.09.2018 8:59:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SharedTasks](
	[bintId] [bigint] IDENTITY(1,1) NOT NULL,
	[bintTaskId] [bigint] NOT NULL,
	[bintRecipientUserId] [bigint] NOT NULL,
	[intShareType] [int] NOT NULL,
	[bitIsActive] [bit] NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_SHAREDTASKS] PRIMARY KEY CLUSTERED 
(
	[bintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[ShareTypes]    Script Date: 13.09.2018 8:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShareTypes](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[vchName] [nvarchar](1) NOT NULL,
	[vchDescription] [nvarchar](1000) NULL,
	[bitIsActive] [bit] NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_SHARETYPES] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 13.09.2018 8:59:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[bintId] [bigint] IDENTITY(1,1) NOT NULL,
	[bintGroupId] [bigint] NOT NULL,
	[bintUserId] [bigint] NOT NULL,
	[dtCreation] [datetime] NOT NULL,
	[intStatus] [int] NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_TASKS] PRIMARY KEY CLUSTERED 
(
	[bintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[TaskStatuses]    Script Date: 13.09.2018 8:59:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatuses](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[vchName] [nvarchar](500) NOT NULL,
	[vchDescription] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_TASKSTATUSES] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.09.2018 8:59:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[bintId] [bigint] IDENTITY(1,1) NOT NULL,
	[vchEmail] [nvarchar](300) NOT NULL,
	[bitIsActive] [bit] NOT NULL,
	[intUserType] [int] NOT NULL,
	[bintUserInfoId] [bigint] NOT NULL,
	[intAccountPlan] [int] NOT NULL,
	[dtRegistration] [datetime] NOT NULL,
	[dtLastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[bintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
UNIQUE NONCLUSTERED 
(
	[vchEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[UsersInfo]    Script Date: 13.09.2018 9:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInfo](
	[bintId] [bigint] IDENTITY(1,1) NOT NULL,
	[vchPhotoUrl] [nvarchar](500) NOT NULL,
	[vchName] [nvarchar](500) NOT NULL,
	[vchTelNumber] [nvarchar](15) NOT NULL,
	[vchRawJson] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_USERSINFO] PRIMARY KEY CLUSTERED 
(
	[bintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 13.09.2018 9:00:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[intId] [int] IDENTITY(1,1) NOT NULL,
	[vchName] [nvarchar](200) NOT NULL,
	[vchDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_USERTYPES] PRIMARY KEY CLUSTERED 
(
	[intId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[AccountPlans]  WITH CHECK ADD  CONSTRAINT [AccountPlans_fk0] FOREIGN KEY([intCurrency])
REFERENCES [dbo].[Currencies] ([intId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[AccountPlans] CHECK CONSTRAINT [AccountPlans_fk0]
GO
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [Attachments_fk0] FOREIGN KEY([intFileType])
REFERENCES [dbo].[AttachmentTypes] ([intId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [Attachments_fk0]
GO
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [Attachments_fk1] FOREIGN KEY([bintTaskId])
REFERENCES [dbo].[Tasks] ([bintId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [Attachments_fk1]
GO
ALTER TABLE [dbo].[SharedGroups]  WITH CHECK ADD  CONSTRAINT [SharedGroups_fk0] FOREIGN KEY([bintRecipientUserId])
REFERENCES [dbo].[Users] ([bintId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SharedGroups] CHECK CONSTRAINT [SharedGroups_fk0]
GO
ALTER TABLE [dbo].[SharedGroups]  WITH CHECK ADD  CONSTRAINT [SharedGroups_fk1] FOREIGN KEY([intShareType])
REFERENCES [dbo].[ShareTypes] ([intId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SharedGroups] CHECK CONSTRAINT [SharedGroups_fk1]
GO
ALTER TABLE [dbo].[SharedTasks]  WITH CHECK ADD  CONSTRAINT [SharedTasks_fk0] FOREIGN KEY([bintTaskId])
REFERENCES [dbo].[Tasks] ([bintId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SharedTasks] CHECK CONSTRAINT [SharedTasks_fk0]
GO
ALTER TABLE [dbo].[SharedTasks]  WITH CHECK ADD  CONSTRAINT [SharedTasks_fk2] FOREIGN KEY([intShareType])
REFERENCES [dbo].[ShareTypes] ([intId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SharedTasks] CHECK CONSTRAINT [SharedTasks_fk2]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [Tasks_fk0] FOREIGN KEY([bintGroupId])
REFERENCES [dbo].[Groups] ([bintId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [Tasks_fk0]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [Tasks_fk1] FOREIGN KEY([bintUserId])
REFERENCES [dbo].[Users] ([bintId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [Tasks_fk1]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [Tasks_fk2] FOREIGN KEY([intStatus])
REFERENCES [dbo].[TaskStatuses] ([intId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [Tasks_fk2]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [Users_fk0] FOREIGN KEY([intUserType])
REFERENCES [dbo].[UserTypes] ([intId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Users_fk0]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [Users_fk1] FOREIGN KEY([bintUserInfoId])
REFERENCES [dbo].[UsersInfo] ([bintId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Users_fk1]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [Users_fk2] FOREIGN KEY([intAccountPlan])
REFERENCES [dbo].[AccountPlans] ([intId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Users_fk2]
GO
USE [master]
GO
ALTER DATABASE [TBTD] SET  READ_WRITE 
GO
