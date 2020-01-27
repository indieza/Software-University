// To create Catalog Collection go to Kinvey, use that URL:
// Use POST API!!!
//https://baas.kinvey.com/appdata/{app_id}/{collection_name}
// Take token from Chrome Console - sessionStorage.getItem("authtoken")

// Choose Headers -> then fill:
// KEY - Authorization, VALUE-Kinvey authtoken
// KEY - Content-Type, VALUE-application/json

// Go to body section:
// Choose raw data - JSON TEXT
// Fill the data!!!

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
        team: "./templates/catalog/team.hbs"
    };

    const app = new Sammy("#main", function () {
        this.use("Handlebars", "hbs");

        this.get("index.html", function (context) {
            loadPage(context, "./templates/home/home.hbs");
        });

        this.get("#/", function (context) {
            loadPage(context, "./templates/home/home.hbs");
        });

        this.get("#/home", function (context) {
            loadPage(context, "./templates/home/home.hbs");
        });

        this.get("#/about", function (context) {
            loadPage(context, "./templates/about/about.hbs");
        });

        this.get("#/create", function (context) {
            loadPage(context, "./templates/create/createPage.hbs");
        });

        this.get("#/login", function (context) {
            loadPage(context, "./templates/login/loginPage.hbs");
        });

        this.post("#/login", function (context) {
            const {
                username,
                password
            } = context.params;
            post("user", "login", {
                    username,
                    password
                }, "Basic")
                .then(resources => saveUserInfo(resources))
                .then(() => context.redirect("#/home"))
                .catch(console.error);
        })

        this.get("#/logout", function (context) {
            sessionStorage.clear();
            context.redirect("#/home");
        });

        this.get("#/register", function (context) {
            loadPage(context, "./templates/register/registerPage.hbs");
        });

        this.post("#/register", function (context) {
            const {
                username,
                password,
                repeatPassword
            } = context.params;
            if (username.length >= 3 && password.length >= 3 && password === repeatPassword) {
                post("user", "", {
                        username,
                        password
                    }, "Basic")
                    .then(resources => saveUserInfo(resources))
                    .then(() => context.redirect("#/home"))
                    .catch(console.error);
            }
        });

        this.get("#/catalog", function (context) {
            get("appdata", "teams", "Kinvey")
                .then(data => {
                    context.teams = data;
                    loadPage(context, "./templates/catalog/teamCatalog.hbs");
                    console.log(data);
                })
                .catch(console.error);
        });
    });

    app.run();

    function getUserInfo(context) {
        context.loggedIn = sessionStorage.getItem("authtoken");
        context.username = sessionStorage.getItem("username");
    }

    function loadPage(context, path) {
        getUserInfo(context);

        context.loadPartials(partials)
            .then(function () {
                this.partial(path);
            });
    }

    function saveUserInfo(resources) {
        if (resources.username && resources._kmd.authtoken) {
            sessionStorage.setItem('username', resources['username']);
            sessionStorage.setItem('authtoken', resources._kmd['authtoken']);
        }
    }
})();