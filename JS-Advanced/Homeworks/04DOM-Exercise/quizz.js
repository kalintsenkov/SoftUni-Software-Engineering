function solve() {
  const answers = Array.from(document.querySelectorAll('.answer-wrap'));

  const rightAnswers = {
    'onclick': true,
    'JSON.stringify()': true,
    'A programming API for HTML and XML documents': true
  };

  let rightAnswersCount = 0;

  for (let i = 0; i < answers.length; i++) {
    const answer = answers[i];
    
    answer.addEventListener('click', function (e) {
      const buttonText = e.target.textContent.trim();

      if (rightAnswers[buttonText]) {
        rightAnswersCount++;
      }

      const sectionClass = answer.parentElement.parentElement.parentElement;
      sectionClass.style.display = 'none';

      const nextSection = document.querySelector('.hidden');

      if (nextSection === null) {
        const resultsUl = document.querySelector('#results');
        resultsUl.style.display = 'block';

        const resultLi = resultsUl.querySelector('.results-inner');
        const h1 = resultLi.querySelector('h1');

        if (rightAnswersCount === 3) {
          h1.innerText = 'You are recognized as top JavaScript fan!';
        } else {
          h1.innerText = `You have ${rightAnswersCount} right answers`;
        }

      } else {
        nextSection.classList.toggle('hidden');
        nextSection.style.display = 'block';
      }
    });
  }
}