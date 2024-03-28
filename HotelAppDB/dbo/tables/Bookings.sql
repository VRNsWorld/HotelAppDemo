CREATE TABLE [dbo].[Bookings]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoomID] INT NOT NULL, 
    [GuestID] INT NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [CheckedIn] BIT NOT NULL DEFAULT 0, 
    [TotalCost] MONEY NOT NULL, 
    CONSTRAINT [FK_Bookings_Rooms] FOREIGN KEY (RoomID) REFERENCES Rooms(ID), 
    CONSTRAINT [FK_Bookings_Guest] FOREIGN KEY (GuestID) REFERENCES Guests(ID),
)