CREATE PROCEDURE [dbo].[spBooking_Search]
	@lastName varchar(50),
	@startDate date
AS
begin
	set nocount on;
	select [b].[ID], [b].[RoomID], [b].[GuestID], [b].[StartDate], [b].[EndDate], [b].[CheckedIn], [b].[TotalCost], 
	[g].[FirstName], [g].[LastName], 
	[r].[RoomNumber], [r].[RoomTypeID], 
	[rt].[Title] as RoomTypeTitle, [rt].[Description] as RoomTypeDescription, [rt].[Price]
	from dbo.Bookings b
	inner join dbo.Guests g on b.GuestID = g.ID
	inner join dbo.Rooms r on b.RoomID = r.ID
	inner join dbo.RoomTypes rt on r.RoomTypeID = rt.ID
	where b.StartDate = @startDate and g.LastName = @lastName
end

