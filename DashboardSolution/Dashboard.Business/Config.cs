using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Business
{
    public static class Config
    {
        public static String TfsServer
        {
            get { return ConfigurationManager.AppSettings.Get("TfsServer") ?? string.Empty; }
        }

        public static string UserName
        {
            get { return ConfigurationManager.AppSettings.Get("UserName") ?? string.Empty; }
        }

        public static string Password
        {
            get { return ConfigurationManager.AppSettings.Get("Password") ?? string.Empty; }
        }

        public static string Project
        {
            get { return ConfigurationManager.AppSettings.Get("Project") ?? string.Empty; }
        }
    }
}
