import {
    get,
    post,
    put,
    del
} from "../scripts/requester.js";

(() => {
    const categories = {
        "Grain Food": "https://cdn.pixabay.com/photo/2014/12/11/02/55/corn-syrup-563796__340.jpg",
        "Fruits": "https://cdn.pixabay.com/photo/2017/06/02/18/24/fruit-2367029__340.jpg",
        "Milk, cheese, eggs and alternatives": "https://image.shutterstock.com/image-photo/assorted-dairy-products-milk-yogurt-260nw-530162824.jpg",
        "Lean meats and poultry, fish and alternatives": "https://t3.ftcdn.net/jpg/01/18/84/52/240_F_118845283_n9uWnb81tg8cG7Rf9y3McWT1DT1ZKTDx.jpg",
        "Vegetables and legumes/beans": "https://t3.ftcdn.net/jpg/00/25/90/48/240_F_25904887_fhZJ692ukng3vQxzHldvuN981OiYVlJ1.jpg"
    };

    const app = new Sammy("#rooter", function () {
        this.use("Handlebars", "hbs");

        this.get("/index.html", async function (ctx) {
            setHeaderInfo(ctx);

            if (ctx.isLogged) {
                await get("appdata", "recipes", "Kinvey")
                    .then(recipes => {
                        ctx.recipes = recipes;
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
                firstName,
                lastName,
                username,
                password,
                repeatPassword
            } = ctx.params;

            if (firstName && lastName && username && password && password === repeatPassword) {
                post("user", "", {
                        firstName,
                        lastName,
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

        this.get("/share", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/recipe/share.hbs");
        });

        this.post("/share", function (ctx) {
            const {
                meal,
                ingredients,
                prepMethod,
                description,
                foodImageURL,
                category
            } = ctx.params;

            if (meal && ingredients && prepMethod && description && foodImageURL && category) {
                post("appdata", "recipes", {
                        meal,
                        ingredients: ingredients.split(" "),
                        prepMethod,
                        description,
                        foodImageURL,
                        category,
                        likesCounter: 0,
                        categoryImageURL: categories[category]
                    })
                    .then(() => {
                        ctx.redirect("/index.html");
                    })
                    .catch(console.error);
            }
        });

        this.get("/recipe/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            get("appdata", `recipes/${id}`, "Kinvey")
                .then(recipe => {
                    recipe.isCreator = sessionStorage.getItem("userId") === recipe._acl.creator;

                    ctx.recipe = recipe;
                    this.loadPartials(getPartials())
                        .partial("../templates/recipe/recipeDetails.hbs");
                })
                .catch(console.error);
        });

        this.get("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            get("appdata", `recipes/${id}`, "Kinvey")
                .then(recipe => {
                    recipe.ingredients = recipe.ingredients.join(" ");
                    ctx.recipe = recipe;

                    this.loadPartials(getPartials())
                        .partial("../templates/recipe/recipeEdit.hbs");
                })
                .catch(console.error);
        });

        this.post("/edit/:id", function (ctx) {
            const id = ctx.params.id;
            const {
                meal,
                ingredients,
                prepMethod,
                description,
                foodImageURL,
                category,
                likesCounter
            } = ctx.params;

            put("appdata", `recipes/${id}`, {
                    meal,
                    ingredients: ingredients.split(" "),
                    prepMethod,
                    description,
                    foodImageURL,
                    category,
                    likesCounter,
                    categoryImageURL: categories[category]
                })
                .then(() => {
                    ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/archive/:id", function (ctx) {
            setHeaderInfo(ctx);
            const id = ctx.params.id;

            del("appdata", `recipes/${id}`, "Kinvey")
                .then(() => {
                    return ctx.redirect("/index.html");
                })
                .catch(console.error);
        });

        this.get("/like/:id", async function (ctx) {
            const id = ctx.params.id;
            setHeaderInfo(ctx);

            const recipe = await get("appdata", `recipes/${id}`, "Kinvey");

            put("appdata", `recipes/${id}`, {
                    meal: recipe.meal,
                    ingredients: recipe.ingredients,
                    prepMethod: recipe.prepMethod,
                    description: recipe.description,
                    foodImageURL: recipe.foodImageURL,
                    category: recipe.category,
                    likesCounter: recipe.likesCounter + 1,
                    categoryImageURL: recipe.categoryImageURL
                })
                .then(() => {
                    ctx.redirect(`/index.html`);
                })
                .catch(console.error);
        });
    });

    app.run();

    function getPartials() {
        return {
            header: "../templates/common/header.hbs",
            footer: "../templates/common/footer.hbs",
            homeAnonymous: "../templates/homeAnonymous.hbs",
            homeUser: "../templates/homeUser.hbs"
        }
    }

    function setHeaderInfo(ctx) {
        ctx.isLogged = sessionStorage.getItem("authtoken") !== null;
        ctx.names = sessionStorage.getItem("names");
    }

    function saveAuthInfo(userInfo) {
        sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
        sessionStorage.setItem("names", `${userInfo.firstName} ${userInfo.lastName}`);
        sessionStorage.setItem("userId", userInfo._id);
    }
})();