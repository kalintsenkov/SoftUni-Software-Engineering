const loadPostsBtn = document.getElementById('btnLoadPosts');
const viewPostBtn = document.getElementById('btnViewPost');
const postsSelect = document.getElementById('posts');
const postTitleHeading = document.getElementById('post-title');
const postBodyUl = document.getElementById('post-body');
const commentsUl = document.getElementById('post-comments');

function attachEvents() {
    let id = '';

    loadPostsBtn.addEventListener('click', getPosts);
    postsSelect.addEventListener('click', getId);
    viewPostBtn.addEventListener('click', getDetails);

    function getId(e) {
        id = e.target.value;
    }

    function getPosts() {
        const allUrl = 'https://blog-apps-c12bf.firebaseio.com/posts.json';

        fetch(allUrl)
            .then(response => response.json())
            .then(data => {
                postsSelect.innerHTML = '';

                for (const id in data) {
                    const option = document.createElement('option');

                    option.value = id;
                    option.innerHTML = data[id].title;

                    postsSelect.appendChild(option);
                }
            });
    }

    function getDetails() {
        const postUrl = `https://blog-apps-c12bf.firebaseio.com/posts/${id}.json`;

        fetch(postUrl)
            .then(response => response.json())
            .then(data => {
                postTitleHeading.innerHTML = data.title;
                postBodyUl.innerHTML = data.body;

                for (const id in data.comments) {
                    const li = document.createElement('li');

                    li.innerHTML = data.comments[id].text;
                    
                    commentsUl.appendChild(li);
                }
            });
    }
}

attachEvents();