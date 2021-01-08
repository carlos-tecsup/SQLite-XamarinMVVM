using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tarea.Interfaces;
using Tarea.Models;
using Xamarin.Forms;

namespace Tarea.DataContext
{
    public class AppDbContext : DbContext
    {
        string DbPath = string.Empty;

        public DbSet<Persona> Personas{ get; set; }

        public AppDbContext()
        {
            this.Database.EnsureCreated();
        }
        public AppDbContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IConfigDataBase>().GetDbPath();

            optionsBuilder.UseSqlite($"Filename={DbPath}");

        }

    }
}
