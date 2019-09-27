CREATE PROCEDURE usp_GetEmployeesFromTown(@Town VARCHAR(50))
AS
SELECT [e].[FirstName], [e].[LastName]
  FROM [dbo].[Employees] AS e
  JOIN [dbo].[Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
  JOIN [dbo].[Towns] AS [t] ON [a].[TownID] = [t].[TownID]
 WHERE [t].[Name] = @Town