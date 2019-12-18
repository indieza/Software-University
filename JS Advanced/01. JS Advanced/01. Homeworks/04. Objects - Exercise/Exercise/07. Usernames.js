function solve(input) {
    let names = new Set();

    for (const line of input) {
        let items = line.split(",");

        items.forEach(element => {
            names.add(element)
        });
    }

    console.log([...names]
        .sort((a, b) => a.length - b.length || a.localeCompare(b))
        .join("\n"));
}

solve(['Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston'
]);

solve(['Denise',
    'Ignatius',
    'Iris',
    'Isacc',
    'Indie',
    'Dean',
    'Donatello',
    'Enfuego',
    'Benjamin',
    'Biser',
    'Bounty',
    'Renard',
    'Rot'
]);