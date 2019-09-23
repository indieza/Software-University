INSERT INTO [dbo].[Planets]
(
    [Name]
)
VALUES
(
    'Mars' -- Name - varchar
),
(
    'Earth' -- Name - varchar
),
(
    'Jupiter' -- Name - varchar
),
(
    'Saturn' -- Name - varchar
);

INSERT INTO [dbo].[Spaceships]
(
	[Name],
    [Manufacturer],
    [LightSpeedRate]
)
VALUES
(
    'Golf', -- Name - varchar
    'VW', -- Manufacturer - varchar
    3 -- LightSpeedRate - int
),
(
    'WakaWaka', -- Name - varchar
    'Wakanda', -- Manufacturer - varchar
    4 -- LightSpeedRate - int
),
(
    'Falcon9', -- Name - varchar
    'SpaceX', -- Manufacturer - varchar
    1 -- LightSpeedRate - int
),
(
    'Bed', -- Name - varchar
    'Vidolov', -- Manufacturer - varchar
    6 -- LightSpeedRate - int
)