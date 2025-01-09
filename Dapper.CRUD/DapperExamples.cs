using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Dto;
using Microsoft.Data.SqlClient;

namespace Dapper.CRUD;

internal class DapperExamples
{
   private readonly    IDbConnection _db;

    public DapperExamples ()
    {
        _db = new SqlConnection(MyConnection._SqlConnectionStringBuilder.ConnectionString);
    }
public void Read()
    {
        string query = "SELECT * FROM N";

      
        var lst = _db.Query<UserDto>(query).ToList();

        foreach (var item in lst)
        {
            Console.WriteLine("Id => " + item.id);
            Console.WriteLine("Name => " + item.name);
            Console.WriteLine("Email => " + item.email);
            Console.WriteLine("__________________________");
            Console.WriteLine();
        }

    }

    public void Edit(int id)
    {
        string query = $"SELECT * FROM N WHERE Id = {id}";
        var item =  _db.Query<UserDto>(query, new UserDto { id = id}).FirstOrDefault();

        if(item == null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }

        Console.WriteLine("Id => " + item.id);
        Console.WriteLine("Name => " + item.name);
        Console.WriteLine("Email => " + item.email);
        Console.WriteLine("__________________________");
        Console.WriteLine();

    }

    public void Insert(string name, string email)
    {
        string query = $@"
INSERT INTO [dbo].[N]
           ([Name]
           ,[Email])
     VALUES
           ('{name}'
           ,'{email}')";

        var i = _db.Execute(query);

        string message = i > 0 ? "Insert Successful" : "Insert Failed";
        Console.WriteLine(message);

    }

    public void Update (int id, string name, string email)
    {
        string query = $@"UPDATE [dbo].[N]
   SET [Name] = '{name}'
      ,[Email] = '{email}'
 WHERE Id = '{id}'";

        var i = _db.Execute(query);

        string message = i > 0 ? "Updating Successful" : "Updating Failed";
        Console.WriteLine(message);
    }

    public void Delete (int id)
    {
        string query = $@"DELETE FROM [dbo].[N]
      WHERE Id = '{id}'";

        int i = _db.Execute(query);

        string message = i > 0 ? "Deleting Successful" : "Deleting Failed";
        Console.WriteLine(message);
    }
}
