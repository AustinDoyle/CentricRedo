using CentricRecognition9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CentricRecognition9.DAL
{
    public class Context: DbContext
    {
        public Context() : base("name=Centric")
        { }

        public DbSet<Employee> Employees { get; set; }
    

    }
}