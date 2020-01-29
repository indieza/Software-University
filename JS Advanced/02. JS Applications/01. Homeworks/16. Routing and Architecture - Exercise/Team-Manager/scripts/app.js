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
            setHeaderInfo(ctx);
            this.loadPartials(getPartials())
                .partial("../templates/register/registerPage.hbs");
        });

        this.post("/register", function (ctx) {
            const {
                username,
                password,
                repeatPassword
            } = ctx.params;

            if (username && password && repeatPassword) {
                post("user", "", {
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

        this.get("/logout", function (ctx) {
            setHeaderInfo(ctx);
            post("user", "_logout", {}, "Kinvey")
                .then(() => {
                    sessionStorage.clear();
                    return ctx.redirect("/index.html");
                })
                .catch(console.error);
        });
    });

    app.run();

    function setHeaderInfo(ctx) {
        ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
        ctx.username = sessionStorage.getItem("username");
    }

    function saveAuthInfo(userInfo) {
        sessionStorage.setItem("username", userInfo.username);
        sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
        sessionStorage.setItem("userId", userInfo._id);
    }

    function getPartials() {
        return {
            header: "../templates/common/header.hbs",
            footer: "../templates/common/footer.hbs",
            loginForm: "../templates/login/loginForm.hbs",
            registerForm: "../templates/register/registerForm.hbs"
        }
    }
})();