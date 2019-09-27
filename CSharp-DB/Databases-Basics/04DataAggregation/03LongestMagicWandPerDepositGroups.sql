  SELECT W.DepositGroup,
	 MAX(MagicWandSize) 
      AS [LongestMagicWand]
    FROM WizzardDeposits AS W
GROUP BY W.DepositGroup
