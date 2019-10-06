CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(32) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName NVARCHAR(32) NOT NULL,
	MajorID INT NOT NULL,

	CONSTRAINT FK_Students_MajorID
	FOREIGN KEY (MajorID)
	REFERENCES Majors(MajorID)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(32) NOT NULL
)

CREATE TABLE Agenda
(
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,

	CONSTRAINT PK_StudentsSubjects
	PRIMARY KEY (StudentID, SubjectID),

	CONSTRAINT FK_Agenda_StudentID
	FOREIGN KEY(StudentID)
	REFERENCES Students(StudentID),

	CONSTRAINT FK_Agenda_SubjectID
	FOREIGN KEY(SubjectID)
	REFERENCES Subjects(SubjectID),
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(15,2) NOT NULL,
	StudentID INT NOT NULL,

	CONSTRAINT FK_Payments_StudentID
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID)
)