// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/* Icon drop down menu */
const icon = document.querySelector(".fa-user");
const menu = document.querySelector(".dropdown-menu");

let timeoutId;

icon.addEventListener("mouseover", function () {
    menu.classList.add("show");
});

icon.addEventListener("mouseleave", function () {
    timeoutId = setTimeout(() => {
        menu.classList.remove("show");
    }, 300);
});

menu.addEventListener("mouseenter", function () {
    clearTimeout(timeoutId);
});

menu.addEventListener("mouseleave", function () {
    menu.classList.remove("show");
});

/* Auto suggestion regarding the location */
Bkoi.onSelect(function () {
    var selectedData = Bkoi.getSelectedData()
})

/* Background image category */
function applyBackground(category) {
    var divcategory = document.querySelector(`.${category}`);
    switch (category) {
        case 'conference':
            divcategory.style.backgroundImage = null;
            break;
        default:
            break;
    }
}
function removeBackground(category) {
    var divcategory = document.querySelector(`.${category}`);
    divcategory.style.backgroundImage = null;
}

