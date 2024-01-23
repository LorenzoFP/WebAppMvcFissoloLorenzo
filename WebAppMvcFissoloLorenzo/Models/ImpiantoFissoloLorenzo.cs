using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAppMvcFissoloLorenzo.Data;
using System;
using System.Linq;

namespace WebAppMvcFissoloLorenzo.Models
{
    public class ImpiantoFissoloLorenzo
    {

        public static void InizializzaFissoloLorenzo(IServiceProvider serviceProvider)
        {
            using (var context = new WebAppMvcFissoloLorenzoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebAppMvcFissoloLorenzoContext>>()))
            {
                // Look for any movies.
                if (context.RichiestaRimboso.Any())
                {
                    return;   // DB has been seeded
                }
                context.RichiestaRimboso.AddRange(
                    new RichiestaRimboso
                    {
                        Nome = "Paolo",
                        Cognome = "Mullace",
                        DataRichiesta = DateTime.Parse("2020-1-12"),
                        Telefono = 1298949,
                        email = "paolo.mullace@gmail.com",
                        PartitaIva = "IAS3213SDAD",
                        Richiesta = "Voglio Un rimborso",
                        Importo = 500
                    },
                    new RichiestaRimboso
                    {
                        Nome = "Thomas",
                        Cognome = "Pashollari",
                        DataRichiesta = DateTime.Parse("2021-3-31"),
                        Telefono = 1232549,
                        email = "thomas.pashollari@gmail.com",
                        PartitaIva = "SKAJDL123KA",
                        Richiesta = "Voglio Un rimborso",
                        Importo = 125
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
