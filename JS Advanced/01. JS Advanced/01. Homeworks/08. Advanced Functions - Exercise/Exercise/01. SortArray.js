function solve(array, sortCriteria) {
    return array
        .sort((a, b) =>
            sortCriteria == "asc" ? a - b : b - a);
}

solve([14, 7, 17, 6, 8], 'asc');
solve([14, 7, 17, 6, 8], 'desc');