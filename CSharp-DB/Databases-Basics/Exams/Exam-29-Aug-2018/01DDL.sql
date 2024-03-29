CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Items
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Price DECIMAL(15, 2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL,
	Salary DECIMAL(15, 2) NOT NULL
)

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderId INT NOT NULL,
	ItemId INT NOT NULL,
	Quantity INT NOT NULL,

	CONSTRAINT CHK_Quantity
	CHECK(Quantity >= 1),

	CONSTRAINT PK_OrderId_ItemId
	PRIMARY KEY(OrderId, ItemId),
	
	CONSTRAINT FK_OrderId_OrderItems
	FOREIGN KEY(OrderId)
	REFERENCES Orders(Id),

	CONSTRAINT FK_ItemId_OrderItems
	FOREIGN KEY(ItemId)
	REFERENCES Items(Id)
)

CREATE TABLE Shifts
(
	Id INT NOT NULL IDENTITY,
	EmployeeId INT NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL,

	CONSTRAINT CHK_CheckIn_CheckOut
	CHECK(CheckOut > CheckIn),

	CONSTRAINT PK_Shifts
	PRIMARY KEY(Id, EmployeeId),

	CONSTRAINT FK_EmployeeId_Shifts
	FOREIGN KEY(EmployeeId)
	REFERENCES Employees(Id)
)