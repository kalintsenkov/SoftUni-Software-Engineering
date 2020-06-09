function solve() {
  const buttons = document.querySelectorAll('button');
  const generateBtn = buttons[0];
  const buyBtn = buttons[1];

  const textAreaList = document.querySelectorAll('textarea');
  const inputTextArea = textAreaList[0];
  const outputTextArea = textAreaList[1];

  const tbody = document.querySelector('tbody');

  const boughtProducts = [];
  let totalPrice = 0;
  let totalDecFactor = 0;

  generateBtn.addEventListener('click', function () {
    const parsed = JSON.parse(inputTextArea.value);

    parsed.forEach(obj => {

      const tr = document.createElement('tr');

      const img = obj.img;
      const name = obj.name;
      const price = obj.price;
      const decFactor = obj.decFactor;

      const tdImg = document.createElement('td');
      const imgTag = document.createElement('img');
      imgTag.src = img;
      tdImg.appendChild(imgTag);
      tr.appendChild(tdImg);

      const tdName = document.createElement('td');
      const pName = document.createElement('p');
      pName.textContent = name;
      tdName.appendChild(pName);
      tr.appendChild(tdName);

      const tdPrice = document.createElement('td');
      const pPrice = document.createElement('p');
      pPrice.textContent = price;
      tdPrice.appendChild(pPrice);
      tr.appendChild(tdPrice);

      const tdDecFactor = document.createElement('td');
      const pDecFactor = document.createElement('p');
      pDecFactor.textContent = decFactor;
      tdDecFactor.appendChild(pDecFactor);
      tr.appendChild(tdDecFactor);

      const td = document.createElement('td');
      const input = document.createElement('input');
      input.type = 'checkbox';

      td.appendChild(input);
      tr.appendChild(td);
      tbody.appendChild(tr);
    });
  });

  buyBtn.addEventListener('click', function () {
    const checkedInputs = document.querySelectorAll('input:checked');

    Array.from(checkedInputs).forEach(input => {
      const decFactorDiv = input.parentElement.previousElementSibling;
      const priceDiv = decFactorDiv.previousElementSibling;
      const nameDiv = priceDiv.previousElementSibling;

      totalPrice += Number(priceDiv.textContent);
      totalDecFactor += Number(decFactorDiv.textContent);
      boughtProducts.push(nameDiv.textContent);
    });

    outputTextArea.value += `Bought furniture: ${boughtProducts.join(', ')}\n`;
    outputTextArea.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    outputTextArea.value += `Average decoration factor: ${totalDecFactor / boughtProducts.length}`;
  });
}