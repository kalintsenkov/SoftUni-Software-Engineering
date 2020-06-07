function deleteByEmail() {
    const tbody = document.querySelector('tbody');
    const tdList = tbody.querySelectorAll('td');
    const result = document.querySelector('#result');
    const emailToDelete = document.querySelector("input[name='email']");

    let isDeleted = false;

    Array.from(tdList).forEach(td => {
        if (td.innerText === emailToDelete.value) {
            isDeleted = true;
            tbody.removeChild(td.parentElement);
        }
    });

    emailToDelete.value = '';
    result.innerText = !isDeleted ? 'Not found.' : 'Deleted';
}