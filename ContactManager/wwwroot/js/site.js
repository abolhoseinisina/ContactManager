// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
fetch("http://localhost:11845/api/contact")
    .then(x => x.text())
    .then(y => displayList(y));

function displayList(datas) {
    datas = JSON.parse(datas);
    datas.forEach(function (data, index) {
        document.getElementById('data-table').innerHTML += "<tr>" +
            "<td> " + data.id + " </td >" +
            "<td> " + data.firstName + " </td >" +
            "<td> " + data.lastName + " </td>" +
            "<td> " + data.homeTelephone + " </td>" +
            "<td> " + data.cellPhone + " </td>" +
            "<td> " + data.email + " </td>" +
            "<td> " + data.address + " </td>" +
            "<td> " + data.skypeName + " </td>" +
            "<td> " + "<button data='" + data.id + "' class='btn btn-danger delete-contact'> Delete </button>" + " </td>" +
            "</tr >";
        document.getElementById('edit-id-dropdown').innerHTML += "<option value=" + data.id + ">" + data.id + "</option>";
    });
    $(".delete-contact").click(delteContact);
}

function GetContact(contact) {
    var selectedValue = contact.value;
    fetch("http://localhost:11845/api/contact/" + selectedValue)
        .then(x => x.text())
        .then(y => displayContact(y));
}

function displayContact(datas) {
    data = JSON.parse(datas);
    document.querySelectorAll("#edit-contact [Name='FirstName']")[0].value = data.firstName;
    document.querySelectorAll("#edit-contact [Name='LastName']")[0].value = data.lastName;
    document.querySelectorAll("#edit-contact [Name='HomeTelephone']")[0].value = data.homeTelephone;
    document.querySelectorAll("#edit-contact [Name='CellPhone']")[0].value = data.cellPhone;
    document.querySelectorAll("#edit-contact [Name='Email']")[0].value = data.email;
    document.querySelectorAll("#edit-contact [Name='Address']")[0].value = data.address;
    document.querySelectorAll("#edit-contact [Name='SkypeName']")[0].value = data.skypeName;
}

$("#edit-contact")[0].reset()
$("#edit-contact").submit(function (e) {
    e.preventDefault();
    var form = $(this);
    var url = form.attr('action');
    if ($("#edit-id-dropdown").val() == 0) return 0;
    $.ajax({
        type: "PUT",
        url: url,
        data: form.serialize(),
        success: function (data) {
            location.reload();
        }
    });
});

$("#create-contact")[0].reset()
$("#create-contact").submit(function (e) {
    e.preventDefault();
    var form = $(this);
    var url = form.attr('action');
    $.ajax({
        type: "POST",
        url: url,
        data: form.serialize(),
        success: function (data) {
            location.reload();
        }
    });
});

function delteContact(e) {
    contactId = $(e.target).attr('data')
    $.ajax({
        type: "DELETE",
        url: "http://localhost:11845/api/contact",
        data: {
            id: contactId
        },
        success: function (data) {
            location.reload();
        }
    });
};