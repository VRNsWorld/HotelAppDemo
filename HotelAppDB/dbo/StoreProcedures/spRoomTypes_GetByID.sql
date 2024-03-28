CREATE PROCEDURE [dbo].[spRoomTypes_GetByID]
	@ID int
AS
begin
	set nocount on;

	select [ID], [Title], [Description], [Price]
	from dbo.RoomTypes
	where ID = @ID;

end