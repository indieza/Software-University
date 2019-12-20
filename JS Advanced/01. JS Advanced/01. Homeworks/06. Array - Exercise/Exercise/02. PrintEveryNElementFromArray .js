function solve(array) {
    let lastElement = array.pop();
    console.log(array.filter((_, i) => i % lastElement === 0).join("\n"));
}

solve(['5',
    '20',
    '31',
    '4',
    '20',
    '2'
]);

solve(['dsa',
        'asd',
        'test',
        'tset',
        '2'
    ]

);

solve(['1',
    '2',
    '3',
    '4',
    '5',
    '6'
]);