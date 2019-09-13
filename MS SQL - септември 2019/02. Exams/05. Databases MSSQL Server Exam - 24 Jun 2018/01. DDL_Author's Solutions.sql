-- 01 DDL
CREATE TABLE Cities (
  Id          INT PRIMARY KEY IDENTITY,
  Name        NVARCHAR(20) NOT NULL,
  CountryCode CHAR(2)      NOT NULL
)

CREATE TABLE Hotels (
  Id            INT PRIMARY KEY IDENTITY,
  Name          NVARCHAR(30)   NOT NULL,
  CityId        INT            NOT NULL,
  EmployeeCount INT            NOT NULL,
  BaseRate      DECIMAL(15, 2) NOT NULL,
  CONSTRAINT FK_Hotels_Cities FOREIGN KEY (CityId) REFERENCES Cities (Id)
)

CREATE TABLE Rooms (
  Id      INT PRIMARY KEY IDENTITY,
  Price   DECIMAL(15, 2) NOT NULL,
  Type    NVARCHAR(20)   NOT NULL,
  Beds    INT            NOT NULL,
  HotelId INT            NOT NULL,
  CONSTRAINT FK_Rooms_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels (Id)
)

CREATE TABLE Trips (
  Id          INT PRIMARY KEY IDENTITY,
  RoomId      INT  NOT NULL,
  BookDate    DATE NOT NULL,
  ArrivalDate DATE NOT NULL,
  ReturnDate  DATE NOT NULL,
  CancelDate  DATE,
  CONSTRAINT FK_Trips_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms (Id),
  CONSTRAINT CK_BookDate_ArrivalDate CHECK (BookDate < ArrivalDate),
  CONSTRAINT CK_ArrivalDate_ReturnDate CHECK (ArrivalDate < ReturnDate),
)

CREATE TABLE Accounts (
  Id         INT PRIMARY KEY IDENTITY,
  FirstName  NVARCHAR(50) NOT NULL,
  MiddleName NVARCHAR(20),
  LastName   NVARCHAR(50) NOT NULL,
  CityId     INT          NOT NULL,
  BirthDate  DATE         NOT NULL,
  Email      VARCHAR(100) NOT NULL,
  CONSTRAINT FK_Accounts_Cities FOREIGN KEY (CityId) REFERENCES Cities (Id),
  CONSTRAINT UQ_Email UNIQUE (Email)
)

CREATE TABLE AccountsTrips (
  AccountId INT NOT NULL,
  TripId    INT NOT NULL,
  Luggage   INT NOT NULL,
  CONSTRAINT PK_AccountsTrips PRIMARY KEY (AccountId, TripId),
  CONSTRAINT FK_AccountsTrips_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts (Id),
  CONSTRAINT FK_AccountsTrips_Trips FOREIGN KEY (TripId) REFERENCES Trips (Id),
  CONSTRAINT CK_Luggage CHECK (Luggage >= 0)
)

-- 02 Insert
INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
  ('John', 'Smith', 'Smith', '34', '1975-07-21', 'j_smith@gmail.com'),
  ('Gosho', NULL, 'Petrov', '11', '1978-05-16', 'g_petrov@gmail.com'),
  ('Ivan', 'Petrovich', 'Pavlov', '59', '1849-09-26', 'i_pavlov@softuni.bg'),
  ('Friedrich', 'Wilhelm', 'Nietzsche', '2', '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
  (101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
  (102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
  (103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
  (104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
  (109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

-- 3 Update
UPDATE Rooms
SET Price += Price * 0.14
WHERE HotelId IN (5, 7, 9)

-- 4 Delete
DELETE FROM AccountsTrips
WHERE AccountId = 47

--5 Bulgarian Cities
SELECT Id, Name FROM Cities
WHERE CountryCode = 'BG'
ORDER BY Name

--6 People Born after 1991
SELECT
  CONCAT(FirstName, ' ' + MiddleName, ' ', LastName) AS [Full Name],
  YEAR(BirthDate) AS BirthYear
FROM Accounts
WHERE YEAR(BirthDate) > 1991
ORDER BY YEAR(BirthDate) DESC, FirstName

--7 EEE-Mails
SELECT a.FirstName, a.LastName, FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate, c.Name AS Hometown, a.Email
FROM Accounts AS a
JOIN Cities AS c
ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name DESC

--8 City Statistics
SELECT C.Name, COUNT(H.Id) AS Cities FROM Cities C
LEFT JOIN Hotels H on C.Id = H.CityId
GROUP BY C.Id, c.Name
ORDER BY Cities DESC, C.Name

--9 Expensive First-Class Rooms
SELECT R.Id, Price, H.Name AS Hotel, C.Name AS City FROM Rooms r
  JOIN Hotels H on r.HotelId = H.Id
  JOIN Cities C on H.CityId = C.Id
WHERE r.Type = 'First Class'
ORDER BY R.Price DESC, R.Id

--10 Longest and Shortest Trips
SELECT
  a.Id AS AccountId,
  FirstName + ' ' + LastName AS FullName,
  MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
  MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
FROM Accounts AS a
JOIN AccountsTrips AS at
ON at.AccountId = a.Id
JOIN Trips AS t
ON t.Id = at.TripId
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName + ' ' + a.LastName
ORDER BY LongestTrip DESC, AccountId

-- 11 Metropolis
SELECT TOP 5
  C.Id,
  C.Name        AS City,
  C.CountryCode AS Country,
  COUNT(*)      AS Accounts
FROM Cities C
  JOIN Accounts A on C.Id = A.CityId
GROUP BY C.Id, C.Name, C.CountryCode
ORDER BY Accounts DESC, C.Id

-- 12 Romantic Getaways
SELECT
  A.Id,
  A.Email,
  C.Name   AS City,
  COUNT(*) AS Trips
FROM Accounts A
  JOIN AccountsTrips AT on A.Id = AT.AccountId
  JOIN Trips T on AT.TripId = T.Id
  JOIN Rooms R on T.RoomId = R.Id
  JOIN Hotels H on R.HotelId = H.Id
  JOIN Cities C on H.CityId = C.Id
WHERE A.CityId = H.CityId
GROUP BY A.Id, A.Email, A.CityId, C.Name
ORDER BY Trips DESC, A.Id

-- 13 Lucrative Destinations
SELECT TOP 10
  C.Id,
  C.Name,
  SUM(H.BaseRate + R.Price) AS [Total Revenue],
  COUNT(*)                  AS Trips
FROM Cities C
  JOIN Hotels H on C.Id = H.CityId
  JOIN Rooms R on H.Id = R.HotelId
  JOIN Trips T on R.Id = T.RoomId
WHERE YEAR(T.BookDate) = 2016
GROUP BY C.Id, C.Name
ORDER BY [Total Revenue] DESC, Trips DESC

-- 14 Trip Revenues
SELECT
  AT.TripId,
  H.Name AS HotelName,
  R.Type AS RoomType,
  CASE WHEN T.CancelDate IS NULL
    THEN SUM(H.BaseRate + R.Price)
  ELSE 0
  END    AS Revenue
FROM Trips T
  JOIN Rooms R on T.RoomId = R.Id
  JOIN Hotels H on R.HotelId = H.Id
  JOIN AccountsTrips AT on T.Id = AT.TripId
GROUP By AT.TripId, H.Name, R.Type, T.CancelDate
ORDER BY RoomType, AT.TripId

-- 15 Top Travelers
SELECT
  AccountId,
  Email,
  CountryCode,
  Trips
FROM (SELECT
        A.Id                             AS AccountId,
        A.Email,
        C.CountryCode,
        COUNT(*)                         AS Trips,
        DENSE_RANK()
        OVER ( PARTITION BY C.CountryCode
          ORDER BY COUNT(*) DESC, A.Id ) AS Rank
      FROM Accounts A
        JOIN AccountsTrips AT on A.Id = AT.AccountId
        JOIN Trips T on AT.TripId = T.Id
        JOIN Rooms R on T.RoomId = R.Id
        JOIN Hotels H on R.HotelId = H.Id
        JOIN Cities C on H.CityId = C.Id
      GROUP BY C.CountryCode, A.Email, A.Id) AS RanksPerCountry
WHERE Rank = 1
ORDER BY Trips DESC, AccountId

-- 16 Luggage Fees
SELECT
  TripId,
  SUM(Luggage)                           AS Luggage,
  '$' + CONVERT(VARCHAR(10), SUM(Luggage) *
                             CASE WHEN SUM(Luggage) > 5
                               THEN 5
                             ELSE 0 END) AS Fee
FROM Trips
  JOIN AccountsTrips AT on Trips.Id = AT.TripId
GROUP BY TripId
HAVING SUM(Luggage) > 0
ORDER BY Luggage DESC

-- 17 GDPR Violation
SELECT
  T.Id,
  CONCAT(A.FirstName, ' ' + A.MiddleName, ' ', A.LastName) AS [Full Name],
  AC.Name                                                  AS [From],
  HC.Name                                                  AS [To],
  CASE WHEN CancelDate IS NOT NULL
    THEN 'Canceled'
  ELSE CONCAT(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate), ' days')
  END                                                      AS Duration
FROM Trips AS T
  JOIN AccountsTrips AT on T.Id = AT.TripId
  JOIN Accounts A ON AT.AccountId = A.Id
  JOIN Rooms R ON T.RoomId = R.Id
  JOIN Hotels H on R.HotelId = H.Id
  JOIN Cities HC on H.CityId = HC.Id
  JOIN Cities AC on A.CityId = AC.Id
ORDER BY [Full Name], T.Id

-- 18. Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
  RETURNS VARCHAR(MAX)
AS
  BEGIN
    DECLARE @BookedRooms TABLE(Id INT)
    INSERT INTO @BookedRooms
      SELECT DISTINCT R.Id
      FROM Rooms R
        LEFT JOIN Trips T on R.Id = T.RoomId
      WHERE R.HotelId = @HotelId AND @Date BETWEEN T.ArrivalDate AND T.ReturnDate AND T.CancelDate IS NULL

    DECLARE @Rooms TABLE(Id INT, Price DECIMAL(15, 2), Type VARCHAR(20), Beds INT, TotalPrice DECIMAL(15, 2))
    INSERT INTO @Rooms
      SELECT TOP 1
        R.Id,
        R.Price,
        R.Type,
        R.Beds,
        @People * (H.BaseRate + R.Price) AS TotalPrice
      FROM Rooms R
        LEFT JOIN Hotels H on R.HotelId = H.Id
      WHERE
        R.HotelId = @HotelId AND
        R.Beds >= @People AND
        R.Id NOT IN (SELECT Id
                     FROM @BookedRooms)
      ORDER BY TotalPrice DESC

    DECLARE @RoomCount INT = (SELECT COUNT(*)
                              FROM @Rooms)
    IF (@RoomCount < 1)
      BEGIN
        RETURN 'No rooms available'
      END

    DECLARE @Result VARCHAR(MAX) = (SELECT CONCAT('Room ', Id, ': ', Type, ' (', Beds, ' beds) - ', '$', TotalPrice)
                                    FROM @Rooms)

    RETURN @Result
  END

-- 19. Switch Rooms
CREATE OR ALTER PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
  BEGIN
    DECLARE @SourceHotelId INT = (SELECT H.Id
                                  FROM Hotels H
                                    JOIN Rooms R on H.Id = R.HotelId
                                    JOIN Trips T on R.Id = T.RoomId
                                  WHERE T.Id = @TripId)

    DECLARE @TargetHotelId INT = (SELECT H.Id
                                  FROM Hotels H
                                    JOIN Rooms R on H.Id = R.HotelId
                                  WHERE R.Id = @TargetRoomId)

    IF (@SourceHotelId <> @TargetHotelId)
      THROW 50013, 'Target room is in another hotel!', 1

    DECLARE @PeopleCount INT = (SELECT COUNT(*)
                                FROM AccountsTrips
                                WHERE TripId = @TripId)

    DECLARE @TargetRoomBeds INT = (SELECT Beds
                                   FROM Rooms
                                   WHERE Id = @TargetRoomId)

    IF (@PeopleCount > @TargetRoomBeds)
      THROW 50013, 'Not enough beds in target room!', 1

    UPDATE Trips
    SET RoomId = @TargetRoomId
    WHERE Id = @TripId
  END

  -- 20. Cancel Trip
  CREATE TRIGGER T_CancelTrip
    ON Trips
    INSTEAD OF DELETE
  AS
    BEGIN
      UPDATE Trips
      SET CancelDate = GETDATE()
      WHERE Id IN (SELECT Id
                   FROM deleted
                   WHERE CancelDate IS NULL)
    END