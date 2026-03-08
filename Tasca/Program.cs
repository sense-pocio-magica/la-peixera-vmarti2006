using System;
using System.Collections.Generic;
using System.Linq;

namespace Peixera
{
    class Program
    {
        static void Main(string[] args)
        {
            int mida = 20;
            Random rnd = new Random();
            List<Criatura> habitants = new List<Criatura>();
            Tauler motor = new Tauler();

            for (int i = 0; i < 10; i++) 
            {
                habitants.Add(new Peix(rnd.Next(mida), rnd.Next(mida), Sexe.Mascle, (Direccio)rnd.Next(4)));
                habitants.Add(new Peix(rnd.Next(mida), rnd.Next(mida), Sexe.Femella, (Direccio)rnd.Next(4)));
            }
            habitants.Add(new Tauro(rnd.Next(mida), rnd.Next(mida), Sexe.Mascle, (Direccio)rnd.Next(4)));
            habitants.Add(new Tauro(rnd.Next(mida), rnd.Next(mida), Sexe.Femella, (Direccio)rnd.Next(4)));
            habitants.Add(new Pop(0, 0));
            habitants.Add(new Pop(mida - 1, mida - 1));
            for (int i = 0; i < 3; i++) habitants.Add(new Tortuga(rnd.Next(mida), rnd.Next(mida), (Sexe)rnd.Next(2), (Direccio)rnd.Next(4)));

            for (int r = 1; r <= 100; r++)
            {
                foreach (var h in habitants) h.Moure(mida);
                foreach (var t in habitants.OfType<Tauro>()) t.Envellir();
                motor.ResolInteraccions(habitants);
                habitants.RemoveAll(h => h.EstaMort);

                Console.WriteLine($"Ronda {r:000} | Peixos: {habitants.Count(h => h is Peix && !(h is Tauro) && !(h is Tortuga))} | Taurons: {habitants.Count(h => h is Tauro)} | Pops: {habitants.Count(h => h is Pop)} | Tortugues: {habitants.Count(h => h is Tortuga)}");
            }
            Console.WriteLine("\nPremeu qualsevol tecla per sortir...");
            Console.ReadKey();
        }
    }
}