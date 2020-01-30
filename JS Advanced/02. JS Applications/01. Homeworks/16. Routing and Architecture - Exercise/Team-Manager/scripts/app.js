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
            setHeaderInfo(ctx);
            ctx.hasTeam = false; // TODO

            this.loadPartials(getPartials())
                .partial("../templates/home/home.hbs");
        });

        this.get("/about", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/about/about.hbs");
        });

        this.get("/login", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/login/loginPage.hbs");
        });

        this.post("/login", function (ctx) {

        });

        this.get("/register", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/register/registerPage.hbs");
        });

        this.post("/register", function (ctx) {

        });

        this.get("/logout", function (ctx) {

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
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            ctx.username = sessionStorage.getItem("username");
        }

        function saveAuthInfo(userInfo) {
            sessionStorage.setItem("username", userInfo.username);
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