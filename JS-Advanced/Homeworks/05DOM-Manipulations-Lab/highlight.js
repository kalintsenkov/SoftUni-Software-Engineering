function focus() {
    const inputList = document.querySelectorAll('input');
    
    Array.from(inputList).forEach(input => {
        
        input.addEventListener('focus', function(e) {
            const div = e.target.parentElement;
            div.classList.add('focused');
        });

        input.addEventListener('blur', function(e) {
            const div = e.target.parentElement;
            div.classList.remove('focused');
        });
    });
}