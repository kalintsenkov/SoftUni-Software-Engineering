function solve() {
   const searchInput = document.querySelector('#searchField');
   const searchBtn = document.querySelector('button#searchBtn');
   const tableRows = document.querySelectorAll('tbody tr');

   searchBtn.addEventListener('click', function () {

      Array.from(tableRows).forEach(row => row.classList.remove('select'));

      Array.from(tableRows).forEach(row => {
         const cols = row.querySelectorAll('td');

         const name = cols[0].innerText;
         const email = cols[1].innerText;
         const course = cols[2].innerText;

         if (name.includes(searchInput.value) ||
            email.includes(searchInput.value) ||
            course.includes(searchInput.value)) {
            row.classList.add('select');
         }

      });

      searchInput.value = '';
   });
}