using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dashboard.Business;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dashboard.Web.Models
{
    public class EstimationModel
    {
        public string ActivityType { get; set; }
        public decimal Hours { get; set; }
    }
}