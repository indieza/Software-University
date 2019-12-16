function solve(elements) {
    let number = elements[0];

    for (let i = 1; i < elements.length; i++) {
        const element = elements[i];

        switch (element) {
            case "chop":
                number /= 2;
                console.log(number);
                break;

            case "dice":
                number = Math.sqrt(number);
                console.log(number);
                break;

            case "spice":
                number += 1;
                console.log(number);
                break;

            case "bake":
                number *= 3;
                console.log(number);
                break;

            case "fillet":
                number -= number * 0.20;
                console.log(number);
                break;
            default:
                break;
        }
    }
}

solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);