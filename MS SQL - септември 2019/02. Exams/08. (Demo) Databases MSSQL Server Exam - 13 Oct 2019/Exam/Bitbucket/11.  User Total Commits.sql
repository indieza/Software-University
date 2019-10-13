CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
	          FROM [dbo].[Users] AS u
	          JOIN [dbo].[Commits] AS [c] ON [u].[Id] = [c].[ContributorId]
	         WHERE [u].[Username] = @username)
END

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')