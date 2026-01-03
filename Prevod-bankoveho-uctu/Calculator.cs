using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Prevod_bankoveho_uctu
{
    internal class Calculator : Movies
    {
        public decimal VypocitajSnacky(Dictionary<string, int> snacky)
        {
            decimal suma = 0;

            foreach (var snack in snacky)
            {
                if (snack.Key == "Popcorn")
                    suma += snack.Value * 2m;
                else if (snack.Key == "Nachos")
                    suma += snack.Value * 2.5m;
                else if (snack.Key == "Sladkosti")
                    suma += snack.Value * 1m;
                else if (snack.Key == "Nápoje")
                    suma += snack.Value * 2.5m;
            }

            return suma;
        }

        public decimal VypocitajSpolu(decimal cenaFilmu, Dictionary<string, int> snacky)
        {
            return cenaFilmu + VypocitajSnacky(snacky);
        }
    }
}
