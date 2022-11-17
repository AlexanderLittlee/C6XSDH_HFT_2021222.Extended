let bikes = [];

let connection;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:30408/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on
        ("BikeCreated", (user, message) => {
            getdata();

        });
    connection.on
        ("BikeDeleted", (user, message) => {
            getdata();

        });

    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:30408/bike')
        .then(x => x.json())
        .then(y => {
            bikes = y;
           // console.log(bikes)
            display();
        });

}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    bikes.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.model + "</td><td>"
        + t.price + "</td><td>" + t.rating + "</td>" +
`<td><button type="button" onclick="remove(${t.id})">Delete</button>`
"</td ></tr > ";

        console.log(t.id)
    });
}

function remove(id) {
    fetch('http://localhost:30408/bike/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let model = document.getElementById('bmodel').value;
    let price = document.getElementById('bprice').value;
    let rating = document.getElementById('brating').value;
    fetch('http://localhost:30408/bike', {
        method: 'POST',
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify(
            { model: model, price: price, rating: rating }),})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
    
}