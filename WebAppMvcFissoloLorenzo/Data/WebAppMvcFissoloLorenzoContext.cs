using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMvcFissoloLorenzo.Models;

namespace WebAppMvcFissoloLorenzo.Data
{
    public class WebAppMvcFissoloLorenzoContext : DbContext
    {
        public WebAppMvcFissoloLorenzoContext (DbContextOptions<WebAppMvcFissoloLorenzoContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppMvcFissoloLorenzo.Models.RichiestaRimboso> RichiestaRimboso { get; set; } = default!;
    }
}
