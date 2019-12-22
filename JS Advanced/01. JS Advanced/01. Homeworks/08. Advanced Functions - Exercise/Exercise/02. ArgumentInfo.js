function solve() {
    let data = new Map();

    for (const arg of arguments) {
        let argumentType = typeof (arg);

        console.log(`${argumentType}: ${arg}`);

        if (!data.get(argumentType)) {
            data.set(argumentType, 0);
        }

        data.set(argumentType, data.get(argumentType) + 1);
    }

    [...data]
    .sort((a, b) =>
            b[1] - a[1])
        .forEach(md => {
            console.log(`${md[0]} = ${md[1]}`);
        });
}

solve('cat', 42, function () {
    console.log('Hello world!');
});