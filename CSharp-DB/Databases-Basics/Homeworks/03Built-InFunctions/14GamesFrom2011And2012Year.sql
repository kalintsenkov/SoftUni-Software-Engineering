  SELECT TOP(50) [Name],
         FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM Games
   WHERE [Start] BETWEEN '2011' AND '2013'
ORDER BY [Start], [Name]