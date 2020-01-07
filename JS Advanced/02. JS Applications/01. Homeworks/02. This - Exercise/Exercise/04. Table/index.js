function solve() {
   const rows = Array.from(document.querySelectorAll("tbody > tr"));
   rows.map(x => x.addEventListener("click", function (e) {
      e.preventDefault();

      if (x.hasAttribute("style")) {
         x.removeAttribute("style");
      } else {
         rows.map(x => x.removeAttribute("style"));
         x.style.backgroundColor = "#413f5e";
      }
   }));
}