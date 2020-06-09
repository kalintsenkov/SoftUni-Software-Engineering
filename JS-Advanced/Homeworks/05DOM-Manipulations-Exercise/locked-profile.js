function lockedProfile() {
    const buttons = document.querySelectorAll('button');

    Array.from(buttons).forEach(btn => {
        btn.addEventListener('click', function (e) {
            const parent = e.target.parentElement;
            const hiddenDiv = parent.querySelector('div');
            const unlockBtn = parent.querySelector('input[value="unlock"]');
            
            if (unlockBtn.checked) {

                if (btn.innerText === 'Show more') {
                    hiddenDiv.style.display = 'block';
                    btn.innerText = 'Hide it';
                } else if (btn.innerText === 'Hide it') {
                    hiddenDiv.style.display = 'none';
                    btn.innerText = 'Show more';
                }
            }
        });
    });
}