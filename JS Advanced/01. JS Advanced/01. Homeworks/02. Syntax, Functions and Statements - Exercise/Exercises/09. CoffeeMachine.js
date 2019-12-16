function solve(orders) {
    let totalIncome = 0;

    for (let i = 0; i < orders.length; i++) {
        const line = orders[i];

        let elements = line.split(", ");
        let coins = elements[0];
        let drinkType = elements[1];
        let drinkPrice = 0;

        if (drinkType == "coffee") {
            let coffeeType = elements[2];

            if (coffeeType == "caffeine") {
                let milkOrSugar = elements[3];
                drinkPrice += 0.80;

                if (milkOrSugar == "milk") {
                    drinkPrice += Math.round(0.80 * 0.10 * 10) / 10;
                    let sugar = elements[4] == 0 ? 0 : 0.10;
                    drinkPrice += sugar;
                } else {
                    let sugar = milkOrSugar == 0 ? 0 : 0.10;
                    drinkPrice += sugar;
                }
            } else {
                let milkOrSugar = elements[3];
                drinkPrice += 0.90;

                if (milkOrSugar == "milk") {
                    drinkPrice += Math.round(0.90 * 0.10 * 10) / 10;
                    let sugar = elements[4] == 0 ? 0 : 0.10;
                    drinkPrice += sugar;
                } else {
                    let sugar = milkOrSugar == 0 ? 0 : 0.10;
                    drinkPrice += sugar;
                }
            }
        } else {
            let milkOrSugar = elements[2];
            drinkPrice += 0.80;

            if (milkOrSugar == "milk") {
                drinkPrice += Math.round(0.80 * 0.10 * 10) / 10;
                let sugar = elements[3] == 0 ? 0 : 0.10;
                drinkPrice += sugar;
            } else {
                let sugar = elements[3] == 0 ? 0 : 0.10;
                drinkPrice += sugar;
            }
        }

        if (drinkPrice > coins) {
            console.log(`Not enough money for ${drinkType}. Need $${(drinkPrice - coins).toFixed(2)} more.`);
        } else {
            console.log(`You ordered ${drinkType}. Price: $${drinkPrice.toFixed(2)} Change: $${(coins - drinkPrice).toFixed(2)}`);
            totalIncome += drinkPrice;
        }
    }

    console.log(`Income Report: $${totalIncome.toFixed(2)}`);
}

solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);
solve(['8.00, coffee, decaf, 4', '1.00, tea, 2']);