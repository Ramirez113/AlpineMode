document.addEventListener("DOMContentLoaded", function () {
    function createPieChart(canvasId, data) {
        new Chart(document.getElementById(canvasId), {
            type: "pie",
            data: {
                labels: Object.keys(data),
                datasets: [{
                    data: Object.values(data),
                    backgroundColor: ["#FF6384", "#36A2EB", "#FFCE56", "#4BC0C0", "#9966FF"]
                }]
            }
        });
    }

    createPieChart("ordersChart", ordersData);
    createPieChart("countriesChart", countriesData);
    createPieChart("toursChart", toursData);
});
