CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
DECLARE @projects INT = (SELECT COUNT([ep].[ProjectID])
                           FROM [dbo].[Employees] AS e
						   JOIN [dbo].[EmployeesProjects] AS [ep] ON [e].[EmployeeID] = [ep].[EmployeeID]
						  WHERE [e].[EmployeeID] = @emloyeeId)

IF(@projects >= 3)
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 1)
	RETURN
END

INSERT INTO [dbo].[EmployeesProjects]
(
    [EmployeeID],
    [ProjectID]
)
VALUES
(
    @emloyeeId,
    @projectID
)

COMMIT