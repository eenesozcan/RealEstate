using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace RealEstate.FacadeLayer.Connection
{
    public class DbConnection
    {
     public static   SqlConnection sqlConnection=new SqlConnection("Data Source = DESKTOP-CSTSJL1\\MSSQLSERVER2019; initial catalog = DbRealEstate; integrated security = true");
    }
}
