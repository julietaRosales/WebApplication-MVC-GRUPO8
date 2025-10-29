using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_MVC_GRUPO8.Models;


namespace WebApplication_MVC_GRUPO8.Context

{
    public class SistemaMantenimientoDBContext : DbContext
    {
        public SistemaMantenimientoDBContext(DbContextOptions<SistemaMantenimientoDBContext> options) : base(options)
        {
        }
        public DbSet<User> Usuarios { get; set; }
    }

}
