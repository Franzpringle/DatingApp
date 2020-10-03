USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 03-10-2020 15:38:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetPotentialMatch]

@username NVARCHAR(30)

AS

BEGIN 

	DECLARE @userId INT
	SET @userId = (SELECT u.id FROM users u WHERE u.username = @username)

	DECLARE @userProfileId INT
	SET @userProfileId = (SELECT p.id FROM profiles p WHERE p.UserId = @userId)

	DECLARE @userInterestedIn NVARCHAR(5)
	SET @userInterestedIn = (SELECT p.interestedIn FROM profiles p INNER JOIN users u ON p.UserId = u.id WHERE u.username = @username)

	DECLARE @userGender NVARCHAR(5)
	SET @userGender = (SELECT p.gender FROM profiles p WHERE p.UserId = @userId)

	SELECT TOP 1
		p.firstname
	   ,p.lastname
	   ,IIF(p.gender = 'm', 'Male', 'Female') AS gender 
	   ,IIF(p.interestedIn = 'm', 'Male', 'Female') AS interestedIn
	   ,p.height
	   ,p.eyecolor
	   ,p.haircolor
	   ,DATEDIFF(YY,p.dateOfBirth,GETDATE()) AS age
	   ,p.about
	   ,p.ID
	FROM 
		profiles p
	INNER JOIN users u ON p.UserId = u.id
	LEFT OUTER JOIN likes l ON p.ID = l.recieverId
	WHERE 
		p.gender = @userInterestedIn
	AND (p.interestedIn = @userGender OR p.interestedIn = 'b')
	AND p.id <> @userId
	AND NOT EXISTS (SELECT * FROM likes WHERE l.senderId = @userProfileId AND l.recieverId = p.ID)
	

END

GO


