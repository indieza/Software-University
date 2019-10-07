CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME,
                                        @StartDate DATETIME,
										@EndDate DATETIME,
										@Discount INT,
										@FirstItemId INT,
										@SecondItemId INT,
										@ThirdItemId INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @firstItemPrice DECIMAL(15, 2) = (SELECT [i].[Price]
                                                FROM [dbo].[Items] AS i
                                               WHERE [i].[Id] = @FirstItemId)

	DECLARE @secondItemPrice DECIMAL(15, 2) = (SELECT [i].[Price]
                                                FROM [dbo].[Items] AS i
                                               WHERE [i].[Id] = @SecondItemId)
	
	DECLARE @thirdItemPrice DECIMAL(15, 2) = (SELECT [i].[Price]
                                                FROM [dbo].[Items] AS i
                                               WHERE [i].[Id] = @ThirdItemId)

	IF(@firstItemPrice IS NULL OR @secondItemPrice IS NULL OR @thirdItemPrice IS NULL)
	BEGIN
		RETURN 'One of the items does not exists!'
	END

	IF(@CurrentDate NOT BETWEEN @StartDate AND @EndDate)
	BEGIN
		RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @firstItemName VARCHAR(50) = (SELECT [i].[Name]
                                            FROM [dbo].[Items] AS i
                                           WHERE [i].[Id] = @FirstItemId)

	DECLARE @secondItemName VARCHAR(50) = (SELECT [i].[Name]
                                             FROM [dbo].[Items] AS i
                                            WHERE [i].[Id] = @SecondItemId)
	
	DECLARE @thirdItemName VARCHAR(50) = (SELECT [i].[Name]
                                            FROM [dbo].[Items] AS i
                                           WHERE [i].[Id] = @ThirdItemId)

	SET @firstItemPrice -= @firstItemPrice * @discount / 100
	SET @secondItemPrice -= @secondItemPrice * @discount / 100
	SET @thirdItemPrice -= @thirdItemPrice * @discount / 100

	RETURN @firstItemName + ' price: ' + 
	       CAST(@firstItemPrice AS VARCHAR(50)) + ' <-> ' + 
		   @secondItemName + ' price: ' + 
		    CAST(@secondItemPrice AS VARCHAR(50)) + ' <-> ' +
		   @thirdItemName + ' price: ' +
		    CAST(@thirdItemPrice AS VARCHAR(50))
END

SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03', 13, 3, 4, 5)
SELECT dbo.udf_GetPromotedProducts('2018-08-01', '2018-08-02', '2018-08-03',13,3 ,4,5)