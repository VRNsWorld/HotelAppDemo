CREATE PROCEDURE [dbo].[spBookings_CheckIn]
	@ID int
AS
begin
	set nocount on;
	update dbo.Bookings
	set CheckedIn = 1
	where ID = @ID;
end