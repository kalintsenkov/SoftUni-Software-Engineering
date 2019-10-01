CREATE TABLE Students 
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(32) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY,
	[Name] NVARCHAR(32) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,

	CONSTRAINT PK_StudentExam
	PRIMARY KEY(StudentID, ExamID),

	CONSTRAINT FK_Exams_ExamsID
	FOREIGN KEY(ExamID)
	REFERENCES Exams(ExamID),

	CONSTRAINT FK_Students_StudentID
	FOREIGN KEY(StudentID)
	REFERENCES Students(StudentID),
)

INSERT INTO Students([Name])
VALUES      ('Mila'),
            ('Toni'),
			('Ron')

INSERT INTO Exams(ExamID ,[Name])
VALUES      (101, 'SpringMVC'),
            (102, 'Neo4j'),
			(103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES      (1, 101),
            (1, 102),
			(2, 101),
			(3, 103),
			(2, 102),
			(2, 103)