using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class ApplicationDdContext : DbContext
{
    public ApplicationDdContext(DbContextOptions<ApplicationDdContext> options) : base(options)
    {
    }

    public DbSet<ToDo> ToDos { get; set; }

}


