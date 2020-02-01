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

          this.get("/create", function (ctx) {
              setHeaderInfo(ctx);

              this.loadPartials(getPartials())
                  .partial("../templates/idea/create.hbs");
          });

          this.post("/create", function (ctx) {
              const {
                  title,
                  description,
                  imageURL
              } = ctx.params;

              if (title.length >= 6 && description.length >= 10 &&
                  (imageURL.startsWith("http://") || imageURL.startsWith("https://"))) {
                  post("appdata", "ideas", {
                          title,
                          description,
                          imageURL,
                          creator: sessionStorage.getItem("username"),
                          likes: 0,
                          comments: []
                      })
                      .then(() => {
                          ctx.redirect("/index.html");
                      })
                      .catch(console.error);
              }
          });

          this.get("/delete/:id", function (ctx) {
              setHeaderInfo(ctx);
              const id = ctx.params.id;

              del("appdata", `ideas/${id}`, "Kinvey")
                  .then(() => {
                      return ctx.redirect("/index.html");
                  })
                  .catch(console.error);
          });

          this.get("/dashboard", async function (ctx) {
              setHeaderInfo(ctx);

              await get("appdata", "ideas", "Kinvey")
                  .then(ideas => {
                      ctx.ideas = ideas;
                  })
                  .catch(console.error);

              this.loadPartials(getPartials())
                  .partial("../templates/idea/dashboard.hbs");
          });

          this.get("/idea/:id", function (ctx) {
              const id = ctx.params.id;
              setHeaderInfo(ctx);

              get("appdata", `ideas/${id}`, "Kinvey")
                  .then(idea => {
                      idea.isCreator = sessionStorage.getItem("userId") === idea._acl.creator;

                      ctx.idea = idea;
                      this.loadPartials(getPartials())
                          .partial("../templates/idea/details.hbs");
                  })
                  .catch(console.error);
          });

          this.get("/like/:id", async function (ctx) {
              const id = ctx.params.id;
              setHeaderInfo(ctx);

              const idea = await get("appdata", `ideas/${id}`, "Kinvey");

              put("appdata", `ideas/${id}`, {
                      title: idea.title,
                      description: idea.description,
                      imageURL: idea.imageURL,
                      creator: idea.creator,
                      likes: idea.likes + 1,
                      comments: idea.comments
                  })
                  .then(() => {
                      ctx.redirect(`/index.html`);
                  })
                  .catch(console.error);
          });

          this.get("/comment/:id", async function (ctx) {
              const id = ctx.params.id;
              const newComment = ctx.params.newComment;
              setHeaderInfo(ctx);

              const idea = await get("appdata", `ideas/${id}`, "Kinvey");
              const comments = idea.comments;
              comments.push(`${sessionStorage.getItem("username")}: ${newComment}`);

              put("appdata", `ideas/${id}`, {
                      title: idea.title,
                      description: idea.description,
                      imageURL: idea.imageURL,
                      creator: idea.creator,
                      likes: idea.likes,
                      comments: comments
                  })
                  .then(() => {
                      ctx.redirect(`/index.html`);
                  })
                  .catch(console.error);
          });

          this.get("/profile", async function (ctx) {
              setHeaderInfo(ctx);
              const allIdeas = await get("appdata", "ideas", "Kinvey");

              const ideas = allIdeas.filter(t => t.creator === sessionStorage.getItem("username"));
              ctx.username = sessionStorage.getItem("username");
              ctx.ideasCount = ideas.length;
              ctx.ideas = ideas.map(x => x.title);


              this.loadPartials(getPartials())
                  .partial("../templates/admin/profile.hbs");
          })
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
          sessionStorage.setItem("username", userInfo.username);
          sessionStorage.setItem("userId", userInfo._id);
      }
  })();