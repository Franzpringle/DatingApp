USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[AnyMessages]    Script Date: 07/10/2020 11.20.25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






ALTER procedure [dbo].[AnyMessages]
@Username nvarchar(30)

as
	declare @Userid int
	Declare @profileID int

	Set @Userid = (Select id from users where username = @Username)

	set @profileID = (Select id from profiles where userId = @Userid)

	Select count(*) from [Messages] where (recieverId = @profileID) and (Opened != 1)

GO


