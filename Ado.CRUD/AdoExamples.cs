using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Dto;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.AdoExamples;

public class AdoExample
{

    private readonly SqlConnection connecion = new SqlConnection(MyConnection._SqlConnectionStringBuilder.ConnectionString);


    public void Read()
    {
        connecion.Open();
        string query = "SELECT * FROM N";
        SqlCommand cmd = new SqlCommand(query, connecion);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        connecion.Close();

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("Id => " + dr["Id"]);
            Console.WriteLine("Name => " + dr["Name"]);
            Console.WriteLine("Email => " + dr["Email"]);
            Console.WriteLine();
            Console.WriteLine("____________________________");
            Console.WriteLine();
        }
    }

    public void Edit(int id)
    {
        connecion.Open();

        string query = $"SELECT * FROM N WHERE Id = '{id}'";

        SqlCommand cmd = new SqlCommand(query, connecion);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        connecion.Close();

        DataRow dr = dt.Rows[0];

        if (dr == null)
        {
            Console.WriteLine("No Data Found");
        }

        Console.WriteLine("Id => " + dr["Id"]);
        Console.WriteLine("Name => " + dr["Name"]);
        Console.WriteLine("Email => " + dr["Email"]);
        Console.WriteLine();
        Console.WriteLine("____________________________");
        Console.WriteLine();

    }

    public void Insert(string name, string email)
    {
        connecion.Open();

        string query = $@"
INSERT INTO [dbo].[N]
           ([Name]
           ,[Email])
     VALUES
           ('{name}'
           ,'{email}')";

        SqlCommand cmd = new SqlCommand(query, connecion);

        int i = cmd.ExecuteNonQuery();

        connecion.Close();

        string result = i > 0 ? "Insert Successful" : "Insert Failed";
        Console.WriteLine(result);

    }

    public void Update(int id, string name, string email)
    {
        connecion.Open();

        string query = $@"UPDATE [dbo].[N]
   SET [Name] = '{name}'
      ,[Email] = '{email}'
 WHERE Id = '{id}'";

        SqlCommand cmd = new SqlCommand(query, connecion);


        int i = cmd.ExecuteNonQuery();

        connecion.Close();

        string result = i > 0 ? "Updating Successful" : "Updating Failed";
        Console.WriteLine(result);
    }

    public void Delete(int id)
    {
        connecion.Open();

        string query = $@"DELETE FROM [dbo].[N]
      WHERE Id = '{id}'";

        SqlCommand cmd = new SqlCommand(query, connecion);

        int i = cmd.ExecuteNonQuery();

        connecion.Close();

        string result = i > 0 ? "Deleting Successful" : " Deleting Failed";
        Console.WriteLine(result);
    }
}
