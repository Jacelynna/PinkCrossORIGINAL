using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinkCross.Models;

namespace PinkCross.Data
{
    public class PinkCrossContext : DbContext
    {
        public PinkCrossContext (DbContextOptions<PinkCrossContext> options)
            : base(options)
        {
        }

        public DbSet<PinkCross.Models.DonorProfile> DonorProfile { get; set; }

        public DbSet<PinkCross.Models.DonationRecord> DonationRecord { get; set; }
    }
}
