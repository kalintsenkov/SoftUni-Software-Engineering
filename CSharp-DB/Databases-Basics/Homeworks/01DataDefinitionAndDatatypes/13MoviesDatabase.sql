CREATE TABLE Directors 
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(30) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(30) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(30) UNIQUE NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(30) UNIQUE NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE,
	[Length] TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL(2, 1) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes)
VALUES		('Pesho', NULL),
		('Gosho', NULL),
		('Kiro', NULL),
		('Ivan', 'Hi!!!'),
		('Test', 'How are you?')

INSERT INTO Genres(GenreName, Notes)
VALUES		('Romantic', NULL),
		('Drama', NULL),
		('Action', NULL),
		('Thriller', NULL),
		('Comedy', NULL)

INSERT INTO Categories(CategoryName, Notes)
VALUES		('Category1', NULL),
		('Category2', NULL),
		('Category3', NULL),
		('Category4', NULL),
		('Category5', NULL)

INSERT INTO Movies
			(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
			('The Godfather', 1, '1972', '02:30:00', 1, 1, 9.5, NULL),
			('Garfield', 2, '2010', '02:30:00', 2, 2, 6.8, NULL),
			('Geostorm', 3, '2012', '02:30:00', 3, 3, 5.2, NULL),
			('Guardians of the Galaxy', 4, '2001', '02:30:00', 4, 4, 7.8, NULL),
			('Ghostbusters', 5, '1984', '02:30:00', 5, 5, 8.4, NULL)
