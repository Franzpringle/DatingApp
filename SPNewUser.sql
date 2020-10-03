use DatingApp 
go

create procedure NewUser

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


















