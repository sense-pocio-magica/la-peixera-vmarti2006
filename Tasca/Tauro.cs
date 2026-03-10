namespace Peixera
{
    public class Tauro : Peix
    {
        public int Vida { get; private set; } = 50;

        public Tauro(int x, int y, Sexe sexe, Direccio dir)
            : base(x, y, sexe, dir) { }

        public void Envellir()
        {
            Vida--;
            if (Vida <= 0) EstaMort = true;
        }
    }
}