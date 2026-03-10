using System;
using System.Collections.Generic;
using System.Linq;

namespace Peixera
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MIDA   = 20;
            const int RONDES = 100;

            var rnd      = new Random();
            var motor    = new Tauler();
            var habitants = Pecera.Inicialitzar(MIDA, rnd);

            for (int r = 1; r <= RONDES; r++)
            {
                // 1. Mover criaturas vivas
                foreach (var h in habitants.Where(h => !h.EstaMort))
                    h.Moure(MIDA);

                // 2. Envejecer tiburones
                foreach (var t in habitants.OfType<Tauro>().Where(t => !t.EstaMort))
                    t.Envellir();

                // 3. Resolver interacciones
                motor.ResolInteraccions(habitants);

                // 4. Eliminar muertos
                habitants.RemoveAll(h => h.EstaMort);

                // 5. Mostrar estado
                MostrarEstat(r, habitants);
            }

            Console.WriteLine("\nSimulació completada. Prem qualsevol tecla...");
            Console.ReadKey();
        }

        static void MostrarEstat(int ronda, List<Criatura> habitants)
        {
            int peixos   = habitants.Count(h => h is Peix && !(h is Tauro) && !(h is Tortuga));
            int taurons  = habitants.Count(h => h is Tauro);
            int pops     = habitants.Count(h => h is Pop);
            int tortuges = habitants.Count(h => h is Tortuga);

            Console.WriteLine($"Ronda {ronda,3} | Peixos: {peixos,4} | Taurons: {taurons,2} | Pops: {pops,1} | Tortuges: {tortuges,2}");
        }
    }
}