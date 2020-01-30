import {
    get,
    post,
    put,
    del
} from "../scripts/requester.js";

(() => {
    const app = new Sammy("#trekDiv", function () {
        this.use("Handlebars", "hbs");

        this.get("/index.html", async function (ctx) {
            setHeaderInfo(ctx);

            if (ctx.isLogged) {
                await get("appdata", "treks", "Kinvey")
                    .then(treks => {
                        ctx.treks = treks;

                        if (treks.length > 0) {
                            ctx.hasTreks = true;
                        }
                    })
                    .catch(console.error);

                this.loadPartials(getPartials())
                    .partial("../templates/home.hbs");
            } else {
                this.loadPartials(getPartials())
                    .partial("../templates/home.hbs");
            }
        });

        this.get("/register", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/admin/register.hbs");
        });

        this.post("/register", function (ctx) {
            const {
                username,
                password,
                rePassword
            } = ctx.params;

            if (username.length >= 3 && password.length >= 6 && rePassword === password) {
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

        this.get("/login", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/admin/login.hbs");
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

        this.get("/logout", function (ctx) {
            post("user", "_logout", {}, "Kinvey")
                .then(() => {
                    sessionStorage.clear();
                    return ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/create", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/trek/create.hbs");
        });

        this.post("/create", function (ctx) {
            const {
                location,
                dateTime,
                description,
                imageURL
            } = ctx.params;

            if (location.length >= 6 && description.length >= 10) {
                post("appdata", "treks", {
                        location,
                        dateTime,
                        description,
                        imageURL,
                        organizer: sessionStorage.getItem("username"),
                        likesCounter: 0
                    })
                    .then(() => {
                        ctx.redirect("/index.html");
                    })
                    .catch(console.error);
            }
        });

        this.get("/trek/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            get("appdata", `treks/${id}`, "Kinvey")
                .then(trek => {
                    trek.isCreator = sessionStorage.getItem("userId") === trek._acl.creator;

                    ctx.trek = trek;
                    this.loadPartials(getPartials())
                        .partial("../templates/trek/details.hbs");
                })
                .catch(console.error);
        });

        this.get("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            get("appdata", `treks/${id}`, "Kinvey")
                .then(trek => {
                    ctx.trek = trek;

                    this.loadPartials(getPartials())
                        .partial("../templates/trek/edit.hbs");
                })
                .catch(console.error);
        });

        this.post("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            const {
                location,
                dateTime,
                description,
                imageURL,
                likes,
                organizer
            } = ctx.params;

            put("appdata", `treks/${id}`, {
                    location,
                    dateTime,
                    description,
                    imageURL,
                    likesCounter: likes,
                    organizer
                })
                .then(() => {
                    ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/close/:id", function (ctx) {
            setHeaderInfo(ctx);
            const id = ctx.params.id;

            del("appdata", `treks/${id}`, "Kinvey")
                .then(() => {
                    return ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/like/:id", async function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            const trek = await get("appdata", `treks/${id}`, "Kinvey");

            put("appdata", `treks/${id}`, {
                    location: trek.location,
                    dateTime: trek.dateTime,
                    description: trek.description,
                    imageURL: trek.imageURL,
                    likesCounter: trek.likesCounter + 1,
                    organizer: trek.organizer
                })
                .then(() => {
                    ctx.redirect(`/index.html`);
                })
                .catch(console.error);
        });
    });

    app.run();

    function setHeaderInfo(ctx) {
        ctx.isLogged = sessionStorage.getItem("authtoken") !== null;
        ctx.username = sessionStorage.getItem("username");
    }

    function saveAuthInfo(userInfo) {
        sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
        sessionStorage.setItem("username", userInfo.username);
        sessionStorage.setItem("userId", userInfo._id);
    }

    function getPartials() {
        return {
            header: "../templates/common/header.hbs",
            footer: "../templates/common/footer.hbs",
            anonymousHome: "../templates/anonymousHome.hbs",
            noTreksHome: "../templates/noTreksHome.hbs"
        }
    }
})();