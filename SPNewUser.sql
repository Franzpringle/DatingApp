USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[NewUser]    Script Date: 07/10/2020 11.23.41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[NewUser]

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


















GO


