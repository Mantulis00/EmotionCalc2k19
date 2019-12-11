CREATE TABLE [dbo].[UserData]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
	[JoyCoins] INT NOT NULL, 
	[JoyGems] INT NOT NULL, 
	[DailyStreak] SMALLINT NOT NULL DEFAULT 0, 
	[LastLogin] DATETIME NULL, 
	[Anger] INT NULL, 
	[Contempt] INT NULL, 
	[Disgust] INT NULL, 
	[Fear] INT NULL, 
	[Happiness] INT NULL, 
	[Neutral] INT NULL, 
	[Sadness] INT NULL, 
	[Surprise] INT NULL, 
	CONSTRAINT [LastLoginConstraint] CHECK (LastLogin < CURRENT_TIMESTAMP), 
    CONSTRAINT [FK_UserId_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])  ON DELETE CASCADE ON UPDATE CASCADE
)
