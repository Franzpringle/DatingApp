USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[DidWeMatch]    Script Date: 07/10/2020 11.21.23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER procedure [dbo].[DidWeMatch]
@senderId int, 
@recieverId int

as
	declare @c as int
	set @c = (Select count(*) from likes  
	where (senderId = @senderId and	recieverId = @recieverId)
	or (senderId = @recieverId and recieverId = @senderId))
	

	
	if (@c > 1)
	begin
			update likes
			set isMatch = 1
			where (senderId = @senderId and	recieverId = @recieverId)
			or (senderId = @recieverId and recieverId = @senderId)
			end
GO


