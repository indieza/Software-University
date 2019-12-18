function solve(input) {
    let cars = new Map();

    for (const line of input) {
        let items = line.split(" | ");
        let [brand, model, count] = [items[0], items[1], Number(items[2])];

        if (!cars.get(brand)) {
            cars.set(brand, new Map());
        }

        if (!cars.get(brand).get(model)) {
            cars.get(brand).set(model, 0);
        }

        cars.get(brand).set(model, cars.get(brand).get(model) + count);
    }

    console.log([...cars]
        .map(car => `${car[0]}\n${[...car[1]]
            .map(item =>`###${item[0]} -> ${item[1]}`)
            .join("\n")}`)
        .join("\n"));
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]);