CREATE VIEW [dbo].[V_Users]
	AS 
	SELECT Email, NickName, IsAdmin, IsActive, Id
	FROM Users
