function solve(array) {
    console.log(array
        .filter((v, i) =>
            v >= Math.max(null, ...array
                .slice(0, i)))
        .join("\n"));
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24
]);

solve([1,
    2,
    3,
    4
]);

solve([20,
    3,
    2,
    15,
    6,
    1
]);