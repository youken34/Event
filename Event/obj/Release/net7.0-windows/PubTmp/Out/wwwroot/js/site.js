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

/*Alert function */
function CustomAlert() {

    this.alert = function (message, title) {
        divid = document.getElementById('alert');
        divid.innerHTML += '<div id = "dialogoverlay"></div><div id="dialogbox" class="slit-in-vertical"><div style="background-color: #1E0A3C"><div id="dialogboxhead"></div><div id="dialogboxbody"><ul><li>Responsive & overall design</li><li>Filters function</li><li>Miscelleanous improvements</li></ul></div><div id="dialogboxfoot"></div></div></div>';

        let dialogoverlay = document.getElementById('dialogoverlay');
        let dialogbox = document.getElementById('dialogbox');

        dialogbox.style.zIndex = "3";
        dialogoverlay.style.zIndex = "2";

        let winH = window.innerHeight;
        dialogoverlay.style.height = winH + "px";

        dialogbox.style.top = "100px";

        dialogoverlay.style.display = "block";
        dialogbox.style.display = "block";

        document.getElementById('dialogboxhead').style.display = 'block';

        if (typeof title === 'undefined') {
            document.getElementById('dialogboxhead').style.display = 'none';
        } else {
            document.getElementById('dialogboxhead').innerHTML = '<i class="fa fa-exclamation-circle" aria-hidden="true"></i> ' + title;
        }
        document.getElementById('dialogboxbody').insertAdjacentHTML('afterbegin', message);
        document.getElementById('dialogboxfoot').innerHTML = '<button class="pure-material-button-contained active" onclick="customAlert.ok()">OK</button>';
    }

    this.ok = function () {
        document.getElementById('dialogbox').style.display = "none";
        document.getElementById('dialogoverlay').style.display = "none";
    }
}

 var customAlert = new CustomAlert();
 //window.addEventListener("DOMContentLoaded", function () {
 //    var url = window.location.href;
 //    var expectedUrl = "http://localhost:5114/";
 //    if (url == expectedUrl) {
 //        customAlert.alert('This project is still in process, tasks I am currently working on:', 'Warning');
 //    }
 //})

window.addEventListener("DOMContentLoaded", function () {
    var url = window.location.href;
    var expectedUrl = "http://comeb69-001-site1.btempurl.com/";
    if (url == expectedUrl) {
        customAlert.alert('This project is still in process, tasks I am currently working on:', 'Warning');
    }
})