CREATE TABLE [dbo].[OwnedItems]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
	[ItemId] INT NOT NULL, 
	[ItemCount] INT NOT NULL, 
    CONSTRAINT [FK_UserId_ToUsers1] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]) , 
    CONSTRAINT [FK_ItemId_ToItems1] FOREIGN KEY ([ItemId]) REFERENCES [Items]([Id]) 
)
