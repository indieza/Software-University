function solve(data) {
    let obj = {};

    for (const currentObject of JSON.parse(data)) {
        for (const key of Object.keys(currentObject)) {
            if (!Object.keys(obj).includes(key)) {
                obj[key] = currentObject[key];
            }
        }
    }

    return obj;
}

console.log(solve(`[{"canMove": true},{"canMove":true, "doors": 4},{"capacity": 5}]`));
console.log(solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`));
console.log(solve(`[{"prop1": 1},{"prop2":2},{"prop3":3}]`));