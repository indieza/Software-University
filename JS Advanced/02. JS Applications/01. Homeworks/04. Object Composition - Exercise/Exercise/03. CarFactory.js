function solve(input) {
    let obj = {
        model: setModel(input),
        engine: setEngine(input),
        carriage: setCarriage(input),
        wheels: setWheels(input)
    }

    function setModel({
        model
    }) {
        return model;
    }

    function setEngine({
        power
    }) {
        const engines = [{
                power: 90,
                volume: 1800
            },
            {
                power: 120,
                volume: 2400
            },
            {
                power: 200,
                volume: 3500
            }
        ]
        return engines.find(e => power <= e.power)
    }

    function setCarriage({
        carriage,
        color
    }) {
        return {
            type: carriage,
            color
        };
    }

    function setWheels({
        wheelsize
    }) {
        let arr = new Array(4)
        wheelsize % 2 === 0 ?
            arr.fill(wheelsize - 1, 0, 4) :
            arr.fill(wheelsize, 0, 4)
        return arr;
    }
    return obj;
}