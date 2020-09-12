var customchart = customchart || {};

customchart.charts = (function () {
    var pub = {},
        _lineChart,
        _barChart,
        _dataURL = '/Home/GetChartData';

    var isMobile;

    pub.init = function (canvasbarid, canvaslineid) {
        //get elements where charts will go
        _barChart = document.getElementById(canvasbarid).getContext("2d");
        _lineChart = document.getElementById(canvaslineid).getContext("2d");

        if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            isMobile = true;
        }
        else {
            isMobile = false;
        }

        getChartData();
    };

    function getChartData() {
        $.ajax({
            url: _dataURL, //replace with url of service that returns json data
            type: 'GET',
            contentType: 'application/json',
            headers: {
                "accept": "application/json;odata=verbose",
            },
            dataType: 'json'
        }).done(function (data) {

            if (data.bar.datasets[0].data.length == 0) {
                var energyUsageBlock = document.getElementById("EnergyUsage");
                energyUsageBlock.style.display = "none";
            }
            else {
                //once we have data, create charts
                //if (isMobile) {
                //    createEnergyUsageBarChartMobile(data.d);
                //}
                //else {
                createEnergyUsageBarChart(data);

                createYearlyCompLineChart(data);
                //}
            }
        }).fail(function (error) {
            //error retreiving data
            console.log('error retreiving data');
        });
    }

    //function createEnergyUsageBarChartMobile(data) {

    //    function setColors(data) {

    //        var green = "#71a52c",
    //            blue = "#2ba4a4",
    //            colors = [],
    //            kwh = [],
    //            chargeAmt = [],
    //            labels = [],
    //            barLabel = [],
    //            dateRange = [],
    //            //currentYear,
    //            len;


    //        len = data.datasets[0].data.length;

    //        //if (len > 0 && data.month[len - 1].length > 1)
    //        //{
    //        //    currentYear = data.month[len - 1].split("/").pop();
    //        //}

    //        //set first to green if we have 13 periods
    //        if (len > 12) {
    //            colors.push(green);
    //            kwh.push(data.datasets[0].data[0]);
    //            chargeAmt.push(data.monthlyAmt[0]);
    //            //barLabel = data.labels[0] + ", " + (currentYear - 1);
    //            //labels.push(barLabel);
    //            labels.push(data.labels[0]);
    //            dateRange.push(data.month[0]);
    //        }

    //        if (len > 1) {
    //            colors.push(blue);
    //            kwh.push(data.datasets[0].data[len - 2]);
    //            chargeAmt.push(data.monthlyAmt[len - 2]);
    //            //barLabel = data.labels[len - 2] + ", " + data.month[len - 2].split("/").pop();
    //            //labels.push(barLabel);
    //            labels.push(data.labels[len - 2]);
    //            dateRange.push(data.month[len - 2]);
    //        }

    //        if (len > 0) {
    //            colors.push(green);
    //            kwh.push(data.datasets[0].data[len - 1]);
    //            chargeAmt.push(data.monthlyAmt[len - 1]);
    //            //barLabel = data.labels[len - 1] + ", " + currentYear;
    //            //labels.push(barLabel);
    //            labels.push(data.labels[len - 1]);
    //            dateRange.push(data.month[len - 1]);
    //        }

    //        data.datasets[0].data = kwh;
    //        data.monthlyAmt = chargeAmt;
    //        data.labels = labels;
    //        data.month = dateRange;

    //        data.datasets[0].backgroundColor = colors;


    //    }

    //    setColors(data.bar);
    //    var maxKwh = Math.max.apply(Math, data.bar.datasets[0].data) * 1.2;

    //    var config = {
    //        type: 'bar',
    //        data: data.bar,
    //        barShowStroke: false,
    //        options: {
    //            scales: {
    //                yAxes: [{
    //                    display: false
    //                    , ticks: {
    //                        beginAtZero: true,
    //                        min: 0,
    //                        max: maxKwh

    //                    }

    //                }],
    //                xAxes: [{
    //                    gridLines: {
    //                        display: false
    //                    },
    //                    scaleLabel: {
    //                        display: false
    //                    },
    //                }],
    //            },
    //            legend: {
    //                display: false
    //            },
    //            tooltips: {
    //                cornerRadius: 0,
    //                // backgroundColor: "#173c56",
    //                backgroundColor: 'rgba(23,60,86,1.0)',
    //                mode: 'single',
    //                callbacks: {
    //                    title: function (tooltipItems, data) {

    //                        var title = data.month[tooltipItems[0].index];

    //                        return title;
    //                    },
    //                    label: function (tooltipItem, data) {
    //                        return formatNumber(tooltipItem.yLabel) + " kWh";
    //                    }
    //                }
    //            },
    //            animation: {
    //                onProgress: function () {
    //                    var ctx = this.chart.ctx;

    //                    ctx.fillStyle = "#666"
    //                    ctx.textAlign = "center";
    //                    ctx.textBaseline = "bottom";

    //                    this.data.datasets.forEach(function (dataset) {
    //                        dataset.metaData.forEach(function (bar) {
    //                            ctx.fillText(formatNumber(dataset.data[bar._index]), bar._view.x - 2, bar._view.y);
    //                        });
    //                    })
    //                },
    //                onComplete: function () {
    //                    var ctx = this.chart.ctx;

    //                    ctx.fillStyle = "#666"
    //                    ctx.textAlign = "center";
    //                    ctx.textBaseline = "bottom";

    //                    this.data.datasets.forEach(function (dataset) {
    //                        dataset.metaData.forEach(function (bar) {
    //                            ctx.fillText(formatNumber(dataset.data[bar._index]), bar._model.x - 2, bar._model.y);
    //                        });
    //                    })
    //                }
    //            }
    //        }
    //    };
    //    //create chart
    //    var energyUsage = new Chart(_barChart, config);

    //    //Display charge data
    //    dispalyChargeData(data);


    //}

    function createEnergyUsageBarChart(data) {
        /* set colors for the bars
           last bar is current month/period, should be green.
           if we are displaying 13 periods, the first one will be from the same period a year ago, make it green as well
        */
        function setColors(data) {
            var green = "#71a52c",
                blue = "#2ba4a4",
                colors = [],
                greenFirst = 0,
                labels = [],
                len;


            len = data.datasets[0].data.length;


            //set first to green if we have 13 periods
            if (data.datasets[0].data.length > 12) {
                colors.push(green);
                greenFirst = 1;
            }
            for (var i = 0; i < len - 1 - greenFirst; i++) {
                colors.push(blue);
            }
            colors.push(green);

            data.datasets[0].backgroundColor = "#08CF1D";
            data.datasets[1].backgroundColor = "#FFFF33";
            data.datasets[2].backgroundColor = "#FF3333";

            data.datasets[0].label = "Good";
            data.datasets[1].label = "Warning";
            data.datasets[2].label = "Error";

            for (var i = 0; i < len; i++) {
                if (i == 0 || i == len - 1) {
                    labels[i] = data.labels[i];
                }
                else {
                    //remove year
                    //labels[i] = data.labels[i].substring(0, 3);
                    labels[i] = data.labels[i];

                }

            }

            data.labels = labels;
        }

        setColors(data.bar);
        var maxKcal1 = Math.max.apply(Math, data.bar.datasets[0].data);
        var maxKcal2 = Math.max.apply(Math, data.bar.datasets[1].data);
        var maxKcal3 = Math.max.apply(Math, data.bar.datasets[2].data);

        var maxKcal = Math.max(maxKcal1, maxKcal2, maxKcal3);

        //var maxKwh = Math.max.apply(Math, data.bar.datasets[0].data);
        var tttitle = '';
        var config = {
            type: 'bar',
            data: data.bar,
            barShowStroke: false,
            options: {
                scales: {
                    pointLabels: {
                        fontStyle: "bold",
                    },
                    yAxes: [{
                        display: true,
                        ticks: {
                            beginAtZero: true,
                            min: 0,
                            max: maxKcal * 1.1

                        }
                    }],
                    xAxes: [{
                        gridLines: {
                            display: false
                        },
                        scaleLabel: {
                            display: false
                        },
                    }],
                },
                legend: {
                    display: true
                },
                tooltips: {
                    //position: 'custom',
                    titleFontStyle: 'bold',
                    cornerRadius: 0,
                    //backgroundColor: "#173c56",
                    backgroundColor: 'rgba(23,60,86,1.0)',
                    mode: 'single',
                    callbacks: {
                        title: function (tooltipItems, data) {

                            var title = data.month[tooltipItems[0].index];
                            tttitle = data.datasets[tooltipItems[0].datasetIndex].label;
                            return title;
                        },
                        label: function (tooltipItem, data) {
                            return tttitle + ":" + formatNumber(tooltipItem.yLabel);
                        }
                    }
                },
                animation: {
                    onProgress: function () {
                        var ctx = this.chart.ctx;

                        ctx.fillStyle = "#666"
                        ctx.textAlign = "center";
                        ctx.textBaseline = "bottom";

                        this.data.datasets.forEach(function (dataset, i) {

                            dataset._meta[0].data.forEach(function (bar) {
                                ctx.fillText(formatNumber(dataset.data[bar._index]), bar._model.x - 2, bar._model.y - 5);
                            });

                            //this.chart.getDatasetMeta(i).data.forEach(function (p, j) {
                            //    ctx.fillText(datasets[i].data[j], p._model.x, p._model.y - 20);
                            //});

                            //this.data.datasets.forEach(function (dataset, i) {
                            //    dataset.metaData.forEach(function (bar) {
                            //        ctx.fillText(formatNumber(dataset.data[bar._index]), bar._view.x - 2, bar._view.y);
                            //    });
                            //dataset._meta[1].data.forEach(function (bar) {
                            //    ctx.fillText(formatNumber(dataset.data[bar._index]), bar._view.x - 2, bar._view.y - 5);
                            //});
                        })
                    },
                    onComplete: function () {
                        var ctx = this.chart.ctx;

                        ctx.fillStyle = "#666"
                        ctx.textAlign = "center";
                        ctx.textBaseline = "bottom";

                        this.data.datasets.forEach(function (dataset, i) {
                        //    dataset._meta[i].data.forEach(function (p, j) {
                        //        ctx.fillText(datasets[i].data[j], p._model.x, p._model.y - 20);
                        //    });
                        //this.data.datasets.forEach(function (dataset, i) {
                        //    dataset.metaData.forEach(function (bar) {
                        //        ctx.fillText(formatNumber(dataset.data[bar._index]), bar._view.x - 2, bar._view.y);
                        //    });
                        dataset._meta[0].data.forEach(function (bar) {
                            ctx.fillText(formatNumber(dataset.data[bar._index]), bar._model.x - 2, bar._model.y - 5);
                        });
                        //dataset._meta[1].data.forEach(function (bar) {
                        //    ctx.fillText(formatNumber(dataset.data[bar._index]), bar._view.x - 2, bar._view.y - 5);
                        //});
                    })
                }
            }
        }
    };
    //create chart
    var energyUsage = new Chart(_barChart, config);



    //Display charge data
    // dispalyChargeData(data);


}

    function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
}

function dispalyChargeData(data) {
    var currentUsage = document.getElementById("currentUsage");
    var currentCharge = document.getElementById("currentCharge");
    var currentDailyAmt = document.getElementById("currentDailyAmt");
    var lastUsage = document.getElementById("lastUsage");
    var lastCharge = document.getElementById("lastCharge");
    var dataLen = data.bar.datasets[0].data.length;

    if (dataLen > 0) {
        currentUsage.innerHTML = formatNumber(data.bar.datasets[0].data[dataLen - 1]);
        currentCharge.innerHTML = formatNumber(data.bar.monthlyAmt[dataLen - 1]);
        currentDailyAmt.innerHTML = formatNumber(data.bar.dailyAmt[dataLen - 1]);

        lastUsage.innerHTML = formatNumber(data.bar.datasets[0].data[dataLen - 2]);
        lastCharge.innerHTML = formatNumber(data.bar.monthlyAmt[dataLen - 2]);
    }
    else {

        currentUsage.innerHTML = 0;
        currentCharge.innerHTML = 0;
        currentDailyAmt.innerHTML = 0;

        lastUsage.innerHTML = 0;
        lastCharge.innerHTML = 0;
    }


    //var yearOverYear = document.getElementById("yearOverYear");

    //if (data.line.datasets[1].label == '0' || isMobile)
    //     yearOverYear.style.display = "none";
}

function createYearlyCompLineChart(data) {
    // set colors, first line is blue, second is green
    function setColors(data) {
        data.datasets.forEach(function (e, i) {
            if (i === 0) {
                e.label = "Good";
                e.borderColor = "#08CF1D";
                e.fillColor = "#08CF1D";
                e.backgroundColor = "#08CF1D";
                e.pointBorderColor = "#08CF1D";
                e.pointBackgroundColor = "#08CF1D";
            }
            if (i === 1) {
                e.label = "Warning";
                e.borderColor = "#FFFF33";
                e.fillColor = "#FFFF33";
                e.backgroundColor = "#FFFF33";
                e.pointBorderColor = "#FFFF33";
                e.pointBackgroundColor = "#FFFF33";
            }
            if (i === 2) {
                e.label = "Error";
                e.borderColor = "#FF3333";
                e.fillColor = "#FF3333";
                e.backgroundColor = "#FF3333";
                e.pointBorderColor = "#FF3333";
                e.pointBackgroundColor = "#FF3333";
            }
        });
    }

    setColors(data.line);

    //data.line.datasets[0].backgroundColor = "#08CF1D";
    //data.line.datasets[1].backgroundColor = "#FFFF33";
    //data.line.datasets[2].backgroundColor = "#FF3333";

    //data.line.datasets[0].label = "Good";
    //data.line.datasets[1].label = "Warning";
    //data.line.datasets[2].label = "Error";

    var maxKcal1 = Math.max.apply(Math, data.line.datasets[0].data);
    var maxKcal2 = Math.max.apply(Math, data.line.datasets[1].data);
    var maxKcal3 = Math.max.apply(Math, data.line.datasets[2].data);

    var maxKcal = Math.max(maxKcal1, maxKcal2, maxKcal3);

    var _hoveringPoint = {};
    var config = {
        type: 'line',
        data: data.line,
        options: {
            scales: {
                yAxes: [{
                    display: true,
                    ticks: {
                        beginAtZero: true,
                        min: 0,
                        max: maxKcal * 1.1

                    }
                }],
                xAxes: [{
                    gridLines: {
                        display: false
                    },
                    scaleLabel: {
                        display: false
                    },
                }],
            },
            elements: {
                line: {
                    tension: 0,
                    fill: false,
                    borderWidth: 5
                },
                point: {
                    radius: 8,
                    hoverRadius: 9,
                    borderRadius: 3
                }
            },
            tooltips: {
                mode: 'label',
                //backgroundColor: "#173c56",
                backgroundColor: 'rgba(23,60,86,1.0)',
                cornerRadius: 0,
                position: 'point',
                callbacks: {
                    title: function (tooltipItems, data) {
                        var title = data.month[tooltipItems[0].index];
                        //tttitle = data.datasets[tooltipItems[0].datasetIndex].label;
                        return title;
                    },
                    label: function (tooltipItem, data) {
                        return data.datasets[tooltipItem.datasetIndex].label + ": " + formatNumber(tooltipItem.yLabel) + " kcal";
                    }
                },
            },
        }
    }
    //create chart
    var yearlyComparison = new Chart.Line(_lineChart, config);
}

return pub;
}) ();

$(document).ready(function () {

    var canvas = document.getElementById('canvas-bar');
    var canvas1 = document.getElementById('canvas-line');
    customchart.charts.init('canvas-bar', 'canvas-line');

    fitToContainer(canvas);
    fitToContainer(canvas1);

    function fitToContainer(canvas) {
        // Make it visually fill the positioned parent
        canvas.style.width = '100%';
        canvas.style.height = '100%';
        // ...then set the internal size to match
        canvas.width = canvas.offsetWidth;
        canvas.height = canvas.offsetHeight;
    }

    //bind chart toggle functionality
    //$(".toggle-chart-view").click(function () {
    //    var textMonthly = "View Monthly Usage",
    //        textYear = "View Year over Year";

    //    //set text of link 
    //    if ($(this).text() === textMonthly) {
    //        $(this).text(textYear);
    //    } else {
    //        $(this).text(textMonthly);
    //    }

    //    //toggle charts being displayed
    //    $(".chart-container").toggleClass("hidden");
    //});
});

