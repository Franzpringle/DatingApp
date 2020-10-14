USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[GetAllMessagesWithUser]    Script Date: 07/10/2020 11.21.34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[GetAllMessagesWithUser]
@Userprofileid int,
@targetprofileid int

as
	
	Select Tekst, ts from [Messages] 
	where (Senderid = @Userprofileid and recieverid = @targetprofileid) or 
	(senderid = @targetprofileid and recieverid = @Userprofileid)
	order by ts desc
GO


