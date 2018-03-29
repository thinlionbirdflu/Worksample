using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSample.ClassLibrary
{
    internal static class Config
    {
        internal static string FileLocation
        {
            get { return ConfigurationManager.AppSettings["JsonFileLocation"]; }
        }
    }
}
