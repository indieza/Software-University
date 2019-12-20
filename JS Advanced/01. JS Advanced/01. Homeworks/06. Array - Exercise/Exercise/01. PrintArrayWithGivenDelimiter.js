function solve(array) {
    console.log(array.slice(0, -1).join(array.splice(-1, 1)));
}

solve(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-'
]);

solve(['How about no?',
    'I',
    'will',
    'not',
    'do',
    'it!',
    '_'
]);