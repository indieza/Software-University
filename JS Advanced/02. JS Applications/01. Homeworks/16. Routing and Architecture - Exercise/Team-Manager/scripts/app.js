import {
    get,
    post,
    put,
    del
} from "../scripts/requester.js";

(() => {
    const app = new Sammy("#main", function () {
        this.use("Handlebars", "hbs");

        this.get("/index.html", function (ctx) {

        });

        this.get("/about", function (ctx) {

        });

        this.get("/login", function (ctx) {

        });

        this.post("/login", function (ctx) {
            const {
                username,
                password
            } = ctx.params;

            if (username && password) {
                post("user", "login", {
                        username,
                        password
                    }, "Basic")
                    .then(userInfo => {
                        saveAuthInfo(userInfo);
                        ctx.redirect("/index.html");
                    })
                    .catch(console.error);
            }
        });

        this.get("/register", function (ctx) {

        });

        this.post("/register", function (ctx) {

        });

        this.get("/logout", function (ctx) {
            //setHeaderInfo(ctx);
            post("user", "_logout", {}, "Kinvey")
                .then(() => {
                    sessionStorage.clear();
                    return ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/catalog", async function (ctx) {

        });

        this.get("/create", function (ctx) {

        });

        this.post("/create", function (ctx) {

        });

        this.get("/catalog/:id", function (ctx) {

        });

        this.get("/edit/:id", function (ctx) {

        });

        function setHeaderInfo(ctx) {

        }

        function saveAuthInfo(userInfo) {

        }
    });

    app.run();

    function getPartials() {
        return {
            header: "../templates/common/header.hbs",
            footer: "../templates/common/footer.hbs",
            loginForm: "../templates/login/loginForm.hbs",
            registerForm: "../templates/register/registerForm.hbs",
            team: "../templates/catalog/team.hbs",
            teamMember: "../templates/catalog/teamMember.hbs",
            teamControls: "../templates/catalog/teamControls.hbs",
            createForm: "../templates/create/createForm.hbs",
            editForm: "../templates/edit/editForm.hbs"
        }
    }
})();