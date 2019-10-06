CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture BIT,
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES	    ('Kiro Kirkov', 2, 1.85, 35.5, 'm', '1989-05-20', 'Zdr'),
	    ('Ivan Ivanov', 1, NULL, 40.0, 'm', '1969-02-21', 'Zdrrr'),
	    ('Pesho Peshov', 2, 2.10, NULL, 'm', '1999-05-16', NULL),
	    ('Stamat Stamatov', 1, 1.93, 81.0, 'm', '1976-02-09', 'Zdr'),
	    ('Vanko Vankov', 1, 1.71, 75.8, 'm', '1999-05-05', 'Zdr')
