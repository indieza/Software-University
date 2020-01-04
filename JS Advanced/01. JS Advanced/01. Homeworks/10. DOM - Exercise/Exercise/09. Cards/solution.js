function solve() {
   const playerOne = document.getElementById('player1Div');
   const playerTwo = document.getElementById('player2Div');
   const result = document.getElementById('result').children;
   const history = document.getElementById('history');

   let playerOneCard = '';
   let playerTwoCard = '';

   [playerOne, playerTwo].map(player => player.addEventListener('click', function (c) {
      if (c.target.name === undefined) {
         return '';
      }

      player === playerOne ?
         playerOneCard = showCard(playerOneCard, result[0], c) :
         playerTwoCard = showCard(playerTwoCard, result[2], c);

      if (result[0].textContent !== '' && result[2].textContent !== '') {
         Number(playerOneCard.name) > Number(playerTwoCard.name) ?
            createBorder(playerOneCard, playerTwoCard) :
            createBorder(playerTwoCard, playerOneCard);

         saveHistory();
         defaultValues();
      }
   }));

   function createBorder(card1, card2) {
      card1.style.border = "2px solid green";
      card2.style.border = "2px solid red";
   }

   function showCard(player, span, c) {
      c.target.src = "images/whiteCard.jpg";
      span.textContent = c.target.name;
      player = c.target;
      return player;
   }

   function defaultValues() {
      result[0].textContent = '';
      result[2].textContent = '';
      playerOneCard = '';
      playerTwoCard = '';
   }

   function saveHistory() {
      history.textContent += `[${playerOneCard.name} vs ${playerTwoCard.name}] `;
   }
}