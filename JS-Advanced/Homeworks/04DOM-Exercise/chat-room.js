function solve() {
   const sendButton = document.getElementById('send');

   sendButton.addEventListener('click', function() {
      const inputValue = document.getElementById('chat_input').value;
      
      const myMessageDiv = document.createElement('div');
      
      myMessageDiv.setAttribute('class', 'message my-message');
      myMessageDiv.innerText = inputValue;

      const chatMessages = document.getElementById('chat_messages');

      chatMessages.appendChild(myMessageDiv);

      document.getElementById('chat_input').value = '';
   });
}