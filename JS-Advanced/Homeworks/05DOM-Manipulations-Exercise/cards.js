function solve() {
   const cardsSection = document.querySelector('section.cards');

   const results = document.querySelectorAll('#result span');
   const firstPlayerSpan = results[0];
   const secondPlayerSpan = results[2];

   const history = document.querySelector('#history');

   cardsSection.addEventListener('click', function (e) {
      if (e.target.tagName === 'IMG') {
         if (e.target.parentNode.id === 'player1Div') {
            e.target.src = "images/whiteCard.jpg";
            firstPlayerSpan.textContent = e.target.name;
         } else if (e.target.parentNode.id === 'player2Div') {
            e.target.src = "images/whiteCard.jpg";
            secondPlayerSpan.textContent = e.target.name;
         }
      }

      const firstPlayerCardValue = firstPlayerSpan.textContent;
      const secondPlayerCardValue = secondPlayerSpan.textContent;

      const firstPlayerCard = document.querySelector(`#player1Div img[name="${firstPlayerCardValue}"]`);
      const secondPlayerCard = document.querySelector(`#player2Div img[name="${secondPlayerCardValue}"]`);

      if (firstPlayerCard !== null && secondPlayerCard !== null) {
         if (Number(firstPlayerCardValue) > Number(secondPlayerCardValue)) {
            firstPlayerCard.style.border = '2px solid green';
            secondPlayerCard.style.border = '2px solid red';
         } else {
            firstPlayerCard.style.border = '2px solid red';
            secondPlayerCard.style.border = '2px solid green';
         }

         firstPlayerSpan.textContent = '';
         secondPlayerSpan.textContent = '';
         history.textContent += `[${firstPlayerCardValue} vs ${secondPlayerCardValue}] `;
      }
   });
}