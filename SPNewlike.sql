Use DatingApp
go

create procedure NewLike
@senderId int, 
@recieverId int

as 

begin tran
	begin try

		Insert into likes
		values(@senderId, @recieverId, CURRENT_TIMESTAMP)

		commit

	end try

	begin catch
		print 'Something went wrong, try again'
		rollback

	end catch


