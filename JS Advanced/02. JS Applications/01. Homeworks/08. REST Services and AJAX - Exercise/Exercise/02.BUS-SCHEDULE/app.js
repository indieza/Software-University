function solve() {
    const departButton = document.getElementById("depart");
    const arriveButton = document.getElementById("arrive");
    const info = document.getElementsByClassName("info")[0];

    let currentId = "depot";

    function depart() {
        const url = `https://judgetests.firebaseio.com/schedule/${currentId}.json`;

        fetch(url)
            .then(resources => resources.json())
            .then(data => {
                info.textContent = `Next stop ${data.name}`;
            })
            .catch(RaiseError());

        departButton.disabled = true;
        arriveButton.disabled = false;
    }

    function arrive() {
        const url = `https://judgetests.firebaseio.com/schedule/${currentId}.json`;

        fetch(url)
            .then(resources => resources.json())
            .then(data => {
                info.textContent = `Arriving at ${data.name}`;
                currentId = data.next;
            })
            .catch(RaiseError());

        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };

    function RaiseError() {
        return () => {
            info.textContent = "Error";
            departButton.disabled = true;
            arriveButton.disabled = true;
        };
    }
}

let result = solve();