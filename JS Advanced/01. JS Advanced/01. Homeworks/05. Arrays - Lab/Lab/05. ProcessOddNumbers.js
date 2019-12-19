function solve(array) {
    console.log(array
        .filter((_, i) =>
            i % 2 === 1)
        .reverse()
        .map(i => i * 2)
        .join(" "));
}

solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7, 3]);