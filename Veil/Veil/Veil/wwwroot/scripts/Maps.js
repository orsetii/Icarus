var DotNet;
async function InitMap(dotnetReference, requestedLat, requestedLong) {
    DotNet = dotnetReference;

    var location = {};

    if (requestedLat != undefined && requestedLong != undefined) {
        location.lat = requestedLat;
        location.long = requestedLong;
    } else {
        location = await getCurrentPosition();
    }



    var map = L.map('map', {
        center: [location.lat, location.long],
        zoom: 12
    });


    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: ''
    }).addTo(map);

    map.addControl(new L.Control.Fullscreen());

    map.on("click", function (e) {
        hideMenu();
    });

    var options = {
        position: 'topright', // toolbar position, options are 'topleft', 'topright', 'bottomleft', 'bottomright'
        drawMarker: true,  // adds button to draw markers
        drawPolygon: true,  // adds button to draw a polygon
        drawPolyline: true,  // adds button to draw a polyline
        drawCircle: true,  // adds button to draw a cricle
        editPolygon: true,  // adds button to toggle global edit mode
        deleteLayer: true   // adds a button to delete layers
    };
    map.pm.addControls(options);

    L.easyButton({
        states: [
            {
                id: 'bob',
                icon: 'fa-save',
                title: 'Save Current Map State',
                onClick: function (btn, map) {
                    saveToDb(btn, map);
                },
                extraHTML: 'bob'
            }
        ]
    }).addTo(map);


    L.easyButton({
        states: [
            {
                id: 'curLoc',
                icon: 'fa-home',
                title: 'Go to Current Location',
                onClick: function (btn, map) {
                    backToCurrentLocation()
                },
            }
        ]
    }).addTo(map);

    var vanIcon = L.icon({
        iconUrl: 'images/van-marker.png',

        iconSize: [42, 34], // size of the icon
        shadowSize: [50, 64], // size of the shadow
        iconAnchor: [21, 17], // point of the icon which will correspond to marker's location
        shadowAnchor: [4, 62],  // the same for the shadow
        popupAnchor: [-3, -76] // point from which the popup should open relative to the iconAnchor
    });

    L.marker([location.lat, location.long], { icon: vanIcon }).addTo(map);

    var data = await GetGeoJsonData();
    if (data) {
        var geoLayer = L.geoJSON(JSON.parse(data)).addTo(map);
    }


    InitMapFollowMouse(map);
    // data for context menu
    const contextmenuItems = [
        {
            text: "🚐 Current location",
            callback: backToCurrentLocation,
        },
        {
            text: "Zoom in",
            callback: zoomIn,
        },
        {
            text: "Zoom out",
            callback: zoomOut,
        },
    ];


    function backToCurrentLocation() {
        map.flyTo([location.lat, location.long], 15);
        hideMenu();
    }

    function zoomIn() {
        map.zoomIn();
        hideMenu();
    }

    function zoomOut() {
        map.zoomOut();
        hideMenu();
    }

    // hide context menu
    function hideMenu() {
        const ul = document.querySelector(".context-menu");
        ul.removeAttribute("style");
        ul.classList.remove("is-open");
    }

    // create context menu
    function createMenu() {
        const menu = document.createElement("ul");
        menu.classList.add("context-menu");
        menu.setAttribute("data-contextmenu", "0");
        contextmenuItems.forEach((item) => {
            const li = document.createElement("li");
            li.innerText = item.text;
            li.addEventListener("click", item.callback);
            menu.appendChild(li);
        });

        return menu;
    }


    // Add context menu to the map
    var menu = document.querySelector("#map");
    document.addEventListener("contextmenu", function (e) {
        e.preventDefault();

        // show context menu
        show(e);
    });

    function show(e) {
        const ul = document.querySelector("ul");
        ul.style.display = "block";
        ul.style.left = `${e.pageX}px`;
        ul.style.top = `${e.pageY}px`;
        ul.classList.add("is-open");

        ul.focus();

        const point = L.point(e.pageX, e.pageY);
        const coordinates = map.containerPointToLatLng(point);


        e.preventDefault();
    }

    // append context menu to the body
    document.body.appendChild(createMenu());

    window.addEventListener("DOMContentLoaded", function () {
        document.addEventListener("wheel", hideMenu);

        ["zoomstart", "resize", "click", "move"].forEach((eventType) => {
            map.on(eventType, hideMenu);
        });
    });


}

function saveToDb(btn, map) {
    var allLayers = L.featureGroup();
    map.eachLayer(function (layer) {
        if (layer instanceof L.Path || layer instanceof L.Marker) {
            allLayers.addLayer(layer);
        }
    });

    var geojson = JSON.stringify(allLayers.toGeoJSON());
    SaveGeoJsonData(geojson);
}



async function getCurrentPosition() {
    const pos = await new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(resolve, reject);
    });

    return {
        long: pos.coords.longitude,
        lat: pos.coords.latitude,
    };
};

async function getLatitude() {
    var pos = await getCurrentPosition();
    console.log("Got position: " + JSON.stringify(pos));
    return pos.lat;
}

async function getLongitude() {
    var pos = await getCurrentPosition();
    console.log("Got position: " + JSON.stringify(pos));
    return pos.long;
}


function SaveGeoJsonData(data) {
    DotNet.invokeMethodAsync("SaveGeoJSONData", data);
}

async function GetGeoJsonData() {
    return await DotNet.invokeMethodAsync("GetGeoJSONData");
}

function InitMapFollowMouse(map) {
    // follow mouse
    // ------------------------------

    // delete old follow mouses (shouldnt happen but does, cant hurt!)
    clearFollowMouseDivs();

    const followMouse = document.createElement("div");
    followMouse.className = "follow-mouse";
    document.body.appendChild(followMouse);

    const mapCointainer = document.querySelector("#map");

    mapCointainer.addEventListener("mousemove", function (e) {
        const { offsetWidth: mapWidth, offsetHeight: mapHeight } = e.target;
        const { offsetWidth: cordWidth, offsetHeight: cordHeight } = followMouse;

        // get co-ordinates
        let { xp, yp } = getCoords(e);

        // convert point x,y to latlng
        const point = L.point(xp, yp);
        const coordinates = map.containerPointToLatLng(point);

        // add coordinates to the div
        followMouse.textContent = coordinates;

        // set the position of the div
        xp = xp + 20 + cordWidth > mapWidth ? xp - cordWidth - 10 : xp + 10;
        yp = yp + 20 + cordHeight > mapHeight ? yp - cordHeight - 10 : yp + 10;

        // followMouse.style.transform = `translate(${xp}px, ${-yp}px)`;
        followMouse.style.left = `${xp}px`;
        followMouse.style.top = `${yp}px`;
    });

    function getCoords(e) {
        let mouseX = e.clientX;
        let mouseY = e.clientY;

        return {
            xp: parseInt(mouseX),
            yp: parseInt(mouseY),
        };
    }

}


function clickSaveButton() {
    const get = document.querySelectorAll('[title="Save Current Map State"]')[0];
    get.click();
}


// ------------------------------------------

function clearFollowMouseDivs() {
    document.querySelectorAll('.follow-mouse').forEach(e => e.remove());
}
