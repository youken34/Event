﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
function $(name) {
    return document.getElementById(name);
}

function all(name) {
    return document.querySelectorAll(name);
}
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
    push.style.transform = "translateX(-105px)";
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
    var gridItems = all(".grid-item");
    // Loop through each grid item
    gridItems.forEach(function (item) {
        applyBackground(item);
    });
});
function applyBackground(item) {
    var img = item.firstElementChild;
    switch (item.getAttribute("class").split(" ")[1]) {
        case 'tournament':
            img.src = "https://t4.ftcdn.net/jpg/01/64/83/47/240_F_164834714_2UMLp8c0bszO8T3kpuKjTPBNcmVO8ad0.jpg";
            break;
        case 'conference':
            img.src = "https://i.pinimg.com/564x/44/d2/da/44d2daf7c1dcec8efdc965d1a3144219.jpg";
            break;
        case 'festival':
            img.src = "https://cdn.pixabay.com/photo/2017/07/21/23/57/concert-2527495__480.jpg";
            break;
        case 'party':
            img.src = "https://t3.ftcdn.net/jpg/02/87/35/70/360_F_287357045_Ib0oYOxhotdjOEHi0vkggpZTQCsz0r19.jpg";
            break;
        case "expo":
            img.src = "https://www.actexpo.com/wp-content/uploads/2022/10/expo-hall.jpg";
            break;
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

/* Filters function 
---------------------------
---------------------------
*/
const categoryDropdownButton = $("categoryDropdown");
const categoryDropdownMenu = $('categoryFilters');

// Toggle the dropdown menu when the category dropdown button is clicked
categoryDropdownButton.addEventListener("click", function () {
    categoryDropdownMenu.classList.toggle("show");
});

// Close the dropdown menu if the user clicks outside of it
window.addEventListener("click", function (event) {
    if (!event.target.matches(".dropdown-toggle")) {
        const dropdowns = document.getElementsByClassName("dropdown-menu");
        for (let i = 0; i < dropdowns.length; i++) {
            const dropdown = dropdowns[i];
            if (dropdown.classList.contains("show")) {
                dropdown.classList.remove("show");
            }
        }
    }
});

/* Week filter 
----------------
*/
const thisWeek = document.getElementById('thisweek')
thisWeek.addEventListener('change', function () {
    if (thisWeek.checked) {
        sameweek()
    } else {
        adjust();
    }
});


function sameweek() {
    // get list of all events
    const eventItems = all('.grid-item');

    // filter events that are not in the same week as now
    const now = new Date();
    const weekStart = new Date(now.getFullYear(), now.getMonth(), now.getDate() - now.getDay());
    const weekEnd = new Date(now.getFullYear(), now.getMonth(), now.getDate() - now.getDay() + 6);
    eventItems.forEach(function (item) {
        const itemDate = new Date(item.querySelector('p:nth-of-type(3)').textContent);
        if (itemDate < weekStart || itemDate > weekEnd) {
            item.style.display = 'none';
        } else {
            item.style.display = 'grid';
        }
    });

};



/* Category filters
-------------------
-------------------
*/
var inputCheked = [false, false, false, false, false]
const category = all('input[name="category"]');

categoryDropdownMenu.addEventListener("click", function () {
    for (let i = 0; i < category.length; i++) {
        category[i].addEventListener("change", function () {
            const parent = this.parentNode;
            var index = oddToIndex(Array.prototype.indexOf.call(categoryDropdownMenu.childNodes, parent));
            applyFilters(category[i], index)
        })
    }
})


function applyFilters(input, index) {
    removeCategories();
    if (input.checked) {
        inputCheked[index] = true
    } else {
        inputCheked[index] = false
    }
    adjust();
};
const gridItems = all('.grid-item');

function removeCategories() {
    gridItems.forEach(function (item) {
        item.style.display = 'none';
    })
}
function displayCategories(category) {
    const categories = all(`.${category}`)
    categories.forEach(function (item) {
        item.style.display = 'grid';
    })
}
function oddToIndex(number) {
    return (number - 1) / 2;
}
function adjust() {
    var indexCategory = 0
    category.forEach(function (item) {
        if (inputCheked[indexCategory] === true) {
            displayCategories(item.nextElementSibling.textContent.toLowerCase())
        }
        indexCategory++;
    })
}




