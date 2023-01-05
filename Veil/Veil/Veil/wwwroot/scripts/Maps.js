async function InitMap() {

    var location = await getCoords();
    setTextBox('lat', location.lat)
    setTextBox('long', location.long)




    var map = L.map('map', {
        center: [location.lat, location.long],
        zoom: 12
    });
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);
}


const getCoords = async () => {
        const pos = await new Promise((resolve, reject) => {
          navigator.geolocation.getCurrentPosition(resolve, reject);
        });
    
        return {
          long: pos.coords.longitude,
          lat: pos.coords.latitude,
        };
};


function setTextBox(type, value) {
    if (type === 'lat') {

        let latTextbox = document.getElementById("latitudeText");
        latTextbox.value = value;
    } else if (type === 'long') {
        let longTextbox = document.getElementById("longitudeText");
        longTextbox.value = value;
    }
}
