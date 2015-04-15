using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.TeamFoundation.Framework.Client.Catalog.Objects;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Dashboard.Business
{
    public class FieldValues
    {
        public static List<string> GetActivityItems()
        {
            var wis = new TfsConnection().GetService<WorkItemStore>();
            var proj = wis.Projects[Config.Project];
            var wit = proj.WorkItemTypes["Task"];
            var xmlDoc = wit.Export(false);
            var nodes = xmlDoc.SelectNodes("//FIELDS/FIELD[@name='Activity']/SUGGESTEDVALUES");
            if (nodes != null && nodes.Count == 1)
            {
                var suggested = nodes[0];

                var activity = new List<string>();
                var listItems = suggested.SelectNodes("LISTITEM");
                if (listItems != null && listItems.Count > 0)
                {
                    var list = (from XmlNode item in listItems select item.Attributes["value"].Value).ToList();
                    return list;
                }
            }
            return null;
        }
    }
}