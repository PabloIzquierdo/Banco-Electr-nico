using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Flus.Model
{
    public class FlusContext : DbContext
    {
        public FlusContext(DbContextOptions<FlusContext> options) 
            : base(options)
        {
        }
        
        public DbSet<FlusModel> FlusModels { get; set; }
    }
}
