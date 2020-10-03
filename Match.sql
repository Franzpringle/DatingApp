Create procedure [Match]
@id1,
@id2

as

begin tran
	begin try

		declare user1
		set user1 = select id from users where id = @id1

		select * likes 
		where (senderId = @id1 and	recieverId = @id2)
		and (senderId = @id2 and recieverId = @id1)
		
	end try

	begin catch
		print 'Something went wrong. Try again'
		rollback
	end catch






