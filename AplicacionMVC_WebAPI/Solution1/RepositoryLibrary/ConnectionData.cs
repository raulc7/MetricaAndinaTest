using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace RepositoryLibrary
{
    public class ConnectionData
    {
        public static String dbCn = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;
    }
}
