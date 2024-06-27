    let containerCreation = document.getElementById('containerCreation');

    function createEntreprise(){
        containerCreation.classList.toggle('active');
}


document.querySelectorAll('tr').forEach(function (row) {
    var cells = row.querySelectorAll('td');
    cells.forEach(function (td, index) {
        if (td.textContent.trim() === '0') {
            td.classList.add('red');
            if (index + 3 < cells.length) {
                cells[index + 1].classList.add('selected');
            }
        }
        else if (td.textContent.trim() === '1') {
            td.classList.add('yellow');
            if (index + 2 < cells.length) {
                cells[index + 3].classList.add('selected');
            }
        }
        else if (td.textContent.trim() === '2') {
            td.classList.add('green');
            if (index + 1 < cells.length) {
                cells[index + 2].classList.add('selected');
            }
        }
    });
});