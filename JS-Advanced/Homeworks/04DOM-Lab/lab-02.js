function solve() {
    const output = document.getElementById('output');
    const text = document.getElementById('input').innerText;
  
    const sentences = text.split(/(?<!\w\.\w.)(?<![A-Z][a-z]\.)(?<=\.|\?)/)
      .map(s => s.trimStart());
  
    let counter = 0;
    let paragraph = document.createElement('p');
  
    for (let i = 0; i < sentences.length; i++) {
  
      paragraph.innerText += sentences[i] + ' ';
      
      counter++;
  
      if (counter === 3 || i === sentences.length - 1) {
        output.appendChild(paragraph);
        paragraph = document.createElement('p');
        counter = 0;
      }
    }
  }