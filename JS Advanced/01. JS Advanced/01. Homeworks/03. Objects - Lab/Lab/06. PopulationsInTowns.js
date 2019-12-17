function solve(array) {
    let towns = {};

    for (const line of array) {
        let items = line.split(" <-> ");

        if (!towns.hasOwnProperty(items[0])) {
            towns[items[0]] = 0;
        }

        towns[items[0]] += Number(items[1]);
    }

    for (const key in towns) {
        if (towns.hasOwnProperty(key)) {
            const element = towns[key];
            console.log(`${key} : ${element}`);
        }
    }
}

solve(['Sofia <-> 1200000', 'Montana <-> 20000', 'New York <-> 10000000', 'Washington <-> 2345000', 'Las Vegas <-> 1000000']);
solve(['Istanbul <-> 100000', 'Honk Kong <-> 2100004', 'Jerusalem <-> 2352344', 'Mexico City <-> 23401925', 'Istanbul <-> 1000']);