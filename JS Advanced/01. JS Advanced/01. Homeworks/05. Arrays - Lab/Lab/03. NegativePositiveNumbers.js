function solve(array) {
    let result = [];

    array.forEach(element => {
        element < 0 ?
            result.unshift(element) :
            result.push(element)
    });

    console.log(result.join("\n"));
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);