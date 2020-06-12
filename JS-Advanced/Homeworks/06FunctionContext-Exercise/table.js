function solve() {
   const trList = document.querySelectorAll('tbody > tr');

   [...trList].forEach(tr => {
      tr.addEventListener('click', function (e) {
         const clicked = document.querySelector('tr[style="background-color: rgb(65, 63, 94);"]');
         
         if (clicked !== null) {
            clicked.removeAttribute('style');
         }

         if (clicked === tr) {
            return;
         }

         tr.style.backgroundColor = '#413f5e';
      });
   });
}