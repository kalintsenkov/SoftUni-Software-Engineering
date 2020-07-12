const usernameInput = document.getElementById('username');
const repositoryInput = document.getElementById('repo');
const commitsUl = document.getElementById('commits');

function loadCommits() {
    commitsUl.innerHTML = '';

    const username = usernameInput.value;
    const repository = repositoryInput.value;

    const url = `https://api.github.com/repos/${username}/${repository}/commits`;

    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw response;
            }

            return response.json()
        }).then(data => {
            [...data].forEach(item => {
                const li = document.createElement('li');
                li.innerHTML = `${item.commit.author.name}: ${item.commit.message}`;
                commitsUl.appendChild(li);
            });
        }).catch(error => {
            const li = document.createElement('li');
            li.innerHTML = `Error: ${error.status} (${error.statusText})`;
            commitsUl.appendChild(li);
        });
}