﻿CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(100) NOT NULL,
	Synopsis VARCHAR(400),
	ReleaseYear INT NOT NULL,
	PEGI INT NOT NULL
)