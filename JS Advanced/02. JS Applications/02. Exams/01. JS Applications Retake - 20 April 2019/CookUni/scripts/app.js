(() => {
    const app = new Sammy("#rooter", function () {
        this.use("Handlebars", "hbs");

        this.get("/index.html", function (ctx) {
            this.loadPartials(getPartials())
                .partial("../templates/home.hbs");
        });
    });

    function getPartials() {
        return {
            header: "../templates/common/header.hbs",
            footer: "../templates/common/footer.hbs"
        }
    }

    app.run();
})();