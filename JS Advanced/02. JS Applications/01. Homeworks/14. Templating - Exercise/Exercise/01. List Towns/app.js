async function loadTowns() {
    const towns = document.getElementById("towns").value.split(", ");

    await fetch("http://127.0.0.1:5500/01.%20Homeworks/14.%20Templating%20-%20Exercise/Exercise/01.%20List%20Towns/townTemplate.hbs")
        .then(resources => resources.text())
        .then(data => {
            const template = Handlebars.compile(data);
            document.getElementById("root").innerHTML = template({
                towns
            });
        })
}