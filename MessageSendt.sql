USE [DatingApp]
GO

/****** Object:  StoredProcedure [dbo].[MessageSendt]    Script Date: 07/10/2020 11.23.15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER Procedure [dbo].[MessageSendt]
@SenderId int,
@RecieverId int,
@Tekst nvarchar(max)

as

begin tran
	begin try
		
		Insert into [Messages]
		values(@SenderId, @RecieverId, CURRENT_TIMESTAMP, @Tekst, Default)

		commit

	end try

	begin catch
		print 'Something went wrong. try again'
		rollback
	end catch
GO


