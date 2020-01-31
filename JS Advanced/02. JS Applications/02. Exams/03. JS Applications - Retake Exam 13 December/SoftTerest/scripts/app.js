  import {
      get,
      post,
      put,
      del
  } from "../scripts/requester.js";

  (() => {
      const app = new Sammy("#ideas", function () {
          this.use("Handlebars", "hbs");

          this.get("/index.html", function (ctx) {
              setHeaderInfo(ctx);

              this.loadPartials(getPartials())
                  .partial("../templates/home.hbs");
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
                  repeatPassword
              } = ctx.params;

              if (username.length >= 3 && password.length >= 3 && password === repeatPassword) {
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

      });

      app.run();

      function getPartials() {
          return {
              header: "../templates/common/header.hbs",
              footer: "../templates/common/footer.hbs",
              guestHome: "../templates/guestHome.hbs"
          }
      }

      function setHeaderInfo(ctx) {
          ctx.isLogged = sessionStorage.getItem("authtoken") !== null;
          ctx.username = sessionStorage.getItem("username");
      }

      function saveAuthInfo(userInfo) {
          sessionStorage.setItem("authtoken", userInfo._kmd.authtoken);
          sessionStorage.setItem("username", userInfo.username);
          sessionStorage.setItem("userId", userInfo._id);
      }
  })();