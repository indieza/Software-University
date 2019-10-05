CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT([r].[StatusId])
             FROM [dbo].[Reports] AS r
            WHERE [r].[EmployeeId] = @employeeId AND [r].[StatusId] = @statusId)
END

SELECT Id, FirstName, Lastname, dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
FROM Employees
ORDER BY Id