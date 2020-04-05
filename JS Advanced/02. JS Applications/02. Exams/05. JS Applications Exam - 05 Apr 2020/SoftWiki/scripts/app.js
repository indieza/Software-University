import {
    get,
    post,
    put,
    del
} from "../scripts/requester.js";

(() => {
    const app = new Sammy("#root", function () {
        this.use("Handlebars", "hbs");

        this.get("/index.html", async function (ctx) {
            setHeaderInfo(ctx);

            if (ctx.isLogged) {
                await get("appdata", "articles", "Kinvey")
                    .then(articles => {
                        let result = {
                            "JavaScript": [],
                            "C#": [],
                            "Java": [],
                            "Pyton": []
                        }

                        Array.from(articles).forEach(article => {
                            result[article.category].push({
                                _id: article._id,
                                title: article.title,
                                category: article.category,
                                content: article.content,
                                creator: article.creator,
                                creatorId: article._acl["creator"]
                            });
                        });

                        Object.keys(result).forEach(element => {
                            result[element].sort((a, b) =>
                                b.title.localeCompare(a.title)
                            );
                        });
                        ctx.articles = result;
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
                email,
                password,
                repeatPassword
            } = ctx.params;

            if (username && email && password && password === repeatPassword) {
                post("user", "", {
                        username,
                        email,
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
                .partial("../templates/article/create.hbs");
        });

        this.post("/create", function (ctx) {
            const {
                title,
                category,
                content
            } = ctx.params;

            if (title && content && category) {
                post("appdata", "articles", {
                        title,
                        category,
                        content,
                        creator: sessionStorage.getItem("email")
                    })
                    .then(() => {
                        ctx.redirect("/index.html");
                    })
                    .catch(console.error);
            }
        });

        this.get("/details/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            get("appdata", `articles/${id}`, "Kinvey")
                .then(article => {
                    article.isCreator = sessionStorage.getItem("userId") === article._acl.creator;

                    ctx.article = article;
                    this.loadPartials(getPartials())
                        .partial("../templates/article/details.hbs");
                })
                .catch(console.error);
        });

        this.get("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            get("appdata", `articles/${id}`, "Kinvey")
                .then(article => {
                    ctx.article = article;

                    this.loadPartials(getPartials())
                        .partial("../templates/article/edit.hbs");
                })
                .catch(console.error);
        });

        this.post("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            const {
                title,
                category,
                content
            } = ctx.params;

            put("appdata", `articles/${id}`, {
                    title,
                    category,
                    content,
                    creator: sessionStorage.getItem("email")
                })
                .then(() => {
                    ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/delete/:id", function (ctx) {
            setHeaderInfo(ctx);
            const id = ctx.params.id;

            del("appdata", `articles/${id}`, "Kinvey")
                .then(() => {
                    return ctx.redirect("/index.html");
                })
                .catch(console.error);
        });
    });

    app.run();

    function getPartials() {
        return {
            header: "../templates/common/header.hbs",
            footer: "../templates/common/footer.hbs"
        }
    }

    function setHeaderInfo(ctx) {
        ctx.isLogged = sessionStorage.getItem("authtoken") !== null;
        ctx.email = sessionStorage.getItem("email");
    }

    function saveAuthInfo(userInfo) {
        sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
        sessionStorage.setItem("userId", userInfo._id);
        sessionStorage.setItem("email", userInfo.email);
    }
})();