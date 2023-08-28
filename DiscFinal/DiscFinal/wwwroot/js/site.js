const apiKey = '2fe7354686ed4b60834bc601bc7dc012';
const membershipId = '4611686018483573770'; // This is the player's unique identifier

const apiUrl = `https://www.bungie.net/Platform/Destiny2/3/Profile/${membershipId}/?components=200`;

fetch(apiUrl ,{
    headers: {
        'X-API-Key': '2fe7354686ed4b60834bc601bc7dc012',
    },
})
    .then(response => response.json())
    .then(data => {
        // Handle the data here
        console.log(data);
    })
    .catch(error => {
        console.error('Error:', error);
    });
