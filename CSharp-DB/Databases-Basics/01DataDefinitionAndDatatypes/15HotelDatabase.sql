CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	PhoneNumber INT UNIQUE NOT NULL,
	EmergencyName NVARCHAR(30),
	EmergencyNumber NVARCHAR(30),
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes (
	RoomType NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes (
	BedType NVARCHAR(20) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(3, 2),
	RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15, 2) NOT NULL,
	TaxRate DECIMAL(3, 2),
	TaxAmount DECIMAL(15, 2) NOT NULL,
	PaymentTotal DECIMAL(15, 2) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(3, 2),
	PhoneCharge DECIMAL(15, 2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
	    (FirstName, LastName, Title, Notes)
VALUES	    
	    ('Kiro', 'Kirov', 'employee1', NULL),
	    ('Ivan', 'Ivanov', 'employee2', NULL),
	    ('Pesho', 'Peshev', 'employee3', NULL)

INSERT INTO Customers
	    (FirstName, LastName, PhoneNumber,
	    EmergencyName, EmergencyNumber, Notes)
VALUES	    
	    ('Toshko', 'Toshkov', 123456, NULL, NULL, NULL),
	    ('Stamat', 'Stamatov', 654321, NULL, NULL, NULL),
	    ('Gosho', 'Goshov', 223341, NULL, NULL, NULL)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES	    ('Status1', NULL),
	    ('Status2', NULL),
	    ('Status3', NULL)

INSERT INTO RoomTypes(RoomType, Notes)
VALUES	    ('Type1', NULL),
	    ('Type2', NULL),
	    ('Type3', NULL)

INSERT INTO BedTypes(BedType, Notes)
VALUES	    ('Bed1', NULL),
	    ('Bed2', NULL),
	    ('Bed3', NULL)

INSERT INTO Rooms
	    (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES     
	    ('Type1', 'Bed1', 7.25, 'Status1', NULL),
	    ('Type2', 'Bed2', 8.30, 'Status2', NULL),
	    ('Type3', 'Bed3', 9.20, 'Status3', NULL)

INSERT INTO Payments
            (EmployeeId, PaymentDate, AccountNumber, 
            FirstDateOccupied, LastDateOccupied, 
            TotalDays, AmountCharged, TaxRate, 
            TaxAmount, PaymentTotal, Notes)
VALUES            
            (1, '2005-05-10', 1, '2005-05-05', '2005-05-10', 5, 305.50, 5.5, 35.72, 341.22, NULL),
            (2, '2007-07-15', 2, '2007-07-21', '2007-07-15', 6, 301.00, 6.5, 15.20, 316.20, NULL),
            (3, '2012-02-09', 3, '2012-02-16', '2012-02-09', 7, 450.25, 8.3, 25.20, 475.45, NULL)

INSERT INTO Occupancies
	    (EmployeeId, DateOccupied, AccountNumber,
	     RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES    
	    (1, '2019-09-15', 1, 1, NULL, 15.90, NULL),
	    (3, '2015-07-16', 3, 3, 7.50, 16.20, NULL),
	    (2, '1999-05-16', 2, 2, 8.32, 12.35, NULL)
