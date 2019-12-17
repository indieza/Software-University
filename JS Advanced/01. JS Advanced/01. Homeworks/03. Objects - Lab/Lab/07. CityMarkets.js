function solve(text) {
    let towns = {};

    for (const line of text) {
        let [town, product, countAndPrice] = line.split(" -> ");
        let [count, price] = countAndPrice.split(" : ")
            .map(x => Number(x));

        if (!towns.hasOwnProperty(town)) {
            towns[town] = {};
        }

        if (!towns[town].hasOwnProperty(product)) {
            towns[town][product] = 0;
        }

        towns[town][product] += count * price;
    }

    let result = "";

    for (const townName in towns) {
        const items = towns[townName];

        result += `Town - ${townName}\n`;

        for (const item in items) {
            result += `$$$${item} : ${items[item]}\n`;
        }
    }

    console.log(result);
}

solve(['Sofia -> Laptops HP -> 200 : 2000',
    'Sofia -> Raspberry -> 200000 : 1500',
    'Sofia -> Audi Q7 -> 200 : 100000',
    'Montana -> Portokals -> 200000 : 1',
    'Montana -> Qgodas -> 20000 : 0.2',
    'Montana -> Chereshas -> 1000 : 0.3'
]);