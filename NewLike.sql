USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[NewLike]    Script Date: 07/10/2020 11.23.29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







ALTER procedure [dbo].[NewLike]
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


