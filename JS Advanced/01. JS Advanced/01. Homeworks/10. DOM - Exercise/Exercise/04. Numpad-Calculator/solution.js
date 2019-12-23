function solve() {
    const operators = ["+", "-", "/", "*"];
    const expressionOutput = document.getElementById("expressionOutput");
    const resultOutput = document.getElementById("resultOutput");


    Array.from(document.querySelectorAll("button"))
        .map((b) => b.addEventListener("click", function (e) {
            e.preventDefault();

            let value = e.target.value;

            if (value === "=") {
                let result = calculate();
                printResult(result);
            } else if (value === "Clear") {
                expressionOutput.innerHTML = "";
                resultOutput.innerHTML = "";
            } else {
                if (operators.includes(value)) {
                    expressionOutput.innerHTML += ` ${value} `;
                } else {
                    expressionOutput.innerHTML += value
                }
            }
        }));

    function calculate() {
        let expression = expressionOutput.innerHTML.split(" ").filter(x => x !== "");

        if (operators.includes(expression[expression.length - 1])) {
            return undefined;
        } else {
            let sum = Number(expression[0]);

            for (let i = 1; i < expression.length - 1; i++) {
                let mark = expression[i];
                let number = Number(expression[i + 1]);

                switch (mark) {
                    case "+":
                        sum += number;
                        break;
                    case "-":
                        sum -= number;
                        break;
                    case "*":
                        sum *= number;
                        break;
                    case "/":
                        sum /= number;
                        break;

                    default:
                        break;
                }
            }

            return sum;
        }
    }

    function printResult(text) {
        if (text === undefined || text === Infinity) {
            resultOutput.innerHTML = "NaN";
        } else {
            resultOutput.innerHTML = text;
        }
    }
}