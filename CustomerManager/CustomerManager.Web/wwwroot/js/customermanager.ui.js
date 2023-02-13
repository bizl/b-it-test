const customerApiEndpoint = 'api/customers';
let customerArr = [];

function getItems() {
    fetch(customerApiEndpoint)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.log('Unable to get items.' + error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');

    const item = {
        isComplete: false,
        name: addNameTextbox.value.trim()
    };

    fetch(customerApiEndpoint, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${customerApiEndpoint}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = customerArr.find(item => item.id === id); 
    //document.getElementById('edit-details').value = JSON.parse(item.obj);
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-firstname').value = item.firstName;
    document.getElementById('edit-lastname').value = item.lastName;
    document.getElementById('edit-age').value = item.age;
    document.getElementById('edit-telephone').value = item.telephone;
    document.getElementById('edit-reference').value = item.reference;
    document.getElementById('edit-address').value = item.address;
    document.getElementById('editForm').style.display = 'block';
    document.getElementById('insertForm').style.display = 'none';

    $('#editForm').find("input[data-validate='number']").on("leave", function () {

        var originalValue = $(this).val();
        var isNumber = isNumber($(this).val(originalValue));
        if (!isNumber) {
            $(this).val(originalValue);
        } 
    });
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(itemId, 10), 
        obj: {
            firstName: document.getElementById('edit-firstname').value.trim(), 
            lastName: document.getElementById('edit-lastname').value.trim(), 
            age: document.getElementById('edit-age').value.trim(),
            address: document.getElementById('edit-address').value.trim(),
            telephone: document.getElementById('edit-telephone').value.trim(),
            reference: document.getElementById('edit-reference').value.trim()
        }
    };

    fetch(`${customerApiEndpoint}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item.obj)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
    document.getElementById('insertForm').style.display = 'block';
    getItems();
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'customer' : 'customers';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function _displayItems(data) {
    const tBody = document.getElementById('customerTbl');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = item.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td0 = tr.insertCell(0);
        td0.appendChild(document.createTextNode(item.firstName));
        $(td0).prop("data-id", item.id);

        tr.insertCell(1).appendChild(document.createTextNode(item.lastName));
        tr.insertCell(2).appendChild(document.createTextNode(item.age));
        tr.insertCell(3).appendChild(document.createTextNode(item.address));
        tr.insertCell(4).appendChild(document.createTextNode(item.telephone));
        tr.insertCell(5).appendChild(document.createTextNode(item.reference));

        tr.insertCell(6).appendChild(editButton);
        tr.insertCell(7).appendChild(deleteButton);
    });

    customerArr = data;
}