CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture BIT,
	LastLoginTime DATETIME,
	IsDeleted BIT DEFAULT 'false'
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) 
VALUES		('Kiro Kirkov', '1234567', 2, '1989-05-20', 0),
		('Ivan Ivanov', '1234567', 2, '1969-02-21', 1),
		('Pesho Peshov', '1234567', 1, '1999-05-16', 1),
		('Stamat Stamatov', '1234567', 1, '1976-02-09', 0),
		('Vanko Vankov', '1234567', 2 , '1999-05-05', 0)
