function solve() {
    const links = document.querySelectorAll("a");
    const visits = document.querySelectorAll("p");

    for (let i = 0; i < links.length; i++) {
        updateVisitors(links[i], visits[i]);
    }

    function updateVisitors(link, visit) {
        link.addEventListener("click", function (e) {
            e.preventDefault();

            let count = parseInt(visit.innerHTML.replace(/^\D+/g, ''));
            visit.innerHTML = `visited ${++count} times`;
        })
    }
}