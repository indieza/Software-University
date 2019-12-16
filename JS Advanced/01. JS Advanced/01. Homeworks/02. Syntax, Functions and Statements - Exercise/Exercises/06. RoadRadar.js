function solve(elements) {
    let speed = elements[0];
    let area = elements[1];

    switch (area) {
        case "motorway":
            if (speed <= 130) {
                break;
            } else if (speed <= 130 + 20) {
                console.log("speeding");
            } else if (speed <= 130 + 40) {
                console.log("excessive speeding");
            } else {
                console.log("reckless driving");
            }
            break;

        case "interstate":
            if (speed <= 90) {
                break;
            } else if (speed <= 90 + 20) {
                console.log("speeding");
            } else if (speed <= 90 + 40) {
                console.log("excessive speeding");
            } else {
                console.log("reckless driving");
            }
            break;

        case "city":
            if (speed <= 50) {
                break;
            } else if (speed <= 50 + 20) {
                console.log("speeding");
            } else if (speed <= 50 + 40) {
                console.log("excessive speeding");
            } else {
                console.log("reckless driving");
            }
            break;

        case "residential":
            if (speed <= 20) {
                break;
            } else if (speed <= 20 + 20) {
                console.log("speeding");
            } else if (speed <= 20 + 40) {
                console.log("excessive speeding");
            } else {
                console.log("reckless driving");
            }
            break;

        default:
            break;
    }
}

solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);