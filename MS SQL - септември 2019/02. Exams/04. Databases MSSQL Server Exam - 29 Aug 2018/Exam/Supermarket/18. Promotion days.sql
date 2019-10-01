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
	DECLARE @targetFirstItemId INT = (SELECT [i].[Id] FROM [dbo].[Items] AS i WHERE [i].[Id] = @FirstItemId)
	DECLARE @targetSecondItemId INT = (SELECT [i].[Id] FROM [dbo].[Items] AS i WHERE [i].[Id] = @SecondItemId)
	DECLARE @targetThirdItemId INT = (SELECT [i].[Id] FROM [dbo].[Items] AS i WHERE [i].[Id] = @ThirdItemId)

	IF(@targetFirstItemId IS NULL OR @targetSecondItemId IS NULL OR @targetThirdItemId IS NULL)
		RETURN 'One of the items does not exists!'

	IF(@CurrentDate NOT BETWEEN @StartDate AND @EndDate)
		RETURN 'The current date is not within the promotion dates!'

	DECLARE @targetFirstItemName VARCHAR(50) = (SELECT [i].[Name] FROM [dbo].[Items] AS i WHERE [i].[Id] = @targetFirstItemId)
	DECLARE @targetSecondItemName VARCHAR(50) = (SELECT [i].[Name] FROM [dbo].[Items] AS i WHERE [i].[Id] = @targetSecondItemId)
	DECLARE @targetThirdItemName VARCHAR(50) = (SELECT [i].[Name] FROM [dbo].[Items] AS i WHERE [i].[Id] = @targetThirdItemId)

	DECLARE @targetFirstItemPrice DECIMAL(15, 2) = (SELECT [i].[Price] FROM [dbo].[Items] AS i WHERE [i].[Id] = @targetFirstItemId)
	DECLARE @targetSecondItemPrice DECIMAL(15, 2) = (SELECT [i].[Price] FROM [dbo].[Items] AS i WHERE [i].[Id] = @targetSecondItemId)
	DECLARE @targetThirdItemPrice DECIMAL(15, 2) = (SELECT [i].[Price] FROM [dbo].[Items] AS i WHERE [i].[Id] = @targetThirdItemId)

	DECLARE @firstPrice DECIMAL(15, 2) = @targetFirstItemPrice - (@targetFirstItemPrice * @Discount / 100)
	DECLARE @secondPrice DECIMAL(15, 2) = @targetSecondItemPrice - (@targetSecondItemPrice * @Discount / 100)
	DECLARE @thirdPrice DECIMAL(15, 2) = @targetThirdItemPrice - (@targetThirdItemPrice * @Discount / 100)

	RETURN @targetFirstItemName +
	       ' price: ' + CAST(@firstPrice AS VARCHAR(50)) +
		   ' <-> ' + @targetSecondItemName +
		   ' price: ' + CAST(@secondPrice AS VARCHAR(50)) +
		   ' <-> ' + @targetThirdItemName +
		   ' price: ' + CAST(@thirdPrice AS VARCHAR(50))
END

SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)
SELECT dbo.udf_GetPromotedProducts('2018-08-01', '2018-08-02', '2018-08-03',13,3 ,4,5)