using Insight.Database;
using Ninject;
using System;
using System.Data.SqlClient;

namespace ADN.DM
{
    class DMInsight
    {
        [Inject]
        public static SqlConnection DefaultCnn()
        {
            SqlInsightDbProvider.RegisterProvider();
            //return new SqlConnection(Environment.GetEnvironmentVariable("stringConnectionSQL"));
            return new SqlConnection("Data Source=projectadn-server.database.windows.net;Initial Catalog=Database-ADN;User ID=Administrador;Password=Prueba123;MultipleActiveResultSets=True;Connect Timeout=3000;");


        }
    }
}
