USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 07/10/2020 11.22.47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[LoginUser]
@Username nvarchar(30),
@password nvarchar(40)

as

	SELECT Count(*) FROM users where username = @Username and pw = @password

GO


