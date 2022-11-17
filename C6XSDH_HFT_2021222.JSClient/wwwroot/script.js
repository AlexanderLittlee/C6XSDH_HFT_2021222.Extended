let bikes = [];

fetch('http://localhost:30408/bike')
    .then(x => x.json())
    .then(y => {
        bikes = y;
        console.log(bikes)
        display();
    });

function display() {
    bikes.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.model + "</td><td>"
            + t.price + "</td><td>" + t.rating + "</td></tr>";

        console.log(t.id)
    });
}