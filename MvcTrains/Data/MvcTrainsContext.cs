using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcTrains.Models;

namespace MvcTrains.Data
{
    public class MvcTrainsContext : DbContext
    {
        public MvcTrainsContext(DbContextOptions<MvcTrainsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcTrains.Models.Train> Train { get; set; }
    }
}