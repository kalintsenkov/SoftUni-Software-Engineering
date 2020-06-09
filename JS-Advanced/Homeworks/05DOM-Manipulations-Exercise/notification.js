function notify(message) {
    const notification = document.getElementById('notification');
    
    notification.style.display = 'block';
    notification.textContent = message;

    setTimeout(function() {
        notification.style.display = 'none';
    }, 2000);
}