using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheMaxieInn.Models;

namespace TheMaxieInn.Data
{
    public class TheMaxieInnContext : DbContext
    {
        public TheMaxieInnContext (DbContextOptions<TheMaxieInnContext> options)
            : base(options)
        {
        }

        public DbSet<TheMaxieInn.Models.DogReservation> DogReservation { get; set; } = default!;
    }
}
