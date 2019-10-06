  SELECT R.EmployeeID,
         R.FirstName,
	 R.LastName,
	 R.Salary,
	 R.[Rank]
    FROM (SELECT EmployeeID,
	         FirstName,
	         LastName,
	         Salary,
	         DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
            FROM Employees
           WHERE Salary BETWEEN 10000 AND 50000) AS R
   WHERE [Rank] = 2
ORDER BY R.Salary DESC
