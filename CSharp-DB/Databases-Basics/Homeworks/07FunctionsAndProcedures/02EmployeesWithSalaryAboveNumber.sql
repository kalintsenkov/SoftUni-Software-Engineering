CREATE PROC usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18, 4))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	  FROM Employees AS e
	 WHERE e.Salary >= @number
END