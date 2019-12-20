function solve(array) {
    console.log(array
        .sort((a, b) =>
            a.length - b.length ||
            a.toLowerCase()
            .localeCompare(b.toLowerCase()))
        .join("\n"));
}

solve(['alpha',
    'beta',
    'gamma'
]);

solve(['Isacc',
        'Theodor',
        'Jack',
        'Harrison',
        'George'
    ]

);

solve(['test',
    'Deny',
    'omen',
    'Default'
]);