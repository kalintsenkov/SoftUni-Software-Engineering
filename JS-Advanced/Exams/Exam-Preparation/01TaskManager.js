'use strict'

function solve() {
    const form = document.querySelector('form');

    const task = form.querySelector('input#task');
    const description = form.querySelector('textarea#description');
    const date = form.querySelector('input#date');
    const addButton = form.querySelector('button#add');

    const openParentDiv = document.querySelector('.orange').parentElement;
    const openSiblingDiv = openParentDiv.nextElementSibling;

    const inProgressDiv = document.querySelector('#in-progress');

    const completeParentDiv = document.querySelector('.green').parentElement;
    const completeSiblingDiv = completeParentDiv.nextElementSibling;

    form.addEventListener('submit', submitHandler);
    addButton.addEventListener('click', addButtonHandler);

    function submitHandler(e) { e.preventDefault(); }

    function addButtonHandler() {
        if (!task.value || !description.value || !date.value) {
            return;
        }

        const taskTitle = createTitleHeading(task.value);
        const taskDescription = createDescriptionParagraph(description.value, true);
        const taskDate = createDateParagraph(date.value, true);

        const startBtn = createButton('green', 'Start');
        const deleteBtn = createButton('red', 'Delete');

        const div = createDivWithFlexClass(startBtn, deleteBtn);

        const article = createArticle(taskTitle, taskDescription, taskDate, div);
        openSiblingDiv.appendChild(article);
        
        deleteBtn.addEventListener('click', openDeleteButtonHandler);
        startBtn.addEventListener('click', startButtonHandler);
    }

    function startButtonHandler(e) {
        const date = e.target.parentElement.previousElementSibling;
        const description = date.previousElementSibling;
        const title = description.previousElementSibling;

        const dateValue = date.innerText;
        const descriptionValue = description.innerText;
        const titleValue = title.innerText;

        openSiblingDiv.removeChild(date.parentElement)

        const taskTitle = createTitleHeading(titleValue);
        const taskDescription = createDescriptionParagraph(descriptionValue);
        const taskDate = createDateParagraph(dateValue);

        const deleteBtn = createButton('red', 'Delete');
        const finishBtn = createButton('orange', 'Finish');

        const div = createDivWithFlexClass(deleteBtn, finishBtn);

        const article = createArticle(taskTitle, taskDescription, taskDate, div);
        inProgressDiv.appendChild(article);

        deleteBtn.addEventListener('click', inProgressDeleteButtonHandler);
        finishBtn.addEventListener('click', finishButtonHandler);
    }

    function openDeleteButtonHandler(e) {
        const article = e.target.parentElement.parentElement;
        openSiblingDiv.removeChild(article);
    }

    function inProgressDeleteButtonHandler(e) {
        const article = e.target.parentElement.parentElement;
        inProgressDiv.removeChild(article);
    }

    function finishButtonHandler(e) {
        const date = e.target.parentElement.previousElementSibling;
        const description = date.previousElementSibling;
        const title = description.previousElementSibling;

        const dateValue = date.innerText;
        const descriptionValue = description.innerText;
        const titleValue = title.innerText;

        inProgressDiv.removeChild(date.parentElement)

        const taskTitle = createTitleHeading(titleValue);
        const taskDescription = createDescriptionParagraph(descriptionValue);
        const taskDate = createDateParagraph(dateValue);

        const article = createArticle(taskTitle, taskDescription, taskDate);
        completeSiblingDiv.appendChild(article);
    }

    function createTitleHeading(title) {
        const h3 = document.createElement('h3');
        h3.innerText = title;
        return h3;
    }

    function createDescriptionParagraph(description, isFirst = false) {
        const p = document.createElement('p');

        p.innerText = isFirst == true ? 'Description: ' + description : description;

        return p;
    }

    function createDateParagraph(date, isFirst = false) {
        const p = document.createElement('p');
        p.innerText = isFirst == true ? 'Due Date: ' + date : date;

        return p;
    }

    function createButton(className, textContent) {
        const btn = document.createElement('button');
        btn.classList.add(className);
        btn.textContent = textContent;

        return btn;
    }

    function createDivWithFlexClass(btn1, btn2) {
        const div = document.createElement('div');
        div.classList.add('flex');
        div.appendChild(btn1);
        div.appendChild(btn2);

        return div;
    }

    function createArticle(title, description, date, btnDiv) {
        const article = document.createElement('article');
        article.appendChild(title);
        article.appendChild(description);
        article.appendChild(date);

        if (btnDiv) { article.appendChild(btnDiv); }

        return article;
    }
}