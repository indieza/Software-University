function solve(n, k) {
    let array = [1];

    for (let i = 0; i < n; i++) {
        let currentElement = array.slice(k * -1)
            .reduce((a, b) => a + b);

        array[i] = currentElement;
    }

    console.log(array.join(" "));
}

solve(6, 3);
solve(8, 2);