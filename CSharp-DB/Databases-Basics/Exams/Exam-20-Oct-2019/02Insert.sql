INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
VALUES		('Marlo', 'O''Malley', '1958-09-21', 1),
			('Niki', 'Stanaghan', '1969-11-26', 4),
			('Ayrton', 'Senna', '1960-03-21', 9),
			('Ronnie', 'Peterson', '1944-02-14', 9),
			('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES		(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
			(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
			(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
			(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)