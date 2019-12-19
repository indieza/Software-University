function solve(array) {
    console.log(Math.max(...array.flat(1)));
}

solve([
    [20, 50, 10],
    [8, 33, 145]
]);

solve([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]
]);