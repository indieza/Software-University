function solve(input) {
    let products = new Map();

    for (const line of input) {
        let items = line.split(" : ");
        
        let productName = items[0];
        let productPrice = Number(items[1]);
        let firstLetter = productName[0];

        if (!products.get(firstLetter)) {
            products.set(firstLetter, new Map());
        }

        products.get(firstLetter).set(productName, productPrice);
    }

    console.log([...products]
        .sort()
        .map(p => `${p[0]}\n  ${[...p[1]]
            .sort()
            .map(i => `${i[0]}: ${i[1]}`)
            .join("\n  ")}`)
        .join("\n"));
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]);

solve(['Banana : 2',
    'Rubic\'s Cube: 5 ',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10'
]);