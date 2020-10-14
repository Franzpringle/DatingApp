USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[createprofilebio]    Script Date: 07/10/2020 11.21.08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER procedure [dbo].[createprofilebio]
@Username nvarchar(30),
@firstname nvarchar(50),
@lastname nvarchar(50),
@gender nvarchar(10),
@interestedIn nvarchar(10),
@height int,
@eyecolor nvarchar(20) = null,
@haircolor nvarchar(30) = null,
@dateOfBirth date,
@isActive bit,
@about nvarchar(max)

as

begin tran
	begin try
		declare @userId int
		set @userId = (select id from users where username = @username)

		insert into profiles(userId, firstname, lastname, gender, interestedIn, height, eyecolor, haircolor, dateOfBirth, isActive, about)
		values(@userId,@firstname, @lastname, @gender, @interestedIn, @height, @eyecolor, @haircolor, @dateofBirth,@isActive, @about)

		commit

	end try

	begin catch
		print 'Something went wrong. Try again'
		rollback
	end catch






































GO


