function solve(array) {
    console.log(array
        .filter((_, i) =>
            i % 2 === 0)
        .join(" "));
}

solve(['20', '30', '40']);
solve(['5', '10']);