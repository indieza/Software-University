(() => {
    const app = new Sammy("#rooter", function () {
        this.use("Handlebars", "hbs");

        this.get("/index.html", function (ctx) {
            this.loadPartials(getPartials())
                .partial("../templates/home.hbs");
        });

        this.get("/register", function (ctx) {
            this.loadPartials(getPartials())
                .partial("../templates/admin/register.hbs");
        });

        this.post("/register", function (ctx) {

        });

        this.get("/login", function (ctx) {
            this.loadPartials(getPartials())
                .partial("../templates/admin/login.hbs");
        });

        this.post("/login", function (ctx) {

        });

        this.get("/logout", function (ctx) {

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