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
    'Ruthanne', -- FirstName - nvarchar
    'Bamb', -- LastName - nvarchar
    '84948 Mesta Junction', -- Address - nvarchar
    '3105500146', -- Phone - char
    6 -- SubjectId - int
),
(
    'Gerrard', -- FirstName - nvarchar
    'Lowin', -- LastName - nvarchar
    '370 Talisman Plaza', -- Address - nvarchar
    '3324874824', -- Phone - char
    2 -- SubjectId - int
),
(
    'Merrile', -- FirstName - nvarchar
    'Lambdin', -- LastName - nvarchar
    '81 Dahle Plaza', -- Address - nvarchar
    '4373065154', -- Phone - char
    5 -- SubjectId - int
),
(
    'Bert', -- FirstName - nvarchar
    'Ivie', -- LastName - nvarchar
    '2 Gateway Circle', -- Address - nvarchar
    '4409584510', -- Phone - char
    4 -- SubjectId - int
);

INSERT INTO [dbo].[Subjects]
(
    [Name],
    [Lessons]
)
VALUES
(
    'Geometry', -- Name - nvarchar
    12 -- Lessons - int
),
(
    'Health', -- Name - nvarchar
    10 -- Lessons - int
),
(
    'Drama', -- Name - nvarchar
    7 -- Lessons - int
),
(
    'Sports', -- Name - nvarchar
    9 -- Lessons - int
);