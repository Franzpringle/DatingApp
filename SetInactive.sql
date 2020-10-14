USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[ChangeStatus]    Script Date: 07/10/2020 11.20.44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER procedure [dbo].[ChangeStatus]
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


