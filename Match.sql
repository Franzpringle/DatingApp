use DatingApp
go


Create procedure DidWeMatch
@id1 int,
@id2 int

as

begin tran
	begin try

		select *  from likes  
		where (senderId = @id1 and	recieverId = @id2)
		and (senderId = @id2 and recieverId = @id1)
		
	end try

	begin catch
		print 'Something went wrong. Try again'
		rollback
	end catch






