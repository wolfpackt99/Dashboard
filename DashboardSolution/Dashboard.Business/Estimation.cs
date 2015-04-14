using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JB.Tfs.Common;
using Microsoft.TeamFoundation.Client.Internal;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Client;

namespace Dashboard.Business
{
    public class Estimation
    {
        private async Task<WorkRemaining> GetWorkRemaining(string path, ActivityType activity, HourRemainingType type = HourRemainingType.OriginalValue)
        {
            const string query = "Select [Remaining Work] from WorkItems where [Work Item Type] = @Type " + 
                                 " and [Team Project] = @Project and [Iteration Path] = @IterationPath" + 
                                 " and [Activity] = @ActivityName";
            var dict = new Dictionary<string, string>
            {
                {"Type", "Task"},
                {"Project", Config.Project },
                {"IterationPath", string.Format("{0}\\{1}", Config.Project, path) },
                {"ActivityName", activity.GetDisplayAttrString() }
            };

            var wis = new TfsConnection().GetService<WorkItemStore>();

            var result = wis.Query(query, dict);
            var list = result.Cast<WorkItem>();
            var hours =
                list.SelectMany(s => s.Fields.Cast<Field>()).Where(s => s.Name == "Remaining Work").Sum(s =>
                {
                    var val = s.Value;
                    if (type == HourRemainingType.OriginalValue)
                    {
                        val = s.OriginalValue;
                    }
                    return val == null ? 0 : System.Convert.ToDecimal(s.Value);
                });


            return new WorkRemaining
            {
                ActivityType = activity,
                Hours = hours
            };
        }

        public async Task<Dictionary<ActivityType, decimal>> GetAllWorkRemaining(string path, HourRemainingType type = HourRemainingType.OriginalValue)
        {
            var list = Enum.GetValues(typeof (ActivityType)).Cast<ActivityType>().Select(activity => GetWorkRemaining(path, activity, type)).ToList();

            var decimals = await Task.WhenAll(list);

            return decimals.ToDictionary(s => s.ActivityType, r => r.Hours);
        }

        
    }
}
