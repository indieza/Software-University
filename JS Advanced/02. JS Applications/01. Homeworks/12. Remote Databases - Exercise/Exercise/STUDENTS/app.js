import {
    get
} from "./requester.js";

const html = {
    tableBody: () => document.getElementById("students")
};

async function solve() {
    const data = await get("appdata", "students");

    data.sort((a, b) => a.id - b.id)
        .forEach(s => {
            const tr = document.createElement("tr");
            const id = document.createElement("th");
            const firstName = document.createElement("th");
            const lastName = document.createElement("th");
            const facultyNumber = document.createElement("th");
            const grade = document.createElement("th");

            tr.id = s._id;
            id.textContent = s.id;
            firstName.textContent = s.firstName;
            lastName.textContent = s.lastName;
            facultyNumber.textContent = s.facultyNumber;
            grade.textContent = s.grade.toFixed(2);

            tr.append(id, firstName, lastName, facultyNumber, grade);
            html.tableBody().append(tr);
        });
}

solve();