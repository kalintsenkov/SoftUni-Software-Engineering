SELECT SUM(k.Diff) AS [SumDifference]
  FROM (SELECT w.DepositAmount - (SELECT DepositAmount 
				    FROM WizzardDeposits AS f 
			           WHERE f.Id = w.Id + 1) AS Diff
          FROM WizzardDeposits AS w) as k 
