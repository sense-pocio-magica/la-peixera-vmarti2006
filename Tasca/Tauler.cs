using System.Collections.Generic;
using System.Linq;

namespace Peixera
{
    public class Tauler
    {
        public void ResolInteraccions(List<Criatura> habitants)
        {
            var nouvinguts = new List<Criatura>();

            // Agrupar criaturas vivas por posición
            var grups = habitants
                .Where(h => !h.EstaMort)
                .GroupBy(h => new { h.X, h.Y })
                .Where(g => g.Count() >= 2);

            foreach (var grup in grups)
            {
                var llista = grup.ToList();
                for (int i = 0; i < llista.Count; i++)
                    for (int j = i + 1; j < llista.Count; j++)
                        Interaccions.Resoldre(llista[i], llista[j], nouvinguts);
            }

            habitants.AddRange(nouvinguts);
        }
    }
}