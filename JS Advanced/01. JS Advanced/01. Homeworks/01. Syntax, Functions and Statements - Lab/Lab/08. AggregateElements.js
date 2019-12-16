function solve(array) {
    let sum1 = 0;
    let sum2 = 0;
    let concat = "";

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        sum1 += element;
        sum2 += 1 / element;
        concat += element
    }

    console.log(sum1);
    console.log(sum2);
    console.log(concat);
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);