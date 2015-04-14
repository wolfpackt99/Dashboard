using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Business
{
    public enum ActivityType
    {
        [Display(Name = "Manual Testing")]
        ManualTesting,
        [Display(Name = "Development")]
        Development,
        [Display(Name = "Automation Testing")]
        Automation,
        [Display(Name = "Design")]
        Design,
        [Display(Name = "Deployment")]
        Deployment,
        [Display(Name = "Documentation")]
        Documentation,
        [Display(Name = "Requirements")]
        Requirements,
        [Display(Name = "Test Cases")]
        TestCases,

    }
}
