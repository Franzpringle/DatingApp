USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[GetUserProfile]    Script Date: 07/10/2020 11.22.00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[GetUserProfile]
@username nvarchar(30)

as

	declare @userid int
	set @userid = (Select ID from users where username = @username)

	declare @profileId int
	set @profileId = (Select ID from profiles where userId = @userid) 


	Select * from profiles where ID = @userid

GO


