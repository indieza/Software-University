function showData(button, info) {
    if (button.innerText === "Show status code") {
        button.innerText = "Hide status code";
        info.style.display = "block";
    } else {
        button.innerText = "Show status code";
        info.style.display = "none";
    }
}

(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        await fetch("http://127.0.0.1:5500/01.%20Homeworks/14.%20Templating%20-%20Exercise/Exercise/02.%20HTTP%20Status%20Cats/catTemplate.hbs")
            .then(resources => resources.text())
            .then(data => {
                const cats = window.cats;
                const template = Handlebars.compile(data);
                document.getElementById("allCats").innerHTML = template({
                    cats
                });
            })
    }

})();