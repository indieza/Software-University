USE Gringotts;

SELECT COUNT(*) AS [Count]
  FROM WizzardDeposits;

SELECT MAX(MagicWandSize) AS [LongestMagicWand]
  FROM WizzardDeposits;

  SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand]
    FROM WizzardDeposits
GROUP BY DepositGroup;

  SELECT TOP(2) DepositGroup
    FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize);


  SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
GROUP BY DepositGroup;

  SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup;

  SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
    FROM WizzardDeposits
   WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC;

  SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge)
    FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup;

SELECT GroupAges.AgeGroup, COUNT(GroupAges.AgeGroup)
  FROM
(
SELECT
  CASE
	WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
	WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
	WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
	WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
	WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
	WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
	ELSE '[61+]'
  END AS [AgeGroup]
    FROM WizzardDeposits
    ) AS [GroupAges]
GROUP BY GroupAges.AgeGroup