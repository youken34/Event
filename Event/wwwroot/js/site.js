// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/* Icon drop down menu */
const icon = document.querySelector(".fa-user");
const menu = document.querySelector(".dropdown-menu");

let timeoutId;

if (icon != null) {
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
}

/* Filters apparition */
var Menufilter = document.querySelector(".filter-details");
var push = document.getElementById("push");
var filterOn = false;
function filterMenuApparition() {
    push.style.transform = "translateX(-100px)";
    Menufilter.style.transform = "translateX(0px)";
}

function removeFilterMenu() {
    Menufilter.style.transform = "translateX(200px)";
    push.style.transform = "translateX(0px)";

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

var dropdownmenu = document.getElementsByClassName("dropdown-toggle")[0];
dropdownmenu.addEventListener("mouseover", function name() {
    console.log(dropdownmenu)
    dropdownmenu.style.zIndex = "1000";
})


/* Auto suggestion regarding the location */


/* Background image category */

document.addEventListener("DOMContentLoaded", function () {
    // Select all the grid items
    var gridItems = document.querySelectorAll(".grid-item");
    // Loop through each grid item
    gridItems.forEach(function (item) {
        applyBackground(item);
    });
});
function applyBackground(item) {
    var img = item.firstElementChild;
    switch (item.getAttribute("class").split(" ")[1]) {
        case 'conference':
            img.src = "https://i.pinimg.com/564x/44/d2/da/44d2daf7c1dcec8efdc965d1a3144219.jpg";
            break;
        case 'festival':
            img.src = "https://cdn.pixabay.com/photo/2017/07/21/23/57/concert-2527495__480.jpg";
        case 'party':
            img.src = "https://t3.ftcdn.net/jpg/02/87/35/70/360_F_287357045_Ib0oYOxhotdjOEHi0vkggpZTQCsz0r19.jpg";
        default:
            break;
    }
}

/* Make the footer stick to the bottom */
function footer() {
    var footer = document.getElementsByTagName("footer")[0];
    footer.style.position = "fixed";
    footer.style.bottom = "0";
    var body = document.body;
    body.style.overflow = "hidden";
}

