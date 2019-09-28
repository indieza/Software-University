CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(100))
RETURNS BIT
AS
BEGIN
	DECLARE @result BIT
	DECLARE @count INT = 1

	WHILE @count <= LEN(@Word)
	BEGIN
		DECLARE @currentSymbol VARCHAR(2) = SUBSTRING(@Word, @count, 1)

		IF(CHARINDEX(@currentSymbol, @SetOfLetters)) > 0
			BEGIN
				SET @result = 1
				SET @count+=1
			END
		ELSE
			BEGIN
				SET @result = 0
				BREAK
			END
	END
	RETURN @result
END