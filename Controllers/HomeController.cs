using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BarChartsV1.Models;

namespace BarChartsV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetChartData()
        {

            var chartVM = new ChartViewModel();
            chartVM = GetTempChartVM(4);
            return Json(chartVM);

        }

        private ChartViewModel GetTempChartVM(int dateRange)
        {
            var chartVM = new ChartViewModel();

            switch (dateRange)
            {
                case 1:
                    //Today
                    var dt = DateTime.Today.ToString("MMM dd, yyyy");
                    chartVM = new ChartViewModel
                    {
                        bar = new Bar()
                        {
                            labels = new List<string>() { dt
                    },
                            datasets = new List<Dataset>()
                    {
                        //Good message dataset
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                 500
                            }
                        },
                        //Warning message dataset
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                200
                            }
                        },
                        //Error messagae dataset
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                 100
                            }
                        }
                    },
                            month = new List<string>() { dt }
                            //month = new List<string>() { "9/8/2020 - 9/8/2020" }
                        },
                        line = new Line()
                        {
                            labels = new List<string>() { dt
                        },
                            datasets = new List<Dataset2>()
                        {
                        //Good messages
                        new Dataset2()
                        {
                           label =  "Good",
                            data = new List<int>()
                            {
                                800
                            }
                        },
                        //Warning messages
                        new Dataset2()
                        {
                            label =  "Warning",
                            data = new List<int>()
                            {
                                150
                            }
                        },
                        //Error messages
                        new Dataset2()
                        {
                            label =  "Error",
                            data = new List<int>()
                            {
                                50
                            }
                        }
                    },
                            //month = new List<string>()
                            //month = new List<string>() { "", "8/30/2019 - 9/30/2019", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        }
                    };

                    //root.D = d;
                    break;
                case 2:
                    //1 Week
                    var week1startdate = DateTime.Now.AddDays(-6).AddHours(-24);
                    var week1enddate = DateTime.Now.AddDays(-6);

                    var week2startdate = DateTime.Now.AddDays(-5).AddHours(-24);
                    var week2enddate = DateTime.Now.AddDays(-5);

                    var week3startdate = DateTime.Now.AddDays(-4).AddHours(-24);
                    var week3enddate = DateTime.Now.AddDays(-4);

                    var week4startdate = DateTime.Now.AddDays(-3).AddHours(-24);
                    var week4enddate = DateTime.Now.AddDays(-3);

                    var week5startdate = DateTime.Now.AddDays(-2).AddHours(-24);
                    var week5enddate = DateTime.Now.AddDays(-2);

                    var week6startdate = DateTime.Now.AddDays(-1).AddHours(-24);
                    var week6enddate = DateTime.Now.AddDays(-1);

                    var week7startdate = DateTime.Now.AddHours(-24);
                    var week7enddate = DateTime.Now;

                    var lbl7 = week1startdate.ToString("MMM dd, yyyy");
                    var lbl6 = week2startdate.ToString("MMM dd, yyyy");
                    var lbl5 = week3startdate.ToString("MMM dd, yyyy");
                    var lbl4 = week4startdate.ToString("MMM dd, yyyy");
                    var lbl3 = week5startdate.ToString("MMM dd, yyyy");
                    var lbl2 = week6startdate.ToString("MMM dd, yyyy");
                    var lbl1 = week7startdate.ToString("MMM dd, yyyy");

                    //var month1 = string.Format("{0} - {1}", week1startdate.ToString("MMM dd, yyyy"), week1enddate.ToString("MMM dd, yyyy"));
                    //var month2 = string.Format("{0} - {1}", week2startdate.ToString("MMM dd, yyyy"), week2enddate.ToString("MMM dd, yyyy"));
                    //var month3 = string.Format("{0} - {1}", week3startdate.ToString("MMM dd, yyyy"), week3enddate.ToString("MMM dd, yyyy"));
                    //var month4 = string.Format("{0} - {1}", week4startdate.ToString("MMM dd, yyyy"), week4enddate.ToString("MMM dd, yyyy"));


                    chartVM = new ChartViewModel
                    {
                        bar = new Bar()
                        {
                            labels = new List<string>() { lbl7,lbl6,lbl5,lbl4,lbl3,lbl2,lbl1
                    },
                            datasets = new List<Dataset>()
                    {
                        //Good messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600,
                                700,
                                800,
                                900
                            }
                        },
                        //Warning messages
                         new Dataset()
                        {
                            data = new List<int>()
                            {
                                50,
                                100,
                                120,
                                150,
                                200,
                                220,
                                250
                            }
                        },
                        //Error messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                20,
                                40,
                                50,
                                60,
                                70,
                                80,
                                90
                            }
                        }
                    },
                            month = new List<string>() { lbl7, lbl6, lbl5, lbl4, lbl3, lbl2, lbl1 }
                            //month = new List<string>() { "9/8/2020 - 9/8/2020", "9/7/2020 - 9/7/2020", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        },
                        line = new Line()
                        {
                            labels = new List<string>() { lbl7, lbl6,lbl5,lbl4,lbl3,lbl2,lbl1
                    },
                            datasets = new List<Dataset2>()
                    {
                        //Good
                        new Dataset2()
                        {
                            label =  "Good",
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600,
                                700,
                                800,
                                900
                            }
                        },
                        //Warning
                        new Dataset2()
                        {
                            label =  "Warning",
                            data = new List<int>()
                            {
                                50,
                                100,
                                120,
                                150,
                                200,
                                220,
                                250
                            }
                        },
                        //Error
                        new Dataset2()
                        {
                            label =  "Error",
                            data = new List<int>()
                            {
                                20,
                                40,
                                50,
                                60,
                                70,
                                80,
                                90
                            }
                        }
                    },
                            month = new List<string>() { lbl7, lbl6, lbl5, lbl4, lbl3, lbl2, lbl1 }
                            //month = new List<string>() { "", "8/30/2019 - 9/30/2019", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        }
                    };

                    //root.D = d;
                    break;
                case 3:
                    //2 Week
                    week1startdate = DateTime.Now.AddDays(-7);
                    week1enddate = DateTime.Now;

                    week2startdate = DateTime.Now.AddDays(-15);
                    week2enddate = DateTime.Now.AddDays(-8);

                    lbl1 = string.Format("{0} - {1}", week1startdate.ToString("MMMM dd"), week1enddate.ToString("MMMM dd"));
                    lbl2 = string.Format("{0} - {1}", week2startdate.ToString("MMMM dd"), week2enddate.ToString("MMMM dd"));

                    var month1 = string.Format("{0} - {1}", week1startdate.ToString("MMM dd, yyyy"), week1enddate.ToString("MMM dd, yyyy"));
                    var month2 = string.Format("{0} - {1}", week2startdate.ToString("MMM dd, yyyy"), week2enddate.ToString("MMM dd, yyyy"));

                    chartVM = new ChartViewModel
                    {
                        bar = new Bar()
                        {
                            labels = new List<string>() { lbl2, lbl1
                        },
                            datasets = new List<Dataset>()
                    {
                        //Good messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                300,
                                400
                            }
                        },
                        //Warning messages
                         new Dataset()
                        {
                            data = new List<int>()
                            {
                                50,
                                100
                            }
                        },
                        //Error messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                20,
                                40
                            }
                        }
                    },
                            month = new List<string>() { month2, month1 }
                            //month = new List<string>() { "9/8/2020 - 9/8/2020", "9/7/2020 - 9/7/2020", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        },
                        line = new Line()
                        {
                            labels = new List<string>() { lbl2, lbl1
                        },
                            datasets = new List<Dataset2>()
                    {
                        //Good
                        new Dataset2()
                        {
                            label =  "Good",
                            data = new List<int>()
                            {
                                300,
                                400
                            }
                        },
                        //Warning
                        new Dataset2()
                        {
                            label =  "Warning",
                            data = new List<int>()
                            {
                                50,
                                100
                            }
                        },
                        //Error
                        new Dataset2()
                        {
                            label =  "Error",
                            data = new List<int>()
                            {
                                20,
                                40
                            }
                        }
                    },

                            month = new List<string>() { month2, month1 }

                            //month = new List<string>() { "", "8/30/2019 - 9/30/2019", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        }
                    };

                    //root.D = d;
                    break;
                case 4:
                    //1 Month
                    week1startdate = DateTime.Now.AddDays(-7);
                    week1enddate = DateTime.Now;

                    week2startdate = DateTime.Now.AddDays(-15);
                    week2enddate = DateTime.Now.AddDays(-8);

                    week3startdate = DateTime.Now.AddDays(-23);
                    week3enddate = DateTime.Now.AddDays(-16);

                    week4startdate = DateTime.Now.AddDays(-30);
                    week4enddate = DateTime.Now.AddDays(-24);

                    lbl1 = string.Format("{0} - {1}", week1startdate.ToString("MMM dd, yyyy"), week1enddate.ToString("MMM dd, yyyy"));
                    lbl2 = string.Format("{0} - {1}", week2startdate.ToString("MMM dd, yyyy"), week2enddate.ToString("MMM dd, yyyy"));
                    lbl3 = string.Format("{0} - {1}", week3startdate.ToString("MMM dd, yyyy"), week3enddate.ToString("MMM dd, yyyy"));
                    lbl4 = string.Format("{0} - {1}", week4startdate.ToString("MMM dd, yyyy"), week4enddate.ToString("MMM dd, yyyy"));

                    month1 = string.Format("{0} - {1}", week1startdate.ToString("MMM dd, yyyy"), week1enddate.ToString("MMM dd, yyyy"));
                    month2 = string.Format("{0} - {1}", week2startdate.ToString("MMM dd, yyyy"), week2enddate.ToString("MMM dd, yyyy"));
                    var month3 = string.Format("{0} - {1}", week3startdate.ToString("MMM dd, yyyy"), week3enddate.ToString("MMM dd, yyyy"));
                    var month4 = string.Format("{0} - {1}", week4startdate.ToString("MMM dd, yyyy"), week4enddate.ToString("MMM dd, yyyy"));

                    chartVM = new ChartViewModel
                    {
                        bar = new Bar()
                        {
                            labels = new List<string>() { lbl4, lbl3, lbl2, lbl1 },
                            datasets = new List<Dataset>()
                    {
                        //Good messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600
                            }
                        },
                        //Warning messages
                         new Dataset()
                        {
                            data = new List<int>()
                            {
                                50,
                                100,
                                150,
                                200
                            }
                        },
                        //Error messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                20,
                                40,
                                60,
                                80
                            }
                        }
                    },
                            month = new List<string>() { month4, month3, month2, month1 }
                            //month = new List<string>() { "SEP 2 - SEP 8",
                            //                          "AUG 26 - SEP 1",
                            //                          "AUG 19 - SEP 25",
                            //                          "AUG 12 - AUG 18" }
                        },
                        line = new Line()
                        {
                            labels = new List<string>() { lbl4, lbl3, lbl2, lbl1
                    },
                            datasets = new List<Dataset2>()
                    {
                        //Good
                        new Dataset2()
                        {
                            label =  "Good",
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600
                            }
                        },
                        //Warning
                        new Dataset2()
                        {
                            label =  "Warning",
                            data = new List<int>()
                            {
                                50,
                                100,
                                150,
                                200
                            }
                        },
                        //Error
                        new Dataset2()
                        {
                            label =  "Error",
                            data = new List<int>()
                            {
                                20,
                                40,
                                60,
                                80
                            }
                        }
                    },
                            month = new List<string>() { month4, month3, month2, month1 }
                            //month = new List<string>() { "", "8/30/2019 - 9/30/2019", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        }
                    };

                    //root.D = d;
                    break;
                case 5:
                    //3 Month
                    var now = new DateTime();
                    int daysinmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    week1startdate = DateTime.Now.AddDays(-daysinmonth);
                    week1enddate = DateTime.Now;

                    now = DateTime.Now.AddMonths(-1);
                    week2startdate = new DateTime(now.Year, now.Month, 1);
                    week2enddate = week2startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-2);
                    week3startdate = new DateTime(now.Year, now.Month, 1);
                    week3enddate = week3startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-3);
                    week4startdate = new DateTime(now.Year, now.Month, 1);
                    week4enddate = week4startdate.AddMonths(1).AddDays(-1);

                    lbl1 = week1startdate.ToString("MMM,yy");
                    lbl2 = week2startdate.ToString("MMM,yy");
                    lbl3 = week3startdate.ToString("MMM,yy");
                    lbl4 = week4startdate.ToString("MMM,yy");

                    month1 = string.Format("{0} - {1}", week1startdate.ToString("MMM dd, yyyy"), week1enddate.ToString("MMM dd, yyyy"));
                    month2 = string.Format("{0} - {1}", week2startdate.ToString("MMM dd, yyyy"), week2enddate.ToString("MMM dd, yyyy"));
                    month3 = string.Format("{0} - {1}", week3startdate.ToString("MMM dd, yyyy"), week3enddate.ToString("MMM dd, yyyy"));
                    month4 = string.Format("{0} - {1}", week4startdate.ToString("MMM dd, yyyy"), week4enddate.ToString("MMM dd, yyyy"));
                    //var month5 = string.Format("{0} - {1}", week5startdate.ToString("MMM dd, yyyy"), week5enddate.ToString("MMM dd, yyyy"));

                    chartVM = new ChartViewModel
                    {
                        bar = new Bar()
                        {
                            labels = new List<string>() { lbl4, lbl3, lbl2, lbl1
                        },
                            datasets = new List<Dataset>()
                    {
                        //Good messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600
                            }
                        },
                        //Warning messages
                         new Dataset()
                        {
                            data = new List<int>()
                            {
                                50,
                                100,
                                150,
                                200
                            }
                        },
                        //Error messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                20,
                                40,
                                60,
                                80
                            }
                        }
                    },
                            month = new List<string>() { month4, month3, month2, month1 }
                            //month = new List<string>() { "9/8/2020 - 9/8/2020", "9/7/2020 - 9/7/2020", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        },
                        line = new Line()
                        {
                            labels = new List<string>() { lbl4, lbl3, lbl2, lbl1
                    },
                            datasets = new List<Dataset2>()
                    {
                        //Good
                        new Dataset2()
                        {
                            label =  "Good",
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600
                            }
                        },
                        //Warning
                        new Dataset2()
                        {
                            label =  "Warning",
                            data = new List<int>()
                            {
                                50,
                                100,
                                150,
                                200
                            }
                        },
                        //Error
                        new Dataset2()
                        {
                            label =  "Error",
                            data = new List<int>()
                            {
                                20,
                                40,
                                60,
                                80
                            }
                        }
                    },
                            month = new List<string>() { month4, month3, month2, month1 }
                            //month = new List<string>() { "", "8/30/2019 - 9/30/2019", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        }
                    };

                    //root.D = d;
                    break;
                case 6:
                    //6 Month
                    now = new DateTime();
                    daysinmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                    week1startdate = DateTime.Now.AddDays(-daysinmonth);
                    week1enddate = DateTime.Now;

                    now = DateTime.Now.AddMonths(-1);
                    week2startdate = new DateTime(now.Year, now.Month, 1);
                    week2enddate = week2startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-2);
                    week3startdate = new DateTime(now.Year, now.Month, 1);
                    week3enddate = week3startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-3);
                    week4startdate = new DateTime(now.Year, now.Month, 1);
                    week4enddate = week4startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-4);
                    week5startdate = new DateTime(now.Year, now.Month, 1);
                    week5enddate = week5startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-5);
                    week6startdate = new DateTime(now.Year, now.Month, 1);
                    week6enddate = week6startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-6);
                    week7startdate = new DateTime(now.Year, now.Month, 1);
                    week7enddate = week7startdate.AddMonths(1).AddDays(-1);

                    lbl1 = week1startdate.ToString("MMM,yy");
                    lbl2 = week2startdate.ToString("MMM,yy");
                    lbl3 = week3startdate.ToString("MMM,yy");
                    lbl4 = week4startdate.ToString("MMM,yy");
                    lbl5 = week5startdate.ToString("MMM,yy");
                    lbl6 = week6startdate.ToString("MMM,yy");
                    lbl7 = week7startdate.ToString("MMM,yy");

                    month1 = string.Format("{0} - {1}", week1startdate.ToString("MMM dd, yyyy"), week1enddate.ToString("MMM dd, yyyy"));
                    month2 = string.Format("{0} - {1}", week2startdate.ToString("MMM dd, yyyy"), week2enddate.ToString("MMM dd, yyyy"));
                    month3 = string.Format("{0} - {1}", week3startdate.ToString("MMM dd, yyyy"), week3enddate.ToString("MMM dd, yyyy"));
                    month4 = string.Format("{0} - {1}", week4startdate.ToString("MMM dd, yyyy"), week4enddate.ToString("MMM dd, yyyy"));
                    var month5 = string.Format("{0} - {1}", week5startdate.ToString("MMM dd, yyyy"), week5enddate.ToString("MMM dd, yyyy"));
                    var month6 = string.Format("{0} - {1}", week6startdate.ToString("MMM dd, yyyy"), week6enddate.ToString("MMM dd, yyyy"));
                    var month7 = string.Format("{0} - {1}", week7startdate.ToString("MMM dd, yyyy"), week7enddate.ToString("MMM dd, yyyy"));

                    chartVM = new ChartViewModel
                    {
                        bar = new Bar()
                        {
                            labels = new List<string>() { lbl7,lbl6,lbl5,lbl4,lbl3,lbl2,lbl1
                        },
                            datasets = new List<Dataset>()
                    {
                        //Good messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600,
                                700,
                                800,
                                900
                            }
                        },
                        //Warning messages
                         new Dataset()
                        {
                            data = new List<int>()
                            {
                                50,
                                100,
                                150,
                                200,
                                250,
                                300,
                                350
                            }
                        },
                        //Error messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                20,
                                40,
                                60,
                                80,
                                100,
                                120,
                                140
                            }
                        }
                    },
                            month = new List<string>() { month7, month6, month5, month4, month3, month2, month1 }
                            //month = new List<string>() { "9/8/2020 - 9/8/2020", "9/7/2020 - 9/7/2020", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        },
                        line = new Line()
                        {
                            labels = new List<string>() {lbl7,lbl6,lbl5,lbl4,lbl3,lbl2,lbl1
                    },
                            datasets = new List<Dataset2>()
                    {
                        //Good
                        new Dataset2()
                        {
                            label =  "Good",
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600,
                                700,
                                800,
                                900
                            }
                        },
                        //Warning
                        new Dataset2()
                        {
                            label =  "Warning",
                            data = new List<int>()
                            {
                                50,
                                100,
                                150,
                                200,
                                250,
                                300,
                                350
                            }
                        },
                        //Error
                        new Dataset2()
                        {
                            label =  "Error",
                            data = new List<int>()
                            {
                                20,
                                40,
                                60,
                                80,
                                100,
                                120,
                                140
                            }
                        }
                    }

                            //month = new List<string>() { "", "8/30/2019 - 9/30/2019", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        }
                    };

                    //root.D = d;
                    break;
                default:
                    // 1 year
                    now = new DateTime();
                    daysinmonth = DateTime.Now.Day - 1;
                    week1startdate = DateTime.Now.AddDays(-daysinmonth);
                    week1enddate = DateTime.Now;

                    now = DateTime.Now.AddMonths(-1);
                    week2startdate = new DateTime(now.Year, now.Month, 1);
                    week2enddate = week2startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-2);
                    week3startdate = new DateTime(now.Year, now.Month, 1);
                    week3enddate = week3startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-3);
                    week4startdate = new DateTime(now.Year, now.Month, 1);
                    week4enddate = week4startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-4);
                    week5startdate = new DateTime(now.Year, now.Month, 1);
                    week5enddate = week5startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-5);
                    week6startdate = new DateTime(now.Year, now.Month, 1);
                    week6enddate = week6startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-6);
                    week7startdate = new DateTime(now.Year, now.Month, 1);
                    week7enddate = week7startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-7);
                    var week8startdate = new DateTime(now.Year, now.Month, 1);
                    var week8enddate = week8startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-8);
                    var week9startdate = new DateTime(now.Year, now.Month, 1);
                    var week9enddate = week9startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-9);
                    var week10startdate = new DateTime(now.Year, now.Month, 1);
                    var week10enddate = week10startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-10);
                    var week11startdate = new DateTime(now.Year, now.Month, 1);
                    var week11enddate = week11startdate.AddMonths(1).AddDays(-1);

                    now = DateTime.Now.AddMonths(-11);
                    var week12startdate = new DateTime(now.Year, now.Month, 1);
                    var week12enddate = week12startdate.AddMonths(1).AddDays(-1);

                    lbl1 = week1enddate.ToString("MMM,yy");
                    lbl2 = week2startdate.ToString("MMM,yy");
                    lbl3 = week3startdate.ToString("MMM,yy");
                    lbl4 = week4startdate.ToString("MMM,yy");
                    lbl5 = week5startdate.ToString("MMM,yy");
                    lbl6 = week6startdate.ToString("MMM,yy");
                    lbl7 = week7startdate.ToString("MMM,yy");
                    var lbl8 = week8startdate.ToString("MMM,yy");
                    var lbl9 = week9startdate.ToString("MMM,yy");
                    var lbl10 = week10startdate.ToString("MMM,yy");
                    var lbl11 = week11startdate.ToString("MMM,yy");
                    var lbl12 = week12startdate.ToString("MMM,yy");

                    month1 = string.Format("{0} - {1}", week1startdate.ToString("MMM dd, yyyy"), week1enddate.ToString("MMM dd, yyyy"));
                    month2 = string.Format("{0} - {1}", week2startdate.ToString("MMM dd, yyyy"), week2enddate.ToString("MMM dd, yyyy"));
                    month3 = string.Format("{0} - {1}", week3startdate.ToString("MMM dd, yyyy"), week3enddate.ToString("MMM dd, yyyy"));
                    month4 = string.Format("{0} - {1}", week4startdate.ToString("MMM dd, yyyy"), week4enddate.ToString("MMM dd, yyyy"));
                    month5 = string.Format("{0} - {1}", week5startdate.ToString("MMM dd, yyyy"), week5enddate.ToString("MMM dd, yyyy"));
                    month6 = string.Format("{0} - {1}", week6startdate.ToString("MMM dd, yyyy"), week6enddate.ToString("MMM dd, yyyy"));
                    month7 = string.Format("{0} - {1}", week7startdate.ToString("MMM dd, yyyy"), week7enddate.ToString("MMM dd, yyyy"));
                    var month8 = string.Format("{0} - {1}", week8startdate.ToString("MMM dd, yyyy"), week8enddate.ToString("MMM dd, yyyy"));
                    var month9 = string.Format("{0} - {1}", week9startdate.ToString("MMM dd, yyyy"), week9enddate.ToString("MMM dd, yyyy"));
                    var month10 = string.Format("{0} - {1}", week10startdate.ToString("MMM dd, yyyy"), week10enddate.ToString("MMM dd, yyyy"));
                    var month11 = string.Format("{0} - {1}", week11startdate.ToString("MMM dd, yyyy"), week11enddate.ToString("MMM dd, yyyy"));
                    var month12 = string.Format("{0} - {1}", week12startdate.ToString("MMM dd, yyyy"), week12enddate.ToString("MMM dd, yyyy"));

                    chartVM = new ChartViewModel
                    {
                        bar = new Bar()
                        {
                            labels = new List<string>() { lbl12, lbl11, lbl10, lbl9, lbl8, lbl7, lbl6, lbl5, lbl4, lbl3, lbl2, lbl1
                        },
                            datasets = new List<Dataset>()
                    {
                        //Good messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600,
                                700,
                                800,
                                900,
                                950,
                                980,
                                990,
                                1100,
                                1200
                            }
                        },
                        //Warning messages
                         new Dataset()
                        {
                            data = new List<int>()
                            {
                                50,
                                100,
                                150,
                                200,
                                250,
                                300,
                                350,
                                380,
                                450,
                                500,
                                550,
                                600
                            }
                        },
                        //Error messages
                        new Dataset()
                        {
                            data = new List<int>()
                            {
                                20,
                                40,
                                60,
                                80,
                                100,
                                120,
                                140,
                                160,
                                180,
                                200,
                                220,
                                240
                            }
                        }
                    },
                            month = new List<string>() { month12, month11, month10, month9, month8, month7, month6, month5, month4, month3, month2, month1 }
                            // month = new List<string>()
                            //month = new List<string>() { "9/8/2020 - 9/8/2020", "9/7/2020 - 9/7/2020", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        },
                        line = new Line()
                        {
                            labels = new List<string>() { lbl12, lbl11, lbl10, lbl9, lbl8, lbl7, lbl6, lbl5, lbl4, lbl3, lbl2, lbl1
                        },
                            datasets = new List<Dataset2>()
                    {
                        //Good
                        new Dataset2()
                        {
                            label =  "Good",
                            data = new List<int>()
                            {
                                300,
                                400,
                                500,
                                600,
                                700,
                                800,
                                900,
                                950,
                                980,
                                990,
                                1100,
                                1200

                            }
                        },
                        //Warning
                        new Dataset2()
                        {
                            label =  "Warning",
                            data = new List<int>()
                            {
                                50,
                                100,
                                150,
                                200,
                                250,
                                300,
                                350,
                                380,
                                450,
                                500,
                                550,
                                600
                            }
                        },
                        //Error
                        new Dataset2()
                        {
                            label =  "Error",
                            data = new List<int>()
                            {
                                20,
                                40,
                                60,
                                80,
                                100,
                                120,
                                140,
                                160,
                                180,
                                200,
                                220,
                                240
                            }
                        }
                    },
                            month = new List<string>() { month12, month11, month10, month9, month8, month7, month6, month5, month4, month3, month2, month1 }
                            //month = new List<string>() { "", "8/30/2019 - 9/30/2019", "9/30/2019 - 10/30/2019", "10/30/2019 - 11/27/2019", "11/27/2019 - 12/31/2019", "12/31/2019 - 1/30/2020", "1/30/2020 - 2/28/2020", "2/28/2020 - 3/31/2020", "3/31/2020 - 4/29/2020", "4/29/2020 - 5/29/2020", "5/29/2020 - 6/30/2020", "6/30/2020 - 7/31/2020", "7/31/2020 - 8/31/2020" }
                        }
                    };

                    //root.D = d;
                    break;
            }

            return chartVM;
        }

    }
}
