using System;
using System.Collections.Generic;
using System.Linq;

namespace Peixera
{
    public class Tauler
    {
        private Random rnd = new Random();

        public void ResolInteraccions(List<Criatura> habitants)
        {
            var nousHabitants = new List<Criatura>();
            var grups = habitants.Where(h => !h.EstaMort).GroupBy(h => new { h.X, h.Y });

            foreach (var grup in grups)
            {
                var llista = grup.ToList();
                if (llista.Count < 2) continue;

                for (int i = 0; i < llista.Count; i++)
                {
                    for (int j = i + 1; j < llista.Count; j++)
                    {
                        var a = llista[i];
                        var b = llista[j];

                        if (a.EstaMort || b.EstaMort) continue;

                        if (a is Tauro && (b is Peix && !(b is Tortuga) || b is Pop)) b.EstaMort = true;
                        else if (b is Tauro && (a is Peix && !(a is Tortuga) || a is Pop)) a.EstaMort = true;
                        else if (a is Tauro && b is Tortuga) a.Moviment = (Direccio)rnd.Next(4);
                        else if (b is Tauro && a is Tortuga) b.Moviment = (Direccio)rnd.Next(4);
                        else if (a.GetType() == b.GetType() && a.Genere != b.Genere && a.Genere != Sexe.Null)
                        {
                            nousHabitants.Add(CrearCria(a, b));
                        }
                        else if (a.GetType() == b.GetType() && a.Genere == b.Genere && a.Genere != Sexe.Null)
                        {
                            a.EstaMort = b.EstaMort = true;
                        }
                    }
                }
            }
            habitants.AddRange(nousHabitants);
        }

        private Criatura CrearCria(Criatura a, Criatura b)
        {
            Sexe s = rnd.Next(2) == 0 ? Sexe.Mascle : Sexe.Femella;
            Direccio d;
            do { d = (Direccio)rnd.Next(4); } while (d == a.Moviment || d == b.Moviment);
            
            if (a is Tauro) return new Tauro(a.X, a.Y, s, d);
            if (a is Tortuga) return new Tortuga(a.X, a.Y, s, d);
            return new Peix(a.X, a.Y, s, d);
        }
    }
}