USE [DatingApp]
GO
/****** Object:  Table [dbo].[likes]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[likes](
	[senderId] [int] NOT NULL,
	[recieverId] [int] NOT NULL,
	[TS] [datetime] NULL,
	[isMatch] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[senderId] ASC,
	[recieverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[SenderId] [int] NOT NULL,
	[RecieverId] [int] NOT NULL,
	[TS] [datetime] NOT NULL,
	[Tekst] [nvarchar](max) NULL,
	[Opened] [bit] NULL,
	[TreadID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SenderId] ASC,
	[RecieverId] ASC,
	[TS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profiles]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profiles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[firstname] [nvarchar](50) NOT NULL,
	[lastname] [nvarchar](50) NOT NULL,
	[gender] [nvarchar](10) NOT NULL,
	[interestedIn] [nvarchar](10) NOT NULL,
	[height] [int] NULL,
	[eyecolor] [nvarchar](20) NOT NULL,
	[haircolor] [nvarchar](30) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[isActive] [bit] NULL,
	[about] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](30) NOT NULL,
	[pw] [nvarchar](40) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT ((0)) FOR [Opened]
GO
ALTER TABLE [dbo].[profiles] ADD  DEFAULT ('N/A') FOR [eyecolor]
GO
ALTER TABLE [dbo].[profiles] ADD  DEFAULT ('N/A') FOR [haircolor]
GO
ALTER TABLE [dbo].[profiles] ADD  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[profiles] ADD  DEFAULT ('This user has no info yet...') FOR [about]
GO
ALTER TABLE [dbo].[likes]  WITH CHECK ADD FOREIGN KEY([recieverId])
REFERENCES [dbo].[profiles] ([ID])
GO
ALTER TABLE [dbo].[likes]  WITH CHECK ADD FOREIGN KEY([senderId])
REFERENCES [dbo].[profiles] ([ID])
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD FOREIGN KEY([RecieverId])
REFERENCES [dbo].[profiles] ([ID])
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD FOREIGN KEY([SenderId])
REFERENCES [dbo].[profiles] ([ID])
GO
ALTER TABLE [dbo].[profiles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[users] ([id])
GO
/****** Object:  StoredProcedure [dbo].[AnyMatchesWithoutMessageThread]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[AnyMatchesWithoutMessageThread]
@userid int

as

	
	Select COUNT(*), l.senderId, l.recieverId from likes l 
	where l.senderId = @userid 
	and not exists(Select * from [Messages] m where l.senderid = m.senderid and l.recieverId = m.recieverid)
	group by senderId, recieverId having COUNT(*) >= 1




GO
/****** Object:  StoredProcedure [dbo].[AnyMessages]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE procedure [dbo].[AnyMessages]
@Username nvarchar(30)

as
	declare @Userid int
	Declare @profileID int

	Set @Userid = (Select id from users where username = @Username)

	set @profileID = (Select id from profiles where userId = @Userid)

	Select count(*) from [Messages] where (recieverId = @profileID) and (Opened != 1)

GO
/****** Object:  StoredProcedure [dbo].[ChangeStatus]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[ChangeStatus]
@username nvarchar(30),
@isActive bit

as

begin tran
	begin try

		declare @UserID as int 

		set @UserID = (Select id from users where username = @username)

		if((Select isActive from profiles where userId = @UserID) > 0)
			begin
				update profiles
				set isActive = 0
				where UserId = @UserID
			end
		else
			begin
				update profiles
				set isActive = 1
				where UserId = @UserID
			end
			
			
		commit

	end try

	begin catch
		print 'something went wrong'
		rollback
	end catch
GO
/****** Object:  StoredProcedure [dbo].[CheckIfUserExists]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[CheckIfUserExists]
@username nvarchar(30),
@email nvarchar(50)

as
	select count(*) from users where username = @username or email = @email
	



	


	
GO
/****** Object:  StoredProcedure [dbo].[createprofilebio]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create procedure [dbo].[createprofilebio]
@Username nvarchar(30),
@firstname nvarchar(50),
@lastname nvarchar(50),
@gender nvarchar(10),
@interestedIn nvarchar(10),
@height int,
@eyecolor nvarchar(20) = null,
@haircolor nvarchar(30) = null,
@dateOfBirth date,
@isActive bit,
@about nvarchar(max)

as

begin tran
	begin try
		declare @userId int
		set @userId = (select id from users where username = @username)

		insert into profiles(userId, firstname, lastname, gender, interestedIn, height, eyecolor, haircolor, dateOfBirth, isActive, about)
		values(@userId,@firstname, @lastname, @gender, @interestedIn, @height, @eyecolor, @haircolor, @dateofBirth,@isActive, @about)

		commit

	end try

	begin catch
		print 'Something went wrong. Try again'
		rollback
	end catch






































GO
/****** Object:  StoredProcedure [dbo].[DidWeMatch]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[DidWeMatch]
@senderId int, 
@recieverId int

as
	declare @c as int
	set @c = (Select count(*) from likes  
	where (senderId = @senderId and	recieverId = @recieverId)
	or (senderId = @recieverId and recieverId = @senderId))
	

	
	if (@c > 1)
	begin
			update likes
			set isMatch = 1
			where (senderId = @senderId and	recieverId = @recieverId)
			or (senderId = @recieverId and recieverId = @senderId)
			end
GO
/****** Object:  StoredProcedure [dbo].[GetAllMessagesWithUser]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[GetAllMessagesWithUser]
@Userprofileid int,
@targetprofileid int

as
	
	Select Tekst, ts from [Messages] 
	where (Senderid = @Userprofileid and recieverid = @targetprofileid) or 
	(senderid = @targetprofileid and recieverid = @Userprofileid)
	order by ts desc
GO
/****** Object:  StoredProcedure [dbo].[GetAllMessageThreads]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[GetAllMessageThreads]
@profileid int

as

Select senderid, recieverid, treadid into #temp from [Messages] where senderid = @profileid
group by Senderid, recieverid, treadid having COUNT(*) >= 1

Select p.firstname, p.lastname, m.treadid
from profiles p
right join #temp m on p.id = m.recieverid
	
drop table #temp

GO
/****** Object:  StoredProcedure [dbo].[GetPotentialMatch]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPotentialMatch]

@username NVARCHAR(30)

AS

BEGIN 

	DECLARE @userId INT
	SET @userId = (SELECT u.id FROM users u WHERE u.username = @username)

	DECLARE @userProfileId INT
	SET @userProfileId = (SELECT p.id FROM profiles p WHERE p.UserId = @userId)

	DECLARE @userInterestedIn NVARCHAR(5)
	SET @userInterestedIn = (SELECT p.interestedIn FROM profiles p INNER JOIN users u ON p.UserId = u.id WHERE u.username = @username)

	DECLARE @userGender NVARCHAR(5)
	SET @userGender = (SELECT p.gender FROM profiles p WHERE p.UserId = @userId)

	SELECT top 1
		p.firstname
	   ,p.lastname
	   ,IIF(p.gender = 'm', 'Male', 'Female') AS gender 
	   ,IIF(p.interestedIn = 'm', 'Male', 'Female') AS interestedIn
	   ,p.height
	   ,p.eyecolor
	   ,p.haircolor
	   ,DATEDIFF(YY,p.dateOfBirth,GETDATE()) AS age
	   ,p.about
	   ,p.ID
	FROM 
		profiles p
	INNER JOIN users u ON p.UserId = u.id
	WHERE 
		p.gender = @userInterestedIn
	AND (p.interestedIn = @userGender OR p.interestedIn = 'b')
	AND p.id <> @userId
	AND NOT EXISTS (SELECT * FROM likes l WHERE l.senderId = @userProfileId AND l.recieverId = p.ID)
	order by NEWID()
	

END
GO
/****** Object:  StoredProcedure [dbo].[GetUserProfile]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[GetUserProfile]
@username nvarchar(30)

as

	declare @userid int
	set @userid = (Select ID from users where username = @username)

	declare @profileId int
	set @profileId = (Select ID from profiles where userId = @userid) 


	Select * from profiles where ID = @userid

GO
/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[LoginUser]
@Username nvarchar(30),
@password nvarchar(40)

as

	SELECT Count(*) FROM users where username = @Username and pw = @password

GO
/****** Object:  StoredProcedure [dbo].[MarkAsRead]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[MarkAsRead]
@Userprofileid int,
@targetprofileid int

as
	begin tran
		begin try

			update [Messages]
			Set opened = 1
			where (senderid = @Userprofileid and recieverid = @targetprofileid) or (Senderid = @targetprofileid and recieverid = @Userprofileid)

			commit

		end try

		begin catch
			rollback
		end catch
GO
/****** Object:  StoredProcedure [dbo].[MessageSendt]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[MessageSendt]
@SenderId int,
@RecieverId int,
@Tekst nvarchar(max)

as

begin tran
	begin try
		
		Insert into [Messages]
		values(@SenderId, @RecieverId, CURRENT_TIMESTAMP, @Tekst, Default)

		commit

	end try

	begin catch
		print 'Something went wrong. try again'
		rollback
	end catch
GO
/****** Object:  StoredProcedure [dbo].[NewLike]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE procedure [dbo].[NewLike]
@Username nvarchar(30), 
@matchProfileId int

as 

begin tran
	begin try

		declare @userid int
		set @userid = (Select id from users where username = @Username) 
		
		declare @senderId int
		Set @senderid = (select id from profiles where userId = @userid)

		Insert into likes
		values(@senderId, @matchProfileId, CURRENT_TIMESTAMP)

		commit



	end try

	begin catch
		print 'Something went wrong, try again'
		rollback

	end catch


GO
/****** Object:  StoredProcedure [dbo].[NewUser]    Script Date: 07/10/2020 12.07.37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[NewUser]

@username nvarchar(30)
,@email nvarchar(50)
,@pw nvarchar(max)

as

begin Tran
	
	begin try

		insert into users(username, pw, email)
		values (@username,@pw, @email)

		commit

	end try


	begin catch
		print 'Error occured, please try again'
		rollback
	end catch


















GO
