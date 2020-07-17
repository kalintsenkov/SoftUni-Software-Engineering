const loadBtn = document.querySelector('#loadBtn');
const submitBtn = document.querySelector('#submitBtn');
const tbodyResults = document.querySelector('#results > tbody');
const firstNameInput = document.querySelector('#firstName');
const lastNameInput = document.querySelector('#lastName');
const facultyNumberInput = document.querySelector('#facultyNumber');
const gradeInput = document.querySelector('#grade');

const api = {
    students: 'https://api.backendless.com/3EF35E83-C6D2-9A77-FF84-B3914ED62F00/5991DFF1-2FDD-44CF-99F4-DB2D7E38B868/data/students'
};

window.addEventListener('load', () => {
    loadBtn.addEventListener('click', getAllStudents);
    submitBtn.addEventListener('click', addStudent);

    async function getStudentsCount() {
        const response = await fetch(api.students);
        const students = await response.json();

        return [...students].length;
    }

    async function getAllStudents() {
        tbodyResults.innerHTML = '';

        const response = await fetch(api.students);
        const students = await response.json();

        const sortedStudents = [...students].sort((a, b) => a.ID - b.ID);

        sortedStudents.forEach(student => {
            const tr = document.createElement('tr');
            const idTd = document.createElement('td');
            const firstNameTd = document.createElement('td');
            const lastNameTd = document.createElement('td');
            const facultyNumberTd = document.createElement('td');;
            const gradeTd = document.createElement('td');

            idTd.innerHTML = student.ID;
            firstNameTd.innerHTML = student.FirstName;
            lastNameTd.innerHTML = student.LastName;
            facultyNumberTd.innerHTML = student.FacultyNumber;
            gradeTd.innerHTML = Number(student.Grade).toFixed(2);

            tr.appendChild(idTd);
            tr.appendChild(firstNameTd);
            tr.appendChild(lastNameTd);
            tr.appendChild(facultyNumberTd);
            tr.appendChild(gradeTd);

            tbodyResults.appendChild(tr);
        });
    }

    async function addStudent(e) {
        e.preventDefault();

        const count = await getStudentsCount();
        const id = count + 1;

        const studentObj = {
            ID: id,
            FirstName: firstNameInput.value,
            lastName: lastNameInput.value,
            FacultyNumber: facultyNumberInput.value,
            Grade: Number(gradeInput.value)
        };

        firstNameInput.value = '';
        lastNameInput.value = '';
        facultyNumberInput.value = '';
        gradeInput.value = '';

        const requestObj = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(studentObj)
        };

        await fetch(api.students, requestObj);
        await getAllStudents();
    }
});
