using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Dashboard.Business
{
    public class TfsConnection
    {
        public T GetService<T>()
        {
            var uri = new Uri(Config.TfsServer);

            var netCreds = new NetworkCredential(Config.UserName, Config.Password);

            var tfs = new TfsTeamProjectCollection(uri, new TfsClientCredentials(new BasicAuthCredential(netCreds)));
            tfs.EnsureAuthenticated();

            var wis = tfs.GetService<T>();
            return wis;
        }

    }
}
