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
            int rondesTotals = 100;
            Random rnd = new Random();
            List<Criatura> habitants = new List<Criatura>();
            Tauler motorTauler = new Tauler();

            for (int i = 0; i < 10; i++)
            {
                habitants.Add(new Peix(rnd.Next(mida), rnd.Next(mida), Sexe.Mascle, (Direccio)rnd.Next(4)));
                habitants.Add(new Peix(rnd.Next(mida), rnd.Next(mida), Sexe.Femella, (Direccio)rnd.Next(4)));
            }

            habitants.Add(new Tauro(rnd.Next(mida), rnd.Next(mida), Sexe.Mascle, (Direccio)rnd.Next(4)));
            habitants.Add(new Tauro(rnd.Next(mida), rnd.Next(mida), Sexe.Femella, (Direccio)rnd.Next(4)));

            habitants.Add(new Pop(0, rnd.Next(mida)));
            habitants.Add(new Pop(mida - 1, rnd.Next(mida)));

            for (int i = 0; i < 3; i++)
            {
                Sexe s = rnd.Next(2) == 0 ? Sexe.Mascle : Sexe.Femella;
                habitants.Add(new Tortuga(rnd.Next(mida), rnd.Next(mida), s, (Direccio)rnd.Next(4)));
            }

            for (int r = 1; r <= rondesTotals; r++)
            {
                foreach (var h in habitants)
                {
                    h.Moure(mida);
                }

                foreach (var h in habitants.OfType<Tauro>())
                {
                    h.Envellir();
                }

                motorTauler.ResolInteraccions(habitants);

                habitants.RemoveAll(h => h.EstaMort);

                MostrarEstat(r, habitants);
            }

            Console.WriteLine("\n=== SIMULACIÓ FINALITZADA ===");
            Console.ReadLine();
        }

        static void MostrarEstat(int ronda, List<Criatura> habitants)
        {
            int peixos = habitants.Count(h => h is Peix && !(h is Tauro) && !(h is Tortuga));
            int taurons = habitants.Count(h => h is Tauro);
            int pops = habitants.Count(h => h is Pop);
            int tortugues = habitants.Count(h => h is Tortuga);

            Console.WriteLine($"Ronda {ronda:000} | Peixos: {peixos:00} | Taurons: {taurons:00} | Pops: {pops:00} | Tortugues: {tortugues:00} | Total: {habitants.Count}");
        }
    }
}