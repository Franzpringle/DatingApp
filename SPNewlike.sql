USE [DatingApp]
GO
/****** Object:  StoredProcedure [dbo].[NewLike]    Script Date: 03-10-2020 17:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[NewLike]
@username NVARCHAR(30)
,@matchProfileId INT

as 

begin tran
	begin try

	DECLARE @senderId INT
	SET @senderId = (SELECT p.id FROM profiles p INNER JOIN users u on p.UserId = u.id WHERE u.username = @username)

		Insert into likes (senderId, recieverId, TS)
		values(@senderId, @matchProfileId, CURRENT_TIMESTAMP)

		commit

	end try

	begin catch
		print 'Something went wrong, try again'
		rollback

	end catch


