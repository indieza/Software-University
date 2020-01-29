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

        this.get("/catalog", async function (ctx) {
            setHeaderInfo(ctx);
            const teams = await get("appdata", "teams", "Kinvey");
            ctx.teams = teams;

            this.loadPartials(getPartials())
                .partial("../templates/catalog/teamCatalog.hbs");
        });

        this.get("/create", function (ctx) {
            setHeaderInfo(ctx);
            this.loadPartials(getPartials())
                .partial("../templates/create/createPage.hbs");
        });

        this.post("/create", function (ctx) {
            setHeaderInfo(ctx);
            const {
                name,
                comment
            } = ctx.params;

            let members = [];
            members.push({
                "username": sessionStorage.getItem("username")
            });

            post("appdata", "teams", {
                    name,
                    comment,
                    members
                }, "Kinvey")
                .then(userInfo => {
                    sessionStorage.setItem("teamId", userInfo._acl.creator);
                    ctx.redirect("/catalog");
                })
                .catch(console.error);
        });

        this.get("/catalog/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            get("appdata", `teams/${id}`, "Kinvey")
                .then(data => {
                    ctx.members = data.members;
                    ctx.comment = data.comment;
                    ctx.name = data.name;
                    ctx.teamId = sessionStorage.getItem("teamId");
                    this.loadPartials(getPartials())
                        .partial("../templates/catalog/details.hbs");
                })
                .catch(console.error);
        });

        this.get("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);
            this.loadPartials(getPartials())
                .partial("../templates/edit/editPage.hbs");
        })
    });

    app.run();

    function setHeaderInfo(ctx) {
        ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
        ctx.username = sessionStorage.getItem("username");
        ctx.hasNoTeam = sessionStorage.getItem("teamId") === sessionStorage.getItem("userId") ? false : true;
        ctx.isAuthor = sessionStorage.getItem("teamId") === sessionStorage.getItem("userId") ? true : false;
        ctx.isOnTeam = sessionStorage.getItem("teamId") === sessionStorage.getItem("userId") ? true : false;
    }

    function saveAuthInfo(userInfo) {
        sessionStorage.setItem("username", userInfo.username);
        sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
        sessionStorage.setItem("userId", userInfo._id);
        //sessionStorage.setItem("teamId", userInfo._acl.creator);
    }

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