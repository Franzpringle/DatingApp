Use DatingApp
go


Create procedure AnyMatchesWithoutMessageThread
@userid int

as

	
	Select COUNT(*), l.senderId, l.recieverId from likes l 
	where l.senderId = @userid 
	and not exists(Select * from [Messages] m where l.senderid = m.senderid and l.recieverId = m.recieverid)
	group by senderId, recieverId having COUNT(*) >= 1




go