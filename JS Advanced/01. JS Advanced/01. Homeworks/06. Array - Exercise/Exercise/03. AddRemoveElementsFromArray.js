function solve(array) {
    let result = [];
    let value = 1;

    for (const item of array) {
        item === "add" ? result.push(value++) : result.pop(value++);
    }    

    console.log(result.length === 0 ? "Empty" : result.join("\n"));
}

solve(['add',
        'add',
        'add',
        'add'
    ]

);

solve(['add',
    'add',
    'remove',
    'add',
    'add'
]);

solve(['remove',
    'remove',
    'remove'
]);