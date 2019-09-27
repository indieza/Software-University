INSERT INTO [dbo].[Teachers]
(
    [FirstName],
    [LastName],
    [Address],
    [Phone],
    [SubjectId]
)
VALUES
(
    'Ruthanne',
    'Bamb',
    '84948 Mesta Junction',
    '3105500146',
    6
),
(
    'Gerrard',
    'Lowin',
    '370 Talisman Plaza',
    '3324874824',
    2
),
(
    'Merrile',
    'Lambdin',
    '81 Dahle Plaza',
    '4373065154',
    5
),
(
    'Bert',
    'Ivie',
    '2 Gateway Circle',
    '4409584510',
    4
);

INSERT INTO [dbo].[Subjects]
(
    [Name],
    [Lessons]
)
VALUES
(
    'Geometry',
    12
),
(
    'Health',
    10
),
(
    'Drama',
    7
),
(
    'Sports',
    9
);