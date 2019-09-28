CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @result VARCHAR(20)

	IF(@salary < 30000)
		SET @result = 'Low'
	IF(@salary BETWEEN 30000 AND 50000)
		SET @result = 'Average'
	IF(@salary > 50000)
		SET @result = 'High'

	RETURN @result
END