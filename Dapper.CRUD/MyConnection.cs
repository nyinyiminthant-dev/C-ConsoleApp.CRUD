using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Dto;

public static class MyConnection
{
    public static SqlConnectionStringBuilder _SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {

        DataSource = ".",
        InitialCatalog = "Nyi",
        UserID = "sa", 
        Password = "sasa@123",
        TrustServerCertificate = true,
    };
}
