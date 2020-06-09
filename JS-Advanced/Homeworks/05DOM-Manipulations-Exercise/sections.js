function create(words) {
   const divList = [];

   words.forEach(word => {
      const paragraph = document.createElement('p');
      paragraph.textContent = word;
      paragraph.style.display = 'none';
      
      const div = document.createElement('div');
      div.appendChild(paragraph);
      div.addEventListener('click', function(e) {
         const child = e.target.firstChild;
         child.style.display = 'block';
      });

      divList.push(div);
   });

   const content = document.getElementById('content');
   divList.forEach(div => content.appendChild(div));
}