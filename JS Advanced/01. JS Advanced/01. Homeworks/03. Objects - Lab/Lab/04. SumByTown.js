function solve(array) {
    let towns = {};

    for (let i = 0; i < array.length; i++) {
        let name = array[i++];

        if (i == array.length) {
            break;
        }

        let income = Number(array[i]);

        if (towns.hasOwnProperty(name)) {
            towns[name] += income;
        } else {
            towns[name] = income;
        }
    }

    console.log(JSON.stringify(towns));
}

solve(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);
solve(['Sofia', '20', 'Varna', '3', 'sofia', '5', 'varna', '4']);