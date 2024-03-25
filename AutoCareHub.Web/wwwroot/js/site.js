let map = document.getElementById('location');

let address = map.textContent;

var mapouter = document.getElementsByClassName("mapouter")[0];
mapouter.innerHTML = `<iframe width = "430" height = "430" id = "gmap_canvas" src = "https://maps.google.com/maps?q=` + address + `&t=&z=14&ie=UTF8&iwloc=&output=embed" frameborder = "0" scrolling = "no" marginheight = "0" marginwidth = "0" ></iframe>`;
mapouter.setAttribute("style", "height: 430px");