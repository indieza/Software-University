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
            ctx.hasTeam = sessionStorage.getItem("teamId") !== null; // TODO

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

            post("user", "login", {
                    username,
                    password,
                    teamId: sessionStorage.getItem("teamId")
                }, "Basic")
                .then(userInfo => {
                    saveAuthInfo(userInfo);
                    ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/register", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/register/registerPage.hbs");
        });

        this.post("/register", function (ctx) {
            const {
                username,
                password
            } = ctx.params;

            post("user", "", {
                    username,
                    password,
                    teamId: null
                }, "Basic")
                .then(userInfo => {
                    saveAuthInfo(userInfo); // Think
                    ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/logout", function (ctx) {
            post("user", "_logout", {}, "Kinvey")
                .then(() => {
                    sessionStorage.clear();
                    return ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/catalog", async function (ctx) {
            setHeaderInfo(ctx);

            get("appdata", "teams", "Kinvey")
                .then(teams => {
                    ctx.teams = teams;

                    if (teams.length === 0) {
                        ctx.hasNoTeam = sessionStorage.getItem("userId") !== sessionStorage.getItem("creator");
                    } else {
                        teams.forEach(team => {
                            if (team.members.find(x => x.username === sessionStorage.getItem("username"))) {
                                ctx.hasNoTeam = false;
                            } else {
                                ctx.hasNoTeam = true;
                            }
                        });
                    }

                    this.loadPartials(getPartials())
                        .partial("../templates/catalog/teamCatalog.hbs");
                    // TODO
                    // recipe.isCreator = sessionStorage.getItem("userId") === recipe._acl.creator;
                })
                .catch(console.error);

            this.loadPartials(getPartials())
                .partial("../templates/catalog/teamCatalog.hbs");
        });

        this.get("/create", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/create/createPage.hbs");
        });

        this.post("/create", function (ctx) {
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
                .then(data => {
                    sessionStorage.setItem("teamId", data._id);
                    ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/catalog/:id", function (ctx) {
            setHeaderInfo(ctx);
            const id = ctx.params.id;

            get("appdata", `teams/${id}`, "Kinvey")
                .then(data => {
                    ctx.members = data.members;
                    ctx.name = data.name;
                    ctx.comment = data.comment;
                    ctx.isAuthor = data.members.find(x => x.username === sessionStorage.getItem("username"));
                    ctx.isOnTeam = data.members.find(x => x.username === sessionStorage.getItem("username"));
                    ctx.teamId = data._id;
                    sessionStorage.setItem("teamId", data._id); // Think

                    this.loadPartials(getPartials())
                        .partial("../templates/catalog/details.hbs");
                })
                .catch(console.error);
        });

        this.get("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            get("appdata", `teams/${id}`, "Kinvey")
                .then(data => {
                    ctx.name = data.name;
                    ctx.comment = data.comment;
                    ctx.members = data.members;
                    ctx.teamId = data._id;
                    this.loadPartials(getPartials())
                        .partial("../templates/edit/editPage.hbs");
                })
                .catch(console.error);
        });

        this.post("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            const {
                name,
                comment,
                members
            } = ctx.params;

            put("appdata", `teams/${id}`, {
                    name,
                    comment,
                    members
                }, "Kinvey")
                .then(() => {
                    ctx.redirect("/index.html");
                })
                .catch(console.error);
        })

        function setHeaderInfo(ctx) {
            ctx.loggedIn = sessionStorage.getItem("authtoken") !== null;
            ctx.username = sessionStorage.getItem("username");
            //ctx.teamId = sessionStorage.getItem("teamId"); // Think
        }

        function saveAuthInfo(userInfo) {
            sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
            sessionStorage.setItem("username", userInfo.username);
            sessionStorage.setItem("userId", userInfo._id);
            //sessionStorage.setItem("teamId", userInfo.teamId); // Think
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