function solve(number) {
    let symbol = String(number)[0];
    let isValid = true;
    let sum = Number(symbol);

    for (let i = 1; i < String(number).length; i++) {
        const element = String(number)[i];

        if (element != symbol) {
            isValid = false;
        }

        sum += Number(element);
    }

    console.log(isValid);
    console.log(sum);
}

solve(2222222);
solve(1234);