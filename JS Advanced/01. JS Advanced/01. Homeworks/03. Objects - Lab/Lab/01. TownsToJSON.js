function solve(table) {
    let headerItems = table[0].split("|").map(item => item.trim()).filter(i => i != "");

    let town = headerItems[0];
    let latitude = headerItems[1];
    let longitude = headerItems[2];

    let result = new Array();

    for (let i = 1; i < table.length; i++) {
        let lineElements = table[i].split("|").map(item => item.trim()).filter(i => i != "");

        let townName = lineElements[0];
        let latitudeValue = Number(lineElements[1]) == 0 ? 0 : Number(lineElements[1]).toFixed(2);
        let longitudeValue = Number(lineElements[2]) == 0 ? 0 : Number(lineElements[2]).toFixed(2);

        result.push(`{\"${town}\":\"${townName}\",\"${latitude}\":${latitudeValue},\"${longitude}\":${longitudeValue}}`);
    }

    console.log(`[${result.join(",")}]`);
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'
]);

solve(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |'
]);