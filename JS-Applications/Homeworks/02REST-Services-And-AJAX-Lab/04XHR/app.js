const resDiv = document.getElementById('res');

function loadRepos() {
   const url = 'https://api.github.com/users/testnakov/repos';
   const httpRequest = new XMLHttpRequest();

   httpRequest.addEventListener('readystatechange', () => {
      if (httpRequest.readyState === 4 && httpRequest.status === 200) {
         resDiv.innerHTML = httpRequest.responseText;
      }
   });

   httpRequest.open('GET', url);
   httpRequest.send();
}