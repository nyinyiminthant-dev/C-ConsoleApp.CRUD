using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.CRUD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EfCore.CRUD;

internal class EfCoreExamples
{
    private readonly AppDbContext _db;

    public EfCoreExamples()
    {
        _db = new AppDbContext();
    }

    public void Read()
    {
        var lst = _db.N.ToList();

        foreach (var item in lst)
        {
            Console.WriteLine("Id => " +item.id);
            Console.WriteLine("Name => " + item.name);
            Console.WriteLine("Email => " + item.email);
            Console.WriteLine("____________________________");
            Console.WriteLine();
        }
    }

    public void Edit(int id)
    {
        var item = _db.N.FirstOrDefault(x => x.id == id);

        if (item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        Console.WriteLine("Id => " + item.id);
        Console.WriteLine("Name => " + item.name);
        Console.WriteLine("Email => " + item.email);
        Console.WriteLine("____________________________");
        Console.WriteLine();

    }

    public void Insert(string name, string email)
    {
        var item = new UserDto
        {
            name = name,
            email = email
        };

        _db.N.Add(item);
        int i = _db.SaveChanges();

        string message = i > 0 ? "Insert Successful" : "Insert Failed";
        Console.WriteLine(message);
    }

    public void Update(int id,string name, string email)
    {
        var item = _db.N.FirstOrDefault(x => x.id == id);

        if(item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        item.name = name;
        item.email = email;
        _db.Entry(item).State = EntityState.Modified;
        int i = _db.SaveChanges();

        string message = i > 0 ? "Updating Successful" : "Updating Failed";
        Console.WriteLine(message);
    }

    public void Delete(int id)
    {
        var item = _db.N.FirstOrDefault(x => x.id == id);

        if (item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        _db.Entry(item).State = EntityState.Deleted;
        int i = _db.SaveChanges();

        string message = i > 0 ? "Updating Successful" : "Updating Failed";
        Console.WriteLine(message);
    }
}
