CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL)
		RETURN 0

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
  FROM Reports