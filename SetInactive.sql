USe DatingApp
go

create procedure SetInactive
@username nvarchar(30)

as

begin tran
	begin try
		declare @UserID as int 

		set @UserID = (Select id from users where username = @username)

		update profiles
		set isActive = 0
		where UserId = @UserID
		commit

	end try

	begin catch
		print 'something went wrong'
		rollback
	end catch