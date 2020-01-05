function solve(array, a, b) {
    if (!Array.isArray(array) || !array.every(x => typeof (x) === "number")) {
        return NaN;
    }
    if (a < 0) {
        a = 0;
    }
    if (b > array.length) {
        b = array.length;
    }

    return array.slice(a, b + 1).reduce((a, b) => a + b, 0);
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve([], 1, 2));
console.log(solve('text', 0, 2));