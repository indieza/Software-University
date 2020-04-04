import {
    get,
    post,
    put,
    del
} from "../scripts/requester.js";

(() => {
    const app = new Sammy("#root", function (ctx) {
        this.use("Handlebars", "hbs");

        this.get("/index.html", async function (ctx) {
            setHeaderInfo(ctx);
            this.loadPartials(getPartials())
                .partial("../templates/home.hbs");
        });

        this.get("/register", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/admin/register.hbs");
        });

        this.get("/login", function (ctx) {
            setHeaderInfo(ctx);

            this.loadPartials(getPartials())
                .partial("../templates/admin/login.hbs");
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
        ctx.username = sessionStorage.getItem("username");
    }

    function saveAuthInfo(userInfo) {
        sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
        sessionStorage.setItem("username", `${userInfo.username}`);
        sessionStorage.setItem("userId", userInfo._id);
    }
})();