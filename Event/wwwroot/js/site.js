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
/* Filters apparition */
var Menufilter = document.querySelector(".filter-details");
var filterOn = false;
function filterMenuApparition() {
    Menufilter.style.transform = "translateX(0px)";
}

function removeFilterMenu() {
    Menufilter.style.transform = "translateX(200px)";
}

function filterMenu() {
    if (filterOn == false) {

        filterMenuApparition();
    }
    else {
        removeFilterMenu();
    }
    filterOn = !filterOn;
}


/* Auto suggestion regarding the location */


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

