using CODEWITHMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CODEWITHMVC.Data
{
    public class EMPContext:DbContext
    {
        public EMPContext(DbContextOptions<EMPContext> options):base(options)
        {

        }
        public DbSet<EMPMASTER> Employees { get; set; }
    }
}
