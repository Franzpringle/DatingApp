Use DatingApp
go


Create procedure AnyMatchesWithoutMessageThread
@userid int

as


	select *  from [Messages]  
		where (senderId = 1)
		and (recieverId = 1)