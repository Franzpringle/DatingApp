USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[GetAllMessageThreads]    Script Date: 07/10/2020 11.21.47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[GetAllMessageThreads]
@profileid int

as

Select senderid, recieverid, treadid into #temp from [Messages] where senderid = @profileid
group by Senderid, recieverid, treadid having COUNT(*) >= 1

Select p.firstname, p.lastname, m.treadid
from profiles p
right join #temp m on p.id = m.recieverid
	
drop table #temp

GO


