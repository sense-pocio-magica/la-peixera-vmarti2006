using System;
using System.Collections.Generic;

namespace Peixera
{
    // Contiene únicamente las reglas de qué pasa entre dos criaturas
    public static class Interaccions
    {
        private static Random rnd = new Random();

        public static void Resoldre(Criatura a, Criatura b, List<Criatura> nouvinguts)
        {
            if (a.EstaMort || b.EstaMort) return;

            bool aEsTauro   = a is Tauro;
            bool bEsTauro   = b is Tauro;
            bool aEsTortuga = a is Tortuga;
            bool bEsTortuga = b is Tortuga;
            bool aEsPeixPur = a is Peix && !aEsTauro && !aEsTortuga;
            bool bEsPeixPur = b is Peix && !bEsTauro && !bEsTortuga;

            // Tauro mata Peix puro o Pop
            if      (aEsTauro && (bEsPeixPur || b is Pop)) b.EstaMort = true;
            else if (bEsTauro && (aEsPeixPur || a is Pop)) a.EstaMort = true;

            // Tauro choca con Tortuga: la tortuga cambia dirección (es dura)
            else if (aEsTauro && bEsTortuga) b.Moviment = (Direccio)rnd.Next(4);
            else if (bEsTauro && aEsTortuga) a.Moviment = (Direccio)rnd.Next(4);

            // Misma especie, sexo diferente → se reproducen
            else if (MateixaTipus(a, b) && a.Genere != b.Genere && a.Genere != Sexe.Null)
                nouvinguts.Add(CrearCria(a, b));

            // Misma especie, mismo sexo → se matan
            else if (MateixaTipus(a, b) && a.Genere == b.Genere && a.Genere != Sexe.Null)
                a.EstaMort = b.EstaMort = true;
        }

        private static bool MateixaTipus(Criatura a, Criatura b)
            => a.GetType() == b.GetType();

        private static Criatura CrearCria(Criatura a, Criatura b)
        {
            Sexe s = rnd.Next(2) == 0 ? Sexe.Mascle : Sexe.Femella;
            Direccio d;
            do { d = (Direccio)rnd.Next(4); } while (d == a.Moviment || d == b.Moviment);

            if (a is Tauro)   return new Tauro(a.X, a.Y, s, d);
            if (a is Tortuga) return new Tortuga(a.X, a.Y, s, d);
            return new Peix(a.X, a.Y, s, d);
        }
    }
}