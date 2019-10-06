  SELECT g.DepositGroup,
         SUM(g.DepositAmount) AS [TotalSum]
    FROM WizzardDeposits AS g
   WHERE g.MagicWandCreator = 'Ollivander family'
GROUP BY g.DepositGroup
  HAVING SUM(g.DepositAmount) < 150000
ORDER BY [TotalSum] DESC