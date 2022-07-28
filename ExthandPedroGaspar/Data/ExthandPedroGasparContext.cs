using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExthandPedroGaspar.Models;

namespace ExthandPedroGaspar.Data
{
    public class ExthandPedroGasparContext : DbContext
    {
        public ExthandPedroGasparContext (DbContextOptions<ExthandPedroGasparContext> options)
            : base(options)
        {
        }

        public DbSet<ExthandPedroGaspar.Models.Trade> Trade { get; set; }
    }
}
