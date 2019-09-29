CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15, 2), @Rate FLOAT, @Years INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN
	RETURN @sum * (POWER(1 + @Rate, @Years))
END