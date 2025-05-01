

using Microsoft.EntityFrameworkCore;
using System;
using TP6.Models;
namespace TP6.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Categorie> Categories { get; set; }
    }
}
