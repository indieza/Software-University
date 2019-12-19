function solve(array) {
    let count = 0;

    for (let i = 0; i < array.length; i++) {
        for (let j = 0; j < array[i].length; j++) {
            let rightNeighbor = array[i][j + 1];

            if (rightNeighbor !== undefined && rightNeighbor === array[i][j]) {
                count++;
            }

            if (i > 0) {
                let upNeighbor = array[i - 1][j];
                if (upNeighbor !== undefined && upNeighbor === array[i][j]) {
                    count++;
                }
            }
        }
    }

    console.log(count);
}

solve([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']
]);

solve([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']
]);