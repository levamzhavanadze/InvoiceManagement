﻿using Microsoft.EntityFrameworkCore;
using WebAPIAuth.Models.Users;

namespace WebAPIAuth.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }

    }
}
