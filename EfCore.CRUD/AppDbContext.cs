using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Dto;
using Dapper.CRUD;
using Microsoft.EntityFrameworkCore;

namespace EfCore.CRUD;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(MyConnection._SqlConnectionStringBuilder.ConnectionString);
        }
    }

    public DbSet<UserDto> N { get; set; }
}
