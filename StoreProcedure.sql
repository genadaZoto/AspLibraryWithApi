USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[InsertBookOfReader]    Script Date: 22-01-20 12:32:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[InsertBookOfReader]
-- on les passse des parametres
@IdBook int,
@IdReader int,
@ReservationDate date
AS
BEGIN
declare @IdBookCopy int
SELECT TOP 1 @IdBookCopy=IdBookCopy From BookCopy Where BookCopy.IdBook = @IdBook AND available=1
INSERT INTO BookReservation(IdBookCopy,IdReader,ReservationDate)  VALUES (@IdBookCopy,@IdReader,@ReservationDate)
Update BookCopy SET available= 0 WHERE  @IdBookCopy=IdBookCopy 
select @IdBookCopy
END
