CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel NVARCHAR(10))
AS
BEGIN
	SELECT e.FirstName,
	       e.LastName
	  FROM Employees AS e
	 WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END