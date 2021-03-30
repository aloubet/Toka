using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entidades;

namespace WebApi.DBContext
{
    public class ApiDBContext: DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options):base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<PersonasFisicas> PersonasFisicas { get; set; }
    }
}
