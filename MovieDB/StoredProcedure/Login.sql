CREATE PROCEDURE [dbo].[Login]
	@email VARCHAR(100),
	@pwd VARCHAR(100)
AS
BEGIN
	DECLARE @salt VARCHAR(100)
	SELECT @salt = Salt FROM Users WHERE Email = @email

	DECLARE @hash VARBINARY(64)
	SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @salt))
	SELECT Id, Email, IsAdmin, NickName FROM Users WHERE Email = @email AND Password = @hash
END

