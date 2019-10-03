CREATE TABLE Monasteries
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(500) NOT NULL,
	CountryCode CHAR(2) FOREIGN KEY REFERENCES [dbo].[Countries]([CountryCode])
);

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR');

ALTER TABLE [dbo].[Countries]
  ADD IsDeleted VARCHAR(10) DEFAULT('false') NOT NULL;

SELECT * FROM [dbo].[Countries] AS c

UPDATE [dbo].[Countries]
   SET
       [dbo].[Countries].[IsDeleted] = 'true'
 WHERE [dbo].[Countries].[CountryCode] IN (SELECT [c].[CountryCode]
                                             FROM [dbo].[Countries] AS c
									   	     JOIN [dbo].[CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
									     GROUP BY [c].[CountryCode]
									       HAVING COUNT([cr].[RiverId]) > 3);

  SELECT [m].[Name] AS [Monastery],
         [c].[CountryName] AS [Country]
    FROM [dbo].[Monasteries] AS m
    JOIN [dbo].[Countries] AS [c] ON [m].[CountryCode] = [c].[CountryCode]
   WHERE [c].[IsDeleted] = 'false'
ORDER BY [Monastery];