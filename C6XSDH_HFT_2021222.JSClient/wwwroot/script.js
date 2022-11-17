fetch('http://localhost:30408/bike')
    .then(x => x.json())
    .then(y => console.log(y));