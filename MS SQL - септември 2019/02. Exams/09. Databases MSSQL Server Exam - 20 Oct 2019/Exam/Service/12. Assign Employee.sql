CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @employeeDepartmentId INT = (SELECT [e].[DepartmentId]
                                           FROM [dbo].[Employees] AS e
                                          WHERE [e].[Id] = @EmployeeId)

	DECLARE @reportDepartmentId INT = (SELECT [e].[DepartmentId]
                                         FROM [dbo].[Reports] AS r
                                         JOIN [dbo].[Employees] AS [e] ON [r].[EmployeeId] = [e].[Id]
                                        WHERE [r].[Id] = @ReportId)

	IF(@employeeDepartmentId <> @reportDepartmentId)
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END

	UPDATE [dbo].[Reports]
	   SET
	       [dbo].[Reports].[EmployeeId] = @EmployeeId
	 WHERE [dbo].[Reports].[Id] = @ReportId
END

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2