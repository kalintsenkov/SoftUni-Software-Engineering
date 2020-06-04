function createArticle() {
	const title = document.getElementById('createTitle').value;
	const content = document.getElementById('createContent').value;

	if (!title || !content) {
		return;
	}

	const titleHeader = document.createElement('h3');
	titleHeader.innerText = title;

	const contentParagraph = document.createElement('p');
	contentParagraph.innerText = content;

	const newArticle = document.createElement('article');
	newArticle.appendChild(titleHeader);
	newArticle.appendChild(contentParagraph);

	const articlesSection = document.getElementById('articles');
	articlesSection.appendChild(newArticle);

	document.getElementById('createTitle').value = '';
	document.getElementById('createContent').value = '';
}