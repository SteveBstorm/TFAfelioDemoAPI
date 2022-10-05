CREATE PROCEDURE [dbo].[RegisterUser]
	@nickname VARCHAR(50),
	@email VARCHAR(100),
	@pwd VARCHAR(50)
AS
BEGIN
	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @hash VARBINARY(64)
	SET @hash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @salt))

	INSERT INTO Users (Email, NickName, Password, Salt) VALUES (@email, @nickname, @hash, @salt)
END