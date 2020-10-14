USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[CheckIfUserExists]    Script Date: 07/10/2020 11.20.58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[CheckIfUserExists]
@username nvarchar(30),
@email nvarchar(50)

as
	select count(*) from users where username = @username or email = @email
	



	


	
GO


