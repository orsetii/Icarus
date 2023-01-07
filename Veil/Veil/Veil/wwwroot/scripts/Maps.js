async function InitMap() {

    var pos = await getCurrentPosition();

    setTextBox('lat', pos.coords.latitude);
    setTextBox('long', pos.coords.longitude);


    var map = L.map('map', {
        center: [pos.coords.latitude, pos.coords.longitude],
        zoom: 12
    });
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);
    console.log("map initalized");
}


const getCurrentPosition = async () => {
    const options = {
        enableHighAccuracy: true,
        timeout: 5000,
        maximumAge: 0
    };
    let pos = await new Promise((resolve, reject) => {
          navigator.geolocation.getCurrentPosition(resolve, reject);
        });

    

    console.log('Your current position is:');
    console.log(`Latitude : ${pos.coords.latitude}`);
    console.log(`Longitude: ${pos.coords.longitude}`);
    console.log(`More or less ${pos.coords.accuracy} meters.`);

    return pos;

};

const options = {
    enableHighAccuracy: true,
    timeout: 5000,
    maximumAge: 0
};

function error(err) {
    console.warn(`ERROR(${err.code}): ${err.message}`);
    return err;
}


function setTextBox(type, value) {
    if (type === 'lat') {
        let latTextbox = document.getElementById("latitudeText");
        latTextbox.value = value;
    } else if (type === 'long') {
        let longTextbox = document.getElementById("longitudeText");
        longTextbox.value = value;
    }
}
