function growingWord() {

    const divExercise = document.querySelector('#exercise');
    const paragraph = divExercise.querySelector('p');
  
    const color = paragraph.style.color;
    const size = paragraph.style.fontSize;
    const sizeAsNumber = Number(size.replace(/[^0-9]/g, ''));
  
    if (color === 'blue') {
      paragraph.style.color = 'green';
    } else if (color === 'green') {
      paragraph.style.color = 'red';
    } else if (color === 'red') {
      paragraph.style.color = 'blue';
    } else {
      paragraph.style.color = 'blue';
    }
  
    sizeAsNumber === 0 ? paragraph.style.fontSize = '2px' : paragraph.style.fontSize = sizeAsNumber * 2 + 'px';
  }