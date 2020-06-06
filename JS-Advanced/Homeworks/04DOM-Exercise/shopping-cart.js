function solve() {
   const textArea = document.querySelector('textarea');
   const buttons = Array.from(document.querySelectorAll('button.add-product'));

   let total = 0;
   const products = new Set();

   buttons.forEach(btn => {
      btn.addEventListener('click', function (e) {
         const parent = e.target.parentElement.parentElement;
         const product = parent.querySelector('.product-title').innerText;
         const price = parent.querySelector('.product-line-price').innerText;

         total += Number(price);
         products.add(product);

         textArea.innerText += `Added ${product} for ${price} to the cart.\n`;
      });
   })

   const checkoutBtn = document.querySelector('button.checkout');

   checkoutBtn.addEventListener('click', function () {
      buttons.forEach(btn => btn.disabled = true);
      checkoutBtn.disabled = true;
      
      textArea.innerText += `You bought ${[...products].join(', ')} for ${total.toFixed(2)}.`;
   });
}