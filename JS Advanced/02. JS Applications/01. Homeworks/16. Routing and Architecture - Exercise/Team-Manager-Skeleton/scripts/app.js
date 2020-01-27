 import {
     get,
     post,
     put,
     del
 } from "./requester.js";

 (() => {
     const partials = {
         header: "./templates/common/header.hbs",
         footer: "./templates/common/footer.hbs"
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
     });

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
 })();