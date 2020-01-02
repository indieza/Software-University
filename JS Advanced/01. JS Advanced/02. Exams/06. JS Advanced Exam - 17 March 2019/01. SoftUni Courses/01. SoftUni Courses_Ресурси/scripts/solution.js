function solve() {
   const coursesNames = {
      "js-fundamentals": "JS-Fundamentals",
      "js-advanced": "JS-Advanced",
      "js-applications": "JS-Applications",
      "js-web": "JS-Web",
      "html": "HTML and CSS"
   };

   const coursesPrices = {
      "js-fundamentals": 170,
      "js-advanced": 180,
      "js-applications": 190,
      "js-web": 490,
      "html": 0
   };

   const courses = document.querySelectorAll("ul > li > input");
   const online = document.getElementsByName("educationForm")[1];
   const signButton = document.getElementsByTagName("button")[0];
   const myCourses = document.getElementsByClassName("courseBody")[1];
   const priceSection = document.getElementsByClassName("courseFoot")[1];

   signButton.addEventListener("click", function (e) {
      e.preventDefault();

      let totalPrice = 0;

      let checkedCourses = [...courses].filter(c => c.checked === true).map(c => c.name);

      if (checkedCourses.includes("js-fundamentals") && checkedCourses.includes("js-advanced") && checkedCourses.length <= 3) {
         for (const course of checkedCourses) {
            addCourseToList(course);
            totalPrice += course === "js-advanced" ? coursesPrices[course] * 0.90 : coursesPrices[course];
         }

         if (checkedCourses.includes("js-applications")) {
            totalPrice *= 0.94;
         }
      } else if (checkedCourses.length === 4) {
         for (const course of checkedCourses) {
            addCourseToList(course);
            totalPrice += course === "js-advanced" ? coursesPrices[course] * 0.90 : coursesPrices[course];
         }

         if (checkedCourses.includes("js-applications")) {
            totalPrice -= coursesPrices["js-web"];
            totalPrice *= 0.94;
            totalPrice += coursesPrices["js-web"];
         }

         addCourseToList("html");
      } else {
         for (const course of checkedCourses) {
            addCourseToList(course);
            totalPrice += coursesPrices[course];
         }
      }

      const discount = online.checked === true ? 6 : 0;
      priceSection.children[0].innerHTML = `Cost: ${Math.floor(totalPrice - totalPrice * discount / 100)}.00 BGN`;
   });

   function addCourseToList(course) {
      const li = document.createElement("li");
      li.innerHTML = coursesNames[course];
      myCourses.children[0].appendChild(li);
   }
}

solve();