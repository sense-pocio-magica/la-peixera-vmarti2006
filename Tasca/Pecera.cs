using System;
using System.Collections.Generic;

namespace Peixera
{
    public static class Pecera
    {
        public static List<Criatura> Inicialitzar(int mida, Random rnd)
        {
            var habitants = new List<Criatura>();

            // 10 parejas de peces
            for (int i = 0; i < 10; i++)
            {
                habitants.Add(new Peix(rnd.Next(mida), rnd.Next(mida), Sexe.Mascle,  (Direccio)rnd.Next(4)));
                habitants.Add(new Peix(rnd.Next(mida), rnd.Next(mida), Sexe.Femella, (Direccio)rnd.Next(4)));
            }

            // 1 pareja de tiburones
            habitants.Add(new Tauro(rnd.Next(mida), rnd.Next(mida), Sexe.Mascle,  (Direccio)rnd.Next(4)));
            habitants.Add(new Tauro(rnd.Next(mida), rnd.Next(mida), Sexe.Femella, (Direccio)rnd.Next(4)));

            // 2 pulpos en esquinas opuestas
            habitants.Add(new Pop(0,        0));
            habitants.Add(new Pop(mida - 1, mida - 1));

            // 3 tortugas
            for (int i = 0; i < 3; i++)
                habitants.Add(new Tortuga(rnd.Next(mida), rnd.Next(mida), (Sexe)rnd.Next(2), (Direccio)rnd.Next(4)));

            return habitants;
        }
    }
}