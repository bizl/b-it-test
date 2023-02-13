const customerApiEndpoint = 'api/customers';
let customerArr = [];

function getCustomers() {
    fetch(customerApiEndpoint)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.log('Unable to get customer.' + error));
}

function addItem() { 

    const customerObj = {
        id:-1,
        firstName: document.getElementById('add-firstname').value.trim(),
        lastName: document.getElementById('add-lastname').value.trim()
    };

    fetch(customerApiEndpoint, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customerObj)
    })
        .then(response => response.json())
        .then(() => {
            getCustomers();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add customer.', error));
}

function deleteItem(id) {
    fetch(`${customerApiEndpoint}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getCustomers())
        .catch(error => console.error('Unable to delete customer.', error));
}

function displayEditForm(id) {
    const customerObj = customerArr.find(customerObj => customerObj.id === id); 
    //document.getElementById('edit-details').value = JSON.parse(customerObj.obj);
    document.getElementById('edit-id').value = customerObj.id;
    document.getElementById('edit-firstname').value = customerObj.firstName;
    document.getElementById('edit-lastname').value = customerObj.lastName;
    document.getElementById('edit-age').value = customerObj.age;
    document.getElementById('edit-telephone').value = customerObj.telephone;
    document.getElementById('edit-reference').value = customerObj.reference;
    document.getElementById('edit-address').value = customerObj.address;
    document.getElementById('editForm').style.display = 'block';
    document.getElementById('insertForm').style.display = 'none'; 
  
}

function numbersOnly(evt) {
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
        return false;
    return true;

}

function updateItem() {
    const customerObj = { 
            id: document.getElementById('edit-id').value.trim(),
            firstName: document.getElementById('edit-firstname').value.trim(), 
            lastName: document.getElementById('edit-lastname').value.trim(),
            address: document.getElementById('edit-address').value.trim(),
            telephone: document.getElementById('edit-telephone').value.trim(),
            reference: document.getElementById('edit-reference').value.trim() 
    };
    if (parseInt(document.getElementById('edit-age').value) > 0)
        customerObj.age = document.getElementById('edit-age').value;

    console.log(customerObj);

    fetch(`${customerApiEndpoint}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customerObj)
    })
        .then(() => getCustomers())
        .catch(error => console.error('Unable to update customer.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
    document.getElementById('insertForm').style.display = 'block';
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

    data.forEach(customerObj => {
        let isCompleteCheckbox = document.createElement('input');
        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.disabled = true;
        isCompleteCheckbox.checked = customerObj.isComplete;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${customerObj.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${customerObj.id})`);

        let tr = tBody.insertRow();

        let td0 = tr.insertCell(0);
        td0.appendChild(document.createTextNode(customerObj.firstName));
        $(td0).prop("data-id", customerObj.id);

        tr.insertCell(1).appendChild(document.createTextNode(customerObj.lastName));
        tr.insertCell(2).appendChild(document.createTextNode(customerObj.age));
        tr.insertCell(3).appendChild(document.createTextNode(customerObj.address));
        tr.insertCell(4).appendChild(document.createTextNode(customerObj.telephone));
        tr.insertCell(5).appendChild(document.createTextNode(customerObj.reference));

        tr.insertCell(6).appendChild(editButton);
        tr.insertCell(7).appendChild(deleteButton);
    });

    customerArr = data;
}