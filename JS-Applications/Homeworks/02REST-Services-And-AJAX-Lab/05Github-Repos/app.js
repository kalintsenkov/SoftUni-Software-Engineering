const reposUl = document.getElementById('repos');
const usernameInput = document.getElementById('username');


function loadRepos() {
	reposUl.innerHTML = '';
	const username = usernameInput.value;
	const url = `https://api.github.com/users/${username}/repos`;

	fetch(url)
		.then(response => {
			if (response.status === 404) {
				const li = document.createElement('li');
				li.innerHTML = response.statusText;
				reposUl.appendChild(li);
			} else if (response.status === 200) {
				return response.json();
			}
		})
		.then(response => {
			[...response].forEach(item => {
				const li = document.createElement('li');
				const a = document.createElement('a');
				a.href = item.html_url;
				a.innerHTML = item.full_name;
				li.appendChild(a);
				reposUl.appendChild(li);
			})
		});
}