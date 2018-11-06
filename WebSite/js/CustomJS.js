$(function () {
    $('button').click(function (e) {
        e.preventDefault();
        var a = $(this).attr('class');
        if (a === 'btn btn-outline-danger') {
            $(this).removeAttr('class');
            $(this).addClass("btn btn-success a");
        } else if (a === 'btn btn-success a'){
            $(this).removeAttr('class');
            $(this).addClass("btn btn-outline-danger");
        }
        else if (a === 'btn btn-light') {
            var name = this.id.substring(20, 24);
            num = document.getElementById(name).innerHTML;
            sum = parseInt(num) - 1;
            document.getElementById(name).innerHTML = sum;
            colorSpan(name, sum);
            this.parentNode.removeChild(this);
        }
    });
})

function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
}

function dropcopy(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    var user = data.substring(20);
    var firstName = user.split("_");
    var copyimg = document.createElement("button");
    copyimg.id = firstName[2] +"_"+ ev.target.id;
    copyimg.className = "btn btn-light";
    copyimg.innerHTML = firstName[0];
    var elem = document.createElement("img");
    elem.setAttribute("src", "img/delete.png");
    elem.setAttribute("height", "15");
    copyimg.setAttribute("onclick", "deleteEv(this)");
    copyimg.appendChild(elem);
    var original = document.getElementById(data);
    ev.target.appendChild(copyimg);
    var num = document.getElementById(firstName[2]).innerHTML;
    var sum = parseInt(num) + 1;
    colorSpan(firstName[2], sum);
    document.getElementById(firstName[2]).innerHTML = sum;
}

function deleteEv(ev) {
    var name = ev.id.substring(0,4);
    num = document.getElementById(name).innerHTML;
    sum = parseInt(num) - 1;
    document.getElementById(name).innerHTML = sum;
    colorSpan(name, sum);
    ev.parentNode.removeChild(ev);
}

function colorSpan(id, num) {
    var parentDiv = document.getElementById(id).parentElement;
    var minimum = parentDiv.children[0];
    var numMinimum = minimum.innerHTML[0];
    if (num == 0) parentDiv.className = "badge badge-pill badge-danger tooltipC";
    else if (num > numMinimum) parentDiv.className = "badge badge-pill badge-primary tooltipC";
    else if (num == numMinimum) parentDiv.className = "badge badge-pill badge-success tooltipC";
    else if (num < numMinimum) parentDiv.className = "badge badge-pill badge-warning tooltipC";
}

function openPage(pageName, elmnt, color) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].style.backgroundColor = "";
    }
    document.getElementById(pageName).style.display = "block";
    elmnt.style.backgroundColor = color;

}
// Get the element with id="defaultOpen" and click on it
