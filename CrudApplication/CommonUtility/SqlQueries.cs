using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.CommonUtility
{
    public class SqlQueries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile(path: "SqlQueries.xml", optional: true, reloadOnChange: true).Build();
    
        public static string AddInformation { get { return _configuration[key: "AddInformation"]; } }
        public static string ReadAllInformation { get { return _configuration[key: "ReadAllInformation"]; } }
        public static string UpdateAllInformationById { get { return _configuration[key: "UpdateAllInformationById"]; } }
        public static string DeleteInformationById { get { return _configuration[key: "DeleteInformationById"]; } }
        public static string GetDeleteReadAllInformation { get { return _configuration[key: "GetDeleteReadAllInformation"]; } }
        public static string DeleteAllInformation { get { return _configuration[key: "DeleteAllInformation"]; } }
        public static string ReadInformationById { get { return _configuration[key: "ReadInformationById"]; } }
        public static string UpdateOneInformationById { get { return _configuration[key: "UpdateOneInformationById"]; } }
    }
}
