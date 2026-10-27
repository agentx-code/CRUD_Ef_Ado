// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const Edit = document.querySelectorAll(".EditBtn");
const modelName = document.getElementById("ModalLabel");
const Button = document.getElementById("btnSubmit");

Edit.forEach((btn) => {
    btn.addEventListener('click', () => {   

        modelName.innerHTML = "Edit User";
        Button.innerHTML = "UPDATE";

        const id = btn.getAttribute("data-Id");
        const name = btn.getAttribute("data-Name");
        const email = btn.getAttribute("data-Email");
        const password = btn.getAttribute("data-Password");
        const address = btn.getAttribute("data-Address");

        console.log(name);

        document.getElementById("formId").value = id;
        document.getElementById("formName").value = name;
        document.getElementById("formEmail").value = email;
        document.getElementById("formPassword").value = password;
        document.getElementById("formAddress").value = address;
    })
});


