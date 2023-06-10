var map = L.map("map").setView([0, 0], 2);

// Load and display the tile layer (e.g., OpenStreetMap)
L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    attribution:
        'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors',
    maxZoom: 18,
}).addTo(map);

// Fetch latitude and longitude data from the server using AJAX
fetch("get_markers.php")
    .then((response) => response.json())
    .then((data) => {
        // Add markers to the map
        data.forEach((marker) => {
            L.marker([marker.latitude, marker.longitude]).addTo(map);
        });
    })
    .catch((error) => console.log(error));
