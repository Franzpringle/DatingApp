Use DatingApp
go


create procedure createprofilebio
@username nvarchar(30),
@firstname nvarchar(50),
@lastname nvarchar(50),
@gender nvarchar(10),
@interestedIn nvarchar(10),
@height int,
@eyecolor nvarchar(20) = null,
@haircolor nvarchar(30) = null,
@dateofBirth date,
@about nvarchar(max)

as

begin tran
	begin try
		declare @userId int
		set @userId = (select id from users where username = @username)

		insert into profiles(userId, firstname, lastname, gender, interestedIn, height, eyecolor, haircolor, dateOfBirth, about)
		values(@userId,@firstname, @lastname, @gender, @interestedIn, @height, @eyecolor, @haircolor, @dateofBirth, @about)

		commit

	end try

	begin catch
		print 'Something went wrong. Try again'
		rollback
	end catch


















































