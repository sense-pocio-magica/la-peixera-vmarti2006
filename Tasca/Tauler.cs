using System;
using System.Collections.Generic;
using System.Linq;

namespace Peixera
{
    public class Tauler
    {
        private int mida = 20;
        private Random rnd = new Random();

        public void ResolInteraccions(List<Criatura> habitants)
        {
            var nousHabitants = new List<Criatura>();
            
            var grups = habitants.Where(h => !h.EstaMort)
                                 .GroupBy(h => new { h.X, h.Y })
                                 .Where(g => g.Count() > 1);

            foreach (var grup in grups)
            {
                var llista = grup.ToList();
                for (int i = 0; i < llista.Count; i++)
                {
                    for (int j = i + 1; j < llista.Count; j++)
                    {
                        ExecutaRegles(llista[i], llista[j], nousHabitants);
                    }
                }
            }
            habitants.AddRange(nousHabitants);
        }

        private void ExecutaRegles(Criatura a, Criatura b, List<Criatura> nous)
        {
            if (a.EstaMort || b.EstaMort) return;

            if (a.GetType() == b.GetType() && a.Genere != b.Genere && a.Genere != Sexe.Null && b.Genere != Sexe.Null)
            {
                nous.Add(CrearCria(a, b));
            }
            else if (a.GetType() == b.GetType() && a.Genere == b.Genere && a.Genere != Sexe.Null)
            {
                a.EstaMort = true;
                b.EstaMort = true;
            }
            else if (a is Tauro && (b is Peix && !(b is Tortuga) || b is Pop))
            {
                b.EstaMort = true;
            }
            else if (b is Tauro && (a is Peix && !(a is Tortuga) || a is Pop))
            {
                a.EstaMort = true;
            }
            else if (a is Tauro && b is Tortuga)
            {
                a.Moviment = (Direccio)rnd.Next(0, 4);
            }
        }

        private Criatura CrearCria(Criatura p1, Criatura p2)
        {
            Sexe nouSexe = rnd.Next(0, 2) == 0 ? Sexe.Mascle : Sexe.Femella;
            Direccio novaDir;
            do {
                novaDir = (Direccio)rnd.Next(0, 4);
            } while (novaDir == p1.Moviment || novaDir == p2.Moviment);

            if (p1 is Tauro) return new Tauro(p1.X, p1.Y, nouSexe, novaDir);
            if (p1 is Tortuga) return new Tortuga(p1.X, p1.Y, nouSexe, novaDir);
            return new Peix(p1.X, p1.Y, nouSexe, novaDir);
        }
    }
}