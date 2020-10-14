USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[MarkAsRead]    Script Date: 07/10/2020 11.23.03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER procedure [dbo].[MarkAsRead]
@Userprofileid int,
@targetprofileid int

as
	begin tran
		begin try

			update [Messages]
			Set opened = 1
			where (senderid = @Userprofileid and recieverid = @targetprofileid) or (Senderid = @targetprofileid and recieverid = @Userprofileid)

			commit

		end try

		begin catch
			rollback
		end catch
GO


