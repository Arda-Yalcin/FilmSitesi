using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlimStesiMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FlimStesiMvc.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}
        public DbSet<Theater> Theaters{get;set;}
    }
}