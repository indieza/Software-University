function solve() {
    document.querySelector("#exercise > button:nth-child(3)").addEventListener("click", generate);
    document.querySelector("#exercise > button:nth-child(6)").addEventListener("click", buy);
    let tableBody = document.querySelector("#exercise > div > div > div > div > table > tbody");

    function generate() {
        let inputJson = document.querySelector("#exercise > textarea").value;
        let parsedInput = JSON.parse(inputJson);

        for (const obj of parsedInput) {
            let tr = document.createElement("tr");
            let td1 = document.createElement("td");
            let img = document.createElement("img");
            img.src = obj.img;

            let td2 = document.createElement("td");
            td2.textContent = obj.name;

            let td3 = document.createElement("td");
            td3.textContent = obj.price;

            let td4 = document.createElement("td");
            td4.textContent = obj.decFactor;

            let td5 = document.createElement("td");
            let input = document.createElement("input");
            input.type = "checkbox";
            td5.appendChild(input);

            td1.appendChild(img);
            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);
            tr.appendChild(td4);
            tr.appendChild(td5);

            tableBody.appendChild(tr);
        }
    }

    function buy() {

        let allInputs = document.getElementsByTagName("input");
        let output = document.querySelector("#exercise > textarea:nth-child(5)");

        let bought = [];
        for (let i = 1; i < allInputs.length; i++) {
            if (allInputs[i].checked === true) {
                bought.push(tableBody.children[i]);
            }
        }

        let names = [];
        let totalPrice = 0;
        let decFactors = [];

        for (const item of bought) {
            names.push(item.children[1].textContent);
            totalPrice += Number(item.children[2].textContent);
            decFactors.push(Number(item.children[3].textContent));
        }

        output.value += `Bought furniture: ${names.join(", ")}\n`
        output.value += `Total price: ${totalPrice.toFixed(2)}\n`
        output.value += `Average decoration factor: ${calculateAvg(decFactors)}`;
    }

    function calculateAvg(arr) {
        var sum = 0;
        for (var i = 0; i < arr.length; i++) {
            sum += arr[i];
        }

        var avg = sum / arr.length;
        return avg;
    }
}