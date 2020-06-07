function validate() {
    const inputEmail = document.querySelector('#email');

    inputEmail.addEventListener('change', function (e) {
        if (e.target.value.search(/[a-z0-9]+\@[a-z]+\.[a-z]+/) === -1) {
            e.target.classList.add('error');
        } else {
            e.target.classList.remove('error');
        }
    });
}