function getInfo() {
    const stopId = document.getElementById("stopId").value;
    const stopName = document.getElementById("stopName");
    const busesData = document.getElementById("buses");

    document.getElementById("stopName").textContent = "";
    document.getElementById("buses").innerHTML = "";

    const url = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;

    fetch(url)
        .then(resources => resources.json())
        .then((data) => {
            stopName.textContent = data.name;

            Object.entries(data.buses)
                .forEach(([busId, time]) => {
                    const li = document.createElement("li");
                    li.textContent = `Bus ${busId} arrives in ${time}`;
                    busesData.appendChild(li);
                })
        })
        .catch(() => stopName.textContent = "Error");
}