CREATE PROCEDURE [dbo].[spRoom_GetAvailableRooms]
	@startDate date,
	@endDate date,
	@roomTypeID int
AS
begin
	set nocount on;
	select [r].[ID], [r].[RoomNumber], [r].[RoomTypeID]
	from dbo.Rooms r
	inner join dbo.RoomTypes t on t.ID = r.RoomTypeID
	where r.RoomTypeID = @roomTypeID and r.ID not in (
	select b.RoomID
	from dbo.Bookings b
	where (@startDate < b.StartDate and @endDate > b.EndDate)
		or (b.StartDate <= @endDate and @endDate < b.EndDate)
		or (b.StartDate <= @startDate and @startDate < b.EndDate)
	)
end