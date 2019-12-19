function solve(array) {
    let first = 0;
    let second = 0;

    for (let i = 0; i < array.length; i++) {
        first += array[i][i];
        second += array[i][array.length - 1 - i];
    }

    console.log(`${first} ${second}`);
}

solve([
    [20, 40],
    [10, 60]
]);

solve([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]
]);