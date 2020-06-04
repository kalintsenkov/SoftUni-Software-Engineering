function solve() {
    const links = document.querySelectorAll('.link-1');
  
    Array.from(links).forEach(link => {
      const anchor = link.querySelector('a');
      const paragraph = link.querySelector('p');
  
      anchor.addEventListener('click', listener);
  
      function listener() {
        const pattern = /\d+/;

        let visited = Number(paragraph.innerText.match(pattern)[0]);
        visited++;
        
        paragraph.innerText = paragraph.innerText.replace(pattern, visited);
      }
    });
  }