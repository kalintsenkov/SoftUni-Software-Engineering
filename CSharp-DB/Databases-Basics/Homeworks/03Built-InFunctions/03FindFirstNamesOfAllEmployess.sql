SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3, 10) AND 
       HireDate BETWEEN CAST('1995' AS DATE) AND CAST('2006' AS DATE)
