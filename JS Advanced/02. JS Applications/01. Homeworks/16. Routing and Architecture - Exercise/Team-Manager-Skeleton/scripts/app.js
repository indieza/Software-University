import {
    get,
    post,
    put,
    del
} from "./requester.js";

(() => {
    const partials = {
        header: "./templates/common/header.hbs",
        footer: "./templates/common/footer.hbs",
        loginForm: "./templates/login/loginForm.hbs",
        registerForm: "./templates/register/registerForm.hbs",
        createForm: "./templates/create/createForm.hbs"
    };

    const app = new Sammy("#main", function () {
        this.use("Handlebars", "hbs");

        this.get("index.html", loadHome);

        this.get("#/", loadHome);

        this.get("#/home", loadHome);

        this.get("#/about", function (ctx) {
            this.loadPartials(partials).then(function () {
                this.partial("./templates/about/about.hbs");
            });
        });

        this.get("#/login", function (ctx) {
            this.loadPartials(partials).then(function () {
                this.partial("./templates/login/loginPage.hbs");
            });
        });

        this.get("#/register", function (ctx) {
            this.loadPartials(partials).then(function () {
                this.partial("./templates/register/registerPage.hbs");
            });
        });

        this.get("#/create", function (ctx) {
            this.loadPartials(partials).then(function () {
                this.partial("./templates/create/createPage.hbs");
            });
        });

        this.post("#/register", function (ctx) {
            const {
                username,
                password,
                repeatPassword
            } = ctx.params;

            const user = post("user", "", {
                username,
                password
            }, "Basic");

            console.log(user);

            ctx.redirect("#/login");
        });
    });

    app.run();

    function loadHome(ctx) {
        this.loadPartials(partials).then(function () {
            this.partial("./templates/home/home.hbs");
        });
    }

    function loadData(ctx) {
        ctx.loggedIn = true;
        ctx.username = "indieza";
    }
})();