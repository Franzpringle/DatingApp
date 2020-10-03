USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[NewUser]    Script Date: 02-10-2020 21:52:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CheckIfUserExists]

@username NVARCHAR(30)
,@email NVARCHAR(50)

AS

BEGIN 

	SELECT u.username, u.email FROM users u
	WHERE u.username = @username OR u.email = @email

END

GO


