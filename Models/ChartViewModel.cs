using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarChartsV1.Models
{
    public class ChartViewModel
    {
        public Bar bar { get; set; }
        public Line line { get; set; }
    }

    public class Dataset
    {
        public List<int> data { get; set; }
    }

    public class Bar
    {
        public List<string> labels { get; set; }
        public List<string> month { get; set; }
        //public List<double> monthlyAmt { get; set; }
        //public List<double> dailyAmt { get; set; }
        public List<Dataset> datasets { get; set; }
    }

    public class Dataset2
    {
        public string label { get; set; }
        public List<int> data { get; set; }
    }

    public class Line
    {
        public List<string> month { get; set; }
        public List<string> labels { get; set; }
        public List<Dataset2> datasets { get; set; }
    }
}
