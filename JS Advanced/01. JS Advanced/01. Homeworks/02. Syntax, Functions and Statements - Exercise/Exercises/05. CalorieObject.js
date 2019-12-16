function solve(array) {
    let result = [];
    let pattern = "";

    for (let i = 0; i < array.length; i++) {
        const element = array[i];
        
        if (i % 2 == 0) {
            pattern += element + ": ";
        }
        else {
            pattern += Number(element);
            result.push(pattern);
            pattern = "";
        }
    }

    console.log(`{ ${result.join(', ')} }`);
}

solve(['Yoghurt', 48, 'Rise', 138, 'Apple', 52]);
solve(['Potato', 93, 'Skyr', 63, 'Cucumber', 18, 'Milk', 42]);