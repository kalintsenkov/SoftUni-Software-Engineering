CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(10)
	
	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF (@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE
		SET @salaryLevel = 'High'

	RETURN @salaryLevel
END
