function toggle() {
    const extraDiv = document.getElementById('extra');
    const button = document.getElementsByClassName('button')[0];
    
    const currentDisplayStyle = extraDiv.style.display || 'none';

    if (currentDisplayStyle === 'none') {
        extraDiv.style.display = 'block';
        button.textContent = 'Less';
    } else {
        extraDiv.style.display = 'none';
        button.textContent = 'More';
    }
}