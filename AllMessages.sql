Use DatingApp
go

Create procedure AllMessages
@profileid int

as

	select distinct recieverid,senderId from [Messages] where (@profileId = SenderId) or (@profileId = recieverId) 

go

