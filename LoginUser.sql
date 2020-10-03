USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[CheckIfUserExists]    Script Date: 03-10-2020 12:19:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[LoginUser]

@username NVARCHAR(30)
,@password NVARCHAR(40)

AS

BEGIN 

	SELECT COUNT(*) FROM users u
	WHERE u.username = @username AND u.pw = @password

END

GO


