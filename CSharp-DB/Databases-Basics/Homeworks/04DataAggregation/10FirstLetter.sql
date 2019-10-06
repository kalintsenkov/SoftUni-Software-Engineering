  SELECT w.FirstLetter
    FROM (SELECT LEFT(FirstName, 1) AS [FirstLetter]
            FROM WizzardDeposits
           WHERE DepositGroup = 'Troll Chest') AS w
GROUP BY w.FirstLetter
ORDER BY w.FirstLetter